using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

/*
 * Player
 *
 * The main snake class that
 * keeps track of where the
 * various player tiles are,
 * the score etc. It also handles
 * the player's movement and
 * collision with other tiles.
 */

namespace Snake
{
	public class Player
	{
		public  enum Direction { Up, Right, Down, Left }
		private Direction currentDirection;
		
		private readonly LinkedList<PlayerBody> bodies;

		private readonly KeyBinding keyBinding;
		private readonly Color      color;
		private readonly Scoreboard score;

		private int  growLength;
		public bool  IsDead { get; private set; }

		public int Score => score.Score;

		public Vector2 HeadPosition
		{
			get => bodies.First.Value.Position;
			private set => bodies.First.Value.Position = value;
		}

		public int GrowLength
		{
			set => growLength = value;
		}

		public Vector2 TailPosition => bodies.Last.Value.Position;

		public Tile HeadTile => bodies.First.Value;

		public Player(int num, Vector2 position, Color color)
		{
			keyBinding = new KeyBinding(num);
			IsDead = false;
			this.color = color;

			// We start as 3 blocks
			growLength = 2;

			// Create list of bodies
			bodies = new LinkedList<PlayerBody>();
			// Add head
			bodies.AddFirst(new PlayerBody(position, color));

			// Set direction
			currentDirection = GetBestDirection();

			// Create scoreboard
			score = new Scoreboard(num, color, new Point(8, 8 + (num - 1) * 16));
		}

		private void SetDirection(Direction direction) => currentDirection = direction;

		public void Update(IEnumerable<Keys> keys, Board board, Engine engine)
		{
			// Don't move or update if we died
			if (IsDead)
				return;
			
			// Update current direction
			foreach (var key in keys)
			{
				var pressed = keyBinding.GetPressedDirection(key);
				if (pressed != KeyBinding.Input.None)
					SetDirection(KeyBinding.ToDirection(pressed));
			}

			// Get new position
			var newPos = GetNewPosition();
			// Die if we hit the edge
			if (!board.IsInBounds(HeadPosition))
			{
				Die();
				return;
			}

			// Check if we should continue, or "consume" the tile

			if (board[newPos].Collide(this) == Collide.Mode.Continue)
				board[newPos] = new Tile(newPos, board.GetRandomBackground());

			// Check if we should stop
			if (board[newPos].Collide(this) == Collide.Mode.Stop)
			{
				// See if we hit another snake
				if (board[newPos].GetType() != typeof(PlayerBody))
					return;
				
				// If we hit outselves, remove 5 points
				// Otherwise, award the other snake with 5 points
				if (bodies.Contains(board[newPos]))
					engine.ChangeScoreForPlayer(this, -5);
				else if (engine.TryGetPlayerAtPosition(newPos, out var hitPlayer))
					engine.ChangeScoreForPlayer(hitPlayer, 5);
			}

			// Else, continue as normal
			if (growLength <= 0)
			{
				// If we shouldn't grow, swap tail to head
				board.SwapTiles(TailPosition, newPos);
				// Update head
				SetHeadFromTail();
			}
			else
			{
				// If we should grow, create new body
				bodies.AddFirst(new PlayerBody(newPos, color));
				board[newPos] = HeadTile;
				growLength--;
			}

			// Update to new position
			HeadPosition = newPos;
		}

		public void Die()
		{
			// Set player as dead
			IsDead = true;

			// Change to grey color
			foreach (var body in bodies)
				body.FillColor = Color.FromArgb(96, 125, 139);
		}

		private void SetHeadFromTail()
		{
			// Save new head temporarily
			var temp = bodies.Last;
			// Remove tail
			bodies.RemoveLast();
			// Readd it as head
			bodies.AddFirst(temp);
		}

		private Vector2 GetNewPosition()
		{
			// Position shortcuts
			var x = HeadPosition.X;
			var y = HeadPosition.Y;

			// Get where we are supposed to go
			switch (currentDirection)
			{
				case Direction.Up:
					return new Vector2(x, y - 1);
				case Direction.Right:
					return new Vector2(x + 1, y);
				case Direction.Down:
					return new Vector2(x, y + 1);
				case Direction.Left:
					return new Vector2(x - 1, y);
				default:
					throw new InvalidOperationException("Invalid direction: Player.GetNewPosition");
			}
		}

		private Direction GetBestDirection()
		{
			var x = HeadPosition.X;
			var y = HeadPosition.Y;

			if (x < 6)
				return Direction.Right;
			if (x > 26)
				return Direction.Left;
			if (y < 6)
				return Direction.Down;
			if (y > 10)
				return Direction.Up;

			// If it doesn't matter, return random
			return (Direction)new Random().Next(3);
		}

		public IEnumerable<Vector2> GetBodyPositions() => from body in bodies select body.Position;

		public void ChangeScore(int amount) => score.ChangeScore(amount);

		public void DrawScore(Graphics g) => score.Draw(g);
	}
}
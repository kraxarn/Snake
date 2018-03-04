using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Snake
{
	public class Player
	{
		public enum Direction { Up, Right, Down, Left }
		private Direction currentDirection;
		private readonly Keybinding keybinding;
		private bool isDead;
		private readonly LinkedList<PlayerBody> bodies;
		private int growLength;
		private Color color;

		public Player(int num, Vector2 position, Color color)
		{
			keybinding = new Keybinding(num);
			isDead = false;
			this.color = color;
			currentDirection = (Direction) new Random().Next(3);

			// We start as 3 blocks
			growLength = 2;

			// Create list of bodies
			bodies = new LinkedList<PlayerBody>();
			// Add head
			bodies.AddFirst(new PlayerBody(position, color));
		}

		private void SetDirection(Direction direction) => currentDirection = direction;

		public void Update(Keys key, Board board)
		{
			// Don't move or update if we died
			if (isDead)
				return;
			
			// Update current direction
			var pressed = keybinding.GetPressedDirection(key);
			if (pressed != Keybinding.Input.None)
				SetDirection(Keybinding.ToDirection(pressed));

			// Get new position
			var newPos = GetNewPosition();
			// Die if we hit the edge
			if (!board.IsInBounds(HeadPosition))
			{
				Die();
				return;
			}
			
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
				board.SetTile(newPos, HeadTile);
				growLength--;
			}

			// Update to new position
			HeadPosition = newPos;
		}

		public void Die() => isDead = true;

		public Vector2 HeadPosition
		{
			get => bodies.First.Value.Position;
			private set => bodies.First.Value.Position = value;
		}

		public Vector2 TailPosition => bodies.Last.Value.Position;

		public Tile HeadTile => bodies.First.Value;

		private void SetNewHead(PlayerBody body)
		{
			bodies.Remove(bodies.Single(b => b.Equals(body)));
			bodies.AddFirst(body);
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

		public int GrowLength
		{
			set => growLength = value;
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

		public string GetDebugString() => $"Direction: {currentDirection}, Dead: {isDead}";
	}
}
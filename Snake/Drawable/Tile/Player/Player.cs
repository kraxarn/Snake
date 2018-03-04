using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	public class Player : Tile
	{
		public enum Direction { Up, Right, Down, Left }
		private Direction currentDirection;
		private readonly Keybinding keybinding;
		private bool isDead;
		private readonly LinkedList<PlayerBody> bodies;
		private int growLength;

		public Player(int num, Vector2 position, Color color)
		{
			keybinding = new Keybinding(num);
			isDead = false;
			SetColor(color);
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
			if (!board.IsInBounds(Head))
			{
				Die();
				return;
			}
			
			if (growLength <= 0)
			{
				// If we should grow, just swap tail to head
				board.SwapTiles(Tail, newPos);
			}
			else
			{
				// If we should grow, just create new body
				bodies.AddFirst(new PlayerBody(newPos, FillColor));
				growLength--;
			}

			// Update to new position
			Head = newPos;
		}

		public void Die() => isDead = true;

		public Vector2 Head
		{
			get => bodies.First.Value.Position;
			private set => bodies.First.Value.Position = value;
		}

		public Vector2 Tail
		{
			get => bodies.Last.Value.Position;
			private set => bodies.Last.Value.Position = value;
		}

		public int GrowLength
		{
			set => growLength = value;
		}

		private Vector2 GetNewPosition()
		{
			// Position shortcuts
			var x = Head.X;
			var y = Head.Y;

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
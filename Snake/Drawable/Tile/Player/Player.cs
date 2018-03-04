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

		public Player(int num, Vector2 position, Color color)
		{
			keybinding = new Keybinding(num);
			isDead = false;
			SetColor(color);
			currentDirection = (Direction) new Random().Next(3);

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
			if (!board.IsInBounds(Position))
			{
				Die();
				return;
			}
			// Switch current position with new one
			board.SwapTiles(Position, newPos);
			// Update to new position
			Position = newPos;
		}

		public void Die() => isDead = true;

		public Vector2 Position
		{
			get => bodies.First.Value.Position;
			private set => bodies.First.Value.Position = value;
		}

		private Vector2 GetNewPosition()
		{
			// Position shortcuts
			var x = Position.X;
			var y = Position.Y;

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
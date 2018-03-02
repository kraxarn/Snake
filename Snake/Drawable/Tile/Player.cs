using System;
using System.Drawing;
using System.Dynamic;
using System.Windows.Forms;

namespace Snake
{
	public class Player : Tile
	{
		private Vector2 position;
		public enum Direction { Up, Right, Down, Left }
		private Direction currentDirection;
		private readonly Keybinding keybinding;
		private bool isDead;
		private readonly Random rng;

		public Player(int num, Vector2 position, Color color)
		{
			currentDirection = (Direction) new Random().Next(3);
			keybinding = new Keybinding(num);
			isDead = false;
			this.position = position;
			SetColor(color);
			rng = new Random();
			currentDirection = (Direction) rng.Next(3);
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

			// Switch current position with new one
			board.SwapTiles(position, GetNewPosition());
		}

		public void Die() => isDead = true;

		public Vector2 GetPosition() => position;

		private Vector2 GetNewPosition()
		{
			var x = position.X;
			var y = position.Y;

			switch (currentDirection)
			{
				case Direction.Up:
					return new Vector2(x, y + 1);
				case Direction.Right:
					return new Vector2(x + 1, y);
				case Direction.Down:
					return new Vector2(x, y - 1);
				case Direction.Left:
					return new Vector2(x - 1, y);
				default:
					throw new InvalidOperationException("Invalid direction: Player.GetNewPosition");
			}
		}

		public string GetDebugString() => $"Direction: {currentDirection}";
	}
}
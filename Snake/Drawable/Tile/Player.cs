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

		public Player(int num, Vector2 position, Color color)
		{
			currentDirection = (Direction) new Random().Next(3);
			keybinding = new Keybinding(num);
			isDead = false;
			this.position = position;
			SetColor(color);
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

			board.SetTile(position, this);
			SetPosition(new Vector2(position.X * 32, position.Y * 32));
		}

		public void Die() => isDead = true;
	}
}
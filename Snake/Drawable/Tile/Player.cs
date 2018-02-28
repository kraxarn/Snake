using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	public class Player : IDrawable
	{
		public enum Direction { Up, Right, Down, Left }
		private Direction currentDirection;

		private readonly Keybinding keybinding;

		public Player(int num)
		{
			currentDirection = (Direction) new Random().Next(3);
			keybinding = new Keybinding(num);
		}

		private void SetDirection(Direction direction) => currentDirection = direction;

		public void HandleKey(Keys key)
		{
			var pressed = keybinding.GetPressedDirection(key);
			if (pressed != Keybinding.Input.None)
				SetDirection(Keybinding.ToDirection(pressed));
		}

		public void Draw(Graphics g)
		{
			throw new NotImplementedException("Player.Draw");
		}

		public void Die()
		{
			throw new NotImplementedException("Player.Die");
		}
	}
}
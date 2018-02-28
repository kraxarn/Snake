using System;
using System.Drawing;
using System.Dynamic;
using System.Windows.Forms;

namespace Snake
{
	public class Player : IDrawable
	{
		public enum Direction { Up, Right, Down, Left }
		private Direction currentDirection;

		private readonly Keybinding keybinding;

		private bool IsDead;

		public Player(int num)
		{
			currentDirection = (Direction) new Random().Next(3);
			keybinding = new Keybinding(num);
			IsDead = false;
		}

		private void SetDirection(Direction direction) => currentDirection = direction;

		public void Update(Keys key)
		{
			if (IsDead)
				return;

			var pressed = keybinding.GetPressedDirection(key);
			if (pressed != Keybinding.Input.None)
				SetDirection(Keybinding.ToDirection(pressed));
		}

		public void Draw(Graphics g)
		{
			throw new NotImplementedException("Player.Draw");
		}

		public void Die() => IsDead = true;
	}
}
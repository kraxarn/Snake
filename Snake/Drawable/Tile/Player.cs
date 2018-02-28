using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	public class Player : IDrawable
	{
		public enum Direction { Up, Right, Down, Left }
		private Direction currentDirection;

		private Keybinding keybinding;

		public Player(int num)
		{
			currentDirection = (Direction) new Random().Next(3);
			keybinding = new Keybinding(num);
		}

		public void SetDirection(Direction direction) => currentDirection = direction;

		public void HandleKey(Keys key)
		{
			
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
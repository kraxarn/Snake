using System;
using System.Windows.Forms;

namespace Snake
{
	public class Keybinding
	{
		private readonly Keys up, right, down, left;

		public Keybinding(int player)
		{
			switch (player)
			{
				case 1:
					up    = Keys.W;
					right = Keys.D;
					down  = Keys.S;
					left  = Keys.A;
					break;
				case 2:
					up    = Keys.I;
					right = Keys.L;
					down  = Keys.K;
					left  = Keys.J;
					break;
				case 3:
					up    = Keys.T;
					right = Keys.H;
					down  = Keys.G;
					left  = Keys.F;
					break;
				default:
					throw new InvalidOperationException("Invalid player num");
			}
		}

		public bool IsUpPressed(Keys keys)    => keys == up;
		public bool IsRightPressed(Keys keys) => keys == right;
		public bool IsDownPressed(Keys keys)  => keys == down;
		public bool IsLeftPressed(Keys keys)  => keys == left;

		public Player.Direction GetPresseDirection(Keys keys)
		{
			switch (keys)
			{
				case Keys.Up:
					return Player.Direction.Up;
				case Keys.Right:
					return Player.Direction.Right;
				case Keys.Down:
					return Player.Direction.Down;
				case Keys.Left:
					return Player.Direction.Left;
				default:
					throw new InvalidOperationException("Direction not valid");
			}
		}
	}
}
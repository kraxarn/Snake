﻿using System;
using System.Windows.Forms;

namespace Snake
{
	public class Keybinding
	{
		public enum Input { None, Up, Right, Down, Left }

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

		public Input GetPressedDirection(Keys keys)
		{
			// We pressed a key
			if (keys == up)
				return Input.Up;
			if (keys == right)
				return Input.Right;
			if (keys == down)
				return Input.Down;
			if (keys == left)
				return Input.Left;

			// We didn't press anything
			return Input.None;
		}

		public static Player.Direction ToDirection(Input input)
		{
			switch (input)
			{
				case Input.Up:
					return Player.Direction.Up;
				case Input.Right:
					return Player.Direction.Right;
				case Input.Down:
					return Player.Direction.Down;
				case Input.Left:
					return Player.Direction.Left;
				default:
					throw new InvalidOperationException("Invalid direction");
			}
		}
	}
}
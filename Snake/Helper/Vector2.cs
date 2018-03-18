using System;
using System.Drawing;

/*
 * Vector2
 *
 * Class to keep track
 * of 2 ints mainly used
 * for positioning. This is
 * mostly a fancy way to keep
 * 2 ints in the same place.
 */

namespace Snake
{
	public class Vector2
	{
		public int X, Y;
		public Vector2(int x = 0, int y = 0)
		{
			X = x;
			Y = y;
		}

		public Point ToPoint() => new Point(X, Y);

		public override string ToString()
		{
			return $"{X},{Y}";
		}

		public override bool Equals(object obj)
		{
			if (obj == null || obj.GetType() != typeof(Vector2))
				return false;
			var pos = (Vector2) obj;
			return pos.X == X && pos.Y == Y;
		}
		
		public override int GetHashCode() => Math.Abs(X * Y).GetHashCode();
	}
}
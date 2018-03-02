using System.Drawing;

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

		public void Set(int x, int y)
		{
			X = x;
			Y = y;
		}

		public Point ToPoint() => new Point(X, Y);

		public override string ToString()
		{
			return $"{X},{Y}";
		}
	}
}
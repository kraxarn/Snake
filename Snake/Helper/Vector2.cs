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

		public override bool Equals(object obj)
		{
			if (obj == null || obj.GetType() != typeof(Vector2))
				return false;
			var pos = (Vector2) obj;
			return pos.X == X && pos.Y == Y;
		}
	}
}
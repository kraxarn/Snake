namespace Snake
{
	public class Board
	{
		private Tile[,] tiles;

		public Board(Vector2 size)
		{
			tiles = new Tile[size.X, size.Y];
		}
	}
}
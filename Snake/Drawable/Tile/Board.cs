using System;
using System.Drawing;

namespace Snake
{
	public class Board
	{
		private Tile[,] tiles;
		private Random rng;

		public Board(Vector2 size)
		{
			tiles = new Tile[size.X, size.Y];
			rng   = new Random();
		}

		public void Draw(Graphics g)
		{
			for (var x = 0; x < tiles.GetLength(0); x++)
				for (var y = 0; y < tiles.GetLength(1); y++)
					tiles[x, y].Draw(g);
		}

		public void  FillWithRandomTiles()
		{
			for (var x = 0; x < tiles.GetLength(0); x++)
				for (var y = 0; y < tiles.GetLength(1); y++)
					tiles[x, y] = new Tile(new Vector2(x * 32, y * 32), GetRandomBackground());
		}

		public void SetTile(Vector2 pos, Tile tile)
		{

		}

		public void SetTileColor(Vector2 pos, Color color)
		{
			tiles[pos.X, pos.Y].FillColor = color;
		}

		private Color GetRandomBackground() => Color.FromArgb(rng.Next(67, 102), rng.Next(160, 187), rng.Next(71, 106));
	}
}
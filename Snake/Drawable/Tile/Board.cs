using System;
using System.Drawing;

namespace Snake
{
	public class Board
	{
		private readonly Tile[,] tiles;
		private readonly Random  rng;
		private readonly int     tileSize;

		public Board(Vector2 size, int tileSize = 32)
		{
			tiles = new Tile[size.X, size.Y];
			rng   = new Random();
			this.tileSize = tileSize;
		}

		public void Draw(Graphics g)
		{
			for (var x = 0; x < tiles.GetLength(0); x++)
				for (var y = 0; y < tiles.GetLength(1); y++)
					tiles[x, y].Draw(g, x * tileSize, y * tileSize);
		}

		public void FillWithRandomTiles()
		{
			for (var x = 0; x < tiles.GetLength(0); x++)
				for (var y = 0; y < tiles.GetLength(1); y++)
					tiles[x, y] = new Tile(new Vector2(x * tileSize, y * tileSize), GetRandomBackground());
		}

		public void SetTile(Vector2 pos, Tile tile) => tiles[pos.X, pos.Y] = tile;

		public void SetTileColor(Vector2 pos, Color color) => tiles[pos.X, pos.Y].FillColor = color;

		public void SwapTiles(Vector2 pos1, Vector2 pos2)
		{
			var temp = tiles[pos1.X, pos1.Y];
			tiles[pos1.X, pos1.Y] = tiles[pos2.X, pos2.Y];
			tiles[pos2.X, pos2.Y] = temp;
		}

		private Color GetRandomBackground() => Color.FromArgb(rng.Next(67, 102), rng.Next(160, 187), rng.Next(71, 106));

		public Vector2 GetRandomPosition() => new Vector2(rng.Next(tiles.GetLength(0)), rng.Next(tiles.GetLength(1)));

		public bool IsInBounds(Vector2 position) => position.X < tiles.GetLength(0) && position.Y < tiles.GetLength(1);
	}
}
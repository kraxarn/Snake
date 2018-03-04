﻿using System.Drawing;

namespace Snake
{
	public class PlayerBody : Tile
	{
		public Vector2 Position;

		public PlayerBody(Vector2 position, Color color)
		{
			// Set color of tile
			SetColor(color);
			// Set position
			Position = position;
		}
	}
}
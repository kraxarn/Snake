﻿using System.Drawing;

namespace Snake
{
	public class Scoreboard : IDrawable
	{
		private readonly Text text;
		private int score;

		public Scoreboard(int player, Color color, Point position)
		{
			text = new Text($"P{player}: 0", "Consolas", 12, position, color);
		}

		public void Draw(Graphics g, int x = 0, int y = 0)
		{
			text.Draw(g, x, y);
		}

		public void ChangeScore(int amount)
		{
			score += amount;
			text.Label = text.Label.Substring(0, text.Label.IndexOf(' ')) + $" {score}";
		}

		public void SetScore(int amount)
		{
			score = amount;
			text.Label = text.Label.Substring(0, text.Label.IndexOf(' ')) + $" {score}";
		}
	}
}
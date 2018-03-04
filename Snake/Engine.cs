using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Snake
{
	public class Engine
	{
		private readonly FormMain     form;
		private readonly Timer        timer;
		private readonly ISet<Text>   scores;
		private readonly Board        board;
		private readonly ISet<Player> players;
		private readonly Random       rng;

		private bool skipFrame;

		/*
		 * P1: Blue   (63,  81,  181)
		 * P2: Red    (244, 67,  54)
		 * P3: Orange (255, 152, 0)
		 */

		public Engine(int numPlayers)
		{
			// Variables
			form    = new FormMain();
			timer   = new Timer();
			scores  = new HashSet<Text>();
			players = new HashSet<Player>();
			board   = new Board(new Vector2(32, 16));
			rng     = new Random();

			skipFrame = false;

			// Colors
			var playerColors = new[]
			{
				Color.FromArgb(63,  81,  181),
				Color.FromArgb(244, 67,  54),
				Color.FromArgb(255, 152, 0)
			};

			// Fill board with tiles, "grass"
			board.FillWithRandomTiles();

			// Add players
			for (var i = 0; i < numPlayers; i++)
			{
				// Add score
				scores.Add(new Text($"P{i + 1}: 0", "Consolas", 12, new Point(8, 8 + i * 16), playerColors[i]));
				// Add player
				var player = new Player(i + 1, board.GetRandomFreePosition(), playerColors[i]);
				players.Add(player);
				board.SetTile(player.HeadPosition, player.HeadTile);
			}
		}

		public void Run()
		{
			form.Paint += Draw;

			timer.Tick += Update;
			timer.Interval = 100;
			timer.Start();

			Application.Run(form);
		}

		private void Update(object sender, EventArgs eventArgs)
		{
			// See if we should add some food
			if (rng.Next(100) <= 1)
				AddRandomFood();

			// See if we should skip the current frame
			if (skipFrame)
			{
				skipFrame = false;
				return;
			}
			skipFrame = true;

			scores.First().Label = players.First().GetDebugString();

			// Update key presses for players
			foreach (var player in players)
				player.Update(form.KeyData, board);

			form.Refresh();
		}

		private void Draw(object sender, PaintEventArgs paintEventArgs)
		{
			// Draw tiles
			board.Draw(paintEventArgs.Graphics);

			// Draw scores
			foreach (var score in scores)
				score.Draw(paintEventArgs.Graphics);
		}

		private void AddRandomFood()
		{
			// Get random food
			var num = rng.Next(2);
			Food food;
			switch (num)
			{
				case 0:
					food = new FoodStandard();
					break;
				case 1:
					food = new FoodExtra();
					break;
				default:
					throw new InvalidOperationException("Invalid number for food");
			}

			// Add food to board
			board.SetTile(board.GetRandomFreePosition(), food);
		}
	}
}
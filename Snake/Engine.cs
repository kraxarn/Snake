using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Snake
{
	public class Engine
	{
		private readonly FormMain   form;
		private readonly Timer      timer;
		private readonly ISet<Text> scores;

		//private Tile[,] tiles;
		private readonly Board        board;
		private readonly ISet<Player> players;

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

			// Colors
			var playerColors = new[]
			{
				Color.FromArgb(63,  81,  181),
				Color.FromArgb(244, 67,  54),
				Color.FromArgb(255, 152, 0)
			};

			// Fill field with tiles
			board.FillWithRandomTiles();

			// Add players
			for (var i = 0; i < numPlayers; i++)
			{
				// Add score
				scores.Add(new Text($"P{i + 1}: 0", "Consolas", 12, new Point(8, 8 + i * 16), playerColors[i]));
				// Add player
				var player = new Player(i + 1, board.GetRandomPosition(), playerColors[i]);
				players.Add(player);
				board.SetTile(player.GetPosition(), player);
			}
		}

		public void Run()
		{
			form.Paint += Draw;

			timer.Tick += Update;
			timer.Interval = 1000 / 5;
			timer.Start();

			Application.Run(form);
		}


		private void Update(object sender, EventArgs eventArgs)
		{
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
	}
}
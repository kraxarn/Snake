using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	public class Engine
	{
		private readonly FormMain   form;
		private readonly Timer      timer;
		private readonly ISet<Text> scores;
		private readonly Random rng;

		private Tile[,] tiles;
		private ISet<Player> players;

		/*
		 * P1: Blue   (63,  81,  181)
		 * P2: Red    (244, 67,  54)
		 * P3: Orange (255, 152, 0)
		 */

		private Color colorP1, colorP2, colorP3;

		public Engine(int numPlayers)
		{
			// Variables
			form    = new FormMain();
			timer   = new Timer();
			scores  = new HashSet<Text>();
			players = new HashSet<Player>();
			tiles   = new Tile[32, 16];
			rng     = new Random();

			// Colors
			colorP1 = Color.FromArgb(63,  81,  181);
			colorP2 = Color.FromArgb(244, 67,  54);
			colorP3 = Color.FromArgb(255, 152, 0);

			// Add players
			for (var i = 0; i < numPlayers; i++)
			{

			}

			// Players
			scores.Add(new Text("P1: 0", "Consolas", 12, new Point(8, 8),  colorP1));
			players.Add(new Player());
			if (numPlayers >= 2)
			{
				scores.Add(new Text("P2: 0", "Consolas", 12, new Point(8, 24), colorP2));
				players.Add(new Player());
			}
			if (numPlayers >= 3)
			{
				scores.Add(new Text("P3: 0", "Consolas", 12, new Point(8, 40), colorP3));
				players.Add(new Player());
			}

			// Fill field with tiles
			for (var x = 0; x < tiles.GetLength(0); x++)
				for (var y = 0; y < tiles.GetLength(1); y++)
					tiles[x, y] = new Tile(new Vector2(x * 32, y * 32), GetRandomBackground());
			
			// Players
			tiles[rng.Next(32), rng.Next(16)].FillColor = colorP1;
		}

		public void Run()
		{
			form.Paint += Draw;

			timer.Tick += Update;
			timer.Interval = 60 / 15;
			timer.Start();

			Application.Run(form);
		}


		private void Update(object sender, EventArgs eventArgs)
		{
			form.Refresh();
		}

		private void Draw(object sender, PaintEventArgs paintEventArgs)
		{
			// Draw scores
			foreach (var score in scores)
				score.Draw(paintEventArgs.Graphics);

			// Draw tiles
			for (var x = 0; x < tiles.GetLength(0); x++)
				for (var y = 0; y < tiles.GetLength(1); y++)
					tiles[x, y].Draw(paintEventArgs.Graphics);
		}

		private Color GetRandomBackground() => Color.FromArgb(rng.Next(67, 102), rng.Next(160, 187), rng.Next(71, 106));
	}
}
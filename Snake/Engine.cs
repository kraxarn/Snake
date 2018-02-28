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

		//private Tile[,] tiles;
		private Board board;
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
			//tiles   = new Tile[32, 16];
			rng     = new Random();
			board   = new Board(new Vector2(32, 16)); 

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
			players.Add(new Player(1));
			if (numPlayers >= 2)
			{
				scores.Add(new Text("P2: 0", "Consolas", 12, new Point(8, 24), colorP2));
				players.Add(new Player(2));
			}
			if (numPlayers >= 3)
			{
				scores.Add(new Text("P3: 0", "Consolas", 12, new Point(8, 40), colorP3));
				players.Add(new Player(3));
			}

			// Fill field with tiles
			board.FillWithRandomTiles();
			
			// Players
			board.SetTileColor(new Vector2(rng.Next(32), rng.Next(16)), colorP1);
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
			// Update key presses for players
			foreach (var player in players)
				player.HandleKey(form.KeyData);

			form.Refresh();
		}

		private void Draw(object sender, PaintEventArgs paintEventArgs)
		{
			// Draw scores
			foreach (var score in scores)
				score.Draw(paintEventArgs.Graphics);

			// Draw tiles
			board.Draw(paintEventArgs.Graphics);
		}
	}
}
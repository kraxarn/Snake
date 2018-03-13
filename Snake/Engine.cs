using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Snake
{
	public class Engine
	{
		private readonly FormMain         form;
		private readonly Timer            timer;
		private readonly List<Scoreboard> scores;
		private readonly Board            board;
		private readonly ISet<Player>     players;
		private readonly Random           rng;

		private bool skipFrame, paused;

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
			scores  = new List<Scoreboard>();
			players = new HashSet<Player>();
			board   = new Board(new Vector2(32, 16));
			rng     = new Random();

			skipFrame = false;
			paused    = false;

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
				scores.Add(new Scoreboard(i + 1, playerColors[i], new Point(8, 8 + i * 16)));
				// Add player
				var player = new Player(i + 1, board.GetRandomFreePosition(), playerColors[i]);
				players.Add(player);
				board.SetTile(player.HeadPosition, player.HeadTile);
			}

			// Place 3-6 random walls
			var walls = rng.Next(3, 6);
			for (var i = 0; i < walls; i++)
				board.SetTile(board.GetRandomFreePosition(), new Wall());
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
			// Check if paused
			if (form.PressedKeys.Contains(Keys.Escape))
				paused = !paused;
			if (paused)
				return;

			// See if we should add some food
			if (rng.Next(100) <= 3)
				AddRandomFood();

			// See if we should skip the current frame
			if (skipFrame)
			{
				skipFrame = false;
				return;
			}
			skipFrame = true;

			// Iterator for current player and if all are dead
			var i = 0;
			var allDead = true;
			foreach (var player in players)
			{
				// Update score
				scores[i++].SetScore(player.Score);

				// Update key presses
				player.Update(form.PressedKeys, board);

				// Check if player is dead
				if (!player.IsDead)
					allDead = false;
			}

			if (allDead)
			{
				// First, pause the game
				paused = true;

				// Variables
				var highestScore  = 0;
				var highestPlayer = 0;
				var index         = 0;

				// Check who had the highest
				foreach (var player in players)
				{
					if (player.Score <= highestScore) continue;
					highestScore  = player.Score;
					highestPlayer = index;
					index++;
				}

				// Show message
				var nl = Environment.NewLine;
				MessageBox.Show($@"Congratulations!{nl}Player {highestPlayer + 1} won the game with {highestScore} points.", @"Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

				// Close
				form.Close();
			}

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

		public void SpeedUpRandomPlayer() => players.ElementAt(rng.Next(players.Count)).SpeedUp();
	}
}
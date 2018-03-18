using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Engine
 *
 * The main engine that keeps
 * track of all the players etc.
 * It also handles updating everything
 * when needed, including players,
 * spawners etc.
 */

namespace Snake
{
	public class Engine
	{
		private readonly FormMain     form;
		private readonly Timer        timer;
		private readonly Board        board;
		private readonly List<Player> players;
		private readonly Random       rng;
		private readonly Text         textPaused;
		private readonly ISet<Player> speedUpPlayers;

		private bool skipFrame, paused;

		/*
		 * Colors
		 *
		 * Grass:	Green
		 * Food:	Red
		 * Wall:	Orange
		 * Dead:	Grey
		 *
		 * Snake1:	Blue
		 * Snake2:	Yellow
		 * Snake3:	Purple
		 */

		public Engine(int numPlayers)
		{
			// Variables
			form       = new FormMain();
			timer      = new Timer();
			players    = new List<Player>();
			board      = new Board(new Vector2(32, 16));
			rng        = new Random();
			textPaused = new Text("Paused...", "Consolas", 32, new Point(form.Width / 2, form.Height / 2), Color.White);

			skipFrame = false;
			paused    = false;

			// Colors
			var playerColors = new[]
			{
				Color.FromArgb(63,  81,  181),
				Color.FromArgb(255, 235, 59),
				Color.FromArgb(156, 39,  176)
			};

			// Fill board with tiles, "grass"
			board.FillWithRandomTiles();

			// Add players
			for (var i = 0; i < numPlayers; i++)
			{
				var player = new Player(i + 1, board.GetRandomFreePosition(), playerColors[i]);
				players.Add(player);
				board[player.HeadPosition] = player.HeadTile;
			}

			// Place 3-6 random walls
			var walls = rng.Next(3, 6);
			for (var i = 0; i < walls; i++)
				board[board.GetRandomFreePosition()] =  new Wall();

			// Center pause text
			textPaused.CenterLabel();

			// Create set with sped up players
			speedUpPlayers = new HashSet<Player>();
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
			{
				form.Refresh();
				form.ClearAllKeys();
				return;
			}

			// See if we should randomly add some food
			if (rng.Next(100) <= 2)
				AddRandomFood();

			// If there is no food anywhere, spawn one
			if (!board.ContainsFood())
				AddRandomFood();

			// See if we should skip the current frame
			if (skipFrame)
			{
				// Update sped up players before we return
				foreach (var player in speedUpPlayers)
					player.Update(form.AllKeys, board, this);

				// Update form
				form.Refresh();
				
				// Set to not skip next frame and return
				skipFrame = false;
				return;
			}
			skipFrame = true;

			// If all are dead
			var allDead = true;
			foreach (var player in players)
			{
				// Update key presses
				player.Update(form.AllKeys, board, this);

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
			form.ClearAllKeys();
		}

		private void Draw(object sender, PaintEventArgs paintEventArgs)
		{
			// Draw tiles
			board.Draw(paintEventArgs.Graphics);

			// Draw scores
			foreach (var player in players)
				player.DrawScore(paintEventArgs.Graphics);

			// Draw pause text if paused
			if (paused)
				textPaused.Draw(paintEventArgs.Graphics);
		}

		private void AddRandomFood()
		{
			// Get random food
			var num = rng.Next(3);
			Food food;
			switch (num)
			{
				case 0:
					food = new FoodStandard();
					break;
				case 1:
					food = new FoodExtra();
					break;
				case 2:
					food = new FoodSpeed(this);
					break;
				default:
					throw new InvalidOperationException("Invalid number for food");
			}

			// Add food to board
			board[board.GetRandomFreePosition()] = food;
		}

		public void SpeedUpRandomPlayer()
		{
			// Create new list of players who aren't sped up
			var nonSpeedUp = players.Except(speedUpPlayers).ToList();

			// See if we have any players we can speed up
			if (nonSpeedUp.Count == 0)
				return;

			// Get random player
			var random = nonSpeedUp.ElementAt(rng.Next(nonSpeedUp.Count));

			// Speed it up
			speedUpPlayers.Add(random);

			// Remove from list after 10 secs
			Task.Factory.StartNew(() =>
			{
				System.Threading.Thread.Sleep(10000);
				speedUpPlayers.Remove(random);
			});
		}

		public bool TryGetPlayerAtPosition(Vector2 pos, out Player player)
		{
			// Check if tile is player
			if (board[pos].GetType() == typeof(PlayerBody))
			{
				// Loop through players and see if we can find it
				foreach (var p in players)
				{
					if (!p.GetBodyPositions().Contains(pos))
						continue;

					player = p;
					return true;
				}
			}

			// It wasn't found, return default and false
			player = default(Player);
			return false;
		}

		public void ChangeScoreForPlayer(int player, int score)
		{
			// See if player is a valid position
			if (player < 0 || player >= players.Count)
				return;
			// Change the score there
			players.ElementAt(player).ChangeScore(score);
		}

		public void ChangeScoreForPlayer(Player player, int score) => ChangeScoreForPlayer(players.IndexOf(player), score);
	}
}
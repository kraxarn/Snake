﻿using System;

/*
 * Program
 *
 * Default class to act
 * as the main entry point for
 * the application.
 */

namespace Snake
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			// Check how many players we need
			var players = new FormPlayers();
			players.ShowDialog();
			var numPlayers = players.GetNumPlayers();
			if (numPlayers == 0)
				return;
			
			// Create the main engine with desired amount of players
			var engine = new Engine(numPlayers);
			engine.Run();
		}
	}
}

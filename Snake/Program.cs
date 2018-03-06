using System;

namespace Snake
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			var players = new FormPlayers();
			players.ShowDialog();
			var numPlayers = players.GetNumPlayers();
			if (numPlayers == 0)
				return;


			var engine = new Engine(numPlayers);
			engine.Run();

			// Default WinForm stuff
			/*
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormMain());
			*/
		}
	}
}

using System.Drawing;

/*
 * Scoreboard
 *
 * Simple class to keep track of the
 * score (for a player) and to draw
 * it on the screen.
 */

namespace Snake
{
	public class Scoreboard : IDrawable
	{
		// The actual text being drawn to the scren
		private readonly Text text;

		// The score
		public int Score { get; private set; }

		// Constructor to create the text
		public Scoreboard(int player, Color color, Point position) => text = new Text($"P{player}: 0", "Consolas", 12, position, color);

		// Draw the text for the scoreboard
		public void Draw(Graphics g, int x = 0, int y = 0) => text.Draw(g, x, y);

		// When we change score, we also want to update the label
		public void ChangeScore(int amount)
		{
			Score += amount;
			text.Label = text.Label.Substring(0, text.Label.IndexOf(' ')) + $" {Score}";
		}
	}
}
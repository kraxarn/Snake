using System.Drawing;

namespace Snake
{
	public class Scoreboard : IDrawable
	{
		private readonly Text text;

		public int Score { get; private set; }

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
			Score += amount;
			text.Label = text.Label.Substring(0, text.Label.IndexOf(' ')) + $" {Score}";
		}
	}
}
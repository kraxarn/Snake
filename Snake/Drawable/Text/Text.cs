using System.Drawing;

namespace Snake
{
	public class Text : IDrawable
	{
		private readonly Font drawFont;
		private readonly SolidBrush drawer;

		private Point pos;

		public string Label;

		public Text(string label, string font, int size, Point pos, Color color)
		{
			drawFont = new Font(font, size);
			drawer = new SolidBrush(color);

			Label = label;
			this.pos = pos;
		}

		public void Draw(Graphics g, int x = 0, int y = 0) => g.DrawString(Label, drawFont, drawer, pos.X, pos.Y);
	}
}
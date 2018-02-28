using System.Drawing;

namespace Snake
{
	public class Text : IDrawable
	{
		private readonly Font drawFont;
		private readonly SolidBrush drawer;

		public string Label { private get; set; }
		private Point pos;

		public Text(string label, string font, int size, Point pos, Color color)
		{
			drawFont = new Font(font, size);
			drawer = new SolidBrush(color);

			Label = label;
			this.pos = pos;
		}

		public Text(string label, int x, int y) : this(label, "Consolas", 12, new Point(x, y), Color.White) { }

		public void Draw(Graphics g)
		{
			g.DrawString(Label, drawFont, drawer, pos.X, pos.Y);
		}
	}
}
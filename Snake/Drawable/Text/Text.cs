using System.Drawing;

/*
 * Text
 *
 * Class to easier draw text to the
 * screen without having to create
 * seperate fonts, brushes etc.
 */

namespace Snake
{
	public class Text : IDrawable
	{
		// Font being used for the text
		private readonly Font drawFont;
		private readonly SolidBrush drawer;
		// String format so we can align the text
		private readonly StringFormat format;

		// Position to draw the text
		private Point  pos;
		public  string Label;

		public Text(string label, string font, int size, Point pos, Color color)
		{
			drawFont = new Font(font, size);
			drawer   = new SolidBrush(color);
			format   = new StringFormat();

			Label    = label;
			this.pos = pos;
		}

		public void Draw(Graphics g, int x = 0, int y = 0) => g.DrawString(Label, drawFont, drawer, pos.X, pos.Y, format);

		// Sets the point where we draw it to the center of the text
		// By default, it's set to the top left
		public void CenterLabel()
		{
			format.Alignment     = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;
		}
	}
}
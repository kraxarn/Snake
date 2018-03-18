using System.Drawing;

/*
 * IDrawable
 *
 * Interface that tells the
 * class can be drawn to the screen.
 * This is mainly used for tiles, but
 * also used for text.
 */

namespace Snake
{
	public interface IDrawable
	{
		void Draw(Graphics g, int x = 0, int y = 0);
	}
}
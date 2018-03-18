using System.Drawing;

/*
 * Food
 *
 * A type of tile that's
 * the base for different
 * types of food. It also
 * makes sure all foods have
 * the same color.
 */

namespace Snake
{
	public abstract class Food : Tile
	{
		protected Food()
		{
			SetColor(Color.FromArgb(244, 67, 54));
		}
	}
}
using System.Drawing;

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
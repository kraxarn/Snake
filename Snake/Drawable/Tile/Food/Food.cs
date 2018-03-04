using System.Drawing;

namespace Snake
{
	public abstract class Food : Tile
	{
		protected Food()
		{
			SetColor(Color.FromArgb(255, 87, 34));
		}
	}
}
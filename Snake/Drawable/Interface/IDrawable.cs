using System.Drawing;

namespace Snake
{
	public interface IDrawable
	{
		void Draw(Graphics g, int x = 0, int y = 0);
	}
}
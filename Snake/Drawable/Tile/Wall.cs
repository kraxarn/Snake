using System.Drawing;

namespace Snake
{
	public class Wall : Tile
	{
		public Wall() => SetColor(Color.FromArgb(255, 193, 7));

		public override bool Collide(Player player)
		{
			player.Die();
			return true;
		}
	}
}
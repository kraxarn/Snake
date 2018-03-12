using System.Drawing;

namespace Snake
{
	public class Wall : Tile
	{
		public Wall() => SetColor(Color.FromArgb(255, 193, 7));

		public override Collide.Mode Collide(Player player)
		{
			player.Die();
			return Snake.Collide.Mode.Stop;
		}
	}
}
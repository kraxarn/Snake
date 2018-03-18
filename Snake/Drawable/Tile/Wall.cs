using System.Drawing;

/*
 * Wall
 *
 * A type of tile which should
 * kill a snake who collides
 * with it.
 */

namespace Snake
{
	public class Wall : Tile
	{
		public Wall() => SetColor(Color.FromArgb(255, 152, 0));

		public override Collide.Mode Collide(Player player)
		{
			player.Die();
			return Snake.Collide.Mode.Stop;
		}
	}
}
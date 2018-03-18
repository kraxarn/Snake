using System.Drawing;

/*
 * PlayerBody
 *
 * A type of tile that's
 * the snake itself. This
 * is the tile being drawn to
 * the screen as the player.
 */

namespace Snake
{
	public class PlayerBody : Tile
	{
		public Vector2 Position;

		public PlayerBody(Vector2 position, Color color)
		{
			// Set color of tile
			SetColor(color);
			// Set position
			Position = position;
		}

		public override Collide.Mode Collide(Player player)
		{
			player.Die();
			return Snake.Collide.Mode.Stop;
		}
	}
}
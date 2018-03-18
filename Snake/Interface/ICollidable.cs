
/*
 * ICollidable
 *
 * Interface that tells the
 * class can be collided with.
 * Mainly used for tiles.
 */

namespace Snake
{
	public interface ICollidable
	{
		Collide.Mode Collide(Player player);
	}
}
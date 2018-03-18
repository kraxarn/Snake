
/*
 * FoodStandard
 *
 * A type of food that
 * grows the snake by 1
 * tile and awards them
 * with 1 point.
 */

namespace Snake
{
	public class FoodStandard : Food
	{
		public override Collide.Mode Collide(Player player)
		{
			player.GrowLength = 1;
			player.ChangeScore(1);
			return Snake.Collide.Mode.Continue;
		}
	}
}

/*
 * FoodExtra
 * A type of food that
 * grows the snake by
 * 2 tiles and awards them
 * with 5 points.
 */

namespace Snake
{
	public class FoodExtra : Food
	{
		public override Collide.Mode Collide(Player player)
		{
			player.GrowLength = 2;
			player.ChangeScore(5);
			return Snake.Collide.Mode.Continue;
		}
	}
}
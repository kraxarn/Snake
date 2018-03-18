
/*
 * FoodSpeed
 *
 * A type of food that
 * randomly speeds up a
 * player on the board.
 * Since we can't manage all
 * players directly from here,
 * we have to keep a reference to
 * the main Engine class.
 */

namespace Snake
{
	public class FoodSpeed : Food
	{
		private readonly Engine engine;

		public FoodSpeed(Engine engine) => this.engine = engine;

		public override Collide.Mode Collide(Player player)
		{
			engine.SpeedUpRandomPlayer();
			return Snake.Collide.Mode.Continue;
		}
	}
}
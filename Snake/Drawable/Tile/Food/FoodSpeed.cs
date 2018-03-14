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
namespace Snake
{
	public class FoodExtra : Food
	{
		public override Collide.Mode Collide(Player player)
		{
			player.GrowLength = 2;
			player.AddScore(5);
			return Snake.Collide.Mode.Continue;
		}
	}
}
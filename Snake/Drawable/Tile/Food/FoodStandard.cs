namespace Snake
{
	public class FoodStandard : Food
	{
		public override Collide.Mode Collide(Player player)
		{
			player.GrowLength = 1;
			player.AddScore(1);
			return Snake.Collide.Mode.Continue;
		}
	}
}
namespace Snake
{
	public class FoodExtra : Food
	{
		public override bool Collide(Player player)
		{
			player.GrowLength = 2;
			player.AddScore(5);
			return true;
		}
	}
}
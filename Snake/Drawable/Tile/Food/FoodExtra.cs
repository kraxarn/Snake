namespace Snake
{
	public class FoodExtra : Food
	{
		public override void Collide(Player player)
		{
			player.GrowLength = 2;
		}
	}
}
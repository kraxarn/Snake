namespace Snake
{
	public class FoodStandard : Food
	{
		public override bool Collide(Player player)
		{
			player.GrowLength = 1;
			return true;
		}
	}
}
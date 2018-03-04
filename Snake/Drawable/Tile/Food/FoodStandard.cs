namespace Snake
{
	public class FoodStandard : Food
	{
		public override void Collide(Player player)
		{
			player.GrowLength = 1;
		}
	}
}
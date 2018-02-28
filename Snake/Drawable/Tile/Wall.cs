namespace Snake
{
	public class Wall : Tile
	{
		public override void Collide(Player player)
		{
			player.Die();
		}
	}
}
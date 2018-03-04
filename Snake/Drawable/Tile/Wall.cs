namespace Snake
{
	public class Wall : Tile
	{
		public override bool Collide(Player player)
		{
			player.Die();
			return true;
		}
	}
}
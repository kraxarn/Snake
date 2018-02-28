namespace Snake
{
	public class Wall : Tile, ICollidable
	{
		public void Collide(Player player)
		{
			player.Die();
		}
	}
}
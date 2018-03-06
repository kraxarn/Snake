namespace Snake
{
	public interface ICollidable
	{
		Collide.Mode Collide(Player player);
	}
}
using System.Drawing;

namespace Snake
{
	public class Tile : IDrawable, ICollidable
	{
		private Vector2 position;
		private readonly SolidBrush drawer;
		private readonly Rectangle shape;

		public Color FillColor
		{
			get => drawer.Color;
			set => drawer.Color = value;
		}

		public Tile(Vector2 position, Color color, int size = 32)
		{
			this.position = position;
			drawer = new SolidBrush(color);
			shape = new Rectangle(position.ToPoint(), new Size(size, size));
		}

		public Tile() : this(new Vector2(), Color.White) { }

		public void Draw(Graphics g)
		{
			g.FillRectangle(drawer, shape);
		}

        public virtual void Collide(Player player)
        {
            
        }
    }
}
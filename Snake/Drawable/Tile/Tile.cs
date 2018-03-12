using System.Drawing;

namespace Snake
{
	public class Tile : IDrawable, ICollidable
	{
		private readonly SolidBrush drawer;
		private Rectangle shape;

		public Color FillColor
		{
			get => drawer.Color;
			set => drawer.Color = value;
		}

		public Tile(Vector2 position, Color color, int size = 32)
		{
			drawer = new SolidBrush(color);
			shape = new Rectangle(position.ToPoint(), new Size(size, size));
		}

		public Tile() : this(new Vector2(), Color.White) { }

		public void Draw(Graphics g, int x, int y)
		{
			shape.X = x;
			shape.Y = y;
			g.FillRectangle(drawer, shape);
		}

		public virtual Collide.Mode Collide(Player player) => Snake.Collide.Mode.None;

		protected void SetColor(Color color) => drawer.Color = color;

		protected void SetPosition(Vector2 newPosition) => shape.Location = newPosition.ToPoint();
	}
}
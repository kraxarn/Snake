using System.Drawing;

/*
 * Tile
 *
 * Basic tile class which fills the
 * board. It can also be drawn and
 * collide with other tiles.
 */

namespace Snake
{
	public class Tile : IDrawable, ICollidable
	{
		// Brush to draw it
		private readonly SolidBrush drawer;
		// A tile is a rectangle
		private Rectangle shape;

		// Easier shortcut to set the color
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

		// Draw the tile at the set position
		// We update the position as we draw it
		// so we don't have to update it when moving it
		public void Draw(Graphics g, int x, int y)
		{
			shape.X = x;
			shape.Y = y;
			g.FillRectangle(drawer, shape);
		}

		public virtual Collide.Mode Collide(Player player) => Snake.Collide.Mode.None;

		protected void SetColor(Color color) => drawer.Color = color;
	}
}
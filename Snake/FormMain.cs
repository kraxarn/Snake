using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	public sealed partial class FormMain : Form
	{
		public readonly HashSet<Keys> PressedKeys;
		public readonly HashSet<Keys> AllKeys;

		public FormMain()
		{
			// Set window title and size
			Text   = @"Snake";
			Width  = 1032;	// 32 * 32 (+ 8)
			Height = 543;	// 16 * 32 (+ 31)

			// Center window to screen
			StartPosition = FormStartPosition.CenterScreen;

			// To avoid flickering
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

			// Set background color
			BackColor = Color.FromArgb(76, 175, 80);

			// Set icon
			var res = new ComponentResourceManager(typeof(FormMain));
			Icon = (Icon)res.GetObject("$this.Icon");

			// Create set with pressed keys
			PressedKeys = new HashSet<Keys>();
			AllKeys     = new HashSet<Keys>();
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			PressedKeys.Remove(e.KeyData);
			base.OnKeyUp(e);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			PressedKeys.Add(e.KeyData);
			AllKeys.Add(e.KeyData);
			base.OnKeyDown(e);
		}

		public void ClearAllKeys() => AllKeys.Clear();
	}
}

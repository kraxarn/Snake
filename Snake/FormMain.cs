using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	public partial class FormMain : Form
	{
		public Keys KeyData { get; private set; }
		public Keys CurrentKeyDown { get; private set; }

		public FormMain()
		{
			Text   = "Snake";
			Width  = 1032;	// 32 * 32 (+ 8)
			Height = 543;	// 16 * 32 (+ 31)

			StartPosition = FormStartPosition.CenterScreen;

			// To avoid flickering
			SetStyle(
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.UserPaint |
				ControlStyles.DoubleBuffer,
				true);

			// Set background color
			BackColor = Color.FromArgb(76, 175, 80);

			// Set icon
			var res = new ComponentResourceManager(typeof(FormMain));
			Icon = (Icon) res.GetObject("$this.Icon");

			// Default WinForm stuff
			//InitializeComponent();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			KeyData = keyData;
			return base.ProcessCmdKey(ref msg, keyData);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			CurrentKeyDown = Keys.None;
			base.OnKeyUp(e);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			CurrentKeyDown = e.KeyData;
			base.OnKeyDown(e);
		}
	}
}

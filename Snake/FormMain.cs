using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
	public partial class FormMain : Form
	{
		public Keys KeyData { get; private set; }

		public FormMain()
		{
			Text   = "Snake";
			Width  = 1024;	// 32 * 32
			Height = 512;	// 16 * 32

			StartPosition = FormStartPosition.CenterScreen;

			// To avoid flickering
			SetStyle(
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.UserPaint |
				ControlStyles.DoubleBuffer,
				true);

			// Set background color
			BackColor = Color.FromArgb(76, 175, 80);

			// Default WinForm stuff
			//InitializeComponent();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			KeyData = keyData;
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}

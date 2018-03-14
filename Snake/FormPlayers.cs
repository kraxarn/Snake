using System;
using System.Windows.Forms;

namespace Snake
{
	public partial class FormPlayers : Form
	{
		private int players;

		public FormPlayers()
		{
			InitializeComponent();

			players = 0;
		}

		private void Btn1_Click(object sender, EventArgs e) => SetPlayerCount(1);
		private void Btn2_Click(object sender, EventArgs e) => SetPlayerCount(2);
		private void Btn3_Click(object sender, EventArgs e) => SetPlayerCount(3);

		private void SetPlayerCount(int num)
		{
			players = num;
			Close();
		}

		public int GetNumPlayers() => players;

		private void BtnColors_Click(object sender, EventArgs e)
		{
			if (Height == 238)
			{
				// Show colors
				Height = 354;
				BtnColors.Text = @"▼ Colors";
			}
			else if (Height == 354)
			{
				// Hide colors
				Height = 238;
				BtnColors.Text = @"► Colors";
			}
		}
	}
}

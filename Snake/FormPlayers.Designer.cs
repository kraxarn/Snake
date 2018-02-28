namespace Snake
{
	partial class FormPlayers
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.Btn1 = new System.Windows.Forms.Button();
			this.Btn2 = new System.Windows.Forms.Button();
			this.Btn3 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(214, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "How many players?";
			// 
			// Btn1
			// 
			this.Btn1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Btn1.Location = new System.Drawing.Point(16, 56);
			this.Btn1.Name = "Btn1";
			this.Btn1.Size = new System.Drawing.Size(76, 24);
			this.Btn1.TabIndex = 1;
			this.Btn1.Text = "1 Player";
			this.Btn1.UseVisualStyleBackColor = true;
			this.Btn1.Click += new System.EventHandler(this.Btn1_Click);
			// 
			// Btn2
			// 
			this.Btn2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Btn2.Location = new System.Drawing.Point(108, 56);
			this.Btn2.Name = "Btn2";
			this.Btn2.Size = new System.Drawing.Size(76, 24);
			this.Btn2.TabIndex = 2;
			this.Btn2.Text = "2 Players";
			this.Btn2.UseVisualStyleBackColor = true;
			this.Btn2.Click += new System.EventHandler(this.Btn2_Click);
			// 
			// Btn3
			// 
			this.Btn3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Btn3.Location = new System.Drawing.Point(200, 56);
			this.Btn3.Name = "Btn3";
			this.Btn3.Size = new System.Drawing.Size(76, 24);
			this.Btn3.TabIndex = 3;
			this.Btn3.Text = "3 Players";
			this.Btn3.UseVisualStyleBackColor = true;
			this.Btn3.Click += new System.EventHandler(this.Btn3_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(189, 57);
			this.label2.TabIndex = 4;
			this.label2.Text = "Player 1: W, A, S, D\r\nPlayer 2: I, J, K, L\r\nPlayer 3: T, F, G, H";
			// 
			// FormPlayers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 165);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Btn3);
			this.Controls.Add(this.Btn2);
			this.Controls.Add(this.Btn1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPlayers";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Snek";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button Btn1;
		private System.Windows.Forms.Button Btn2;
		private System.Windows.Forms.Button Btn3;
		private System.Windows.Forms.Label label2;
	}
}
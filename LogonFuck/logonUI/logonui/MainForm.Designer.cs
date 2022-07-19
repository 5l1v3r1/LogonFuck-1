namespace logonui
{
	// Token: 0x02000002 RID: 2
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000022A9 File Offset: 0x000004A9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000022C8 File Offset: 0x000004C8
		private void InitializeComponent()
		{
			this.onetimeLabel = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.onetimeLabel.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.onetimeLabel.AutoSize = true;
			this.onetimeLabel.Font = new global::System.Drawing.Font("Microsoft YaHei", 72f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.onetimeLabel.Location = new global::System.Drawing.Point(293, 374);
			this.onetimeLabel.Name = "onetimeLabel";
			this.onetimeLabel.Size = new global::System.Drawing.Size(1187, 248);
			this.onetimeLabel.TabIndex = 0;
			this.onetimeLabel.Text = "THIS SCREEN CAN ONLY\r\nBE SEEN ONE TIME";
			this.onetimeLabel.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(255, 128, 0);
			base.ClientSize = new global::System.Drawing.Size(1920, 1080);
			base.ControlBox = false;
			base.Controls.Add(this.onetimeLabel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MainForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.TopMost = true;
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			base.Load += new global::System.EventHandler(this.MainForm_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000007 RID: 7
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Label onetimeLabel;
	}
}

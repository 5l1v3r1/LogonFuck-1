using System;
using System.Drawing;

namespace LogonFuck
{
	// Token: 0x02000008 RID: 8
	internal class InverseDrawer : Drawer
	{
		// Token: 0x06000026 RID: 38 RVA: 0x000027E4 File Offset: 0x000009E4
		public InverseDrawer(int delay, int strenght, CopyPixelOperation dwRop) : base(delay)
		{
			this.strenght = strenght;
			this.dwRop = dwRop;
			this.lpPoints = new Point[3];
			this.lpPoints[0] = new Point(strenght * 2, strenght);
			this.lpPoints[1] = new Point(Drawer.screenWidth - strenght, strenght * 2);
			this.lpPoints[2] = new Point(strenght, Drawer.screenHeight - strenght * 2);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002864 File Offset: 0x00000A64
		protected override void Draw(IntPtr hdc)
		{
			Drawer.PlgBlt(hdc, this.lpPoints, hdc, 0, 0, Drawer.screenWidth, Drawer.screenHeight, IntPtr.Zero, 0, 0);
			Drawer.BitBlt(hdc, this.i, 0, Drawer.screenWidth, Drawer.screenHeight, hdc, 0, 0, this.dwRop);
			this.i *= -1;
		}

		// Token: 0x04000017 RID: 23
		public int strenght;

		// Token: 0x04000018 RID: 24
		public CopyPixelOperation dwRop;

		// Token: 0x04000019 RID: 25
		private Point[] lpPoints;

		// Token: 0x0400001A RID: 26
		private int i = 1;
	}
}

using System;
using System.Drawing;

namespace LogonFuck
{
	// Token: 0x0200000A RID: 10
	internal class RandomDrawer : Drawer
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00002927 File Offset: 0x00000B27
		public RandomDrawer(int delay, CopyPixelOperation dwRop) : base(delay)
		{
			this.dwRop = dwRop;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002938 File Offset: 0x00000B38
		protected override void Draw(IntPtr hdc)
		{
			int nXDest = Drawer.random.Next(0, Drawer.screenWidth);
			int nYDest = Drawer.random.Next(0, Drawer.screenHeight);
			int nXSrc = Drawer.random.Next(0, Drawer.screenWidth);
			int nYSrc = Drawer.random.Next(0, Drawer.screenHeight);
			int nWidth = Drawer.random.Next(0, Drawer.screenWidth);
			int nHeight = Drawer.random.Next(0, Drawer.screenHeight);
			Drawer.BitBlt(hdc, nXDest, nYDest, nWidth, nHeight, hdc, nXSrc, nYSrc, this.dwRop);
		}

		// Token: 0x0400001C RID: 28
		public CopyPixelOperation dwRop;
	}
}

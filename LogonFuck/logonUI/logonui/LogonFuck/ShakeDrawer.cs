using System;
using System.Drawing;

namespace LogonFuck
{
	// Token: 0x0200000B RID: 11
	internal class ShakeDrawer : Drawer
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000029C3 File Offset: 0x00000BC3
		public ShakeDrawer(int delay, int strenght, bool clockwise) : base(delay)
		{
			this.strenght = strenght;
			this.clockwise = clockwise;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000029DC File Offset: 0x00000BDC
		protected override void Draw(IntPtr hdc)
		{
			int nXDest = (int)(Math.Cos(this.rads) * (double)this.strenght);
			int nYDest = (int)(Math.Sin(this.rads) * (double)this.strenght);
			Drawer.BitBlt(hdc, nXDest, nYDest, Drawer.screenWidth, Drawer.screenHeight, hdc, 0, 0, CopyPixelOperation.SourceCopy);
			if (this.clockwise)
			{
				this.rads += 0.39269908169872414;
			}
			else
			{
				this.rads -= 0.39269908169872414;
			}
			if (this.rads > 6.283185307179586)
			{
				this.rads -= 6.283185307179586;
			}
			else if (this.rads < 0.0)
			{
				this.rads += 6.283185307179586;
			}
			int num = Drawer.random.Next(0, 256);
			int num2 = Drawer.random.Next(0, 256);
			int num3 = Drawer.random.Next(0, 256);
			if (this.c == 0)
			{
				IntPtr intPtr = Drawer.CreateSolidBrush((uint)(num + num2 * 256 + num3 * 256 * 256));
				Drawer.SelectObject(hdc, intPtr);
				Drawer.PatBlt(hdc, 0, 0, Drawer.screenWidth, Drawer.screenHeight, CopyPixelOperation.PatInvert);
				Drawer.DeleteObject(intPtr);
			}
			this.c++;
			if (this.c >= 10)
			{
				this.c -= 10;
			}
		}

		// Token: 0x0400001D RID: 29
		public bool clockwise;

		// Token: 0x0400001E RID: 30
		public int strenght;

		// Token: 0x0400001F RID: 31
		private double rads;

		// Token: 0x04000020 RID: 32
		private int c;
	}
}

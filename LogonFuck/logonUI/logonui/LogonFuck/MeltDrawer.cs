using System;
using System.Drawing;

namespace LogonFuck
{
	// Token: 0x02000009 RID: 9
	internal class MeltDrawer : Drawer
	{
		// Token: 0x06000028 RID: 40 RVA: 0x000028C1 File Offset: 0x00000AC1
		public MeltDrawer(int strenght) : base(0)
		{
			this.strenght = strenght;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000028D4 File Offset: 0x00000AD4
		protected override void Draw(IntPtr hdc)
		{
			int nXDest = Drawer.random.Next(-this.strenght, this.strenght + 1);
			int num = Drawer.random.Next(0, Drawer.screenHeight);
			Drawer.BitBlt(hdc, nXDest, num, Drawer.screenWidth, 300, hdc, 0, num, CopyPixelOperation.SourceCopy);
		}

		// Token: 0x0400001B RID: 27
		public int strenght;
	}
}

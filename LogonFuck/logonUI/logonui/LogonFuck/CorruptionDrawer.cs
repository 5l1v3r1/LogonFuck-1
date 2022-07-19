using System;
using System.Drawing;

namespace LogonFuck
{
	// Token: 0x02000006 RID: 6
	internal class CorruptionDrawer : Drawer
	{
		// Token: 0x06000016 RID: 22 RVA: 0x000025EB File Offset: 0x000007EB
		public CorruptionDrawer(int delay) : base(delay)
		{
			this.delay = delay;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002610 File Offset: 0x00000810
		protected override void Draw(IntPtr hdc)
		{
			int nXDest = Drawer.random.Next(-this.move, this.move + 1);
			int nYDest = Drawer.random.Next(-this.move, this.move + 1);
			Drawer.BitBlt(hdc, nXDest, this.row, Drawer.screenWidth, this.blockHeight, hdc, 0, this.row, CopyPixelOperation.SourceCopy);
			Drawer.BitBlt(hdc, this.column, nYDest, this.blockWidth, Drawer.screenHeight, hdc, this.column, 0, CopyPixelOperation.SourceCopy);
			this.row += this.blockHeight;
			this.column += this.blockWidth;
			if (this.row >= Drawer.screenHeight)
			{
				this.row = 0;
			}
			if (this.column >= Drawer.screenWidth)
			{
				this.column = 0;
			}
		}

		// Token: 0x0400000D RID: 13
		protected int blockWidth = 5;

		// Token: 0x0400000E RID: 14
		protected int blockHeight = 5;

		// Token: 0x0400000F RID: 15
		protected int move = 2;

		// Token: 0x04000010 RID: 16
		protected int row;

		// Token: 0x04000011 RID: 17
		protected int column;
	}
}

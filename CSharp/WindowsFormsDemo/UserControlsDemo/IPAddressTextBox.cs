using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TrainingCenter.Windows.Forms.Controls
{
	public class IPAddressTextBox : Control
	{
		static IPAddressTextBox()
		{
			INITCOMMONCONTROLSEX iccex = default(INITCOMMONCONTROLSEX);
			iccex.dwSize = Marshal.SizeOf(iccex);
			iccex.dwICC = CommonControls.ICC_INTERNET_CLASSES;
			InitCommonControlsEx(ref iccex);
		}

		protected override void CreateHandle()
		{
			//CreateWindowEx(WC_IPADDRESSW);
			base.CreateHandle();
		}

		const string WC_IPADDRESSW = "SysIPAddress32";

		[DllImport("comctl32.dll", EntryPoint = "InitCommonControlsEx", CallingConvention = CallingConvention.StdCall)]
		static extern bool InitCommonControlsEx(ref INITCOMMONCONTROLSEX iccex);

		[StructLayout(LayoutKind.Sequential)]
		struct INITCOMMONCONTROLSEX
		{
			public int dwSize;
			public CommonControls dwICC;
		}
	
		[Flags]
		public enum CommonControls : uint
		{
			//ICC_LISTVIEW_CLASSES = 0x00000001, // listview, header
			//ICC_TREEVIEW_CLASSES = 0x00000002, // treeview, tooltips
			//ICC_BAR_CLASSES = 0x00000004, // toolbar, statusbar, trackbar, tooltips
			//ICC_TAB_CLASSES = 0x00000008, // tab, tooltips
			//ICC_UPDOWN_CLASS = 0x00000010, // updown
			//ICC_PROGRESS_CLASS = 0x00000020, // progress
			//ICC_HOTKEY_CLASS = 0x00000040, // hotkey
			//ICC_ANIMATE_CLASS = 0x00000080, // animate
			//ICC_WIN95_CLASSES = 0x000000FF,
			//ICC_DATE_CLASSES = 0x00000100, // month picker, date picker, time picker, updown
			//ICC_USEREX_CLASSES = 0x00000200, // comboex
			//ICC_COOL_CLASSES = 0x00000400, // rebar (coolbar) control
			ICC_INTERNET_CLASSES = 0x00000800,
			//ICC_PAGESCROLLER_CLASS = 0x00001000,  // page scroller
			//ICC_NATIVEFNTCTL_CLASS = 0x00002000,  // native font control
			//ICC_STANDARD_CLASSES = 0x00004000,
			//ICC_LINK_CLASS = 0x00008000
		}
	}
}

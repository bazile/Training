using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EnvironmentInformation
{
	public partial class MainForm : Form
	{
		private const string EnvGroup     = "System.Environment";
		private const string BitConvGroup = "System.BitConverter";
		private const string PathGroup    = "System.IO.Path";
		private const string SysInfoGroup = "System.Windows.Forms.SystemInformation";
		private const string ScreenGroup  = "System.Windows.Forms.Screen";
		private const string ComputerInfoGroup = "Microsoft.VisualBasic.Devices.ComputerInfo";
		const string RuntimeEnvGroup = "System.Runtime.InteropServices.RuntimeEnvironment";

		public MainForm()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			InitSystemInfoData();
			InitVarsData();

			//EnableCollapsibleGroups(listViewSysInfo);
		}

		private void InitSystemInfoData()
		{
			listViewSysInfo.BeginUpdate();

			#region System.Environment

			AddEnvironmentItem(EnvGroup, "CommandLine", Environment.CommandLine);
			//AddEnvironmentItem("EnvGroup", "CurrentDirectory", Environment.CurrentDirectory);
			AddEnvironmentItem(EnvGroup, "Is64BitOperatingSystem", Environment.Is64BitOperatingSystem);
			AddEnvironmentItem(EnvGroup, "Is64BitProcess", Environment.Is64BitProcess);
			AddEnvironmentItem(EnvGroup, "MachineName", Environment.MachineName);
			AddEnvironmentItem(EnvGroup, "OSVersion", Environment.OSVersion);
			AddEnvironmentItem(EnvGroup, "ProcessorCount", Environment.ProcessorCount);
			AddEnvironmentItem(EnvGroup, "SystemDirectory", Environment.SystemDirectory);
			AddEnvironmentItem(EnvGroup, "SystemPageSize", Environment.SystemPageSize);
			AddEnvironmentItem(EnvGroup, "TickCount", Environment.TickCount);
			AddEnvironmentItem(EnvGroup, "UserDomainName", Environment.UserDomainName);
			AddEnvironmentItem(EnvGroup, "UserInteractive", Environment.UserInteractive);
			AddEnvironmentItem(EnvGroup, "UserName", Environment.UserName);
			AddEnvironmentItem(EnvGroup, "Version", Environment.Version);
			AddEnvironmentItem(EnvGroup, "WorkingSet", Environment.WorkingSet);

			#endregion

			#region System.Runtime.InteropServices.RuntimeEnvironment
			AddEnvironmentItem(RuntimeEnvGroup, "SystemConfigurationFile", RuntimeEnvironment.SystemConfigurationFile);
			AddEnvironmentItem(RuntimeEnvGroup, "RuntimeDirectory", RuntimeEnvironment.GetRuntimeDirectory());
			AddEnvironmentItem(RuntimeEnvGroup, "SystemVersion", RuntimeEnvironment.GetSystemVersion());
			#endregion

			#region System.BitConverter
			AddEnvironmentItem(BitConvGroup, "IsLittleEndian", BitConverter.IsLittleEndian);
			#endregion

			#region System.IO.Path
			AddEnvironmentItem(PathGroup, "GetTempPath()", Path.GetTempPath());
			#endregion

			//#region System.Diagnostics.Process
			//Process p = Process.GetCurrentProcess();
			//#endregion

			//#region System.Globalization.CultureInfo
			//CultureInfo.CurrentCulture
			//CultureInfo.CurrentUICulture
			//#endregion

			#region System.Windows.Forms.Screen
			var allScreens = Screen.AllScreens.OrderBy(s => !s.Primary).ToArray();
			for (int i=0; i<allScreens.Length; i++)
			{
				var scr = allScreens[i];
				AddEnvironmentItem(
					ScreenGroup,
					string.Format("Монитор {0}", i+1),
					string.Format("{0}x{1}, {2} bits per pixel.", scr.Bounds.Width, scr.Bounds.Height, scr.BitsPerPixel)
				);
			}
			#endregion

			#region Microsoft.VisualBasic.Devices.ComputerInfo
			var computerInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
			AddEnvironmentItem(ComputerInfoGroup, "AvailablePhysicalMemory", computerInfo.AvailablePhysicalMemory.ToString("N0"));
			AddEnvironmentItem(ComputerInfoGroup, "AvailablePhysicalMemory", computerInfo.AvailablePhysicalMemory.ToString("N0"));
			AddEnvironmentItem(ComputerInfoGroup, "OSFullName", computerInfo.OSFullName);
			AddEnvironmentItem(ComputerInfoGroup, "OSPlatform", computerInfo.OSPlatform);
			AddEnvironmentItem(ComputerInfoGroup, "OSVersion", computerInfo.OSVersion);
			AddEnvironmentItem(ComputerInfoGroup, "TotalPhysicalMemory", computerInfo.TotalPhysicalMemory.ToString("N0"));
			AddEnvironmentItem(ComputerInfoGroup, "TotalVirtualMemory", computerInfo.TotalVirtualMemory.ToString("N0"));
			#endregion

			#region System.Windows.Forms.SystemInformation

			AddEnvironmentItem(SysInfoGroup, "ActiveWindowTrackingDelay", SystemInformation.ActiveWindowTrackingDelay);
			AddEnvironmentItem(SysInfoGroup, "ArrangeDirection", SystemInformation.ArrangeDirection);
			AddEnvironmentItem(SysInfoGroup, "ArrangeStartingPosition", SystemInformation.ArrangeStartingPosition);
			AddEnvironmentItem(SysInfoGroup, "BootMode", SystemInformation.BootMode);
			AddEnvironmentItem(SysInfoGroup, "Border3DSize", SystemInformation.Border3DSize);
			AddEnvironmentItem(SysInfoGroup, "BorderMultiplierFactor", SystemInformation.BorderMultiplierFactor);
			AddEnvironmentItem(SysInfoGroup, "BorderSize", SystemInformation.BorderSize);
			AddEnvironmentItem(SysInfoGroup, "CaptionButtonSize", SystemInformation.CaptionButtonSize);
			AddEnvironmentItem(SysInfoGroup, "CaptionHeight", SystemInformation.CaptionHeight);
			AddEnvironmentItem(SysInfoGroup, "CaretBlinkTime", SystemInformation.CaretBlinkTime);
			AddEnvironmentItem(SysInfoGroup, "CaretWidth", SystemInformation.CaretWidth);
			AddEnvironmentItem(SysInfoGroup, "ComputerName", SystemInformation.ComputerName);
			AddEnvironmentItem(SysInfoGroup, "CursorSize", SystemInformation.CursorSize);
			AddEnvironmentItem(SysInfoGroup, "DbcsEnabled", SystemInformation.DbcsEnabled);
			AddEnvironmentItem(SysInfoGroup, "DebugOS", SystemInformation.DebugOS);
			AddEnvironmentItem(SysInfoGroup, "DoubleClickSize", SystemInformation.DoubleClickSize);
			AddEnvironmentItem(SysInfoGroup, "DoubleClickTime", SystemInformation.DoubleClickTime);
			AddEnvironmentItem(SysInfoGroup, "DragFullWindows", SystemInformation.DragFullWindows);
			AddEnvironmentItem(SysInfoGroup, "DragSize", SystemInformation.DragSize);
			AddEnvironmentItem(SysInfoGroup, "FixedFrameBorderSize", SystemInformation.FixedFrameBorderSize);
			AddEnvironmentItem(SysInfoGroup, "FontSmoothingContrast", SystemInformation.FontSmoothingContrast);
			AddEnvironmentItem(SysInfoGroup, "FontSmoothingType", SystemInformation.FontSmoothingType);
			AddEnvironmentItem(SysInfoGroup, "FrameBorderSize", SystemInformation.FrameBorderSize);
			AddEnvironmentItem(SysInfoGroup, "HighContrast", SystemInformation.HighContrast);
			AddEnvironmentItem(SysInfoGroup, "HorizontalFocusThickness", SystemInformation.HorizontalFocusThickness);
			AddEnvironmentItem(SysInfoGroup, "HorizontalResizeBorderThickness", SystemInformation.HorizontalResizeBorderThickness);
			AddEnvironmentItem(SysInfoGroup, "HorizontalScrollBarArrowWidth", SystemInformation.HorizontalScrollBarArrowWidth);
			AddEnvironmentItem(SysInfoGroup, "HorizontalScrollBarHeight", SystemInformation.HorizontalScrollBarHeight);
			AddEnvironmentItem(SysInfoGroup, "HorizontalScrollBarThumbWidth", SystemInformation.HorizontalScrollBarThumbWidth);
			AddEnvironmentItem(SysInfoGroup, "IconHorizontalSpacing", SystemInformation.IconHorizontalSpacing);
			AddEnvironmentItem(SysInfoGroup, "IconSize", SystemInformation.IconSize);
			AddEnvironmentItem(SysInfoGroup, "IconSpacingSize", SystemInformation.IconSpacingSize);
			AddEnvironmentItem(SysInfoGroup, "IconVerticalSpacing", SystemInformation.IconVerticalSpacing);
			AddEnvironmentItem(SysInfoGroup, "IsActiveWindowTrackingEnabled", SystemInformation.IsActiveWindowTrackingEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsComboBoxAnimationEnabled", SystemInformation.IsComboBoxAnimationEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsDropShadowEnabled", SystemInformation.IsDropShadowEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsFlatMenuEnabled", SystemInformation.IsFlatMenuEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsFontSmoothingEnabled", SystemInformation.IsFontSmoothingEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsHotTrackingEnabled", SystemInformation.IsHotTrackingEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsIconTitleWrappingEnabled", SystemInformation.IsIconTitleWrappingEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsKeyboardPreferred", SystemInformation.IsKeyboardPreferred);
			AddEnvironmentItem(SysInfoGroup, "IsListBoxSmoothScrollingEnabled", SystemInformation.IsListBoxSmoothScrollingEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsMenuAnimationEnabled", SystemInformation.IsMenuAnimationEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsMenuFadeEnabled", SystemInformation.IsMenuFadeEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsMinimizeRestoreAnimationEnabled",
							   SystemInformation.IsMinimizeRestoreAnimationEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsSelectionFadeEnabled", SystemInformation.IsSelectionFadeEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsSnapToDefaultEnabled", SystemInformation.IsSnapToDefaultEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsTitleBarGradientEnabled", SystemInformation.IsTitleBarGradientEnabled);
			AddEnvironmentItem(SysInfoGroup, "IsToolTipAnimationEnabled", SystemInformation.IsToolTipAnimationEnabled);
			AddEnvironmentItem(SysInfoGroup, "KanjiWindowHeight", SystemInformation.KanjiWindowHeight);
			AddEnvironmentItem(SysInfoGroup, "KeyboardDelay", SystemInformation.KeyboardDelay);
			AddEnvironmentItem(SysInfoGroup, "KeyboardSpeed", SystemInformation.KeyboardSpeed);
			AddEnvironmentItem(SysInfoGroup, "MaxWindowTrackSize", SystemInformation.MaxWindowTrackSize);
			AddEnvironmentItem(SysInfoGroup, "MenuAccessKeysUnderlined", SystemInformation.MenuAccessKeysUnderlined);
			AddEnvironmentItem(SysInfoGroup, "MenuBarButtonSize", SystemInformation.MenuBarButtonSize);
			AddEnvironmentItem(SysInfoGroup, "MenuButtonSize", SystemInformation.MenuButtonSize);
			AddEnvironmentItem(SysInfoGroup, "MenuCheckSize", SystemInformation.MenuCheckSize);
			AddEnvironmentItem(SysInfoGroup, "MenuFont", SystemInformation.MenuFont);
			AddEnvironmentItem(SysInfoGroup, "MenuHeight", SystemInformation.MenuHeight);
			AddEnvironmentItem(SysInfoGroup, "MenuShowDelay", SystemInformation.MenuShowDelay);
			AddEnvironmentItem(SysInfoGroup, "MidEastEnabled", SystemInformation.MidEastEnabled);
			AddEnvironmentItem(SysInfoGroup, "MinimizedWindowSize", SystemInformation.MinimizedWindowSize);
			AddEnvironmentItem(SysInfoGroup, "MinimizedWindowSpacingSize", SystemInformation.MinimizedWindowSpacingSize);
			AddEnvironmentItem(SysInfoGroup, "MinimumWindowSize", SystemInformation.MinimumWindowSize);
			AddEnvironmentItem(SysInfoGroup, "MinWindowTrackSize", SystemInformation.MinWindowTrackSize);
			AddEnvironmentItem(SysInfoGroup, "MonitorCount", SystemInformation.MonitorCount);
			AddEnvironmentItem(SysInfoGroup, "MonitorsSameDisplayFormat", SystemInformation.MonitorsSameDisplayFormat);
			AddEnvironmentItem(SysInfoGroup, "MouseButtons", SystemInformation.MouseButtons);
			AddEnvironmentItem(SysInfoGroup, "MouseButtonsSwapped", SystemInformation.MouseButtonsSwapped);
			AddEnvironmentItem(SysInfoGroup, "MouseHoverSize", SystemInformation.MouseHoverSize);
			AddEnvironmentItem(SysInfoGroup, "MouseHoverTime", SystemInformation.MouseHoverTime);
			AddEnvironmentItem(SysInfoGroup, "MousePresent", SystemInformation.MousePresent);
			AddEnvironmentItem(SysInfoGroup, "MouseSpeed", SystemInformation.MouseSpeed);
			AddEnvironmentItem(SysInfoGroup, "MouseWheelPresent", SystemInformation.MouseWheelPresent);
			AddEnvironmentItem(SysInfoGroup, "MouseWheelScrollDelta", SystemInformation.MouseWheelScrollDelta);
			AddEnvironmentItem(SysInfoGroup, "MouseWheelScrollLines", SystemInformation.MouseWheelScrollLines);
			AddEnvironmentItem(SysInfoGroup, "NativeMouseWheelSupport", SystemInformation.NativeMouseWheelSupport);
			AddEnvironmentItem(SysInfoGroup, "Network", SystemInformation.Network);
			AddEnvironmentItem(SysInfoGroup, "PenWindows", SystemInformation.PenWindows);
			AddEnvironmentItem(SysInfoGroup, "PopupMenuAlignment", SystemInformation.PopupMenuAlignment);

			AddEnvironmentItem(SysInfoGroup, "PowerStatus.BatteryChargeStatus", SystemInformation.PowerStatus.BatteryChargeStatus);
			AddEnvironmentItem(SysInfoGroup, "PowerStatus", SystemInformation.PowerStatus.BatteryFullLifetime);
			AddEnvironmentItem(SysInfoGroup, "PowerStatus.BatteryFullLifetime", SystemInformation.PowerStatus.BatteryLifePercent);
			AddEnvironmentItem(SysInfoGroup, "PowerStatus.BatteryLifeRemaining", SystemInformation.PowerStatus.BatteryLifeRemaining);
			AddEnvironmentItem(SysInfoGroup, "PowerStatus.PowerLineStatus", SystemInformation.PowerStatus.PowerLineStatus);

			AddEnvironmentItem(SysInfoGroup, "PrimaryMonitorMaximizedWindowSize",
							   SystemInformation.PrimaryMonitorMaximizedWindowSize);
			AddEnvironmentItem(SysInfoGroup, "PrimaryMonitorSize", SystemInformation.PrimaryMonitorSize);
			AddEnvironmentItem(SysInfoGroup, "RightAlignedMenus", SystemInformation.RightAlignedMenus);
			AddEnvironmentItem(SysInfoGroup, "ScreenOrientation", SystemInformation.ScreenOrientation);
			AddEnvironmentItem(SysInfoGroup, "Secure", SystemInformation.Secure);
			AddEnvironmentItem(SysInfoGroup, "ShowSounds", SystemInformation.ShowSounds);
			AddEnvironmentItem(SysInfoGroup, "SizingBorderWidth", SystemInformation.SizingBorderWidth);
			AddEnvironmentItem(SysInfoGroup, "SmallCaptionButtonSize", SystemInformation.SmallCaptionButtonSize);
			AddEnvironmentItem(SysInfoGroup, "SmallIconSize", SystemInformation.SmallIconSize);
			AddEnvironmentItem(SysInfoGroup, "TerminalServerSession", SystemInformation.TerminalServerSession);
			AddEnvironmentItem(SysInfoGroup, "ToolWindowCaptionButtonSize", SystemInformation.ToolWindowCaptionButtonSize);
			AddEnvironmentItem(SysInfoGroup, "ToolWindowCaptionHeight", SystemInformation.ToolWindowCaptionHeight);
			AddEnvironmentItem(SysInfoGroup, "UIEffectsEnabled", SystemInformation.UIEffectsEnabled);
			AddEnvironmentItem(SysInfoGroup, "UserDomainName", SystemInformation.UserDomainName);
			AddEnvironmentItem(SysInfoGroup, "UserInteractive", SystemInformation.UserInteractive);
			AddEnvironmentItem(SysInfoGroup, "UserName", SystemInformation.UserName);
			AddEnvironmentItem(SysInfoGroup, "VerticalFocusThickness", SystemInformation.VerticalFocusThickness);
			AddEnvironmentItem(SysInfoGroup, "VerticalResizeBorderThickness", SystemInformation.VerticalResizeBorderThickness);
			AddEnvironmentItem(SysInfoGroup, "VerticalScrollBarArrowHeight", SystemInformation.VerticalScrollBarArrowHeight);
			AddEnvironmentItem(SysInfoGroup, "VerticalScrollBarThumbHeight", SystemInformation.VerticalScrollBarThumbHeight);
			AddEnvironmentItem(SysInfoGroup, "VerticalScrollBarWidth", SystemInformation.VerticalScrollBarWidth);
			AddEnvironmentItem(SysInfoGroup, "VirtualScreen", SystemInformation.VirtualScreen);
			AddEnvironmentItem(SysInfoGroup, "WorkingArea", SystemInformation.WorkingArea);

			#endregion

			listViewSysInfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			listViewSysInfo.EndUpdate();
		}

		private void InitVarsData()
		{
			listViewVars.BeginUpdate();

			var envVars = Environment.GetEnvironmentVariables()
									 .Cast<DictionaryEntry>()
									 .Select(e => new {Name = e.Key.ToString(), Value = e.Value.ToString()})
									 .OrderBy(e => e.Name);
			foreach (var envVar in envVars)
			{
				ListViewItem listItem = new ListViewItem(envVar.Name);
				listItem.SubItems.Add(envVar.Value);
				listViewVars.Items.Add(listItem);
			}

			listViewVars.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			listViewVars.EndUpdate();
		}

		private void AddEnvironmentItem(string groupName, string name, object value)
		{
			AddEnvironmentItem(groupName, name, value.ToString());
		}

		private void AddEnvironmentItem(string groupName, string name, string value)
		{
			ListViewItem listItem = new ListViewItem(name);
			ListViewGroup itemGroup = listViewSysInfo.Groups[groupName];
			if (itemGroup == null)
			{
				itemGroup = new ListViewGroup(groupName, "Класс " + groupName);
				listViewSysInfo.Groups.Add(itemGroup);
			}
			listItem.Group = itemGroup;
			listItem.SubItems.Add(value);
			listItem.Tag = groupName + "." + name;
			listViewSysInfo.Items.Add(listItem);
		}

		private void OnSysInfoContextItem_Click(object sender, EventArgs e)
		{
			if (listViewSysInfo.SelectedItems.Count != 1) return;
		
			ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
			ListViewItem selectedItem = listViewSysInfo.SelectedItems[0];
			
			string lang = (string)(menuItem.Tag);

			string msdnUrl =
				string.Format(
					"http://msdn.microsoft.com//query/dev10.query?appId=Dev10IDEF1&l={0}&k=k({1});k(TargetFrameworkMoniker-\".NETFRAMEWORK,VERSION=V4.0\");k(DevLang-CSHARP)&rd=true",
					lang, selectedItem.Tag);
			Process.Start(msdnUrl);
		}

		private void OnOpenEnvVarDialogItem_Click(object sender, EventArgs e)
		{
			Process.Start(
				Path.Combine(Environment.SystemDirectory, "rundll32.exe"),
				"sysdm.cpl,EditEnvironmentVariables"
			);
		}

		///// <remarks>via http://www.codeproject.com/Articles/31276/Add-Group-Collapse-Behavior-on-a-Listview-Control</remarks>
		//private void EnableCollapsibleGroups(ListView listView)
		//{
		//    for (int i = 0; i <= listView.Groups.Count; i++)
		//    {
		//        var group = new NativeMethods.LVGROUP();
		//        group.cbSize = Marshal.SizeOf(group);
		//        group.state = (int)NativeMethods.GroupState.COLLAPSIBLE; // LVGS_COLLAPSIBLE 
		//        group.mask = 4; // LVGF_STATE
		//        group.iGroupId = i;
		//        IntPtr ip = IntPtr.Zero;
		//        try
		//        {
		//            ip = Marshal.AllocHGlobal(group.cbSize);
		//            Marshal.StructureToPtr(group, ip, true);
		//            NativeMethods.SendMessage(listView.Handle, 0x1000 + 147, i, ip); // #define LVM_SETGROUPINFO(LVM_FIRST + 147)
		//        }
		//        finally
		//        {
		//            if (ip != IntPtr.Zero) Marshal.FreeHGlobal(ip);
		//        }
		//    }
		//}

		//private static class NativeMethods
		//{
		//    [StructLayout(LayoutKind.Sequential)]
		//    public struct LVGROUP
		//    {
		//        public int cbSize;
		//        public int mask;
		//        [MarshalAs(UnmanagedType.LPTStr)]
		//        public string pszHeader;
		//        public int cchHeader;
		//        [MarshalAs(UnmanagedType.LPTStr)]
		//        public string pszFooter;
		//        public int cchFooter;
		//        public int iGroupId;
		//        public int stateMask;
		//        public int state;
		//        public int uAlign;
		//    }

		//    public enum GroupState
		//    {
		//        COLLAPSIBLE = 8,
		//        COLLAPSED = 1,
		//        EXPANDED = 0
		//    }

		//    [DllImport("user32.dll")]
		//    public static extern int SendMessage(IntPtr window, int message, int wParam, IntPtr lParam);
		//}
	}
}

//using System;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;

//// ReSharper disable InconsistentNaming

//namespace RunNonElevated.Interop
//{
//    //[Guid("00000114-0000-0000-C000-000000000046")]
//    //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
//    //[ComImport]
//    //public interface IOleWindow
//    //{
//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int GetWindow([In, Out] ref int phwnd);

//    //    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    void ContextSensitiveHelp([In] int fEnterMode);
//    //}

//    //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
//    //[Guid("000214E3-0000-0000-C000-000000000046")]
//    //[ComImport]
//    //public interface IShellView : IOleWindow
//    //{
//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int GetWindow([In, Out] ref int phwnd);

//    //    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    void ContextSensitiveHelp([In] int fEnterMode);

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int TranslateAccelerator([In] ref System.Windows.Forms.Message msg);

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int EnableModeless([In] int fEnable);

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int UIActivate([In] int uState);

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int Refresh();

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int CreateViewWindow([MarshalAs(UnmanagedType.Interface), In] IShellView lpPrevView, [In] ref FOLDERSETTINGS lpfs, [In] ref int psb, [In] ref int prcView, [In, Out] ref int phwnd);

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int DestroyViewWindow();

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int GetCurrentInfo([In, Out] ref FOLDERSETTINGS lpfs);

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int AddPropertySheetPages([In] int dwReserved, [In] int lpfn, [In] int lParam);

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int SaveViewState();

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int SelectItem([In] int pidlItem, [In] int uFlags);

//    //    [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
//    //    int GetItemObject([In] int uItem, [In] ref Guid riid, [In, Out] IntPtr ppv);
//    //}

///*
//    [ComImport]
//    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
//    [Guid("000214E2-0000-0000-C000-000000000046")]
//    internal interface IShellBrowser
//    {
//        void GetWindow(out IntPtr phwnd);
//        void ContextSensitiveHelp(bool fEnterMode);

//        void InsertMenusSB(IntPtr IntPtrShared, IntPtr lpMenuWidths);
//        void SetMenuSB(IntPtr IntPtrShared, IntPtr holemenuRes, IntPtr IntPtrActiveObject);
//        void RemoveMenusSB(IntPtr IntPtrShared);
//        void SetStatusTextSB(IntPtr pszStatusText);
//        void EnableModelessSB(bool fEnable);
//        void TranslateAcceleratorSB(IntPtr pmsg, UInt16 wID);

//        void BrowseObject(IntPtr pidl, UInt32 wFlags);
//        void GetViewStateStream(UInt32 grfMode, IntPtr ppStrm);
//        void GetControlWindow(UInt32 id, out IntPtr lpIntPtr);
//        void SendControlMsg(UInt32 id, UInt32 uMsg, UInt32 wParam, UInt32 lParam, IntPtr pret);
//        void QueryActiveShellView(ref IShellView ppshv);
//        void OnViewWindowActive(IShellView ppshv);
//        void SetToolbarItems(IntPtr lpButtons, UInt32 nButtons, UInt32 uFlags);
//    }

//    [ComImport, Guid("000214E3-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
//    internal interface IShellView
//    {
//        #region IOleWindow members

//        /// <summary>
//        /// Get the handle of the shellview implemented
//        /// </summary>
//        void GetWindow(out IntPtr windowHandle);

//        /// <summary>
//        /// ContextSensitiveHelp
//        /// </summary>
//        void ContextSensitiveHelp(bool fEnterMode);

//        #endregion

//        /// <summary>
//        /// Translates accelerator key strokes when a namespace extension's view has the focus
//        /// </summary>
//        [PreserveSig]
//        long TranslateAcceleratorA(IntPtr message);

//        /// <summary>
//        /// Enables or disables modeless dialog boxes. This method is not currently implemented
//        /// </summary>
//        void EnableModeless(bool enable);

//        /// <summary>
//        /// Called when the activation state of the view window is changed by an event that is not caused by the Shell view itself. For example, if the TAB key is pressed when the tree has the focus, the view should be given the focus
//        /// </summary>
//        void UIActivate([MarshalAs(UnmanagedType.U4)] SVUIA_STATUS activtionState);

//        /// <summary>
//        /// Refreshes the view's contents in response to user input
//        ///  Explorer calls this method when the F5 key is pressed on an already open view
//        /// </summary>
//        void Refresh();

//        /// <summary>
//        /// Creates a view window. This can be either the right pane of  Explorer or the client window of a folder window.
//        /// </summary>
//        void CreateViewWindow(
//            [In, MarshalAs(UnmanagedType.Interface)] IShellView previousShellView,
//            [In] ref FolderSettings folderSetting,
//            [In] IShellBrowser shellBrowser,
//            [In] ref RECT bounds,
//            [In, Out] ref IntPtr handleOfCreatedWindow
//        );

//        /// <summary>
//        /// Destroys the view window
//        /// </summary>
//        void DestroyViewWindow();

//        /// <summary>
//        /// Retrieves the current folder settings
//        /// </summary>
//        void GetCurrentInfo(ref FolderSettings pfs);

//        /// <summary>
//        /// Allows the view to add pages to the Options property sheet from the View menu
//        /// </summary>
//        void AddPropertySheetPages(
//            [In, MarshalAs(UnmanagedType.U4)] uint reserved,
//            [In]ref IntPtr functionPointer, // LPFNADDPROPSHEETPAGE
//            [In] IntPtr lparam
//        );

//        /// <summary>
//        /// Saves the Shell's view settings so the current state can be restored during a subsequent browsing session
//        /// </summary>
//        void SaveViewState();

//        /// <summary>
//        /// Changes the selection state of one or more items within the Shell view window
//        /// </summary>
//        void SelectItem(IntPtr pidlItem, [MarshalAs(UnmanagedType.U4)] SVSIF flags);

//        /// <summary>
//        /// Retrieves an interface that refers to data presented in the view
//        /// </summary>
//        [PreserveSig]
//        long GetItemObject([MarshalAs(UnmanagedType.U4)] SVGIO AspectOfView, ref Guid riid, ref IntPtr ppv);
//    }

//    internal struct FolderSettings
//    {
//        public FOLDERVIEWMODE ViewMode;
//        public FOLDERFLAGS Flags;
//    }

//    [StructLayout(LayoutKind.Sequential)]
//    internal struct RECT
//    {
//        public int Left, Top, Right, Bottom;
//    }

//    internal enum FOLDERVIEWMODE
//    {
//        FVM_AUTO = -1,    //The view should determine the best option.
//        FVM_FIRST = 1,    //The minimum constant value in FOLDERVIEWMODE, for validation purposes.
//        FVM_ICON = 1,     //The view should display medium-size icons.
//        FVM_SMALLICON = 2,    //The view should display small icons.
//        FVM_LIST = 3,     //Object names are displayed in a list view.
//        FVM_DETAILS = 4,      //Object names and other selected information, such as the size or date last updated, are shown.
//        FVM_THUMBNAIL = 5,    //The view should display thumbnail icons.
//        FVM_TILE = 6,       //The view should display large icons.
//        FVM_THUMBSTRIP = 7, //The view should display icons in a filmstrip format.
//        FVM_CONTENT = 8,    //Windows 7 and later. The view should display content mode.
//        FVM_LAST = 8       //The maximum constant value in FOLDERVIEWMODE, for validation purposes.
//    }

//    enum FOLDERFLAGS : uint
//    {
//        FWF_NONE = 0x00000000,
//        FWF_AUTOARRANGE = 0x00000001,
//        FWF_ABBREVIATEDNAMES = 0x00000002,
//        FWF_SNAPTOGRID = 0x00000004,
//        FWF_OWNERDATA = 0x00000008,
//        FWF_BESTFITWINDOW = 0x00000010,
//        FWF_DESKTOP = 0x00000020,
//        FWF_SINGLESEL = 0x00000040,
//        FWF_NOSUBFOLDERS = 0x00000080,
//        FWF_TRANSPARENT = 0x00000100,
//        FWF_NOCLIENTEDGE = 0x00000200,
//        FWF_NOSCROLL = 0x00000400,
//        FWF_ALIGNLEFT = 0x00000800,
//        FWF_NOICONS = 0x00001000,
//        FWF_SHOWSELALWAYS = 0x00002000,
//        FWF_NOVISIBLE = 0x00004000,
//        FWF_SINGLECLICKACTIVATE = 0x00008000,
//        FWF_NOWEBVIEW = 0x00010000,
//        FWF_HIDEFILENAMES = 0x00020000,
//        FWF_CHECKSELECT = 0x00040000,
//        FWF_NOENUMREFRESH = 0x00080000,
//        FWF_NOGROUPING = 0x00100000,
//        FWF_FULLROWSELECT = 0x00200000,
//        FWF_NOFILTERS = 0x00400000,
//        FWF_NOCOLUMNHEADER = 0x00800000,
//        FWF_NOHEADERINALLVIEWS = 0x01000000,
//        FWF_EXTENDEDTILES = 0x02000000,
//        FWF_TRICHECKSELECT = 0x04000000,
//        FWF_AUTOCHECKSELECT = 0x08000000,
//        FWF_NOBROWSERVIEWSTATE = 0x10000000,
//        FWF_SUBSETGROUPS = 0x20000000,
//        FWF_USESEARCHFOLDER = 0x40000000,
//        FWF_ALLOWRTLREADING = 0x80000000
//    }

//    enum SVGIO : uint
//    { 
//        SVGIO_BACKGROUND      = 0x00000000,
//        SVGIO_SELECTION       = 0x00000001,
//        SVGIO_ALLVIEW         = 0x00000002,
//        SVGIO_CHECKED         = 0x00000003,
//        SVGIO_TYPE_MASK       = 0x0000000F,
//        SVGIO_FLAG_VIEWORDER  = 0x80000000
//    }

//    enum SVSIF : uint
//    { 
//        SVSI_DESELECT        = 0x00000000,
//        SVSI_SELECT          = 0x00000001,
//        SVSI_EDIT            = 0x00000003,
//        SVSI_DESELECTOTHERS  = 0x00000004,
//        SVSI_ENSUREVISIBLE   = 0x00000008,
//        SVSI_FOCUSED         = 0x00000010,
//        SVSI_TRANSLATEPT     = 0x00000020,
//        SVSI_SELECTIONMARK   = 0x00000040,
//        SVSI_POSITIONITEM    = 0x00000080,
//        SVSI_CHECK           = 0x00000100,
//        SVSI_CHECK2          = 0x00000200,
//        SVSI_KEYBOARDSELECT  = 0x00000401,
//        SVSI_NOTAKEFOCUS     = 0x40000000
//    }

//    enum SVUIA_STATUS : uint
//    {
//        /// <summary>
//        /// Windows Explorer is about to destroy the Shell view window. The Shell view should remove all extended user interfaces. These are typically merged menus and merged modeless pop-up windows.
//        /// </summary>
//        SVUIA_DEACTIVATE = 0,

//        /// <summary>
//        /// The Shell view is losing the input focus, or it has just been created without the input focus. The Shell view should be able to set menu items appropriate for the nonfocused state. This means no selection-specific items should be added.
//        /// </summary>
//        SVUIA_ACTIVATE_NOFOCUS = 1,

//        /// <summary>
//        /// Windows Explorer has just created the view window with the input focus. This means the Shell view should be able to set menu items appropriate for the focused state.
//        /// </summary>
//        SVUIA_ACTIVATE_FOCUS = 2,

//        /// <summary>
//        /// The Shell view is active without focus. This flag is only used when UIActivate is exposed through the IShellView2 interface.
//        /// </summary>
//        SVUIA_INPLACEACTIVATE = 3
//    }
// */
//}

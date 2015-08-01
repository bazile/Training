using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RunNonElevated
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            switch (GetProcessElevationType())
            {
                case ProcessElevationType.Undefined:
                case ProcessElevationType.Default:
                    panelAdmin.Visible = false;
                    panelNonAdmin.Visible = true;
                    break;

                case ProcessElevationType.Limited:
                    panelAdmin.Visible = false;
                    panelAdminNonElevated.Visible = true;
                    break;
            }
        }

        //bool IsRunningAsLocalAdmin()
        //{
        //    WindowsIdentity cur = WindowsIdentity.GetCurrent();
        //    foreach (IdentityReference role in cur.Groups)
        //    {
        //        if (role.IsValidTargetType(typeof(SecurityIdentifier)))
        //        {
        //            SecurityIdentifier sid = (SecurityIdentifier)role.Translate(typeof (SecurityIdentifier));
        //            if (sid.IsWellKnown(WellKnownSidType.AccountAdministratorSid) || sid.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid))
        //            {
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}

        //private static bool IsAdministratorNoCache(string username)
        //{
        //    PrincipalContext ctx;
        //    try
        //    {
        //        Domain.GetComputerDomain();
        //        try
        //        {
        //            ctx = new PrincipalContext(ContextType.Domain);
        //        }
        //        catch (PrincipalServerDownException)
        //        {
        //            // can't access domain, check local machine instead 
        //            ctx = new PrincipalContext(ContextType.Machine);
        //        }
        //    }
        //    catch (ActiveDirectoryObjectNotFoundException)
        //    {
        //        // not in a domain
        //        ctx = new PrincipalContext(ContextType.Machine);
        //    }
        //    var up = UserPrincipal.FindByIdentity(ctx, username);
        //    if (up != null)
        //    {
        //        PrincipalSearchResult<Principal> authGroups = up.GetAuthorizationGroups();
        //        return authGroups.Any(principal =>
        //                              principal.Sid.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid) ||
        //                              principal.Sid.IsWellKnown(WellKnownSidType.AccountDomainAdminsSid) ||
        //                              principal.Sid.IsWellKnown(WellKnownSidType.AccountAdministratorSid) ||
        //                              principal.Sid.IsWellKnown(WellKnownSidType.AccountEnterpriseAdminsSid));
        //    }
        //    return false;
        //}

        //static bool IsElevatedProcess()
        //{
        //    return GetProcessElevationType() == ProcessElevationType.Full;
        //}

        public enum ProcessElevationType
        {
            Undefined,
            Default,
            Full,
            Limited
        }

        static ProcessElevationType GetProcessElevationType()
        {
            ProcessElevationType elevationType = ProcessElevationType.Undefined;
            IntPtr hProcessToken;
            if (NativeMethods.OpenProcessToken(NativeMethods.GetCurrentProcess(), NativeMethods.TOKEN_READ, out hProcessToken))
            {
                // You can then look at either or both the TokenElevationType or TokenElevation token property:

                //int infoLen;
                //NativeMethods.TOKEN_ELEVATION_TYPE elevationType;
                //NativeMethods.GetTokenInformation(hToken, TokenElevationType, &elevationType, sizeof (elevationType),
                //    &infoLen);

                //NativeMethods.TOKEN_ELEVATION elevation;
                //object elevationType = NativeMethods.TOKEN_ELEVATION_TYPE.TokenElevationTypeDefault;
                //IntPtr tokenInformation = Marshal.StructureToPtr();
                //GCHandle h = GCHandle.Alloc(elevationType, GCHandleType.Pinned);

                IntPtr infoPtr = Marshal.AllocHGlobal(sizeof(NativeMethods.TokenElevationType));
                try
                {
                    int returnLength;
                    if (NativeMethods.GetTokenInformation(
                        hProcessToken,
                        NativeMethods.TOKEN_INFORMATION_CLASS.TokenElevationType,
                        infoPtr,
                        sizeof (NativeMethods.TokenElevationType),
                        out returnLength
                        ))
                    {
                        NativeMethods.TokenElevationType tokenElevationType = (NativeMethods.TokenElevationType)Marshal.ReadInt32(infoPtr);
                        switch (tokenElevationType)
                        {
                            case NativeMethods.TokenElevationType.Default:
                                elevationType = ProcessElevationType.Default;
                                break;
                            case NativeMethods.TokenElevationType.Full:
                                elevationType = ProcessElevationType.Full;
                                break;
                            case NativeMethods.TokenElevationType.Limited:
                                elevationType = ProcessElevationType.Limited;
                                break;
                        }
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(infoPtr);
                }

                NativeMethods.CloseHandle(hProcessToken);
            }

            return elevationType;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //bool rv = IsElevatedProcess();
        //    //MessageBox.Show(rv.ToString());
        //    //bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

        //    //NativeMethods.ShellExecuteFromExplorer("calc.exe", null, null, null);
        //    //Guid IID_IShellView = Guid.Parse("000214E3-0000-0000-C000-000000000046");
        //    //Type comType = Type.GetTypeFromCLSID(IID_IShellView);
        //    //var instance = Activator.CreateInstance(comType);

        //    //Guid IID_IShellFolder2 = Guid.Parse("93F2F68C-1D1B-11d3-A30E-00C04F79ABD1");
        //    //Guid CLSID_ShellDesktop = Guid.Parse("00021400-0000-0000-C000-000000000046");
        //    //object x = RuntimeEnvironment.GetRuntimeInterfaceAsObject(CLSID_ShellDesktop, IID_IShellFolder2);
        //    //Marshal.ReleaseComObject(x);

        //    //System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile
        //    //dynamic shellView = new IShellWindows();
        //    //shellView.Release();
        //}

        private void btnRun_Click(object sender, EventArgs e)
        {
            NativeMethods.ShellExecuteFromExplorer(tbFileName.Text, tbArguments.Text, null, null, NativeMethods.WindowShowStyle.ShowDefault);
        }

        private void btnRunSelf_Click(object sender, EventArgs e)
        {
            NativeMethods.ShellExecuteFromExplorer(Application.ExecutablePath, null, null, null, NativeMethods.WindowShowStyle.ShowDefault);
        }

        //void ShellExecuteFromExplorer(string fileName, string arguments)
        ////PCWSTR pszDirectory  = nullptr,
        ////PCWSTR pszOperation  = nullptr,
        ////int nShowCmd         = SW_SHOWNORMAL)
        //{
        //    CComPtr<IShellFolderViewDual> spFolderView;
        //    GetDesktopAutomationObject(IID_PPV_ARGS(&spFolderView));
        //    CComPtr<IDispatch> spdispShell;
        //    spFolderView->get_Application(&spdispShell);

        //    CComQIPtr<IShellDispatch2>(spdispShell)->ShellExecute(
        //        CComBSTR(pszFile),
        //        CComVariant(pszParameters ? pszParameters : L""),
        //        "", //CComVariant(pszDirectory ? pszDirectory : L""),
        //        "", //CComVariant(pszOperation ? pszOperation : L""),
        //        CComVariant(nShowCmd)
        //    );
        //}

        //void GetDesktopAutomationObject(REFIID riid, void** ppv)
        //{
        //    IShellView spsv;
        //    FindDesktopFolderView(IID_PPV_ARGS(&spsv));
        //    IDispatch spdispView;
        //    spsv.GetItemObject(SVGIO.SVGIO_BACKGROUND, IID_PPV_ARGS(&spdispView));
        //    spdispView->QueryInterface(riid, ppv);
        //}

        //void FindDesktopFolderView(REFIID riid, void **ppv)
        //{
        //    IShellWindows spShellWindows;
        //    spShellWindows.CoCreateInstance(CLSID_ShellWindows);

        //    CComVariant vtLoc(CSIDL_DESKTOP);
        //    CComVariant vtEmpty;
        //    long lhwnd;
        //    CComPtr<IDispatch> spdisp;
        //    spShellWindows->FindWindowSW(
        //    &vtLoc, &vtEmpty,
        //    SWC_DESKTOP, &lhwnd, SWFO_NEEDDISPATCH, &spdisp);

        //    CComPtr<IShellBrowser> spBrowser;
        //    CComQIPtr<IServiceProvider>(spdisp)->
        //    QueryService(SID_STopLevelBrowser,
        //    IID_PPV_ARGS(&spBrowser));

        //    CComPtr<IShellView> spView;
        //    spBrowser->QueryActiveShellView(&spView);

        //    spView->QueryInterface(riid, ppv);
        //}
    }
}

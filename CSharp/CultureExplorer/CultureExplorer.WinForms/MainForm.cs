using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainingCenter.Globalization;

namespace CultureExplorer.WinForms
{
    public partial class MainForm : Form
    {
        enum GroupByMode
        {
            Language, Country, Calendar, AnsiCodePage, EbcdicCodePage, MacCodePage, OemCodePage
        }

        #region Коды стран ISO 3166-1 alpha-2
        static readonly IReadOnlyDictionary<string, string> __isoCodeToName = new Dictionary<string, string>()
        {
            {"AD", "Andorra"},
            {"AE", "United Arab Emirates"},
            {"AF", "Afghanistan"},
            {"AG", "Antigua and Barbuda"},
            {"AI", "Anguilla"},
            {"AL", "Albania"},
            {"AM", "Armenia"},
            {"AO", "Angola"},
            {"AQ", "Antarctica"},
            {"AR", "Argentina"},
            {"AS", "American Samoa"},
            {"AT", "Austria"},
            {"AU", "Australia"},
            {"AW", "Aruba"},
            {"AX", "Åland Islands"},
            {"AZ", "Azerbaijan"},
            {"BA", "Bosnia and Herzegovina"},
            {"BB", "Barbados"},
            {"BD", "Bangladesh"},
            {"BE", "Belgium"},
            {"BF", "Burkina Faso"},
            {"BG", "Bulgaria"},
            {"BH", "Bahrain"},
            {"BI", "Burundi"},
            {"BJ", "Benin"},
            {"BL", "Saint Barthélemy"},
            {"BM", "Bermuda"},
            {"BN", "Brunei Darussalam"},
            {"BO", "Bolivia, Plurinational State of"},
            {"BQ", "Bonaire, Sint Eustatius and Saba"},
            {"BR", "Brazil"},
            {"BS", "Bahamas"},
            {"BT", "Bhutan"},
            {"BV", "Bouvet Island"},
            {"BW", "Botswana"},
            {"BY", "Belarus"},
            {"BZ", "Belize"},
            {"CA", "Canada"},
            {"CC", "Cocos (Keeling) Islands"},
            {"CD", "Congo, the Democratic Republic of the"},
            {"CF", "Central African Republic"},
            {"CG", "Congo"},
            {"CH", "Switzerland"},
            {"CI", "Côte d'Ivoire"},
            {"CK", "Cook Islands"},
            {"CL", "Chile"},
            {"CM", "Cameroon"},
            {"CN", "China"},
            {"CO", "Colombia"},
            {"CR", "Costa Rica"},
            {"CU", "Cuba"},
            {"CV", "Cabo Verde"},
            {"CW", "Curaçao"},
            {"CX", "Christmas Island"},
            {"CY", "Cyprus"},
            {"CZ", "Czech Republic"},
            {"DE", "Germany"},
            {"DJ", "Djibouti"},
            {"DK", "Denmark"},
            {"DM", "Dominica"},
            {"DO", "Dominican Republic"},
            {"DZ", "Algeria"},
            {"EC", "Ecuador"},
            {"EE", "Estonia"},
            {"EG", "Egypt"},
            {"EH", "Western Sahara"},
            {"ER", "Eritrea"},
            {"ES", "Spain"},
            {"ET", "Ethiopia"},
            {"FI", "Finland"},
            {"FJ", "Fiji"},
            {"FK", "Falkland Islands (Malvinas)"},
            {"FM", "Micronesia, Federated States of"},
            {"FO", "Faroe Islands"},
            {"FR", "France"},
            {"GA", "Gabon"},
            {"GB", "United Kingdom of Great Britain and Northern Ireland"},
            {"GD", "Grenada"},
            {"GE", "Georgia"},
            {"GF", "French Guiana"},
            {"GG", "Guernsey"},
            {"GH", "Ghana"},
            {"GI", "Gibraltar"},
            {"GL", "Greenland"},
            {"GM", "Gambia"},
            {"GN", "Guinea"},
            {"GP", "Guadeloupe"},
            {"GQ", "Equatorial Guinea"},
            {"GR", "Greece"},
            {"GS", "South Georgia and the South Sandwich Islands"},
            {"GT", "Guatemala"},
            {"GU", "Guam"},
            {"GW", "Guinea-Bissau"},
            {"GY", "Guyana"},
            {"HK", "Hong Kong"},
            {"HM", "Heard Island and McDonald Islands"},
            {"HN", "Honduras"},
            {"HR", "Croatia"},
            {"HT", "Haiti"},
            {"HU", "Hungary"},
            {"ID", "Indonesia"},
            {"IE", "Ireland"},
            {"IL", "Israel"},
            {"IM", "Isle of Man"},
            {"IN", "India"},
            {"IO", "British Indian Ocean Territory"},
            {"IQ", "Iraq"},
            {"IR", "Iran, Islamic Republic of"},
            {"IS", "Iceland"},
            {"IT", "Italy"},
            {"JE", "Jersey"},
            {"JM", "Jamaica"},
            {"JO", "Jordan"},
            {"JP", "Japan"},
            {"KE", "Kenya"},
            {"KG", "Kyrgyzstan"},
            {"KH", "Cambodia"},
            {"KI", "Kiribati"},
            {"KM", "Comoros"},
            {"KN", "Saint Kitts and Nevis"},
            {"KP", "Korea, Democratic People's Republic of"},
            {"KR", "Korea, Republic of"},
            {"KW", "Kuwait"},
            {"KY", "Cayman Islands"},
            {"KZ", "Kazakhstan"},
            {"LA", "Lao People's Democratic Republic"},
            {"LB", "Lebanon"},
            {"LC", "Saint Lucia"},
            {"LI", "Liechtenstein"},
            {"LK", "Sri Lanka"},
            {"LR", "Liberia"},
            {"LS", "Lesotho"},
            {"LT", "Lithuania"},
            {"LU", "Luxembourg"},
            {"LV", "Latvia"},
            {"LY", "Libya"},
            {"MA", "Morocco"},
            {"MC", "Monaco"},
            {"MD", "Moldova, Republic of"},
            {"ME", "Montenegro"},
            {"MF", "Saint Martin (French part)"},
            {"MG", "Madagascar"},
            {"MH", "Marshall Islands"},
            {"MK", "Macedonia, the former Yugoslav Republic of"},
            {"ML", "Mali"},
            {"MM", "Myanmar"},
            {"MN", "Mongolia"},
            {"MO", "Macao"},
            {"MP", "Northern Mariana Islands"},
            {"MQ", "Martinique"},
            {"MR", "Mauritania"},
            {"MS", "Montserrat"},
            {"MT", "Malta"},
            {"MU", "Mauritius"},
            {"MV", "Maldives"},
            {"MW", "Malawi"},
            {"MX", "Mexico"},
            {"MY", "Malaysia"},
            {"MZ", "Mozambique"},
            {"NA", "Namibia"},
            {"NC", "New Caledonia"},
            {"NE", "Niger"},
            {"NF", "Norfolk Island"},
            {"NG", "Nigeria"},
            {"NI", "Nicaragua"},
            {"NL", "Netherlands"},
            {"NO", "Norway"},
            {"NP", "Nepal"},
            {"NR", "Nauru"},
            {"NU", "Niue"},
            {"NZ", "New Zealand"},
            {"OM", "Oman"},
            {"PA", "Panama"},
            {"PE", "Peru"},
            {"PF", "French Polynesia"},
            {"PG", "Papua New Guinea"},
            {"PH", "Philippines"},
            {"PK", "Pakistan"},
            {"PL", "Poland"},
            {"PM", "Saint Pierre and Miquelon"},
            {"PN", "Pitcairn"},
            {"PR", "Puerto Rico"},
            {"PS", "Palestine, State of"},
            {"PT", "Portugal"},
            {"PW", "Palau"},
            {"PY", "Paraguay"},
            {"QA", "Qatar"},
            {"RE", "Réunion"},
            {"RO", "Romania"},
            {"RS", "Serbia"},
            {"RU", "Russian Federation"},
            {"RW", "Rwanda"},
            {"SA", "Saudi Arabia"},
            {"SB", "Solomon Islands"},
            {"SC", "Seychelles"},
            {"SD", "Sudan"},
            {"SE", "Sweden"},
            {"SG", "Singapore"},
            {"SH", "Saint Helena, Ascension and Tristan da Cunha"},
            {"SI", "Slovenia"},
            {"SJ", "Svalbard and Jan Mayen"},
            {"SK", "Slovakia"},
            {"SL", "Sierra Leone"},
            {"SM", "San Marino"},
            {"SN", "Senegal"},
            {"SO", "Somalia"},
            {"SR", "Suriname"},
            {"SS", "South Sudan"},
            {"ST", "Sao Tome and Principe"},
            {"SV", "El Salvador"},
            {"SX", "Sint Maarten (Dutch part)"},
            {"SY", "Syrian Arab Republic"},
            {"SZ", "Swaziland"},
            {"TC", "Turks and Caicos Islands"},
            {"TD", "Chad"},
            {"TF", "French Southern Territories"},
            {"TG", "Togo"},
            {"TH", "Thailand"},
            {"TJ", "Tajikistan"},
            {"TK", "Tokelau"},
            {"TL", "Timor-Leste"},
            {"TM", "Turkmenistan"},
            {"TN", "Tunisia"},
            {"TO", "Tonga"},
            {"TR", "Turkey"},
            {"TT", "Trinidad and Tobago"},
            {"TV", "Tuvalu"},
            {"TW", "Taiwan, Province of China"},
            {"TZ", "Tanzania, United Republic of"},
            {"UA", "Ukraine"},
            {"UG", "Uganda"},
            {"UM", "United States Minor Outlying Islands"},
            {"US", "United States of America"},
            {"UY", "Uruguay"},
            {"UZ", "Uzbekistan"},
            {"VA", "Holy See"},
            {"VC", "Saint Vincent and the Grenadines"},
            {"VE", "Venezuela, Bolivarian Republic of"},
            {"VG", "Virgin Islands, British"},
            {"VI", "Virgin Islands, U.S."},
            {"VN", "Viet Nam"},
            {"VU", "Vanuatu"},
            {"WF", "Wallis and Futuna"},
            {"WS", "Samoa"},
            {"YE", "Yemen"},
            {"YT", "Mayotte"},
            {"ZA", "South Africa"},
            {"ZM", "Zambia"},
            {"ZW", "Zimbabwe"}
        };
        #endregion

        GroupByMode _groupByMode;
        CultureTypes _currentCultureType;
        ToolStripMenuItem[] _cultureTypeMenuItems;
        ToolStripMenuItem[] _groupByMenuItems;

        public MainForm()
        {
            TypeDescriptor.AddProvider(new CultureExplorerTypeDescriptionProvider<Calendar,CalendarTypeDescriptor>(), typeof(Calendar));
            TypeDescriptor.AddProvider(new CultureExplorerTypeDescriptionProvider<CompareInfo,CompareInfoTypeDescriptor>(), typeof(CompareInfo));
            TypeDescriptor.AddProvider(new CultureExplorerTypeDescriptionProvider<DateTimeFormatInfo,DateTimeFormatInfoTypeDescriptor>(), typeof(DateTimeFormatInfo));
            TypeDescriptor.AddProvider(new CultureExplorerTypeDescriptionProvider<NumberFormatInfo,NumberFormatInfoTypeDescriptor>(), typeof(NumberFormatInfo));
            TypeDescriptor.AddProvider(new CultureExplorerTypeDescriptionProvider<TextInfo,TextInfoTypeDescriptor>(), typeof(TextInfo));

            InitializeComponent();

            _groupByMode = menuItemGroupCountry.Checked ? GroupByMode.Country : GroupByMode.Language;

            InitViewMenu();
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            DisplayCultures();
        }

        #region DisplayCultures

        private void DisplayCultures()
        {
            treeViewCultures.BeginUpdate();
            try
            {
                treeViewCultures.Nodes.Clear();

                CultureInfo[] cultures = CultureInfo.GetCultures(_currentCultureType);
                statusLabel.Text = String.Format("Number of cultures: {0}", cultures.Length);

                switch (_groupByMode)
                {
                    case GroupByMode.Language:
                        DisplayCulturesByLanguage(cultures);
                        break;
                    case GroupByMode.Country:
                        DisplayCulturesByCountry(cultures);
                        break;
                    case GroupByMode.Calendar:
                        DisplayCulturesByCalendar(cultures);
                        break;
                    case GroupByMode.AnsiCodePage:
                    case GroupByMode.EbcdicCodePage:
                    case GroupByMode.MacCodePage:
                    case GroupByMode.OemCodePage:
                        DisplayCulturesByEncoding(cultures, _groupByMode);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            finally
            {
                treeViewCultures.EndUpdate();
            }
        }

        void DisplayCulturesByLanguage(CultureInfo[] cultures)
        {
            Array.Sort(cultures, new CultureNameComparer());

            TreeNode parentNode = null;
            foreach (CultureInfo ci in cultures)
            {
                var node = CreateTreeNode(ci);
                LanguageInfo langInfo = ci.GetLanguageInfo();
                if (langInfo.Name.Length > 0)
                {
                    node.Text += " (" + langInfo.Name + ")";
                }

                if (ci.Name.Contains("-"))
                {
                    if (parentNode != null)
                        parentNode.Nodes.Add(node);
                    else
                        treeViewCultures.Nodes.Add(node);
                }
                else
                {
                    parentNode = node;
                    treeViewCultures.Nodes.Add(node);
                }
            }
        }

        void DisplayCulturesByCountry(CultureInfo[] cultures)
        {
            Array.Sort(cultures, new CultureNameComparer());

            var calToNode = new Dictionary<string, TreeNode>();
            foreach (CultureInfo ci in cultures)
            {
                string[] nameParts = ci.Name.Split('-');
                string countryName="???", countryCode = "???";
                if (nameParts.Length > 1)
                {
                    countryCode = nameParts[nameParts.Length - 1];
                    if (__isoCodeToName.ContainsKey(countryCode))
                    {
                        countryName = __isoCodeToName[countryCode] + " (" + countryCode + ")";
                    }
                }

                var cultureNode = CreateTreeNode(ci);
                TreeNode parentNode;
                if (!calToNode.TryGetValue(countryName, out parentNode))
                {
                    parentNode = new TreeNode { Text = countryName };
                    calToNode.Add(countryName, parentNode);
                }
                parentNode.Nodes.Add(cultureNode);
            }

            foreach (string countryCode in calToNode.Keys.OrderBy(name => name))
            {
                treeViewCultures.Nodes.Add(calToNode[countryCode]);
            }
        }

        void DisplayCulturesByCalendar(CultureInfo[] cultures)
        {
            Array.Sort(cultures, new CultureNameComparer());

            var calToNode = new Dictionary<string, TreeNode>();
            foreach (CultureInfo ci in cultures)
            {
                string calendarName = ci.Calendar.GetType().Name;
                var treeNode = CreateTreeNode(ci);
                TreeNode parentNode;
                if (!calToNode.TryGetValue(calendarName, out parentNode))
                {
                    parentNode = new TreeNode { Text = calendarName };
                    calToNode.Add(calendarName, parentNode);
                }
                parentNode.Nodes.Add(treeNode);

                foreach (var calendar in ci.OptionalCalendars)
                {
                    calendarName = calendar.GetType().Name;
                    treeNode = CreateTreeNode(ci);
                    if (!calToNode.TryGetValue(calendarName, out parentNode))
                    {
                        parentNode = new TreeNode { Text = calendarName };
                        calToNode.Add(calendarName, parentNode);
                    }

                    if (parentNode.Nodes.Find(treeNode.Name, true).Length == 0)
                    {
                        parentNode.Nodes.Add(treeNode);
                    }
                }
            }

            foreach (string calendarName in calToNode.Keys.OrderBy(name => name))
            {
                treeViewCultures.Nodes.Add(calToNode[calendarName]);
            }
        }

        void DisplayCulturesByEncoding(CultureInfo[] cultures, GroupByMode groupMode)
        {
            var groups = cultures.GroupBy(c => groupMode == GroupByMode.AnsiCodePage ? c.TextInfo.ANSICodePage : c.TextInfo.OEMCodePage).OrderBy(g => g.Key);
            foreach (IGrouping<int, CultureInfo> g in groups)
            {
                TreeNode codePageNode;
                if (g.Key == 0)
                {
                    codePageNode = new TreeNode("0");
                }
                else
                {
                    Encoding encoding = null;
                    try { encoding = Encoding.GetEncoding(g.Key); }
                    catch { }

                    if (encoding == null)
                    {
                        codePageNode = new TreeNode(g.Key.ToString());
                    }
                    else
                    {
                        codePageNode = new TreeNode(string.Format("{0}: {1}", g.Key, encoding.EncodingName));
                        codePageNode.Tag = encoding;
                    }
                }
                treeViewCultures.Nodes.Add(codePageNode);

                foreach (CultureInfo ci in g)
                {
                    codePageNode.Nodes.Add(CreateTreeNode(ci));
                }
            }
        }

        #endregion

        #region Event Handlers

        private void OnCultureTypeMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem menuItem in _cultureTypeMenuItems)
            {
                menuItem.Checked = false;
                menuItem.CheckState = CheckState.Unchecked;
            }

            var senderMenuItem = (ToolStripMenuItem)sender;
            senderMenuItem.Checked = true;
            senderMenuItem.CheckState = CheckState.Checked;

            _currentCultureType = (CultureTypes)senderMenuItem.Tag;
            DisplayCultures();
        }

        void OnGroupByMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            if (menuItem.Checked) return;

            menuItem.Checked = true;
            foreach (var otherItem in _groupByMenuItems)
            {
                if (otherItem != menuItem) otherItem.Checked = false;
            }

            _groupByMode = (GroupByMode)menuItem.Tag;

            DisplayCultures();
        }

        private void OnCulturesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            propertyGridCulture.SelectedObject = e.Node.Tag;
        }

        private void OnExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void InitViewMenu()
        {
            // Группировки
            _groupByMenuItems = new[] {
                    menuItemGroupLang,
                    menuItemGroupCountry,
                    menuItemGroupCalendar,

                    menuItemGroupAnsi,
                    menuItemGroupEbcdic,
                    menuItemGroupMac,
                    menuItemGroupOem
            };
            menuItemGroupLang.Tag = GroupByMode.Language;
            menuItemGroupCountry.Tag = GroupByMode.Country;
            menuItemGroupCalendar.Tag = GroupByMode.Calendar;
            menuItemGroupAnsi.Tag = GroupByMode.AnsiCodePage;
            menuItemGroupEbcdic.Tag = GroupByMode.EbcdicCodePage;
            menuItemGroupMac.Tag = GroupByMode.MacCodePage;
            menuItemGroupOem.Tag = GroupByMode.OemCodePage;

            // Типы культур
            List<ToolStripMenuItem> cultureTypeMenuItems = new List<ToolStripMenuItem>();

            cultureTypeMenuItems.Add(AddViewMenuItem("&All cultures"            , true, CultureTypes.AllCultures));
            cultureTypeMenuItems.Add(AddViewMenuItem("&Neutral cultures"        , false, CultureTypes.NeutralCultures));
            cultureTypeMenuItems.Add(AddViewMenuItem("&Specific cultures"       , false, CultureTypes.SpecificCultures));
            cultureTypeMenuItems.Add(AddViewMenuItem("Installed &Win32 cultures", false, CultureTypes.InstalledWin32Cultures));

            _cultureTypeMenuItems = cultureTypeMenuItems.ToArray();
        }

        private ToolStripMenuItem AddViewMenuItem(string text, bool isChecked, CultureTypes cultureType)
        {
            var menuItem = new ToolStripMenuItem {Text = text};
            if (isChecked)
            {
                _currentCultureType = cultureType;
                menuItem.Checked = true;
                menuItem.CheckState = CheckState.Checked;
            }
            menuItem.Tag = cultureType;
            menuItem.Click += OnCultureTypeMenuItem_Click;

            menuItemView.DropDownItems.Add(menuItem);

            return menuItem;
        }

        static TreeNode CreateTreeNode(CultureInfo ci)
        {
            var node = new TreeNode { Text = ci.Name, Tag = ci };
            if (string.IsNullOrEmpty(node.Text))
            {
                node.Text = "<empty>";
            }
            node.Name = node.Text;
            return node;
        }
    }
}

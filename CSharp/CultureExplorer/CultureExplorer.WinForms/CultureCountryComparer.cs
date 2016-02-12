//using System;
//using System.Collections.Generic;
//using System.Globalization;

//namespace CultureExplorer.WinForms
//{
//    class CultureCountryComparer : IComparer<CultureInfo>
//    {
//        public int Compare(CultureInfo x, CultureInfo y)
//        {
//            string[] xparts = x.Name.Split('-');
//            string[] yparts = y.Name.Split('-');

//            if (xparts.Length > 1 && yparts.Length > 1)
//            {
//                //if (xparts.Length == yparts.Length)
//                return string.Compare(xparts[xparts.Length - 1], yparts[yparts.Length - 1], StringComparison.InvariantCultureIgnoreCase);
//            }
//            if (xparts.Length == 1 && yparts.Length == 1)
//                return string.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase);

//            return yparts.Length - xparts.Length;
//        }
//    }
//}

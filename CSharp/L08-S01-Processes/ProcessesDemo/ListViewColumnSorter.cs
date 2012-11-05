﻿using System;
using System.Collections;
using System.Windows.Forms;

namespace ProcessesDemo
{
	/// <summary>
	/// This class is an implementation of the 'IComparer' interface.
	/// </summary>
	public class ListViewColumnSorter : IComparer
	{
		/// <summary>Specifies the column to be sorted</summary>
		private int _columnToSort;

		/// <summary>Specifies the order in which to sort (i.e. 'Ascending').</summary>
		private SortOrder _orderOfSort;

		/// <summary>Case insensitive comparer object</summary>
		private readonly CaseInsensitiveComparer _objectCompare;

		/// <summary>
		/// Class constructor.  Initializes various elements
		/// </summary>
		public ListViewColumnSorter()
		{
			_columnToSort = 0;
			_orderOfSort = SortOrder.None;
			_objectCompare = new CaseInsensitiveComparer();
		}

		/// <summary>
		/// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
		/// </summary>
		/// <param name="x">First object to be compared</param>
		/// <param name="y">Second object to be compared</param>
		/// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
		public int Compare(object x, object y)
		{
			var itemX = (ListViewItem)x;
			var itemY = (ListViewItem)y;

			if (itemX.ListView.Columns[_columnToSort].Tag == "number")
			{
				return CompareNumbers(itemX, itemY);
			}

			return CompareText(itemX, itemY);
		}

		private int CompareNumbers(ListViewItem itemX, ListViewItem itemY)
		{
			int x = Int32.Parse(itemX.SubItems[_columnToSort].Text);
			int y = Int32.Parse(itemY.SubItems[_columnToSort].Text);
			int compareResult = x.CompareTo(y);
			if (_orderOfSort == SortOrder.Ascending)
			{
				return compareResult;
			}
			if (_orderOfSort == SortOrder.Descending)
			{
				return (-compareResult);
			}

			return 0;
			
		}

		private int CompareText(ListViewItem itemX, ListViewItem itemY)
		{
			int compareResult = _objectCompare.Compare(itemX.SubItems[_columnToSort].Text, itemY.SubItems[_columnToSort].Text);
			if (_orderOfSort == SortOrder.Ascending)
			{
				return compareResult;
			}
			if (_orderOfSort == SortOrder.Descending)
			{
				return (-compareResult);
			}

			return 0;
		}

		/// <summary>
		/// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
		/// </summary>
		public int SortColumn
		{
			set { _columnToSort = value; }
			get { return _columnToSort; }
		}

		/// <summary>
		/// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
		/// </summary>
		public SortOrder Order
		{
			set { _orderOfSort = value; }
			get { return _orderOfSort; }
		}
	}
}

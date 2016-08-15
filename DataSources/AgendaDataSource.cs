using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using XamarinDevDaysFinder.Core;

namespace XamarinDevDaysFinder
{
	public class AgendaTableSource : UITableViewSource
	{
		List<Session> _sessions = null;
		string CellIdentifier = "TableCell";

		public AgendaTableSource(List<Session> sessions) 
		{
			_sessions = sessions;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			Session item = _sessions[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier); }

			cell.TextLabel.Text = item.TopicName;
			cell.DetailTextLabel.Text = item.Timing;
			//cell.BackgroundColor = UIColor.Blue;
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _sessions.Count;
		}
	}
}


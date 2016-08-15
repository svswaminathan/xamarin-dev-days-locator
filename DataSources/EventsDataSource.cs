using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using XamarinDevDaysFinder.Core;

namespace XamarinDevDaysFinder
{
	public class EventsDataSource : UITableViewSource
	{
		List<Event> _events = null;
		string CellIdentifier = "EventCell";
		UIViewController parentController;

		public EventsDataSource(List<Event> events, UIViewController controller)
		{
			_events = events;
			parentController = controller;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			Event item = _events[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Value1, CellIdentifier);
			}

			cell.TextLabel.Text = item.Location.City;
			cell.DetailTextLabel.Text = item.Date.ToString("M");

			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			//cell.BackgroundColor = UIColor.Blue;
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _events.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			Event selectedEvent = GetItem(indexPath.Row);
			parentController.NavigationController.PushViewController(new EventDetailViewController(selectedEvent), true);
			tableView.DeselectRow(indexPath, true);
		}

		public Event GetItem(int index)
		{
			return _events[index];
		}
	}
}


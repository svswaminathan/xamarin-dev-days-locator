using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using XamarinDevDaysFinder.Core;

namespace XamarinDevDaysFinder
{
	public partial class EventsViewController : UIViewController
	{
		
		DataProvider provider = new DataProvider();
		List<Event> events = null;
		UITableView EventsTableView;

		public EventsViewController(IntPtr handle) : base(handle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			EventsTableView = new UITableView(View.Bounds);
			events = provider.GetEvents();
			EventsTableView.Source = new EventsDataSource(events, this);

			Add(EventsTableView);
		}
	}
}
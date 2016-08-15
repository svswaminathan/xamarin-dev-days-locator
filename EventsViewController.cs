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
		UIImageView imageView;

		public EventsViewController(IntPtr handle) : base(handle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			imageView = new UIImageView(UIImage.FromBundle("xamarin-logo.png"));

			EventsTableView = new UITableView(View.Bounds, UITableViewStyle.Grouped);
			events = provider.GetEvents();
			EventsTableView.Source = new EventsDataSource(events, this);
			EventsTableView.BackgroundColor = UIColor.White;
			this.View.AddSubviews(imageView, EventsTableView);
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			imageView.Frame = new CoreGraphics.CGRect(-20, 60, imageView.Image.CGImage.Width, imageView.Image.CGImage.Height);
			EventsTableView.Frame = new CoreGraphics.CGRect(0, 200, View.Bounds.Width, View.Bounds.Height);
		}
	}
}
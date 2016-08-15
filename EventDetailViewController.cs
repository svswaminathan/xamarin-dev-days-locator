using Foundation;
using System;
using UIKit;
using XamarinDevDaysFinder.Core;
using CoreGraphics;
using MapKit;
using CoreLocation;

namespace XamarinDevDaysFinder
{
	public partial class EventDetailViewController : UIViewController
	{
		Event selectedEvent;
		UILabel lblOrganizerKey;
		UILabel lblOrganizer;
		UILabel lblUserGroupKey;
		UILabel lblUserGroup;
		MKMapView map;
		UIButton btnRegister;
		LocationHelper helper = new LocationHelper();

		public EventDetailViewController(IntPtr handle) : base(handle)
		{
		}
		public EventDetailViewController(Event _selectedEvent)
		{
			selectedEvent = _selectedEvent;
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Event Details";
			this.View.BackgroundColor = UIColor.White;

			lblOrganizerKey = new UILabel();
			lblOrganizerKey.Text = "Contact";

			lblUserGroupKey = new UILabel();
			lblUserGroupKey.Text = "UserGroup";

			lblOrganizer = new UILabel();
			lblOrganizer.Text = selectedEvent.Organizer;

			lblUserGroup = new UILabel();
			lblUserGroup.Text = selectedEvent.UserGroup;

			map = new MKMapView();
			map.MapType = MKMapType.Standard;
			map.ZoomEnabled = true;
			map.ScrollEnabled = true;

			var coords = new CLLocationCoordinate2D(selectedEvent.Location.Latitude, selectedEvent.Location.Longitude);
			var span = new MKCoordinateSpan(helper.KilometresToLatitudeDegrees(2), helper.KilometresToLongitudeDegrees(2, selectedEvent.Location.Latitude));

			map.AddAnnotation(new PinAnnotation(coords, selectedEvent.Location.Building, selectedEvent.Location.Address));
			map.Region = new MKCoordinateRegion(coords, span);

			btnRegister = UIButton.FromType(UIButtonType.RoundedRect); ;
			btnRegister.SetTitle("Register", UIControlState.Normal);
			btnRegister.TouchUpInside += (sender, e) =>
			{
				this.NavigationController.PushViewController(new RegistrationWebViewController(new NSUrl(selectedEvent.RegistrationLink)), true);
			};

			this.View.AddSubviews(lblOrganizerKey, lblOrganizer, lblUserGroupKey, lblUserGroup, map, btnRegister);

		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			lblOrganizerKey.Frame = new CGRect(5, 60, 100, 50);
			lblOrganizer.Frame = new CGRect(110, 60, 200, 50);
			lblUserGroupKey.Frame = new CGRect(5, 120, 100, 50);
			lblUserGroup.Frame = new CGRect(110, 120, 200, 50);
			map.Frame = new CGRect(20, 200, 300, 300);
			btnRegister.Frame = new CGRect(100, 550, 100, 50);
		}
	}
}
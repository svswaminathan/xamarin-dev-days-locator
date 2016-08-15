using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using XamarinDevDaysFinder.Core;
using System.Threading.Tasks;

namespace XamarinDevDaysFinder
{
	public partial class AgendaViewController : UIViewController
	{
		UITableView agendaTableView;
		UIImageView imageView;
		DataProvider provider = new DataProvider();

		public AgendaViewController(IntPtr handle) : base(handle)
		{
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Perform any additional setup after loading the view, typically from a nib.
			//Task<List<Session>> sessions =  provider.GetAgendaAsync();;

			imageView = new UIImageView(UIImage.FromBundle("xamarin-logo.png"));

			List<Session> sessions = provider.GetAgenda();
			agendaTableView = new UITableView(View.Bounds, UITableViewStyle.Grouped);
			agendaTableView.BackgroundColor = UIColor.White;
			agendaTableView.SeparatorColor = UIColor.Blue;
			agendaTableView.Source = new AgendaTableSource(sessions);

			this.View.AddSubviews(imageView, agendaTableView);

		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			imageView.Frame = new CoreGraphics.CGRect(-20, 60, imageView.Image.CGImage.Width, imageView.Image.CGImage.Height);
			agendaTableView.Frame = new CoreGraphics.CGRect(0, 200, View.Bounds.Width, View.Bounds.Height);
		}
	}
}
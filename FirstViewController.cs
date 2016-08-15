using System;
using XamarinDevDaysFinder.Core;
using UIKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinDevDaysFinder
{
	public partial class FirstViewController : UIViewController
	{

		protected FirstViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Perform any additional setup after loading the view, typically from a nib.
			//Task<List<Session>> sessions =  provider.GetAgendaAsync();
			//agendaTableView = new UITableView(View.Bounds);
			//List<Session> sessions = new List<Session>
			//{
			//	new Session { TopicName ="Registration", Timing ="9:00 - 10:00 AM"},
			//	new Session { TopicName ="Intro to Xamarin", Timing ="10:00 - 11:00 AM"},
			//};
			//agendaTableView.Source = new AgendaTableSource(sessions);
			//Add(agendaTableView);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


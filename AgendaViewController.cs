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
		DataProvider provider = new DataProvider();
		public AgendaViewController (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Perform any additional setup after loading the view, typically from a nib.
			//Task<List<Session>> sessions =  provider.GetAgendaAsync();;
			List<Session> sessions = provider.GetAgenda();
			agendaTableView = new UITableView(View.Bounds);
			agendaTableView.Source = new AgendaTableSource(sessions);

			Add(agendaTableView);
		}
    }
}
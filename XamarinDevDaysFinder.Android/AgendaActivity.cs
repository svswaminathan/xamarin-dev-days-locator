
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinDevDaysFinder.Core;

namespace XamarinDevDaysFinder.Droid
{
	[Activity(Label = "Agenda", MainLauncher = true)]
	public class AgendaActivity : Activity
	{
		DataProvider provider;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.AgendaView);

			provider = new DataProvider();
			List<Session> sessions = provider.GetAgenda();
			ListView myList = FindViewById<ListView>(Resource.Id.agendaListView);

			myList.Adapter = new AgendaListViewAdapter(this, sessions);
		
		}
	}
}


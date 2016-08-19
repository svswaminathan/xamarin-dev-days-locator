using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using XamarinDevDaysFinder.Core;

namespace XamarinDevDaysFinder.Droid
{
	public class AgendaListViewAdapter : BaseAdapter<Session>
	{
		List<Session> sessions = null;
		Activity context;
		public AgendaListViewAdapter(Activity context, List<Session> sessions)
		{
			this.context = context;
			this.sessions = sessions;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override int Count
		{
			get
			{
				return sessions.Count;
			}
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			//throw new NotImplementedException();
			var item = sessions[position];
			View view = convertView;
			if (view == null)
			{
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
				view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.TopicName;
				view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = item.Timing;
			}
			return view;
		}

		public override Session this[int position]
		{
			get
			{
				return sessions[position];
			}
		}
	}
}


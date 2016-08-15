using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamarinDevDaysFinder.Core
{
	public class DataProvider
	{
		//HttpClient client = new HttpClient();
		public List<Session> GetAgenda()
		{
			//string response = await client.GetStringAsync(Constants.GetAgendaUrl);
			//sessions = JsonConvert.DeserializeObject<List<Session>>(response);
			List<Session> sessions = new List<Session>
			{
				new Session { TopicName ="Registration", Timing ="9:00 AM - 9:30 AM"},
				new Session { TopicName ="Intro to Xamarin", Timing ="9:30 AM - 10:10 AM"},
				new Session { TopicName ="Cross-platform + Xamarin", Timing ="10:20 AM - 11:00 AM"},
				new Session { TopicName ="Cloud + Xamarin", Timing ="11:10 AM - 11:50 AM"},
				new Session { TopicName ="Lunch", Timing ="12:00 AM - 1:00 PM"},
				new Session { TopicName ="Hands-On Lab", Timing ="1:00 PM - 4:00 PM"},
			};
			return sessions;
		}

		public List<Event> GetEvents()
		{
			List<Event> events = new List<Event>();
			var bangaloreEvent = CreateNewEvent(new DateTime(2016, 8, 20), "@nishanil", "XHackers Bangalore", "https://ti.to/xamarin/dev-days-bangalore", "Magnolia, Microsoft Corp Pvt. Ltd", "EGL, Domlur", "Bangalore", 12.954695, 77.641305);
			var kochiEvent = CreateNewEvent(new DateTime(2016, 8, 27), "@safilsunny", "XHackers Kerala", "https://ti.to/xamarin/dev-days-kochi", "Athulya Hall", "Kakkanad, Kochi, Kerala, 680030", "Kochi", 10.008894, 76.361726);
			var kolkataEvent = CreateNewEvent(new DateTime(2016, 9, 3), "@abhisheknandy81", "Kolkata Geeks", "https://ti.to/xamarin/dev-days-kolkata", "Nasscom Warehouse 7th Floor", "Salt Lake City,West Bengal 700091", "Kolkata", 22.570111, 88.436937);
			var hydbadEvent = CreateNewEvent(new DateTime(2016, 9, 17), "@a_pranav", "Microsoft UG Hyderabad", "https://ti.to/xamarin/dev-days-hyderabad", "Microsoft India Development Center", "Gachibowli Hyderabad, Telangana 500081", "Hyderabad", 17.443357, 78.382211);
			var tvmEvent = CreateNewEvent(new DateTime(2016, 9, 24), "@safilsunny", "XHackers Kerala", "https://ti.to/xamarin/dev-days-thiruvananthapuram", "Ernst & Young Innovation Center", "Kazhakkottam, Thiruvananthapuram, Kerala, 695585", "Thiruvananthapuram", 8.579389, 76.874979);

			events.Add(bangaloreEvent);
			events.Add(kochiEvent);
			events.Add(kolkataEvent);
			events.Add(hydbadEvent);
			events.Add(tvmEvent);

			return events;
		}

		private Event CreateNewEvent(DateTime date, string organizer, string userGroup, string registrationLink, string building, string address,
									 string city, double latitude, double longitude)
		{
			Event newEvent = new Event
			{
				Date = date,
				Organizer = organizer,
				UserGroup = userGroup,
				RegistrationLink = registrationLink,
				Location = new Location
				{
					Building = building,
					Address = address,
					City = city,
					Latitude = latitude,
					Longitude = longitude
				}
			};
			return newEvent;
		}
	}
}


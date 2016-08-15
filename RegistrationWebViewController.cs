using Foundation;
using System;
using UIKit;

namespace XamarinDevDaysFinder
{
	public partial class RegistrationWebViewController : UIViewController
	{
		UIWebView webView;
		NSUrl urlToLoad;
		public RegistrationWebViewController(IntPtr handle) : base(handle)
		{

		}
		public RegistrationWebViewController(NSUrl url)
		{
			urlToLoad = url;;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			webView = new UIWebView(View.Bounds);
			webView.ScalesPageToFit = true;
			webView.LoadRequest(new NSUrlRequest(urlToLoad));

			this.View.Add(webView);
		}
	}
}
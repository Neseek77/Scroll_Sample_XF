using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace chatsamplecustom
{
	public partial class chatsamplecustomPage : ContentPage
	{

		public ObservableCollection<CustomViewModel> holder { get; set; }

		public chatsamplecustomPage()
		{
			InitializeComponent();
			int i = 0;
			var scroll = new ScrollView { Content = comx };
			scroll.HeightRequest = 2000;

			send.Clicked += (sender, e) => {

				if (string.IsNullOrEmpty(chat.Text) || (string.IsNullOrWhiteSpace(chat.Text)))
				{
					DisplayAlert("Warning !!", "Please type something to send.", "Ok");
				}
				else{
					var chatlabel = new Editor()
					{
						FontSize = 17,
						//FontAttributes = FontAttributes.Bold,
					};
					chatlabel.Text = chat.Text;

						if (i % 2 == 0)
						{
						chatlabel.HorizontalOptions = LayoutOptions.End;
						chatlabel.BackgroundColor = Color.Green;
						chatlabel.TextColor = Color.White;
						i++;
						}
						else{
						chatlabel.HorizontalOptions = LayoutOptions.Start;
						chatlabel.BackgroundColor = Color.Blue;
						chatlabel.TextColor = Color.White;
						i++;
						}

					stack.Children.Add(chatlabel);
					chat.Text = "";

					double scrollingSpace = scroll.ContentSize.Height - scroll.Height;
					scroll.ScrollToAsync(0.0, scrollingSpace + 10, true);
				}
			};

			//ScrollView scrollView = sender as ScrollView;
			facebook.Clicked += (sender, e) => { 
			double scrollingSpace = scroll.ContentSize.Height - scroll.Height;
				scroll.ScrollToAsync(0.0, scrollingSpace + 1, true);
				//if (scrollingSpace >= e.ScrollY) {
				//	scroll.ScrollToAsync(0.0,scrollingSpace+1,true);
				//	//DisplayAlert("1","2","3");
				//}

			};



			Content = new StackLayout
			{
				Children = {
					blueBar,
					scroll,
					sandy,
					//new StackLayout{
					//	Children={
					//		sandy
					//	}
					//}
				},

			};

		}

		public class Customcell : ViewCell
		{
			public Customcell()
			{
				//instantiate each of our views
				var image = new Image();
				var nameLabel = new Label();
				var typeLabel = new Label();
				var verticaLayout = new StackLayout();
				var horizontalLayout = new StackLayout() { BackgroundColor = Color.Olive };

				//set bindings
				nameLabel.SetBinding(Label.TextProperty, new Binding("Name"));
				typeLabel.SetBinding(Label.TextProperty, new Binding("Type"));
				image.SetBinding(Image.SourceProperty, new Binding("Image"));

				//Set properties for desired design
				horizontalLayout.Orientation = StackOrientation.Horizontal;
				horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
				image.HorizontalOptions = LayoutOptions.End;
				nameLabel.FontSize = 24;

				//add views to the view hierarchy
				verticaLayout.Children.Add(nameLabel);
				verticaLayout.Children.Add(typeLabel);
				horizontalLayout.Children.Add(verticaLayout);
				horizontalLayout.Children.Add(image);

				// add to parent view
				View = horizontalLayout;
			}
		}

	}
}


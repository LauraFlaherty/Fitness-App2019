using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTrackerApp.Models; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace FitnessTrackerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FitnessPage : ContentPage
	{
		public FitnessPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var exercises = new List<Fit>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.exercise.txt");
            //populates the list
            foreach (var fitfile in files)
            {
                exercises.Add(new Fit
                {
                    Fitfile = fitfile,
                    Text = File.ReadAllText(fitfile), //exercise details
                    Date = File.GetCreationTime(fitfile) //date
                });
            }

            listView.ItemsSource = exercises
                .OrderBy(d => d.Date)
                .ToList();
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FitnessInfoPage
            {
                //New Fit Instance
                BindingContext = new Fit()
            });
        }

        //Navigates to FitnessInfoPage, binds to Fit instance
        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new FitnessInfoPage
            {
                BindingContext = e.SelectedItem as Fit
            });
        }
    }
}
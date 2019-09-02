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
	public partial class FitnessInfoPage : ContentPage
	{
		public FitnessInfoPage ()
		{
			InitializeComponent ();
		}

        async void Delete_Button_Clicked(object sender, EventArgs e)
        {
            var fit = (Fit)BindingContext;

            //If the file exists, delete
            if (File.Exists(fit.Fitfile))
            {
                File.Delete(fit.Fitfile);
            }

            await Navigation.PopAsync();
        }

        async void Save_Button_Clicked(object sender, EventArgs e)
        {
            var fit = (Fit)BindingContext;

            if (string.IsNullOrWhiteSpace(fit.Fitfile))
            {
                // Save to exercise.txt file
                var fitFile = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.exercise.txt");
                File.WriteAllText(fitFile, fit.Text);
            }
            else
            {
                // Change or update
                File.WriteAllText(fit.Fitfile, fit.Text);
            }

            await Navigation.PopAsync();
        }
    }
}
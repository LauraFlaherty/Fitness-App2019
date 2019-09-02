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

        /*
         * deletes the file if it existed and the user is brought back to the fitness Information List page. 
         * */
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

        /*
        * save the details entered into a new file with a randomly generated name 
        * or, if the list item is being edited,  an existing file, .
        * */

        async void Save_Button_Clicked(object sender, EventArgs e)
        {
            var fit = (Fit)BindingContext;

            if (string.IsNullOrWhiteSpace(fit.Fitfile))
            {
                var fitFile = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.exercise.txt");
                File.WriteAllText(fitFile, fit.Text);
            }
            else
            {
                File.WriteAllText(fit.Fitfile, fit.Text);
            }

            await Navigation.PopAsync();
        }
    }
}
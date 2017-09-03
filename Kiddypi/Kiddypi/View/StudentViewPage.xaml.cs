using Kiddypi.Model;
using Kiddypi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kiddypi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentViewPage : ContentPage
    {
        public StudentViewPage()
        {
            InitializeComponent();

           
        }


       
        public StudentViewModel ViewModel { get { return (BindingContext as StudentViewModel); } }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel.Studentdetails.Count == 0)
                ViewModel.GetStudentCommand.Execute(null);
        }
    }


    //private async void button_clicked(object sender, eventargs e)
    //{
    //    var nextpage = new videoviewmodel();
    //    await this.navigation.pushasync(nextpage);
    //}
}

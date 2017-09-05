using Kiddypi.Model;
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
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = e.SelectedItem as MenuPageMenuItem;
            if (item == null)
                return;
            switch (item.Title)
            {

                case "Student Profile":
                    {
                        var StudentProfilepage = new StudentViewPage();

                        StudentProfilepage.Title = item.Title;
                        Detail = new NavigationPage(StudentProfilepage);
                        IsPresented = false;
                        MasterPage.ListView.SelectedItem = null;
                        break;

                    }
                case "Images":
                    {
                        var Imagepage = new ImageViewPage();
                        Imagepage.Title = item.Title;
                        Detail = new NavigationPage(Imagepage);
                        IsPresented = false;
                        MasterPage.ListView.SelectedItem = null;
                        break;

                    }
                case "Student Videos":
                    {
                        var Videopage = new VideoViewPage();                       
                        Videopage.Title = item.Title;
                        Detail = new NavigationPage(Videopage);
                        IsPresented = false;
                        MasterPage.ListView.SelectedItem = null;
                        break;

                    }
                case "Project Videos":
                    {

                        var ProjectVideoPage = new ProjectVideoViewPage();                      
                        ProjectVideoPage.Title = item.Title;
                        Detail = new NavigationPage(ProjectVideoPage);
                        IsPresented = false;
                        MasterPage.ListView.SelectedItem = null;
                        break;

                    }
                case "Session Schedule":
                    {
                       var SessionPage = new SessionsPage();
                        SessionPage.Title = item.Title;
                        Detail = new NavigationPage(SessionPage);
                        IsPresented = false;
                        MasterPage.ListView.SelectedItem = null;
                        break;

                    }
                  
                case "About":
                    {
                        var AboutPage = new AboutViewPage();                      
                        AboutPage.Title = item.Title;
                        Detail = new NavigationPage(AboutPage);
                        IsPresented = false;
                        MasterPage.ListView.SelectedItem = null;
                        break;
                    }
                case "Logout":
                    {
                        var LoginPage = new LoginPage();                       
                        LoginPage.Title = item.Title;
                        Detail = new NavigationPage(LoginPage);
                        IsPresented = false;
                        MasterPage.ListView.SelectedItem = null;

                        break;
                    }

            }
            //var page = (Page)Activator.CreateInstance(item.TargetType);

            //page.Title = item.Title;
            //Detail = new NavigationPage(page1);
            //IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}
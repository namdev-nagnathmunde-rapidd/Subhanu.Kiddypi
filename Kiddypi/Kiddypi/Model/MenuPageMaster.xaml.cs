using Kiddypi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kiddypi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageMaster : ContentPage
    {
        public ListView ListView;

        public MenuPageMaster()
        {
            InitializeComponent();

            BindingContext = new MenuPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MenuPageMasterViewModel : VideoViewModel
        {
            public ObservableCollection<MenuPageMenuItem> MenuItems { get; set; }

            public MenuPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MenuPageMenuItem>(new[]
                {
                    new MenuPageMenuItem { Id = 0, Icon = "videos_logo", Title = "Student Profile" },
                    new MenuPageMenuItem { Id = 1, Icon = "images", Title = "Images" },
                    new MenuPageMenuItem { Id = 2, Icon = "student_videos", Title = "Student Videos" },
                    new MenuPageMenuItem { Id = 3, Icon = "project_videos", Title = "Project Videos" },
                    new MenuPageMenuItem { Id = 4, Icon = "about_us", Title = "About" },
                    new MenuPageMenuItem { Id = 5, Icon = "logout", Title = "Logout" },
                });
            }
                
        }
    }
}
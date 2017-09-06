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
    public partial class StudentDetailViewPage : ContentPage
    {
        public StudentDetailViewPage()
        {
            InitializeComponent();
        }
         Student student;
        StudentViewModel vm;
        public StudentDetailViewPage(Student selectedStudent, StudentViewModel vm) : this()
        {
            BindingContext = this.student = selectedStudent;
            this.vm = vm;
        }
    }
}
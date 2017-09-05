using Kiddypi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiddypi
{
   public class LocalStorage
    {


        //public static List<string> UserComparedetails { get; set; }

        public static string [] UserComparedetails =new string[2];


        public static string[]  userstor()
        {

            return UserComparedetails;
        }
    }
}

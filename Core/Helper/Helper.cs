using Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class Helper
    {
        public static void ReloadPage()
        {
            DriverHolder.Driver.Navigate().Refresh();
        }
    }
}

using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalizationSample
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        public string[] Languages { get { return LocalResourcesManager.AvailableCultures.Select(ci => ci.Name).ToArray(); } }

        public string CurrentLanguage
        {
            get { return LocalResourcesManager.CurrentCulture.Name; }
            set
            {
                if (value != LocalResourcesManager.CurrentCulture.Name)
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(value);

                    LocalResourcesManager.RefreshLocalResources();

                    Notify();
                }
            }
        }
    }
}

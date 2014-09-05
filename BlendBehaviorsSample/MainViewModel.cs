using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlendBehaviorsSample
{
    public class MainViewModel
    {
        public IEnumerable<MyData> AllData
        {
            get
            {
                return new[]
                {
                    new MyData{ Header = "First" },
                    new MyData{ Header = "Second" },
                    new MyData{ Header = "Third" }
                };
            }
        }

        public ICommand LoadDataCommand { get; set; }

        public MainViewModel()
        {
            LoadDataCommand = new RelayCommand<MyData>(LoadData);
        }

        private async void LoadData(MyData data)
        {
            if (data.Content == null)
            {
                data.Content = "Loading content...";

                await Task.Delay(3000);

                data.Content = string.Format(@"[{0}] Lorem ipsum dolor sit amet, consectetur adipiscing elit.
Morbi porta lacus diam, in commodo sapien tristique eu.
In vel sagittis orci.
Pellentesque eget risus eros.
Proin interdum enim quis mauris blandit, et mattis massa faucibus.
Suspendisse sodales cursus feugiat.
Suspendisse non ipsum dolor.
Integer a odio sapien.
Proin non pharetra eros.", data.Header);
            }
        }
    }
}

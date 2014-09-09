using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridSample
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        private ObservableCollection<Movie> movies;
        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            set { UpdateAndNotify(ref movies, value); }
        }

        public MainViewModel()
        {
            this.Movies = new ObservableCollection<Movie>(MoviesRepository.Movies);
        }
    }
}

using Model;

namespace DataBinding.ViewModels
{
    public class NameViewModel
    {
        public Computer Computer { get; set; }

        public NameViewModel()
        {
            Computer = new Computer { Name = "..." };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSeminar
{
    internal class Window1ViewModel: BaseViewModel
    {
        private string needle = "Search Text ...";
        public string Needle { 
            get => needle;
            set
            {
                if(needle != value)
                {
                    needle = value;
                    NotifyPropertyChanged();
                }
            }
                
                }
    }
}

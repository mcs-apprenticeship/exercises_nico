using Exercises_4_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_4_1.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>{
            new Contact(){FirstName = "Paul", LastName = "Adank"},
        };

        private int? currentContact = null;

        public Contact CurrentContact { 
            get => 
                currentContact != null ? 
                Contacts[(int)currentContact] : 
                new Contact(); 
            set 
            { 
                if(currentContact != null)
                {
                    if (value != Contacts[(int)currentContact])
                    {
                        Contacts[(int)currentContact] = value;
                        NotifyPropertyChanged();
                    }
                }
            } 
        }

        public int CurrentContactId { 
            get => currentContact ?? 0;
            set
            {
                currentContact = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(CurrentContact));
                NotifyPropertyChanged(nameof(CanEdit));
            }     
        }

        public List<string> ContactNames { get
            {
                List<string> Names = new List<string>();
                foreach(Contact contact in Contacts)
                {
                    Names.Add($"{contact.FirstName} {contact.LastName}");
                }

                return Names;
            } 
        }

        public bool CanEdit { get => currentContact != null ; }

        public void AddContact()
        {
            Contacts.Add(new Contact());
            currentContact = Contacts.Count - 1;
            NotifyPropertyChanged(nameof(currentContact));
            NotifyPropertyChanged(nameof(CanEdit));
        }

        public void RemoveContact()
        {
            Contacts.RemoveAt(CurrentContactId);
            currentContact = null;
            NotifyPropertyChanged(nameof(currentContact));
            NotifyPropertyChanged(nameof(CanEdit));
        }
    }
}

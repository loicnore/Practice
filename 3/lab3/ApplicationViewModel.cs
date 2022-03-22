using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Contact selectedContact;
        public ObservableCollection<Contact> Contacts { get; set; }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Contact contact = new Contact();
                        Contacts.Insert(0, contact);
                        SelectedContact = contact;
                    }));
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Contact phone = obj as Contact;
                        if (phone != null)
                        {
                            Contacts.Remove(phone);
                        }
                    },
                    (obj) => Contacts.Count > 0));
            }
        }
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedContact");
            }

        }
        public ApplicationViewModel()
        {
            Contacts = new ObservableCollection<Contact>
            {
                new Contact{Name="Donna",Surname="Patrition",Phone="89990127834"},
                new Contact{Name="Bobbie",Surname="Brown",Phone="89056718920"},
                new Contact{Name="Rick",Surname="Wells",Phone="89119038702"},
                new Contact{Name="Sam",Surname="Stars",Phone="89067819351"}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}

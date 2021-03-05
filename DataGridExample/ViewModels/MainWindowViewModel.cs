using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using DataGridExample.Models;
using ReactiveUI;

namespace DataGridExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string text;
        public string Text 
        {
            get => text;
            set => this.RaiseAndSetIfChanged(ref text, value);
        }

        private bool isChecked;
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                Text = "Privet!";
                this.RaiseAndSetIfChanged(ref isChecked, value);
            }
        }

        public ObservableCollection<Person> People { get; }
        public ReactiveCommand<Unit, Unit> ButtonCommand { get; }

        public MainWindowViewModel()
        {
            People = new ObservableCollection<Person>(GenerateMockPeopleTable());
            ButtonCommand = ReactiveCommand.Create(ButtonAction);
        }

        private void ButtonAction()
        {
            var person = new Person()
            {
                FirstName = "New FirstName",
                LastName = "New LastName",
                EmployeeNumber = 1010,
                DepartmentNumber = 100,
                DeskLocation = "B3F3R5T7"
            };
            People.Add(person);
        }
        
        private IEnumerable<Person> GenerateMockPeopleTable()
        {
            var defaultPeople = new List<Person>()
            {
                new Person()
                {
                    FirstName = "Pat", 
                    LastName = "Patterson", 
                    EmployeeNumber = 1010,
                    DepartmentNumber = 100, 
                    DeskLocation = "B3F3R5T7"
                },
                new Person()
                {
                    FirstName = "Jean", 
                    LastName = "Jones", 
                    EmployeeNumber = 973,
                    DepartmentNumber = 200, 
                    DeskLocation = "B1F1R2T3"
                },
                new Person()
                {
                    FirstName = "Terry", 
                    LastName = "Tompson", 
                    EmployeeNumber = 300,
                    DepartmentNumber = 100, 
                    DeskLocation = "B3F2R10T1"
                }
            };

            return defaultPeople;
        }
    }
}

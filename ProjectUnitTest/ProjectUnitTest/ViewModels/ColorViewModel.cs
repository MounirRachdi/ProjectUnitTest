using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ProjectUnitTest.Models;
using Root.Services.Sqlite;
using Xamarin.Forms;

namespace ProjectUnitTest.ViewModels
{
    public class ColorViewModel :  INotifyPropertyChanged
    {
        private readonly IDependencyService _dependencyService;
        public IDataStore<Models.Color> DataStore => DependencyService.Get<IDataStore<Models.Color>>() ?? new DataStore<Models.Color>("ProductDataBase.db3");
        public INavigation _nav;
        public ContentPage CurrentPage { get; set; }
        public void OpenPage()
        {

            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
                _nav.PushAsync(CurrentPage);
            }
        }
        public ColorViewModel(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
            DataStore.CreateTableAsync();
            AddColorAsync();


        }


        public ColorViewModel() : this(new DependencyServiceWrapper())
        {

        }
       
        public ColorViewModel(INavigation nav) 
        {

            _nav = nav;
            CurrentPage = DependencyInject<MainPage>.Get();
            DataStore.CreateTableAsync();
            AddColorAsync();



        }
        public int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }

        }
        public string _colorcode;
        public string Colorcode
        {
            get
            {
                return _colorcode;
            }
            set
            {
                _colorcode = value;
                OnPropertyChanged();
            }
        }
        public string _colorname;
        public string Colorname
        {
            get
            {
                return _colorname;
            }
            set
            {
                _colorname = value;
                OnPropertyChanged();
            }
        }
        public async void AddColorAsync()
        {

            Models.Color c = new Models.Color
            {
                Colorcode = "#FF0000",
            Colorname="Red",

            };

            try
            {
                await DataStore.AddAsync(c);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public ICommand VALIDATE => new Command(async () =>
        {

            try
            {
              
                var c = await DataStore.GetAllAsync();
               
                if (c.Count() > 0)
                {
                    await CurrentPage.DisplayAlert("Notification !..", "Welcome ..", "Ok ..");
                    
                }
                else
                {
                    await CurrentPage.DisplayAlert("Error !..", "No Data ..", "Ok ..");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        });
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

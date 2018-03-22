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
    public class MesearementViewModel : INotifyPropertyChanged
    {
        private readonly IDependencyService _dependencyService;
        public IDataStore<Mesearement> DataStore => DependencyService.Get<IDataStore<Mesearement>>() ?? new DataStore<Mesearement>("ProductDataBase.db3");
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
        public MesearementViewModel(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
            DataStore.CreateTableAsync();

        }


        public MesearementViewModel() : this(new DependencyServiceWrapper())
        {

        }
        public MesearementViewModel(INavigation nav)
        {

            _nav = nav;
            CurrentPage = DependencyInject<MainPage>.Get();
            DataStore.CreateTableAsync();


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
        public int _height;
        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }
        public int _width;
        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }
        public int _depth;
        public int Depth
        {
            get { return _depth; }
            set
            {
                _depth = value;
                OnPropertyChanged();
            }
        }
        public async void AddColorAsync()
        {

            Mesearement m = new Mesearement
            {
                Height = 14,
                Width=100,
                Depth=50,

            };

            try
            {
                await DataStore.AddAsync(m);


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

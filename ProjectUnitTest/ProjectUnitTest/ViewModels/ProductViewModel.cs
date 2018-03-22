using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using ProjectUnitTest.Models;
using Root.Services.Sqlite;
using Xamarin.Forms;
using System.Drawing;
namespace ProjectUnitTest.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly IDependencyService _dependencyService;
        public IDataStore<Product> DataStore => DependencyService.Get<IDataStore<Product>>() ?? new DataStore<Product>("ProductDataBase.db3");
        public INavigation _nav;
        public ContentPage CurrentPage { get; set; }
        public ObservableCollection<Product> Products;
      

        public ObservableCollection<Product> ProductList
        {
            get
            {

                return Products ?? (Products = new ObservableCollection<Product>());
            }
            set
            {
                Products = value;
                OnPropertyChanged();
                
            }
        }
        public ProductViewModel(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
            DataStore.CreateTableAsync();
            AddProductAsync();
        }


        public ProductViewModel() : this(new DependencyServiceWrapper())
        {
            
        }
        public ProductViewModel(INavigation nav)
        {

            _nav = nav;
            CurrentPage = DependencyInject<MainPage>.Get();
            DataStore.CreateTableAsync();
            AddProductAsync();

        }
        public void OpenPage()
        {

            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
                _nav.PushAsync(CurrentPage);
            }
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
        public string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }

        }
        public int _colorid;
        public int DolorId
        {
            get { return _colorid; }
            set
            {
                _colorid = value;
                OnPropertyChanged();
            }
        }
        public int _mesearementid;
        public int MesearementId
        {
            get { return _mesearementid; }
            set
            {
                _mesearementid = value;
                OnPropertyChanged();
            }
        }
        public  async void AddProductAsync()
        {
            Mesearement m = new Mesearement();
            Models.Color c = new Models.Color();
            Product p = new Product
            {
               Name = Name,
              ColorId=c.Id,
              MesearementId=m.Id,
       
            };

            try
            {
                await DataStore.AddAsync(p);

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public ICommand VALIDATE
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        ProductList.Clear();
                        var u = await DataStore.GetAllAsync();
                        foreach (var item in u)
                        {
                            ProductList.Add(item);

                        }

                        if (u.Count() > 0)
                        {
                            await CurrentPage.DisplayAlert("Notification !..", "Welcome ..", "Ok ..");
                            // var ss = DependencyService.Get<ProductViewModel>() ?? (new ProductViewModel(_nav));
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
            }
        }
    
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

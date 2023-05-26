using DevExpress.Mvvm;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using mvvm.OtherFiles;
using mvvm.ViewModels;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using mvvm.Models;

namespace mvvm.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        
        public ObservableCollection<Tblproduct> Products { get; set; }
        public ObservableCollection<Tblcategory> Categories { get; set; }
        public ObservableCollection<Tblprovider> Providers { get; set; }

       
        public Tblcategory SelectedCategory { get; set; }
        public Tblprovider SelectedProvider { get; set; }

        public MainWindowViewModel()
        {
            List<Tblcategory> categories = new List<Tblcategory>
            { new Tblcategory() { Id = 0, Category = "ALL Rатегории" } };
            categories.AddRange(DB.instance.Tblcategories.ToList());
            Categories = categories.ToObservableCollection();

            List<Tblprovider> providers = new List<Tblprovider> { new Tblprovider()
            { Id = 0, Provider = "All Производители" } };
            providers.AddRange(DB.instance.Tblproviders.ToList());
            Providers = providers.ToObservableCollection();

            Products = DB.instance.Tblproducts.ToObservableCollection();

            SelectedCategory = Categories[0];
            SelectedProvider = Providers[0];
        }

        
        private void Search()
        {
            Products = DB.instance.Tblproducts.Include(s => s.CategoryNavigation).
                Include(s => s.Provider)
               .Where(s => (this.SelectedProvider.Id == 0 || s.ProviderId == this.SelectedProvider.Id)
               && (this.SelectedCategory.Id == 0 || s.Category == this.SelectedCategory.Id)).ToObservableCollection();
        }

        
        public DelegateCommand SearchCommand
        {
            get
            {
                return new DelegateCommand(
                    () => Search()
                    );
            }
        }


    }
}


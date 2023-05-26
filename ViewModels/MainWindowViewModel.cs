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
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using mvvm.Models;

namespace mvvm.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        
        public ObservableCollection<TblProduct> Products { get; set; }
        public ObservableCollection<TblCategory> Categories { get; set; }
        public ObservableCollection<TblProvider> Providers { get; set; }

       
        public TblCategory SelectedCategory { get; set; }
        public TblProvider SelectedProvider { get; set; }

        public MainWindowViewModel()
        {
            List<TblCategory> categories = new List<TblCategory>
            { new TblCategory() { Id = 0, Category = "ALL Rатегории" } };
            categories.AddRange(DB.instance.TblCategories.ToList());
            Categories = categories.ToObservableCollection();

            List<TblProvider> providers = new List<TblProvider> { new TblProvider()
            { Id = 0, Provider = "All Производители" } };
            providers.AddRange(DB.instance.TblProviders.ToList());
            Providers = providers.ToObservableCollection();

            Products = DB.instance.TblProducts.ToObservableCollection();

            SelectedCategory = Categories[0];
            SelectedProvider = Providers[0];
        }

        
        private void Search()
        {
            Products = DB.instance.TblProducts.Include(s => s.CategoryNavigation).
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


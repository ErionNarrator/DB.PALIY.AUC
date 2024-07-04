using DB.PALIY.AUC.Model;
using DB.PALIY.AUC.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.PALIY.AUC.ModelView
{
     class SalePageViewModel : BaseClass
    {
        AuctionDb1Context db = new AuctionDb1Context();
        private ObservableCollection<Sale> salesList;
        public ObservableCollection<Sale> SalesList
        {
            get { return salesList; }
            set
            {
                salesList = value; 
                OnPropertyChanged(nameof(SalesList));
            }
        }
        public SalePage window;

        private Sale? selectedSale;
        public Sale? SelecteSale
        {
            get { return selectedSale; }
            set
            {
                selectedSale = value;
                OnPropertyChanged(nameof(SelecteSale));
            }
        }
        public SalePageViewModel()
        {
            db.Sales.Load();
            SalesList = db.Sales.Local.ToObservableCollection();
        }
        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand(obj =>

                    {
                        Sale? sale = obj as Sale;
                        if (sale == null) return;
                        {
                            sale.ActualPrice = window.Sale.ActualPrice;
                            sale.ItemId = window.Sale.ItemId;
                            sale.PurchaserId = window.Sale.PurchaserId;
                            sale.DateSale = window.Sale.DateSale;
                        }

                    }));
            }
        }
    }
}

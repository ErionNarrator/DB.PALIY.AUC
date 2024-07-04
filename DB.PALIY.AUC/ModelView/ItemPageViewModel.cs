using DB.PALIY.AUC.Model;
using DB.PALIY.AUC.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.PALIY.AUC.ModelView
{
    class ItemPageViewModel : BaseClass
    {
        AuctionDb1Context db = new AuctionDb1Context();
        private ObservableCollection<Item> itemList;
        public ObservableCollection<Item> ItemList
        {
            get { return itemList; }
            set
            {
                itemList = value;
                OnPropertyChanged(nameof(ItemList));
            }
        }

        public ItemPage window;

        private Item? selectItem;
        public Item? SelectItem
        {
            get { return selectItem; }
            set
            {
                selectItem = value;
                OnPropertyChanged(nameof(SelectItem));
            }

        }
        public ItemPageViewModel()
        {
            db.Items.Load();
            ItemList = db.Items.Local.ToObservableCollection();
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditItem window = new AddEditItem(new Item());
                        if (window.ShowDialog() == true)
                        {
                            Item item = window.Item;
                            db.Items.Local.Add(item);
                            db.SaveChanges();
                        }
                    }));
            }
        }

        private Item selectedItem;
        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

            }
        }



        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand(obj =>
                    {
                        Item? item = obj as Item;
                        if (item == null) return;
                        AddEditItem window = new AddEditItem(item!);
                        if (window.ShowDialog() == true)
                        {
                            item.ItemId = window.Item.ItemId;
                            item.LotNumber = window.Item.LotNumber;
                            item.InitialPrice = window.Item.InitialPrice;
                            item.Description = window.Item.Description;
                            item.AuctionId = window.Item.AuctionId;
                            item.SellerId = window.Item.SellerId;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();



                        }
                    }));
            }
        }


        RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(selectedItem =>
                    {
                        // получаем выделенный объект
                        Item? item = selectItem as Item;
                        if (item == null) return;
                        db.Items.Remove(item);
                        db.SaveChanges();
                    }));
            }
        }
    }
}

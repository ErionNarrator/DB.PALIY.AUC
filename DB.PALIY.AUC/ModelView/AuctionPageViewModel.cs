using DB.PALIY.AUC.Model;
using DB.PALIY.AUC.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.PALIY.AUC.ModelView
{
    class AuctionPageViewModel : BaseClass
    {
        AuctionDb1Context db = new AuctionDb1Context();
        private ObservableCollection<Auction> auctionList;
        public ObservableCollection<Auction> AuctionList
        {
            get { return auctionList; }
            set
            {
                auctionList = value;
                OnPropertyChanged(nameof(AuctionList));
            }
        }

        public AuctionPage window;

        private Auction? selectAuction;
        public Auction? SelectAuction
        {
            get { return selectAuction; }
            set
            {
                selectAuction = value;
                OnPropertyChanged(nameof(SelectAuction));
            }

        }
        public AuctionPageViewModel(AuctionPage w)
        {
            this.window = w;
            db.Auctions.Load();
            AuctionList = db.Auctions.Local.ToObservableCollection();
            UpdateCards();
        }
        public void UpdateCards()
        {
            //window.AuctionContainer.Children.Clear();
            //foreach ( Auction auction in auctionList )
            //{
            //    AddEditItem suc = new AddEditItem(auction);
            //    window.AuctionContainer.Children.Add(suc);
            //}
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        AddEditAuction window = new AddEditAuction(new Auction());
                        if (window.ShowDialog() == true)
                        {
                            Auction auction = window.Auction;
                            db.Auctions.Add(auction);
                            db.SaveChanges();
                        }
                    }));
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
                        Auction? auction = obj as Auction;
                        if (auction == null) return;
                        AddEditAuction window = new AddEditAuction(auction!);
                        if (window.ShowDialog() == true)
                        {
                            auction.AuctionId = window.Auction.AuctionId;
                            auction.Name = window.Auction.Name;
                            auction.Data = window.Auction.Data;
                            auction.Place = window.Auction.Place;
                            auction.Specificity = window.Auction.Specificity;
                            db.Entry(auction).State = EntityState.Modified;
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
                        Auction? auction = selectedItem as Auction;
                        if (auction == null) return;
                        db.Auctions.Remove(auction);
                        db.SaveChanges();
                    }));
            }
        }
    }
}

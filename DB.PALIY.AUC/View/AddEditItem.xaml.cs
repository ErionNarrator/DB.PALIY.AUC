using DB.PALIY.AUC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DB.PALIY.AUC.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditItem.xaml
    /// </summary>
    public partial class AddEditItem : Window
    {
        private AuctionDb1Context AuctionDb1Context=new AuctionDb1Context();
        private Participant participant;

        public Item Item { get; private set; }
        public List<Auction> AuctionList { get; private set; }
        public List<Paragraph> ParagraphList { get; private set; }
        public Participant Participant { get; private set; }

        public AddEditItem(Item item)
        {
            InitializeComponent();
            Item = item;
            DataContext = Item;
            ComboBoxAuctionId.ItemsSource = AuctionDb1Context.Auctions.ToList();
            var bv = 7;
            ComboBoxSellerId.ItemsSource = AuctionDb1Context.Participants.ToList();
        }

        public AddEditItem(Participant participant)
        {
            this.participant = participant;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        //private void auctionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    AuctionDb1Context = new AuctionDb1Context();



        //}
    }
}

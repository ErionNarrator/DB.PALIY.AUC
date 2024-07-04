using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.PALIY.AUC.Model;

public partial class Sale : BaseClass
{
    [Key]
    public int SalesId { get; set; }

    private int itemId;
    public int ItemId
    {
        get { return  itemId; }
        set
        {
            itemId = value;
            OnPropertyChanged(nameof(ItemId));
        }
    }

    private double actualPrice;
    public double ActualPrice
    {
        get { return  actualPrice; }
        set
        {
            actualPrice = value; 
            OnPropertyChanged(nameof(ActualPrice));
        }
    }

    private int purchaserId;
    public int PurchaserId
    {
        get { return  purchaserId; }
        set
        {
            purchaserId = value;
            OnPropertyChanged(nameof(PurchaserId));
        }
    }

    private DateTime dateSale;
    public DateTime DateSale
    {
        get { return  dateSale; }
        set
        {
            dateSale = value;
            OnPropertyChanged(nameof(DateSale));
        }
    }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Participant Purchaser { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.PALIY.AUC.Model;

public partial class Item : BaseClass
{
    [Key]
    public int ItemId { get; set; }

    private int auctionId;
    public int AuctionId
    {
        get { return auctionId; }
        set
        {
            auctionId = value;
            OnPropertyChanged(nameof(AuctionId));
        }
    }

    private string lotNumber;
    public string LotNumber
    {
        get { return lotNumber; }
        set 
        { 
            lotNumber = value;
            OnPropertyChanged(nameof(LotNumber));
        }
    }

    private int sellerId;
    public int SellerId
    {
        get { return sellerId; }
        set
        {
            sellerId = value;
            OnPropertyChanged(nameof(SellerId));
        }
    }

    private string initialPrice;
    public string InitialPrice
    {
        get { return initialPrice; }
        set
        {
            initialPrice = value;
            OnPropertyChanged(nameof(InitialPrice));
        }
    }

    private string? description;
    public string? Description
    {
        get {  return  description; }
        set
        {
            description = value; 
            OnPropertyChanged(nameof(Description));    
        }
    }

    public virtual Auction Auction { get; set; } = null!;

    public virtual Sale Seller { get; set; } = null!;
}

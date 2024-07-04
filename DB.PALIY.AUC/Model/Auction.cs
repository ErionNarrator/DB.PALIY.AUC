using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.PALIY.AUC.Model;

public partial class Auction : BaseClass
{
    [Key]
    public int AuctionId { get; set; }
    private string? name;
    public string? Name
    {
        get {  return name; }
        set { name = value; OnPropertyChanged(nameof(Name));}
    }
    private string? data;

    public string? Data
    {
        get { return data; }
        set { data = value; OnPropertyChanged(nameof(Data));}
    }
    private string? place;
    public string? Place
    {
        get { return place; }
        set { place = value; OnPropertyChanged(nameof(Place));}
    }

    private string? specifitiy;
    public string? Specificity
    {
        get { return specifitiy; } set {  specifitiy = value; OnPropertyChanged(nameof(Specificity)); }
    }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}

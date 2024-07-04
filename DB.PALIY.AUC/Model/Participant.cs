using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.PALIY.AUC.Model;

public partial class Participant : BaseClass
{
    [Key]
    public int ParticipantsId { get; set; }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; OnPropertyChanged(nameof(Name)); }
    }

    private string contactInformation;
    public string? ContactInformation
    {
        get { return contactInformation; }
        set
        {
            contactInformation = value; OnPropertyChanged(nameof(ContactInformation));
        }
    }

    private string? type;
    public string? Type
    {
        get { return type; }
        set { type = value; OnPropertyChanged(nameof (Type)); }
    }

    private string? login;
    public string? Login
    {
        get { return login; }
        set { login = value; OnPropertyChanged(nameof(Login));}
    }

    private string? password;
    public string? Password
    {
        get { return password; }
        set { password = value; OnPropertyChanged( nameof(Password)); }
    }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}

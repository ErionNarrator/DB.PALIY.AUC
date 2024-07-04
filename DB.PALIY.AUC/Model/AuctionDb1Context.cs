using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB.PALIY.AUC.Model;

public partial class AuctionDb1Context : DbContext
{
    public AuctionDb1Context()
    {
    }

    public AuctionDb1Context(DbContextOptions<AuctionDb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Asus\\source\\repos\\DB.PALIY.AUC\\DB.PALIY.AUC\\DB\\AuctionDB1.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auction>(entity =>
        {
            entity.ToTable("Auction");

            entity.Property(e => e.AuctionId).HasColumnName("Auction_id");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");

            entity.Property(e => e.ItemId).HasColumnName("Item_id");
            entity.Property(e => e.AuctionId).HasColumnName("Auction_id");
            entity.Property(e => e.LotNumber).HasColumnName("Lot_Number");
            entity.Property(e => e.SellerId).HasColumnName("Seller_id");

            entity.HasOne(d => d.Auction).WithMany(p => p.Items)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Seller).WithMany(p => p.Items)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.ParticipantsId);

            entity.Property(e => e.ParticipantsId).HasColumnName("Participants_id");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SalesId);

            entity.Property(e => e.SalesId).HasColumnName("Sales_id");
            entity.Property(e => e.DateSale).HasColumnType("DATE");
            entity.Property(e => e.ItemId).HasColumnName("Item_id");
            entity.Property(e => e.PurchaserId).HasColumnName("Purchaser_id");

            entity.HasOne(d => d.Purchaser).WithMany(p => p.Sales)
                .HasForeignKey(d => d.PurchaserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

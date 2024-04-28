using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EF
{
    public partial class BcaoCuoiKyDbContext : DbContext
    {
        public BcaoCuoiKyDbContext()
            : base("name=BcaoCuoiKyDbContext")
        {
        }

        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.KhachHang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiSP>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.LoaiSP)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Nhanvien>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.Nhanvien)
                .WillCascadeOnDelete();
        }
    }
}

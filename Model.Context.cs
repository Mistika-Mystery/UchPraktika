//------------------------------------------------------------------------------
// <auto-generated>
//     ���� ��� ������ �� �������.
//
//     ���������, �������� � ���� ���� �������, ����� �������� � �������������� ������ ����������.
//     ���������, �������� � ���� ���� �������, ����� ������������ ��� ��������� �������� ����.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UchPraktika
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UchPractikEntities1 : DbContext
    {
        private static UchPractikEntities1 _UchPr;
        public UchPractikEntities1()
            : base("name=UchPractikEntities1")
        {
        }
        public static UchPractikEntities1 GetContext()
        {
            if (_UchPr == null)
            {
                _UchPr = new UchPractikEntities1();
            }
            return _UchPr;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<LicensiaInfo> LicensiaInfo { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Software> Software { get; set; }
        public virtual DbSet<SoftwarePosition> SoftwarePosition { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}

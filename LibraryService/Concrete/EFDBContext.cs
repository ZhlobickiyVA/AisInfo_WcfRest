using LibraryService.Entities;
using LibraryService.KhowBase;
using LibraryService.Price;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
  class EFDBContext
  {
  }


  public class AdContext : DbContext
  {
    public AdContext() : base("ConnectAisInfo") { }
    public DbSet<Ad> Ads { get; set; }
  }

  public class HolidayContext : DbContext
  {
    public HolidayContext() : base("ConnectAisInfo") { }
    public DbSet<Holiday> Holidays { get; set; }
  }

  public class KnowBaseContext : DbContext
  {
    public KnowBaseContext() : base("ConnectAisInfo") { }

    public DbSet<ViewAuthority> ViewAuthoritys { get; set; }
    public DbSet<Territory> Territorys { get; set; }
    public DbSet<Authority> Authoritys { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Service> Services { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {


    }
  }

  public class EmployeeContext : DbContext
  {
    public EmployeeContext() : base("ConnectAisInfo") { }
    public DbSet<Employee> Staff { get; set; }
  }

  public class PriceDocContext : DbContext
  {
    public PriceDocContext() : base("ConnectAisInfo") { }

    public DbSet<AuthoryPrice> AuthoryPrice { get; set; }
    public DbSet<Purpose> Purposes { get; set; }
    public DbSet<Document> Documents { get; set; }

  }


  public class DictionaryContext : DbContext
  {
    public DictionaryContext() : base("ConnectAisInfo") { }
    public DbSet<ModelDictionary> DictionaryList { get; set; }
  }

  public class BranchMfcContext : DbContext
  {
    public BranchMfcContext() : base("ConnectAisInfo") { }

    public DbSet<BranchMFC> ListBranchMFC { get; set; }
    public DbSet<BranchWorkDayMFC> ListWorkDayMFC { get; set; }
    public DbSet<DepartmentMFC> ListDepartments { get; set; }

  }






}

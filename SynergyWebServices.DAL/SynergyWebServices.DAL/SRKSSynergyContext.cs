using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SynergyWebServices.DAL;

public class SRKSSynergyContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
	public virtual DbSet<Applications> Applications { get; set; }

	public virtual DbSet<AutoMailSystem> AutoMailSystem { get; set; }

	public virtual DbSet<AutoMailer> AutoMailer { get; set; }


    public virtual DbSet<AvailSpareQuantity> AvailSpareQuantity { get; set; }

	public virtual DbSet<BuhlerAdminCc> BuhlerAdminCc { get; set; }

	public virtual DbSet<BusinessUnit> BusinessUnit { get; set; }

	public virtual DbSet<ChannelPartners> ChannelPartners { get; set; }

	public virtual DbSet<ChannelPartnersEngineer> ChannelPartnersEngineer { get; set; }

	public virtual DbSet<CpbankDetails> CpbankDetails { get; set; }

	public virtual DbSet<CpcontactPersonData> CpcontactPersonData { get; set; }

	public virtual DbSet<CpmailIdTo> CpmailIdTo { get; set; }

	public virtual DbSet<Cpperformance> Cpperformance { get; set; }

	public virtual DbSet<DistrictPinCodeDetailsTbl> DistrictPinCodeDetailsTbl { get; set; }

	public virtual DbSet<EquipSalesByVal> EquipSalesByVal { get; set; }

	public virtual DbSet<EquipSalesByVol> EquipSalesByVol { get; set; }

	public virtual DbSet<EquipSalesByVolAck> EquipSalesByVolAck { get; set; }

	public virtual DbSet<Handover> Handover { get; set; }

	public virtual DbSet<InwardSpare> InwardSpare { get; set; }

	public virtual DbSet<LeadEnquiry> LeadEnquiry { get; set; }

	public virtual DbSet<LeadEnquiryRevised> LeadEnquiryRevised { get; set; }

	public virtual DbSet<LeadEnquiryRevisedTemp> LeadEnquiryRevisedTemp { get; set; }

	public virtual DbSet<LeadFollowUptbl> LeadFollowUptbl { get; set; }

	public virtual DbSet<Loa> Loa { get; set; }

	public virtual DbSet<Loaccd240> Loaccd240 { get; set; }

	public virtual DbSet<Loaccd320> Loaccd320 { get; set; }

	public virtual DbSet<Loacmos160> Loacmos160 { get; set; }

	public virtual DbSet<Loacmos240> Loacmos240 { get; set; }

	public virtual DbSet<Loacmos320> Loacmos320 { get; set; }

	public virtual DbSet<Loasum> Loasum { get; set; }

	public virtual DbSet<LoginData> LoginData { get; set; }

	public virtual DbSet<LostOrderAnalysis> LostOrderAnalysis { get; set; }

	public virtual DbSet<MachineDispatch> MachineDispatch { get; set; }

	public virtual DbSet<MachineInventory> MachineInventory { get; set; }

	public virtual DbSet<MachineInvoiced> MachineInvoiced { get; set; }

	public virtual DbSet<MailMaster> MailMaster { get; set; }

	public virtual DbSet<MailSendCredentials> MailSendCredentials { get; set; }

	public virtual DbSet<MailSendDetails> MailSendDetails { get; set; }

	public virtual DbSet<MailingTargets> MailingTargets { get; set; }

	public virtual DbSet<MasterProducts> MasterProducts { get; set; }

	public virtual DbSet<MdbbankDetail> MdbbankDetail { get; set; }

	public virtual DbSet<MdbcontactPersonData> MdbcontactPersonData { get; set; }

	public virtual DbSet<MdbgeneralData> MdbgeneralData { get; set; }

	public virtual DbSet<MdbstatutoryNumber> MdbstatutoryNumber { get; set; }

	public virtual DbSet<Memberships> Memberships { get; set; }

	public virtual DbSet<Mfr> Mfr { get; set; }

	public virtual DbSet<Mfrbban> Mfrbban { get; set; }

	public virtual DbSet<Mfrparts> Mfrparts { get; set; }

	public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }

	public virtual DbSet<MinSpareEquipQuantity> MinSpareEquipQuantity { get; set; }

	public virtual DbSet<OaequipGeneralData> OaequipGeneralData { get; set; }

	public virtual DbSet<OaequipPayment> OaequipPayment { get; set; }

	public virtual DbSet<OaequipTableData> OaequipTableData { get; set; }

	public virtual DbSet<Oasapdetails> Oasapdetails { get; set; }

	public virtual DbSet<Ocmaccessories> Ocmaccessories { get; set; }

	public virtual DbSet<OcmaccessoriesNew> OcmaccessoriesNew { get; set; }

	public virtual DbSet<Ocmbrake> Ocmbrake { get; set; }

	public virtual DbSet<Ocmbrakechamfer> Ocmbrakechamfer { get; set; }

	public virtual DbSet<OcmcapacityKw> OcmcapacityKw { get; set; }

	public virtual DbSet<OcmcapacityTph> OcmcapacityTph { get; set; }

	public virtual DbSet<Ocmctcoil> Ocmctcoil { get; set; }

	public virtual DbSet<OcmctcoilNew> OcmctcoilNew { get; set; }

	public virtual DbSet<Ocmdrive> Ocmdrive { get; set; }

	public virtual DbSet<OcmdriveMs> OcmdriveMs { get; set; }

	public virtual DbSet<OcmgrainType> OcmgrainType { get; set; }

	public virtual DbSet<Ocmmotor> Ocmmotor { get; set; }

	public virtual DbSet<Ocmpass> Ocmpass { get; set; }

	public virtual DbSet<OcmpassageSticker> OcmpassageSticker { get; set; }

	public virtual DbSet<Ocmpassname> Ocmpassname { get; set; }

	public virtual DbSet<Ocmpolisher> Ocmpolisher { get; set; }

	public virtual DbSet<OcmpolisherReport> OcmpolisherReport { get; set; }

	public virtual DbSet<Ocmprocess> Ocmprocess { get; set; }

	public virtual DbSet<Ocmprocessname> Ocmprocessname { get; set; }

	public virtual DbSet<OcmreducerRing> OcmreducerRing { get; set; }

	public virtual DbSet<OcmreducerRingNew> OcmreducerRingNew { get; set; }

	public virtual DbSet<Ocmsieve> Ocmsieve { get; set; }

	public virtual DbSet<Ocmsieveslot> Ocmsieveslot { get; set; }

	public virtual DbSet<Ocmstone> Ocmstone { get; set; }

	public virtual DbSet<OcmstoneGrit> OcmstoneGrit { get; set; }

	public virtual DbSet<Ocmwhitner> Ocmwhitner { get; set; }

	public virtual DbSet<OcmwhitnerReport> OcmwhitnerReport { get; set; }

	public virtual DbSet<OutwardMfr> OutwardMfr { get; set; }

	public virtual DbSet<OutwardSpare> OutwardSpare { get; set; }

	public virtual DbSet<OverAllLeadStatus> OverAllLeadStatus { get; set; }

	public virtual DbSet<OverallReport> OverallReport { get; set; }

	public virtual DbSet<ProductModel> ProductModel { get; set; }

	public virtual DbSet<ProductModelSpare> ProductModelSpare { get; set; }

	public virtual DbSet<Products> Products { get; set; }

	public virtual DbSet<Profiles> Profiles { get; set; }

	public virtual DbSet<QgequipGeneralData> QgequipGeneralData { get; set; }

	public virtual DbSet<QgequipPayment> QgequipPayment { get; set; }

	public virtual DbSet<QgequipTableData> QgequipTableData { get; set; }

	public virtual DbSet<QgspareGeneralData> QgspareGeneralData { get; set; }

	public virtual DbSet<QgsparePayment> QgsparePayment { get; set; }

	public virtual DbSet<QgspareTableData> QgspareTableData { get; set; }

	public virtual DbSet<RiceMillHod> RiceMillHod { get; set; }

	public virtual DbSet<RiceOaequipGeneralData> RiceOaequipGeneralData { get; set; }

	public virtual DbSet<RiceOaequipPayment> RiceOaequipPayment { get; set; }

	public virtual DbSet<RiceOaequipTableData> RiceOaequipTableData { get; set; }

	public virtual DbSet<RiceOareportDataTable> RiceOareportDataTable { get; set; }

	public virtual DbSet<RiceOareportDbsheet> RiceOareportDbsheet { get; set; }

	public virtual DbSet<Roles> Roles { get; set; }

	public virtual DbSet<SalesManagerMaster> SalesManagerMaster { get; set; }

	public virtual DbSet<SotTempTbl> SotTempTbl { get; set; }

	public virtual DbSet<SotbyVol> SotbyVol { get; set; }

	public virtual DbSet<SotbyVolCp> SotbyVolCp { get; set; }

	public virtual DbSet<Sotrm> Sotrm { get; set; }

	public virtual DbSet<Sots> Sots { get; set; }

	public virtual DbSet<StatesTbl> StatesTbl { get; set; }

	public virtual DbSet<StoredProceduresMaster> StoredProceduresMaster { get; set; }

	public virtual DbSet<TargetSettings> TargetSettings { get; set; }

	public virtual DbSet<TargetSettingsLead> TargetSettingsLead { get; set; }

	public virtual DbSet<TermsAndConditionMaster> TermsAndConditionMaster { get; set; }

	public virtual DbSet<TestTable> TestTable { get; set; }

	public virtual DbSet<UserLogins> UserLogins { get; set; }

	public virtual DbSet<UserProfile> UserProfile { get; set; }

	public virtual DbSet<Users> Users { get; set; }

	public virtual DbSet<UsersInRoles> UsersInRoles { get; set; }

	public virtual DbSet<VisitFollowUp> VisitFollowUp { get; set; }

	public virtual DbSet<VisitHistory> VisitHistory { get; set; }

	public virtual DbSet<VisitPurpose> VisitPurpose { get; set; }

	public virtual DbSet<Warranty> Warranty { get; set; }

	public virtual DbSet<Zone> Zone { get; set; }

    public virtual DbSet<CHFValueConvs> CHFValueConvs { get; set; }


    public SRKSSynergyContext()
	{
	}

	public SRKSSynergyContext(DbContextOptions<SRKSSynergyContext> options)
		: base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer("Server=localhost;Database=SRKSSynergy;Integrated Security=SSPI;TrustServerCertificate=True;");
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity(delegate(EntityTypeBuilder<Applications> entity)
		{
			entity.HasKey((Applications e) => e.ApplicationId).HasName("PK__Applicat__C93A4C992B3F6F97");
			entity.Property((Applications e) => e.ApplicationId).ValueGeneratedNever();
			entity.Property((Applications e) => e.ApplicationName).IsRequired().HasMaxLength(235);
			entity.Property((Applications e) => e.Description).HasMaxLength(256);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<AutoMailSystem> entity)
		{
			entity.HasKey((AutoMailSystem e) => e.Amsid).HasName("PK_dbo.AutoMailSystem");
			entity.Property((AutoMailSystem e) => e.Amsid).HasColumnName("AMSID");
			entity.Property((AutoMailSystem e) => e.Cpid).HasColumnName("CPID");
			entity.Property((AutoMailSystem e) => e.MailSentDate).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<AutoMailer> entity)
		{
			entity.HasKey((AutoMailer e) => e.Amid).HasName("PK_dbo.AutoMailer");
			entity.Property((AutoMailer e) => e.Amid).HasColumnName("AMID");
			entity.Property((AutoMailer e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((AutoMailer e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((AutoMailer e) => e.Otperiod).HasColumnName("OTPeriod");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<AvailSpareQuantity> entity)
		{
			entity.HasKey((AvailSpareQuantity e) => e.Asid).HasName("PK_dbo.AvailSpareQuantity");
			entity.HasIndex((AvailSpareQuantity e) => e.ProductModelSparesId).HasName("IX_ProductModelSparesID");
			entity.Property((AvailSpareQuantity e) => e.Asid).HasColumnName("ASID");
			entity.Property((AvailSpareQuantity e) => e.Cpid).HasColumnName("CPID");
			entity.Property((AvailSpareQuantity e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((AvailSpareQuantity e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((AvailSpareQuantity e) => e.Month).HasColumnName("month");
			entity.Property((AvailSpareQuantity e) => e.ProductModelSparesId).HasColumnName("ProductModelSparesID");
			entity.Property((AvailSpareQuantity e) => e.Week).HasColumnName("week");
			entity.HasOne((AvailSpareQuantity d) => d.ProductModelSpares).WithMany((ProductModelSpare p) => p.AvailSpareQuantity).HasForeignKey((AvailSpareQuantity d) => d.ProductModelSparesId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.AvailSpareQuantity_dbo.ProductModelSpare_ProductModelSparesID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<BuhlerAdminCc> entity)
		{
			entity.HasKey((BuhlerAdminCc e) => e.Baid).HasName("PK_dbo.BuhlerAdminCC");
			entity.ToTable("BuhlerAdminCC");
			entity.Property((BuhlerAdminCc e) => e.Baid).HasColumnName("BAID");
			entity.Property((BuhlerAdminCc e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((BuhlerAdminCc e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((BuhlerAdminCc e) => e.ZonalManagerId).HasColumnName("ZonalManagerID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<BusinessUnit> entity)
		{
			entity.HasKey((BusinessUnit e) => e.BuId);
			entity.ToTable("businessUnit");
			entity.Property((BusinessUnit e) => e.BuId).HasColumnName("buId");
			entity.Property((BusinessUnit e) => e.BuName).HasColumnName("buName").HasMaxLength(500);
			entity.Property((BusinessUnit e) => e.CreatedBy).HasColumnName("createdBy");
			entity.Property((BusinessUnit e) => e.CreatedOn).HasColumnName("createdOn").HasColumnType("datetime");
			entity.Property((BusinessUnit e) => e.Description).HasColumnName("description");
			entity.Property((BusinessUnit e) => e.IsActive).HasColumnName("isActive").HasDefaultValueSql("((1))");
			entity.Property((BusinessUnit e) => e.IsDeleted).HasColumnName("isDeleted").HasDefaultValueSql("((0))");
			entity.Property((BusinessUnit e) => e.ModifiedBy).HasColumnName("modifiedBy");
			entity.Property((BusinessUnit e) => e.ModifiedOn).HasColumnName("modifiedOn").HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<ChannelPartners> entity)
		{
			entity.HasKey((ChannelPartners e) => e.Cpid).HasName("PK_dbo.ChannelPartners");
			entity.HasIndex((ChannelPartners e) => e.ZoneId).HasName("IX_ZoneID");
			entity.Property((ChannelPartners e) => e.Cpid).HasColumnName("CPID");
			entity.Property((ChannelPartners e) => e.AddressLine1).IsRequired().HasMaxLength(50);
			entity.Property((ChannelPartners e) => e.AddressLine2).IsRequired().HasMaxLength(50);
			entity.Property((ChannelPartners e) => e.AddressLine3).HasMaxLength(50);
			entity.Property((ChannelPartners e) => e.City).IsRequired().HasMaxLength(20);
			entity.Property((ChannelPartners e) => e.CompanyPan).IsRequired().HasColumnName("CompanyPAN")
				.HasMaxLength(13);
			entity.Property((ChannelPartners e) => e.ContactNumLl1).IsRequired().HasColumnName("ContactNumLL1")
				.HasMaxLength(8);
			entity.Property((ChannelPartners e) => e.ContactNumLl2).HasColumnName("ContactNumLL2").HasMaxLength(8);
			entity.Property((ChannelPartners e) => e.Country).IsRequired().HasMaxLength(20);
			entity.Property((ChannelPartners e) => e.Cpname).IsRequired().HasColumnName("CPName")
				.HasMaxLength(40);
			entity.Property((ChannelPartners e) => e.CporgType).HasColumnName("CPOrgType");
			entity.Property((ChannelPartners e) => e.CporgTypeothers).HasColumnName("CPOrgTypeothers").HasMaxLength(20);
			entity.Property((ChannelPartners e) => e.CpuniqueId).HasColumnName("CPUniqueID");
			entity.Property((ChannelPartners e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((ChannelPartners e) => e.Cstnumber).HasColumnName("CSTNumber").HasMaxLength(13);
			entity.Property((ChannelPartners e) => e.Email).IsRequired();
			entity.Property((ChannelPartners e) => e.Fax).HasColumnName("FAX").HasMaxLength(8);
			entity.Property((ChannelPartners e) => e.Isd1).HasMaxLength(3);
			entity.Property((ChannelPartners e) => e.Isd2).HasMaxLength(3);
			entity.Property((ChannelPartners e) => e.Isdf).HasMaxLength(3);
			entity.Property((ChannelPartners e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((ChannelPartners e) => e.Others).HasMaxLength(30);
			entity.Property((ChannelPartners e) => e.PinCode).IsRequired().HasMaxLength(6);
			entity.Property((ChannelPartners e) => e.Postcour).IsRequired().HasColumnName("postcour");
			entity.Property((ChannelPartners e) => e.State).IsRequired();
			entity.Property((ChannelPartners e) => e.Std1).IsRequired().HasMaxLength(5);
			entity.Property((ChannelPartners e) => e.Std2).HasMaxLength(5);
			entity.Property((ChannelPartners e) => e.Stdf).HasMaxLength(5);
			entity.Property((ChannelPartners e) => e.Tin).IsRequired().HasColumnName("TIN")
				.HasMaxLength(20);
			entity.Property((ChannelPartners e) => e.Website).HasMaxLength(40);
			entity.Property((ChannelPartners e) => e.ZoneId).HasColumnName("ZoneID");
			entity.HasOne((ChannelPartners d) => d.Zone).WithMany((Zone p) => p.ChannelPartners).HasForeignKey((ChannelPartners d) => d.ZoneId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.ChannelPartners_dbo.Zone_ZoneID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<ChannelPartnersEngineer> entity)
		{
			entity.Property((ChannelPartnersEngineer e) => e.ChannelPartnersEngineerId).HasColumnName("channelPartnersEngineerId");
			entity.Property((ChannelPartnersEngineer e) => e.Cpid).HasColumnName("cpid");
			entity.Property((ChannelPartnersEngineer e) => e.CreatedBy).HasColumnName("createdBy");
			entity.Property((ChannelPartnersEngineer e) => e.CreatedOn).HasColumnName("createdOn").HasColumnType("datetime");
			entity.Property((ChannelPartnersEngineer e) => e.EmaiId).HasColumnName("emaiId").HasMaxLength(50);
			entity.Property((ChannelPartnersEngineer e) => e.EscalationMails).HasColumnName("escalationMails");
			entity.Property((ChannelPartnersEngineer e) => e.IsActive).HasColumnName("isActive").HasDefaultValueSql("((1))");
			entity.Property((ChannelPartnersEngineer e) => e.IsDeleted).HasColumnName("isDeleted").HasDefaultValueSql("((0))");
			entity.Property((ChannelPartnersEngineer e) => e.ModifiedBy).HasColumnName("modifiedBy");
			entity.Property((ChannelPartnersEngineer e) => e.ModifiedOn).HasColumnName("modifiedOn").HasColumnType("datetime");
			entity.Property((ChannelPartnersEngineer e) => e.Name).HasColumnName("name").HasMaxLength(500);
			entity.Property((ChannelPartnersEngineer e) => e.PhoneNumber).HasColumnName("phoneNumber").HasMaxLength(50);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<CpbankDetails> entity)
		{
			entity.HasKey((CpbankDetails e) => e.Cpbdid).HasName("PK_dbo.CPBankDetails");
			entity.ToTable("CPBankDetails");
			entity.HasIndex((CpbankDetails e) => e.Cpid).HasName("IX_CPID");
			entity.Property((CpbankDetails e) => e.Cpbdid).HasColumnName("CPBDID");
			entity.Property((CpbankDetails e) => e.AccountNumber).HasMaxLength(20);
			entity.Property((CpbankDetails e) => e.BankChequeinfavor).HasMaxLength(40);
			entity.Property((CpbankDetails e) => e.BankName).HasMaxLength(30);
			entity.Property((CpbankDetails e) => e.BranchName).HasMaxLength(30);
			entity.Property((CpbankDetails e) => e.Cpid).HasColumnName("CPID");
			entity.Property((CpbankDetails e) => e.Ifsccode).HasColumnName("IFSCCode").HasMaxLength(11);
			entity.HasOne((CpbankDetails d) => d.Cp).WithMany((ChannelPartners p) => p.CpbankDetails).HasForeignKey((CpbankDetails d) => d.Cpid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.CPBankDetails_dbo.ChannelPartners_CPID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<CpcontactPersonData> entity)
		{
			entity.HasKey((CpcontactPersonData e) => e.Cpcpdid).HasName("PK_dbo.CPContactPersonData");
			entity.ToTable("CPContactPersonData");
			entity.HasIndex((CpcontactPersonData e) => e.Cpid).HasName("IX_CPID");
			entity.Property((CpcontactPersonData e) => e.Cpcpdid).HasColumnName("CPCPDID");
			entity.Property((CpcontactPersonData e) => e.Comments).HasMaxLength(50);
			entity.Property((CpcontactPersonData e) => e.Cpid).HasColumnName("CPID");
			entity.Property((CpcontactPersonData e) => e.Department).HasMaxLength(20);
			entity.Property((CpcontactPersonData e) => e.Designation).HasMaxLength(20);
			entity.Property((CpcontactPersonData e) => e.EmailId).HasColumnName("EmailID");
			entity.Property((CpcontactPersonData e) => e.FirstName).HasMaxLength(20);
			entity.Property((CpcontactPersonData e) => e.Isd1).HasMaxLength(3);
			entity.Property((CpcontactPersonData e) => e.Isd2).HasMaxLength(3);
			entity.Property((CpcontactPersonData e) => e.Isdm1).HasMaxLength(5);
			entity.Property((CpcontactPersonData e) => e.Isdm2).HasMaxLength(5);
			entity.Property((CpcontactPersonData e) => e.KeyActivity).HasMaxLength(20);
			entity.Property((CpcontactPersonData e) => e.LastName).HasMaxLength(20);
			entity.Property((CpcontactPersonData e) => e.MiddleName).HasMaxLength(20);
			entity.Property((CpcontactPersonData e) => e.Mobile1).HasMaxLength(10);
			entity.Property((CpcontactPersonData e) => e.Mobile2).HasMaxLength(10);
			entity.Property((CpcontactPersonData e) => e.PhoneLl1).HasColumnName("PhoneLL1").HasMaxLength(8);
			entity.Property((CpcontactPersonData e) => e.PhoneLl2).HasColumnName("PhoneLL2").HasMaxLength(8);
			entity.Property((CpcontactPersonData e) => e.Photo).HasColumnName("PHOTO");
			entity.Property((CpcontactPersonData e) => e.Std1).HasMaxLength(5);
			entity.Property((CpcontactPersonData e) => e.Std2).HasMaxLength(5);
			entity.Property((CpcontactPersonData e) => e.Titleothers).HasMaxLength(15);
			entity.HasOne((CpcontactPersonData d) => d.Cp).WithMany((ChannelPartners p) => p.CpcontactPersonData).HasForeignKey((CpcontactPersonData d) => d.Cpid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.CPContactPersonData_dbo.ChannelPartners_CPID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<CpmailIdTo> entity)
		{
			entity.HasKey((CpmailIdTo e) => e.Ceid).HasName("PK_dbo.CPMailIdTO");
			entity.ToTable("CPMailIdTO");
			entity.Property((CpmailIdTo e) => e.Ceid).HasColumnName("CEID");
			entity.Property((CpmailIdTo e) => e.Cpid).HasColumnName("CPID");
			entity.Property((CpmailIdTo e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((CpmailIdTo e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((CpmailIdTo e) => e.ZonalManagerId).HasColumnName("ZonalManagerID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Cpperformance> entity)
		{
			entity.HasKey((Cpperformance e) => e.Cppid).HasName("PK_dbo.CPPerformance");
			entity.ToTable("CPPerformance");
			entity.Property((Cpperformance e) => e.Cppid).HasColumnName("CPPID");
			entity.Property((Cpperformance e) => e.Performancepercent).HasColumnName("performancepercent");
			entity.Property((Cpperformance e) => e.Totalvalue).HasColumnName("totalvalue");
			entity.Property((Cpperformance e) => e.TotalvalueCur).HasColumnName("totalvalueCur");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<DistrictPinCodeDetailsTbl> entity)
		{
			entity.HasKey((DistrictPinCodeDetailsTbl e) => e.Dpid).HasName("PK_dbo.DistrictPinCodeDetails_tbl");
			entity.ToTable("DistrictPinCodeDetails_tbl");
			entity.Property((DistrictPinCodeDetailsTbl e) => e.Dpid).HasColumnName("DPID");
			entity.Property((DistrictPinCodeDetailsTbl e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((DistrictPinCodeDetailsTbl e) => e.Pincode).HasColumnName("PINCode");
			entity.Property((DistrictPinCodeDetailsTbl e) => e.StateId).HasColumnName("StateID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<EquipSalesByVal> entity)
		{
			entity.HasKey((EquipSalesByVal e) => e.Esbvalid).HasName("PK_dbo.EquipSalesByVal");
			entity.Property((EquipSalesByVal e) => e.Esbvalid).HasColumnName("ESBVALID");
			entity.Property((EquipSalesByVal e) => e.Qty).HasColumnName("qty");
			entity.Property((EquipSalesByVal e) => e.Value).HasColumnName("value");
			entity.Property((EquipSalesByVal e) => e.Valuecur).HasColumnName("valuecur");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<EquipSalesByVol> entity)
		{
			entity.HasKey((EquipSalesByVol e) => e.Esbvolid).HasName("PK_dbo.EquipSalesByVol");
			entity.Property((EquipSalesByVol e) => e.Esbvolid).HasColumnName("ESBVOLID");
			entity.Property((EquipSalesByVol e) => e.Cpid).HasColumnName("CPID");
			entity.Property((EquipSalesByVol e) => e.Cpname).HasColumnName("CPName");
			entity.Property((EquipSalesByVol e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.Property((EquipSalesByVol e) => e.Qty).HasColumnName("qty");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<EquipSalesByVolAck> entity)
		{
			entity.HasKey((EquipSalesByVolAck e) => e.Esbvolackid).HasName("PK_dbo.EquipSalesByVolAck");
			entity.Property((EquipSalesByVolAck e) => e.Esbvolackid).HasColumnName("ESBVOLACKID");
			entity.Property((EquipSalesByVolAck e) => e.Cpid).HasColumnName("CPID");
			entity.Property((EquipSalesByVolAck e) => e.Cpname).HasColumnName("CPName");
			entity.Property((EquipSalesByVolAck e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.Property((EquipSalesByVolAck e) => e.Qty).HasColumnName("qty");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Handover> entity)
		{
			entity.HasKey((Handover e) => e.Hid).HasName("PK_dbo.Handover");
			entity.HasIndex((Handover e) => e.Cpid).HasName("IX_CPID");
			entity.HasIndex((Handover e) => e.Mdbid).HasName("IX_MDBID");
			entity.Property((Handover e) => e.Hid).HasColumnName("HID");
			entity.Property((Handover e) => e.Buhlercustorderno).HasMaxLength(20);
			entity.Property((Handover e) => e.Buhlerrep).HasMaxLength(20);
			entity.Property((Handover e) => e.Comments).HasMaxLength(160);
			entity.Property((Handover e) => e.Cpid).HasColumnName("CPID");
			entity.Property((Handover e) => e.Custpurorderno).HasMaxLength(20);
			entity.Property((Handover e) => e.Custrep).HasMaxLength(20);
			entity.Property((Handover e) => e.Handeddate).HasColumnType("datetime");
			entity.Property((Handover e) => e.Hodnumber).HasColumnName("HODNumber");
			entity.Property((Handover e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((Handover e) => e.Modelno).HasColumnName("modelno");
			entity.Property((Handover e) => e.Oanum).HasColumnName("OAnum");
			entity.Property((Handover e) => e.Project).HasMaxLength(20);
			entity.HasOne((Handover d) => d.Cp).WithMany((ChannelPartners p) => p.Handover).HasForeignKey((Handover d) => d.Cpid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.Handover_dbo.ChannelPartners_CPID");
			entity.HasOne((Handover d) => d.Mdb).WithMany((MdbgeneralData p) => p.Handover).HasForeignKey((Handover d) => d.Mdbid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.Handover_dbo.MDBGeneralData_MDBID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<InwardSpare> entity)
		{
			entity.HasKey((InwardSpare e) => e.InwardId).HasName("PK_dbo.InwardSpare");
			entity.HasIndex((InwardSpare e) => e.ProductModelSparesId).HasName("IX_ProductModelSparesID");
			entity.Property((InwardSpare e) => e.InwardId).HasColumnName("InwardID");
			entity.Property((InwardSpare e) => e.Ponumber).HasColumnName("PONumber");
			entity.Property((InwardSpare e) => e.ProductModelSparesId).HasColumnName("ProductModelSparesID");
			entity.HasOne((InwardSpare d) => d.ProductModelSpares).WithMany((ProductModelSpare p) => p.InwardSpare).HasForeignKey((InwardSpare d) => d.ProductModelSparesId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.InwardSpare_dbo.ProductModelSpare_ProductModelSparesID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<LeadEnquiry> entity)
		{
			entity.HasKey((LeadEnquiry e) => e.Leid).HasName("PK_dbo.LeadEnquiry");
			entity.Property((LeadEnquiry e) => e.Leid).HasColumnName("LEID");
			entity.Property((LeadEnquiry e) => e.AddressLine1).IsRequired().HasMaxLength(50);
			entity.Property((LeadEnquiry e) => e.AddressLine2).IsRequired().HasMaxLength(50);
			entity.Property((LeadEnquiry e) => e.AddressLine3).HasMaxLength(50);
			entity.Property((LeadEnquiry e) => e.City).IsRequired().HasMaxLength(20);
			entity.Property((LeadEnquiry e) => e.Country).IsRequired().HasMaxLength(20);
			entity.Property((LeadEnquiry e) => e.Cpid).HasColumnName("CPID");
			entity.Property((LeadEnquiry e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((LeadEnquiry e) => e.DateOfMeeting).HasColumnType("datetime");
			entity.Property((LeadEnquiry e) => e.EmailId).HasColumnName("EmailID");
			entity.Property((LeadEnquiry e) => e.EmailIdcontact).HasColumnName("EmailIDContact");
			entity.Property((LeadEnquiry e) => e.FirstName).HasMaxLength(20);
			entity.Property((LeadEnquiry e) => e.IsHod).HasColumnName("IsHOD");
			entity.Property((LeadEnquiry e) => e.Isd1).HasMaxLength(3);
			entity.Property((LeadEnquiry e) => e.Isdc1).HasMaxLength(3);
			entity.Property((LeadEnquiry e) => e.Isdm1).HasMaxLength(5);
			entity.Property((LeadEnquiry e) => e.LastName).HasMaxLength(20);
			entity.Property((LeadEnquiry e) => e.MiddleName).HasMaxLength(20);
			entity.Property((LeadEnquiry e) => e.Mobile1).HasMaxLength(10);
			entity.Property((LeadEnquiry e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((LeadEnquiry e) => e.NotifyDate).HasColumnType("datetime");
			entity.Property((LeadEnquiry e) => e.OrganizationName).IsRequired().HasMaxLength(50);
			entity.Property((LeadEnquiry e) => e.OrganizationType).IsRequired();
			entity.Property((LeadEnquiry e) => e.PhoneLl1).IsRequired().HasColumnName("PhoneLL1")
				.HasMaxLength(8);
			entity.Property((LeadEnquiry e) => e.PhoneLlc1).HasColumnName("PhoneLLc1").HasMaxLength(8);
			entity.Property((LeadEnquiry e) => e.Pincode).IsRequired().HasMaxLength(9);
			entity.Property((LeadEnquiry e) => e.State).IsRequired();
			entity.Property((LeadEnquiry e) => e.Std1).IsRequired().HasMaxLength(5);
			entity.Property((LeadEnquiry e) => e.Stdc1).HasMaxLength(5);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<LeadEnquiryRevised> entity)
		{
			entity.HasKey((LeadEnquiryRevised e) => e.Lerid).HasName("PK_dbo.LeadEnquiryRevised");
			entity.Property((LeadEnquiryRevised e) => e.Lerid).HasColumnName("LERID");
			entity.Property((LeadEnquiryRevised e) => e.Cpid).HasColumnName("CPID");
			entity.Property((LeadEnquiryRevised e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((LeadEnquiryRevised e) => e.DrumSieveMkzm9510).HasColumnName("DrumSieveMKZM9510");
			entity.Property((LeadEnquiryRevised e) => e.EmdmillOperatingDetailsHoursPerDay).HasColumnName("EMDMillOperatingDetailsHoursPerDay");
			entity.Property((LeadEnquiryRevised e) => e.EmdprocessingCapacityMill).HasColumnName("EMDProcessingCapacityMill");
			entity.Property((LeadEnquiryRevised e) => e.EmdprocessingCapacityMillTph).HasColumnName("EMDProcessingCapacityMillTPH");
			entity.Property((LeadEnquiryRevised e) => e.Glcompitator).HasColumnName("GLCompitator");
			entity.Property((LeadEnquiryRevised e) => e.Gmcompitator).HasColumnName("GMCompitator");
			entity.Property((LeadEnquiryRevised e) => e.HullerKw).HasColumnName("HullerKW");
			entity.Property((LeadEnquiryRevised e) => e.IsHod).HasColumnName("IsHOD");
			entity.Property((LeadEnquiryRevised e) => e.LeadDate).HasColumnType("datetime");
			entity.Property((LeadEnquiryRevised e) => e.Leadtype).HasColumnName("leadtype");
			entity.Property((LeadEnquiryRevised e) => e.MachineAspirationChannelMvse).HasColumnName("MachineAspirationChannelMVSE");
			entity.Property((LeadEnquiryRevised e) => e.MachineAutomaticMoistureControlMyfe).HasColumnName("MachineAutomaticMoistureControlMYFE");
			entity.Property((LeadEnquiryRevised e) => e.MachineClassifierMtra).HasColumnName("MachineClassifierMTRA");
			entity.Property((LeadEnquiryRevised e) => e.MachineDampenerMozj).HasColumnName("MachineDampenerMOZJ");
			entity.Property((LeadEnquiryRevised e) => e.MachineDampenerMozl).HasColumnName("MachineDampenerMOZL");
			entity.Property((LeadEnquiryRevised e) => e.MachineDestonerMtsc).HasColumnName("MachineDestonerMTSC");
			entity.Property((LeadEnquiryRevised e) => e.MachinePurifierMqrf).HasColumnName("MachinePurifierMQRF");
			entity.Property((LeadEnquiryRevised e) => e.MachineRollerMillMddk).HasColumnName("MachineRollerMillMDDK");
			entity.Property((LeadEnquiryRevised e) => e.MachineScourerMhxf).HasColumnName("MachineScourerMHXF");
			entity.Property((LeadEnquiryRevised e) => e.MillSectionKw).HasColumnName("MillSectionKW");
			entity.Property((LeadEnquiryRevised e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((LeadEnquiryRevised e) => e.NotifyDate).HasColumnType("datetime");
			entity.Property((LeadEnquiryRevised e) => e.OthersTph).HasColumnName("OthersTPH");
			entity.Property((LeadEnquiryRevised e) => e.PaddyStorageMttotal).HasColumnName("PaddyStorageMTTotal");
			entity.Property((LeadEnquiryRevised e) => e.PlantAutomationTypeRelayOrPlcbased).HasColumnName("PlantAutomationTypeRelayOrPLCBased");
			entity.Property((LeadEnquiryRevised e) => e.PlantAutomationTypeRelayOrPlcbasedMake).HasColumnName("PlantAutomationTypeRelayOrPLCBasedMake");
			entity.Property((LeadEnquiryRevised e) => e.PolisherKw).HasColumnName("PolisherKW");
			entity.Property((LeadEnquiryRevised e) => e.PolisherRpm).HasColumnName("PolisherRPM");
			entity.Property((LeadEnquiryRevised e) => e.PreCleanerClassifierLkga20).HasColumnName("PreCleanerClassifierLKGA20");
			entity.Property((LeadEnquiryRevised e) => e.PreCleanerClassifierTas152).HasColumnName("PreCleanerClassifierTAS152");
			entity.Property((LeadEnquiryRevised e) => e.TotalMt).HasColumnName("TotalMT");
			entity.Property((LeadEnquiryRevised e) => e.Tph2025).HasColumnName("TPH2025");
			entity.Property((LeadEnquiryRevised e) => e.Tph4050).HasColumnName("TPH4050");
			entity.Property((LeadEnquiryRevised e) => e.VisitDate).HasColumnType("datetime");
			entity.Property((LeadEnquiryRevised e) => e.WhitnerKw).HasColumnName("WhitnerKW");
			entity.Property((LeadEnquiryRevised e) => e.WhitnerRpm).HasColumnName("WhitnerRPM");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<LeadEnquiryRevisedTemp> entity)
		{
			entity.HasKey((LeadEnquiryRevisedTemp e) => e.Leridpk).HasName("PK_dbo.LeadEnquiryRevisedTemp");
			entity.Property((LeadEnquiryRevisedTemp e) => e.Leridpk).HasColumnName("LERIDPK");
			entity.Property((LeadEnquiryRevisedTemp e) => e.Cpid).HasColumnName("CPID");
			entity.Property((LeadEnquiryRevisedTemp e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((LeadEnquiryRevisedTemp e) => e.DrumSieveMkzm9510).HasColumnName("DrumSieveMKZM9510");
			entity.Property((LeadEnquiryRevisedTemp e) => e.EmdmillOperatingDetailsHoursPerDay).HasColumnName("EMDMillOperatingDetailsHoursPerDay");
			entity.Property((LeadEnquiryRevisedTemp e) => e.EmdprocessingCapacityMill).HasColumnName("EMDProcessingCapacityMill");
			entity.Property((LeadEnquiryRevisedTemp e) => e.EmdprocessingCapacityMillTph).HasColumnName("EMDProcessingCapacityMillTPH");
			entity.Property((LeadEnquiryRevisedTemp e) => e.Glcompitator).HasColumnName("GLCompitator");
			entity.Property((LeadEnquiryRevisedTemp e) => e.Gmcompitator).HasColumnName("GMCompitator");
			entity.Property((LeadEnquiryRevisedTemp e) => e.HullerKw).HasColumnName("HullerKW");
			entity.Property((LeadEnquiryRevisedTemp e) => e.IsHod).HasColumnName("IsHOD");
			entity.Property((LeadEnquiryRevisedTemp e) => e.LeadDate).HasColumnType("datetime");
			entity.Property((LeadEnquiryRevisedTemp e) => e.Leadtype).HasColumnName("leadtype");
			entity.Property((LeadEnquiryRevisedTemp e) => e.Lerid).HasColumnName("LERID");
			entity.Property((LeadEnquiryRevisedTemp e) => e.MachineAspirationChannelMvse).HasColumnName("MachineAspirationChannelMVSE");
			entity.Property((LeadEnquiryRevisedTemp e) => e.MachineAutomaticMoistureControlMyfe).HasColumnName("MachineAutomaticMoistureControlMYFE");
			entity.Property((LeadEnquiryRevisedTemp e) => e.MachineClassifierMtra).HasColumnName("MachineClassifierMTRA");
			entity.Property((LeadEnquiryRevisedTemp e) => e.MachineDampenerMozj).HasColumnName("MachineDampenerMOZJ");
			entity.Property((LeadEnquiryRevisedTemp e) => e.MachineDampenerMozl).HasColumnName("MachineDampenerMOZL");
			entity.Property((LeadEnquiryRevisedTemp e) => e.MachineDestonerMtsc).HasColumnName("MachineDestonerMTSC");
			entity.Property((LeadEnquiryRevisedTemp e) => e.MachinePurifierMqrf).HasColumnName("MachinePurifierMQRF");
			entity.Property((LeadEnquiryRevisedTemp e) => e.MachineRollerMillMddk).HasColumnName("MachineRollerMillMDDK");
			entity.Property((LeadEnquiryRevisedTemp e) => e.MachineScourerMhxf).HasColumnName("MachineScourerMHXF");
			entity.Property((LeadEnquiryRevisedTemp e) => e.MillSectionKw).HasColumnName("MillSectionKW");
			entity.Property((LeadEnquiryRevisedTemp e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((LeadEnquiryRevisedTemp e) => e.NotifyDate).HasColumnType("datetime");
			entity.Property((LeadEnquiryRevisedTemp e) => e.OthersTph).HasColumnName("OthersTPH");
			entity.Property((LeadEnquiryRevisedTemp e) => e.PaddyStorageMttotal).HasColumnName("PaddyStorageMTTotal");
			entity.Property((LeadEnquiryRevisedTemp e) => e.PlantAutomationTypeRelayOrPlcbased).HasColumnName("PlantAutomationTypeRelayOrPLCBased");
			entity.Property((LeadEnquiryRevisedTemp e) => e.PlantAutomationTypeRelayOrPlcbasedMake).HasColumnName("PlantAutomationTypeRelayOrPLCBasedMake");
			entity.Property((LeadEnquiryRevisedTemp e) => e.PolisherKw).HasColumnName("PolisherKW");
			entity.Property((LeadEnquiryRevisedTemp e) => e.PolisherRpm).HasColumnName("PolisherRPM");
			entity.Property((LeadEnquiryRevisedTemp e) => e.PreCleanerClassifierLkga20).HasColumnName("PreCleanerClassifierLKGA20");
			entity.Property((LeadEnquiryRevisedTemp e) => e.PreCleanerClassifierTas152).HasColumnName("PreCleanerClassifierTAS152");
			entity.Property((LeadEnquiryRevisedTemp e) => e.TotalMt).HasColumnName("TotalMT");
			entity.Property((LeadEnquiryRevisedTemp e) => e.Tph2025).HasColumnName("TPH2025");
			entity.Property((LeadEnquiryRevisedTemp e) => e.Tph4050).HasColumnName("TPH4050");
			entity.Property((LeadEnquiryRevisedTemp e) => e.VisitDate).HasColumnType("datetime");
			entity.Property((LeadEnquiryRevisedTemp e) => e.WhitnerKw).HasColumnName("WhitnerKW");
			entity.Property((LeadEnquiryRevisedTemp e) => e.WhitnerRpm).HasColumnName("WhitnerRPM");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<LeadFollowUptbl> entity)
		{
			entity.HasKey((LeadFollowUptbl e) => e.Lfid).HasName("PK_dbo.LeadFollowUptbl");
			entity.HasIndex((LeadFollowUptbl e) => e.Lerid).HasName("IX_LERID");
			entity.Property((LeadFollowUptbl e) => e.Lfid).HasColumnName("LFID");
			entity.Property((LeadFollowUptbl e) => e.Cpid).HasColumnName("CPID");
			entity.Property((LeadFollowUptbl e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((LeadFollowUptbl e) => e.FollowUpDate).HasColumnType("datetime");
			entity.Property((LeadFollowUptbl e) => e.Lerid).HasColumnName("LERID");
			entity.HasOne((LeadFollowUptbl d) => d.Ler).WithMany((LeadEnquiryRevised p) => p.LeadFollowUptbl).HasForeignKey((LeadFollowUptbl d) => d.Lerid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.LeadFollowUptbl_dbo.LeadEnquiryRevised_LERID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Loa> entity)
		{
			entity.ToTable("LOA");
			entity.Property((Loa e) => e.Loaid).HasColumnName("LOAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Loaccd240> entity)
		{
			entity.HasKey((Loaccd240 e) => e.Loaid).HasName("PK_dbo.LOACCD240");
			entity.ToTable("LOACCD240");
			entity.Property((Loaccd240 e) => e.Loaid).HasColumnName("LOAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Loaccd320> entity)
		{
			entity.HasKey((Loaccd320 e) => e.Loaid).HasName("PK_dbo.LOACCD320");
			entity.ToTable("LOACCD320");
			entity.Property((Loaccd320 e) => e.Loaid).HasColumnName("LOAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Loacmos160> entity)
		{
			entity.HasKey((Loacmos160 e) => e.Loaid).HasName("PK_dbo.LOACMOS160");
			entity.ToTable("LOACMOS160");
			entity.Property((Loacmos160 e) => e.Loaid).HasColumnName("LOAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Loacmos240> entity)
		{
			entity.HasKey((Loacmos240 e) => e.Loaid).HasName("PK_dbo.LOACMOS240");
			entity.ToTable("LOACMOS240");
			entity.Property((Loacmos240 e) => e.Loaid).HasColumnName("LOAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Loacmos320> entity)
		{
			entity.HasKey((Loacmos320 e) => e.Loaid).HasName("PK_dbo.LOACMOS320");
			entity.ToTable("LOACMOS320");
			entity.Property((Loacmos320 e) => e.Loaid).HasColumnName("LOAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Loasum> entity)
		{
			entity.HasKey((Loasum e) => e.Loaid).HasName("PK_dbo.LOASum");
			entity.ToTable("LOASum");
			entity.Property((Loasum e) => e.Loaid).HasColumnName("LOAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<LoginData> entity)
		{
			entity.HasKey((LoginData e) => e.UserLoginId).HasName("PK_dbo.LoginData");
			entity.Property((LoginData e) => e.UserLoginId).HasColumnName("UserLoginID");
			entity.Property((LoginData e) => e.Channelpartnerid).HasColumnName("channelpartnerid");
			entity.Property((LoginData e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((LoginData e) => e.LogOutDate).HasColumnType("datetime");
			entity.Property((LoginData e) => e.LoginDate).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<LostOrderAnalysis> entity)
		{
			entity.HasKey((LostOrderAnalysis e) => e.Loid).HasName("PK_dbo.LostOrderAnalysis");
			entity.Property((LostOrderAnalysis e) => e.Loid).HasColumnName("LOID");
			entity.Property((LostOrderAnalysis e) => e.Comments).HasColumnName("comments");
			entity.Property((LostOrderAnalysis e) => e.Cpid).HasColumnName("CPID");
			entity.Property((LostOrderAnalysis e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((LostOrderAnalysis e) => e.Loadate).HasColumnName("LOADate").HasColumnType("datetime");
			entity.Property((LostOrderAnalysis e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((LostOrderAnalysis e) => e.ProductModelProductModelId).HasColumnName("ProductModel_ProductModelID");
			entity.Property((LostOrderAnalysis e) => e.Qgid).HasColumnName("QGID");
			entity.Property((LostOrderAnalysis e) => e.Qty).HasColumnName("qty").HasMaxLength(50);
			entity.Property((LostOrderAnalysis e) => e.Tsotid).HasColumnName("TSOTID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MachineDispatch> entity)
		{
			entity.HasIndex((MachineDispatch e) => e.Cpid).HasName("IX_CPID");
			entity.HasIndex((MachineDispatch e) => e.MachineInventoryId).HasName("IX_MachineInventoryID");
			entity.HasIndex((MachineDispatch e) => e.Mdbid).HasName("IX_MDBID");
			entity.HasIndex((MachineDispatch e) => e.Oaid).HasName("IX_OAID");
			entity.Property((MachineDispatch e) => e.MachineDispatchId).HasColumnName("MachineDispatchID");
			entity.Property((MachineDispatch e) => e.CommissionDate).HasColumnType("datetime");
			entity.Property((MachineDispatch e) => e.Cpid).HasColumnName("CPID");
			entity.Property((MachineDispatch e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((MachineDispatch e) => e.DispatchDate).HasColumnType("datetime");
			entity.Property((MachineDispatch e) => e.InvoiceDate).HasColumnType("datetime");
			entity.Property((MachineDispatch e) => e.InvoiceNumber).HasMaxLength(160);
			entity.Property((MachineDispatch e) => e.Lrnumber).HasColumnName("LRNumber").HasMaxLength(160);
			entity.Property((MachineDispatch e) => e.MachineInventoryId).HasColumnName("MachineInventoryID");
			entity.Property((MachineDispatch e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((MachineDispatch e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((MachineDispatch e) => e.Oadate).HasColumnName("OADate").HasColumnType("datetime");
			entity.Property((MachineDispatch e) => e.Oaid).HasColumnName("OAID");
			entity.Property((MachineDispatch e) => e.Oanumber).HasColumnName("OANumber");
			entity.Property((MachineDispatch e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.Property((MachineDispatch e) => e.Transporter).HasMaxLength(160);
			entity.HasOne((MachineDispatch d) => d.Cp).WithMany((ChannelPartners p) => p.MachineDispatch).HasForeignKey((MachineDispatch d) => d.Cpid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MachineDispatch_dbo.ChannelPartners_CPID");
			entity.HasOne((MachineDispatch d) => d.MachineInventory).WithMany((MachineInventory p) => p.MachineDispatch).HasForeignKey((MachineDispatch d) => d.MachineInventoryId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MachineDispatch_dbo.MachineInventory_MachineInventoryID");
			entity.HasOne((MachineDispatch d) => d.Mdb).WithMany((MdbgeneralData p) => p.MachineDispatch).HasForeignKey((MachineDispatch d) => d.Mdbid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MachineDispatch_dbo.MDBGeneralData_MDBID");
			entity.HasOne((MachineDispatch d) => d.Oa).WithMany((OaequipGeneralData p) => p.MachineDispatch).HasForeignKey((MachineDispatch d) => d.Oaid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MachineDispatch_dbo.OAEquipGeneralData_OAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MachineInventory> entity)
		{
			entity.HasIndex((MachineInventory e) => e.ProductModelId).HasName("IX_ProductModelID");
			entity.Property((MachineInventory e) => e.MachineInventoryId).HasColumnName("MachineInventoryID");
			entity.Property((MachineInventory e) => e.Cpid).HasColumnName("CPID");
			entity.Property((MachineInventory e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((MachineInventory e) => e.CustomerName).HasMaxLength(160);
			entity.Property((MachineInventory e) => e.MachineSerialNo).IsRequired().HasMaxLength(40);
			entity.Property((MachineInventory e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((MachineInventory e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((MachineInventory e) => e.PlaceStocked).HasMaxLength(160);
			entity.Property((MachineInventory e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.Property((MachineInventory e) => e.Remarks).HasMaxLength(160);
			entity.Property((MachineInventory e) => e.Type).HasMaxLength(40);
			entity.HasOne((MachineInventory d) => d.ProductModel).WithMany((ProductModel p) => p.MachineInventory).HasForeignKey((MachineInventory d) => d.ProductModelId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MachineInventory_dbo.ProductModel_ProductModelID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MachineInvoiced> entity)
		{
			entity.HasKey((MachineInvoiced e) => e.Miid).HasName("PK_dbo.MachineInvoiced");
			entity.Property((MachineInvoiced e) => e.Miid).HasColumnName("MIID");
			entity.Property((MachineInvoiced e) => e.Cpname).HasColumnName("CPName");
			entity.Property((MachineInvoiced e) => e.Qty).HasColumnName("qty");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MailMaster> entity)
		{
			entity.HasKey((MailMaster e) => e.MailId);
			entity.ToTable("mailMaster");
			entity.Property((MailMaster e) => e.MailId).HasColumnName("mailId");
			entity.Property((MailMaster e) => e.CreatedBy).HasColumnName("createdBy");
			entity.Property((MailMaster e) => e.CreatedOn).HasColumnName("createdOn").HasColumnType("datetime");
			entity.Property((MailMaster e) => e.EmailId).HasColumnName("emailId").HasMaxLength(500);
			entity.Property((MailMaster e) => e.IsActive).HasColumnName("isActive");
			entity.Property((MailMaster e) => e.IsDeleted).HasColumnName("isDeleted");
			entity.Property((MailMaster e) => e.ModifiedBy).HasColumnName("modifiedBy");
			entity.Property((MailMaster e) => e.ModifiedOn).HasColumnName("modifiedOn").HasColumnType("datetime");
			entity.Property((MailMaster e) => e.UserId).HasColumnName("userId");
			entity.Property((MailMaster e) => e.UserName).HasColumnName("userName").HasMaxLength(50);
			entity.Property((MailMaster e) => e.UserType).HasColumnName("userType").HasMaxLength(500);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MailSendCredentials> entity)
		{
			entity.HasKey((MailSendCredentials e) => e.Msid).HasName("PK_dbo.MailSendCredentials");
			entity.Property((MailSendCredentials e) => e.Msid).HasColumnName("MSID");
			entity.Property((MailSendCredentials e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((MailSendCredentials e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MailSendDetails> entity)
		{
			entity.HasKey((MailSendDetails e) => e.MailSendId);
			entity.ToTable("mailSendDetails");
			entity.Property((MailSendDetails e) => e.MailSendId).HasColumnName("mailSendId");
			entity.Property((MailSendDetails e) => e.CreatedBy).HasColumnName("createdBy");
			entity.Property((MailSendDetails e) => e.CreatedOn).HasColumnName("createdOn").HasColumnType("datetime");
			entity.Property((MailSendDetails e) => e.EmailId).HasColumnName("emailId").HasMaxLength(500);
			entity.Property((MailSendDetails e) => e.IsActive).HasColumnName("isActive");
			entity.Property((MailSendDetails e) => e.IsDeleted).HasColumnName("isDeleted");
			entity.Property((MailSendDetails e) => e.IsMailSent).HasColumnName("isMailSent");
			entity.Property((MailSendDetails e) => e.ModifiedBy).HasColumnName("modifiedBy");
			entity.Property((MailSendDetails e) => e.ModifiedOn).HasColumnName("modifiedOn").HasColumnType("datetime");
			entity.Property((MailSendDetails e) => e.UserId).HasColumnName("userId");
			entity.Property((MailSendDetails e) => e.UserName).HasColumnName("userName").HasMaxLength(50);
			entity.Property((MailSendDetails e) => e.UserType).HasColumnName("userType").HasMaxLength(500);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MailingTargets> entity)
		{
			entity.HasKey((MailingTargets e) => e.Mtid).HasName("PK_dbo.MailingTargets");
			entity.Property((MailingTargets e) => e.Mtid).HasColumnName("MTID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MasterProducts> entity)
		{
			entity.HasKey((MasterProducts e) => e.MasterProductId).HasName("PK_dbo.MasterProducts");
			entity.Property((MasterProducts e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((MasterProducts e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((MasterProducts e) => e.MasterProductDescriptor).IsRequired().HasMaxLength(160);
			entity.Property((MasterProducts e) => e.MasterProductName).IsRequired().HasMaxLength(20);
			entity.Property((MasterProducts e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MdbbankDetail> entity)
		{
			entity.HasKey((MdbbankDetail e) => e.Mdbbdid).HasName("PK_dbo.MDBBankDetail");
			entity.ToTable("MDBBankDetail");
			entity.HasIndex((MdbbankDetail e) => e.Mdbid).HasName("IX_MDBID");
			entity.Property((MdbbankDetail e) => e.Mdbbdid).HasColumnName("MDBBDID");
			entity.Property((MdbbankDetail e) => e.AccountNumber).HasMaxLength(30);
			entity.Property((MdbbankDetail e) => e.AddressLine1).HasMaxLength(50);
			entity.Property((MdbbankDetail e) => e.AddressLine2).HasMaxLength(50);
			entity.Property((MdbbankDetail e) => e.AddressLine3).HasMaxLength(50);
			entity.Property((MdbbankDetail e) => e.BankChequeinfavor).HasMaxLength(100);
			entity.Property((MdbbankDetail e) => e.BankName).HasMaxLength(40);
			entity.Property((MdbbankDetail e) => e.BranchName).HasMaxLength(40);
			entity.Property((MdbbankDetail e) => e.City).HasMaxLength(20);
			entity.Property((MdbbankDetail e) => e.Country).HasMaxLength(20);
			entity.Property((MdbbankDetail e) => e.Fax).HasColumnName("FAX").HasMaxLength(8);
			entity.Property((MdbbankDetail e) => e.Ifsccode).HasColumnName("IFSCCode").HasMaxLength(11);
			entity.Property((MdbbankDetail e) => e.Isd1).HasMaxLength(3);
			entity.Property((MdbbankDetail e) => e.Isd2).HasMaxLength(3);
			entity.Property((MdbbankDetail e) => e.Isdf).HasMaxLength(3);
			entity.Property((MdbbankDetail e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((MdbbankDetail e) => e.PhoneLl1).HasColumnName("PhoneLL1").HasMaxLength(8);
			entity.Property((MdbbankDetail e) => e.PhoneLl2).HasColumnName("PhoneLL2").HasMaxLength(8);
			entity.Property((MdbbankDetail e) => e.PinCode).HasMaxLength(6);
			entity.Property((MdbbankDetail e) => e.Std1).HasMaxLength(5);
			entity.Property((MdbbankDetail e) => e.Std2).HasMaxLength(5);
			entity.Property((MdbbankDetail e) => e.Stdf).HasMaxLength(5);
			entity.Property((MdbbankDetail e) => e.Website).HasMaxLength(40);
			entity.HasOne((MdbbankDetail d) => d.Mdb).WithMany((MdbgeneralData p) => p.MdbbankDetail).HasForeignKey((MdbbankDetail d) => d.Mdbid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MDBBankDetail_dbo.MDBGeneralData_MDBID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MdbcontactPersonData> entity)
		{
			entity.HasKey((MdbcontactPersonData e) => e.Mdbcpdid).HasName("PK_dbo.MDBContactPersonData");
			entity.ToTable("MDBContactPersonData");
			entity.HasIndex((MdbcontactPersonData e) => e.Mdbid).HasName("IX_MDBID");
			entity.Property((MdbcontactPersonData e) => e.Mdbcpdid).HasColumnName("MDBCPDID");
			entity.Property((MdbcontactPersonData e) => e.Comments).HasMaxLength(100);
			entity.Property((MdbcontactPersonData e) => e.Department).HasMaxLength(40);
			entity.Property((MdbcontactPersonData e) => e.Designation).HasMaxLength(40);
			entity.Property((MdbcontactPersonData e) => e.EmailId).HasColumnName("EmailID");
			entity.Property((MdbcontactPersonData e) => e.FirstName).HasMaxLength(50);
			entity.Property((MdbcontactPersonData e) => e.Isd1).HasMaxLength(3);
			entity.Property((MdbcontactPersonData e) => e.Isd2).HasMaxLength(3);
			entity.Property((MdbcontactPersonData e) => e.Isdm1).HasMaxLength(5);
			entity.Property((MdbcontactPersonData e) => e.Isdm2).HasMaxLength(5);
			entity.Property((MdbcontactPersonData e) => e.KeyActivity).HasMaxLength(100);
			entity.Property((MdbcontactPersonData e) => e.LastName).HasMaxLength(30);
			entity.Property((MdbcontactPersonData e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((MdbcontactPersonData e) => e.MiddleName).HasMaxLength(30);
			entity.Property((MdbcontactPersonData e) => e.Mobile1).HasMaxLength(10);
			entity.Property((MdbcontactPersonData e) => e.Mobile2).HasMaxLength(10);
			entity.Property((MdbcontactPersonData e) => e.PhoneLl1).HasColumnName("PhoneLL1").HasMaxLength(8);
			entity.Property((MdbcontactPersonData e) => e.PhoneLl2).HasColumnName("PhoneLL2").HasMaxLength(8);
			entity.Property((MdbcontactPersonData e) => e.Std1).HasMaxLength(5);
			entity.Property((MdbcontactPersonData e) => e.Std2).HasMaxLength(5);
			entity.Property((MdbcontactPersonData e) => e.Titleothers).HasMaxLength(15);
			entity.HasOne((MdbcontactPersonData d) => d.Mdb).WithMany((MdbgeneralData p) => p.MdbcontactPersonData).HasForeignKey((MdbcontactPersonData d) => d.Mdbid)
				.HasConstraintName("FK_dbo.MDBContactPersonData_dbo.MDBGeneralData_MDBID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MdbgeneralData> entity)
		{
			entity.HasKey((MdbgeneralData e) => e.Mdbid).HasName("PK_dbo.MDBGeneralData");
			entity.ToTable("MDBGeneralData");
			entity.Property((MdbgeneralData e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((MdbgeneralData e) => e.AddressLine3).HasMaxLength(50);
			entity.Property((MdbgeneralData e) => e.AddressLine4).HasMaxLength(50);
			entity.Property((MdbgeneralData e) => e.CompanyUniqueId).HasColumnName("CompanyUniqueID");
			entity.Property((MdbgeneralData e) => e.ContactNumLl2).HasColumnName("ContactNumLL2");
			entity.Property((MdbgeneralData e) => e.Cpid).HasColumnName("CPID");
			entity.Property((MdbgeneralData e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((MdbgeneralData e) => e.EmailId).HasColumnName("EmailID");
			entity.Property((MdbgeneralData e) => e.EmailId2).HasColumnName("EmailID2");
			entity.Property((MdbgeneralData e) => e.Fax).HasColumnName("FAX");
			entity.Property((MdbgeneralData e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((MdbgeneralData e) => e.OrganizationName).IsRequired();
			entity.Property((MdbgeneralData e) => e.OrganizationType).IsRequired();
			entity.Property((MdbgeneralData e) => e.PhoneLl1).HasColumnName("PhoneLL1").HasMaxLength(8);
			entity.Property((MdbgeneralData e) => e.Pincode).IsRequired().HasMaxLength(6);
			entity.Property((MdbgeneralData e) => e.Std1).HasMaxLength(5);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MdbstatutoryNumber> entity)
		{
			entity.HasKey((MdbstatutoryNumber e) => e.Mdbsnid).HasName("PK_dbo.MDBStatutoryNumber");
			entity.ToTable("MDBStatutoryNumber");
			entity.HasIndex((MdbstatutoryNumber e) => e.Mdbid).HasName("IX_MDBID");
			entity.Property((MdbstatutoryNumber e) => e.Mdbsnid).HasColumnName("MDBSNID");
			entity.Property((MdbstatutoryNumber e) => e.CompanyPan).IsRequired().HasColumnName("CompanyPAN")
				.HasMaxLength(13);
			entity.Property((MdbstatutoryNumber e) => e.Cstnumber).HasColumnName("CSTNumber").HasMaxLength(20);
			entity.Property((MdbstatutoryNumber e) => e.ImporterExporterCode).HasMaxLength(20);
			entity.Property((MdbstatutoryNumber e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((MdbstatutoryNumber e) => e.Others).HasMaxLength(40);
			entity.Property((MdbstatutoryNumber e) => e.RegistrationNumber).HasMaxLength(20);
			entity.Property((MdbstatutoryNumber e) => e.ServiceTaxNumber).HasMaxLength(20);
			entity.Property((MdbstatutoryNumber e) => e.TaxDeductionAccountNumber).HasMaxLength(20);
			entity.Property((MdbstatutoryNumber e) => e.Tin).IsRequired().HasColumnName("TIN")
				.HasMaxLength(20);
			entity.HasOne((MdbstatutoryNumber d) => d.Mdb).WithMany((MdbgeneralData p) => p.MdbstatutoryNumber).HasForeignKey((MdbstatutoryNumber d) => d.Mdbid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MDBStatutoryNumber_dbo.MDBGeneralData_MDBID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Memberships> entity)
		{
			entity.HasKey((Memberships e) => e.UserId).HasName("PK__Membersh__1788CC4C2F10007B");
			entity.Property((Memberships e) => e.UserId).ValueGeneratedNever();
			entity.Property((Memberships e) => e.Comment).HasMaxLength(256);
			entity.Property((Memberships e) => e.CreateDate).HasColumnType("datetime");
			entity.Property((Memberships e) => e.Email).HasMaxLength(256);
			entity.Property((Memberships e) => e.FailedPasswordAnswerAttemptWindowsStart).HasColumnType("datetime");
			entity.Property((Memberships e) => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
			entity.Property((Memberships e) => e.LastLockoutDate).HasColumnType("datetime");
			entity.Property((Memberships e) => e.LastLoginDate).HasColumnType("datetime");
			entity.Property((Memberships e) => e.LastPasswordChangedDate).HasColumnType("datetime");
			entity.Property((Memberships e) => e.Password).IsRequired().HasMaxLength(128);
			entity.Property((Memberships e) => e.PasswordAnswer).HasMaxLength(128);
			entity.Property((Memberships e) => e.PasswordQuestion).HasMaxLength(256);
			entity.Property((Memberships e) => e.PasswordSalt).IsRequired().HasMaxLength(128);
			entity.HasOne((Memberships d) => d.Application).WithMany((Applications p) => p.Memberships).HasForeignKey((Memberships d) => d.ApplicationId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("MembershipEntity_Application");
			entity.HasOne((Memberships d) => d.User).WithOne((Users p) => p.Memberships).HasForeignKey((Memberships d) => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("MembershipEntity_User");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Mfr> entity)
		{
			entity.ToTable("MFR");
			entity.HasIndex((Mfr e) => e.Mdbid).HasName("IX_MDBID");
			entity.Property((Mfr e) => e.Mfrid).HasColumnName("MFRID");
			entity.Property((Mfr e) => e.CommissionedBy).HasMaxLength(40);
			entity.Property((Mfr e) => e.Cpid).HasColumnName("CPID");
			entity.Property((Mfr e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Mfr e) => e.IsMfr).HasColumnName("IsMFR");
			entity.Property((Mfr e) => e.IsSpareNeededFromBban).HasColumnName("IsSpareNeededFromBBAN");
			entity.Property((Mfr e) => e.IsSpareTakenFromExistingCpstock).HasColumnName("IsSpareTakenFromExistingCPStock");
			entity.Property((Mfr e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((Mfr e) => e.MfrEnteredBy).HasMaxLength(20);
			entity.Property((Mfr e) => e.MfrTo).HasMaxLength(40);
			entity.Property((Mfr e) => e.Mfrcomment).HasColumnName("MFRComment").HasMaxLength(160);
			entity.Property((Mfr e) => e.Mfrnumber).HasColumnName("MFRNumber");
			entity.Property((Mfr e) => e.ModifiedOn).HasColumnType("datetime");
			entity.HasOne((Mfr d) => d.Mdb).WithMany((MdbgeneralData p) => p.Mfr).HasForeignKey((Mfr d) => d.Mdbid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MFR_dbo.MDBGeneralData_MDBID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Mfrbban> entity)
		{
			entity.HasKey((Mfrbban e) => e.Mfrbbid).HasName("PK_dbo.MFRBBAN");
			entity.ToTable("MFRBBAN");
			entity.Property((Mfrbban e) => e.Mfrbbid).HasColumnName("MFRBBID");
			entity.Property((Mfrbban e) => e.Aoddat).HasColumnName("AODDat");
			entity.Property((Mfrbban e) => e.Code).HasMaxLength(20);
			entity.Property((Mfrbban e) => e.Cpid).HasColumnName("CPID");
			entity.Property((Mfrbban e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Mfrbban e) => e.Mfrid).HasColumnName("MFRID");
			entity.Property((Mfrbban e) => e.MfrnoYear).HasColumnName("MFRNoYear").HasMaxLength(20);
			entity.Property((Mfrbban e) => e.MfrprocessedBy).HasColumnName("MFRProcessedBy").HasMaxLength(20);
			entity.Property((Mfrbban e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((Mfrbban e) => e.RecdOn).HasMaxLength(20);
			entity.Property((Mfrbban e) => e.TanoDat).HasColumnName("TANoDat").HasMaxLength(20);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Mfrparts> entity)
		{
			entity.HasKey((Mfrparts e) => e.Mfrpid).HasName("PK_dbo.MFRParts");
			entity.ToTable("MFRParts");
			entity.HasIndex((Mfrparts e) => e.Mfrid).HasName("IX_MFRID");
			entity.HasIndex((Mfrparts e) => e.ProductModelSparesId).HasName("IX_ProductModelSparesID");
			entity.Property((Mfrparts e) => e.Mfrpid).HasColumnName("MFRPID");
			entity.Property((Mfrparts e) => e.Mfrid).HasColumnName("MFRID");
			entity.Property((Mfrparts e) => e.ProductModelSparesId).HasColumnName("ProductModelSparesID");
			entity.HasOne((Mfrparts d) => d.Mfr).WithMany((Mfr p) => p.Mfrparts).HasForeignKey((Mfrparts d) => d.Mfrid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MFRParts_dbo.MFR_MFRID");
			entity.HasOne((Mfrparts d) => d.ProductModelSpares).WithMany((ProductModelSpare p) => p.Mfrparts).HasForeignKey((Mfrparts d) => d.ProductModelSparesId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MFRParts_dbo.ProductModelSpare_ProductModelSparesID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MigrationHistory> entity)
		{
			entity.HasKey((MigrationHistory e) => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");
			entity.ToTable("__MigrationHistory");
			entity.Property((MigrationHistory e) => e.MigrationId).HasMaxLength(150);
			entity.Property((MigrationHistory e) => e.ContextKey).HasMaxLength(300);
			entity.Property((MigrationHistory e) => e.Model).IsRequired();
			entity.Property((MigrationHistory e) => e.ProductVersion).IsRequired().HasMaxLength(32);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<MinSpareEquipQuantity> entity)
		{
			entity.HasKey((MinSpareEquipQuantity e) => e.Msid).HasName("PK_dbo.MinSpareEquipQuantity");
			entity.HasIndex((MinSpareEquipQuantity e) => e.ProductModelSparesId).HasName("IX_ProductModelSparesID");
			entity.Property((MinSpareEquipQuantity e) => e.Msid).HasColumnName("MSID");
			entity.Property((MinSpareEquipQuantity e) => e.CpminStock).HasColumnName("CPMinStock");
			entity.Property((MinSpareEquipQuantity e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((MinSpareEquipQuantity e) => e.MinDate).HasColumnType("datetime");
			entity.Property((MinSpareEquipQuantity e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((MinSpareEquipQuantity e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.Property((MinSpareEquipQuantity e) => e.ProductModelSparesId).HasColumnName("ProductModelSparesID");
			entity.HasOne((MinSpareEquipQuantity d) => d.ProductModelSpares).WithMany((ProductModelSpare p) => p.MinSpareEquipQuantity).HasForeignKey((MinSpareEquipQuantity d) => d.ProductModelSparesId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.MinSpareEquipQuantity_dbo.ProductModelSpare_ProductModelSparesID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OaequipGeneralData> entity)
		{
			entity.HasKey((OaequipGeneralData e) => e.Oaid).HasName("PK_dbo.OAEquipGeneralData");
			entity.ToTable("OAEquipGeneralData");
			entity.HasIndex((OaequipGeneralData e) => e.Cpid).HasName("IX_CPID");
			entity.HasIndex((OaequipGeneralData e) => e.Mdbid).HasName("IX_MDBID");
			entity.Property((OaequipGeneralData e) => e.Oaid).HasColumnName("OAID");
			entity.Property((OaequipGeneralData e) => e.CompanyUniqueId).HasColumnName("CompanyUniqueID");
			entity.Property((OaequipGeneralData e) => e.Cpid).HasColumnName("CPID");
			entity.Property((OaequipGeneralData e) => e.Cpname).HasColumnName("CPName");
			entity.Property((OaequipGeneralData e) => e.CpquotationNumber).HasColumnName("CPQuotationNumber");
			entity.Property((OaequipGeneralData e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OaequipGeneralData e) => e.IsHod).HasColumnName("IsHOD");
			entity.Property((OaequipGeneralData e) => e.KindAttention).IsRequired().HasMaxLength(320);
			entity.Property((OaequipGeneralData e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((OaequipGeneralData e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((OaequipGeneralData e) => e.Oadate).HasColumnName("OADate").HasColumnType("datetime");
			entity.Property((OaequipGeneralData e) => e.Oanumber).HasColumnName("OANumber");
			entity.Property((OaequipGeneralData e) => e.OarejectComm).HasColumnName("OARejectComm").HasMaxLength(160);
			entity.Property((OaequipGeneralData e) => e.Oastatus).HasColumnName("OAStatus");
			entity.Property((OaequipGeneralData e) => e.Qgid).HasColumnName("QGID");
			entity.Property((OaequipGeneralData e) => e.QuotationDate).HasColumnType("datetime");
			entity.Property((OaequipGeneralData e) => e.Subjectinfo).IsRequired().HasMaxLength(160);
			entity.Property((OaequipGeneralData e) => e.TinNumber).HasMaxLength(20);
			entity.HasOne((OaequipGeneralData d) => d.Cp).WithMany((ChannelPartners p) => p.OaequipGeneralData).HasForeignKey((OaequipGeneralData d) => d.Cpid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OAEquipGeneralData_dbo.ChannelPartners_CPID");
			entity.HasOne((OaequipGeneralData d) => d.Mdb).WithMany((MdbgeneralData p) => p.OaequipGeneralData).HasForeignKey((OaequipGeneralData d) => d.Mdbid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OAEquipGeneralData_dbo.MDBGeneralData_MDBID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OaequipPayment> entity)
		{
			entity.HasKey((OaequipPayment e) => e.Oapid).HasName("PK_dbo.OAEquipPayment");
			entity.ToTable("OAEquipPayment");
			entity.HasIndex((OaequipPayment e) => e.Oaid).HasName("IX_OAID");
			entity.Property((OaequipPayment e) => e.Oapid).HasColumnName("OAPID");
			entity.Property((OaequipPayment e) => e.Annexure).HasColumnName("annexure").HasMaxLength(320);
			entity.Property((OaequipPayment e) => e.Commodity).IsRequired().HasMaxLength(20);
			entity.Property((OaequipPayment e) => e.Cst).IsRequired().HasColumnName("CST")
				.HasMaxLength(400);
			entity.Property((OaequipPayment e) => e.DateofDispatch).IsRequired().HasMaxLength(50);
			entity.Property((OaequipPayment e) => e.Delivery).IsRequired().HasMaxLength(50);
			entity.Property((OaequipPayment e) => e.Freight).IsRequired().HasMaxLength(30);
			entity.Property((OaequipPayment e) => e.Oaid).HasColumnName("OAID");
			entity.Property((OaequipPayment e) => e.Overallprice).HasColumnName("overallprice");
			entity.Property((OaequipPayment e) => e.PaymentTerms).IsRequired().HasMaxLength(100);
			entity.Property((OaequipPayment e) => e.TransitInsu).IsRequired().HasMaxLength(30);
			entity.Property((OaequipPayment e) => e.Transport).IsRequired().HasMaxLength(20);
			entity.Property((OaequipPayment e) => e.Validity).IsRequired().HasMaxLength(70);
			entity.HasOne((OaequipPayment d) => d.Oa).WithMany((OaequipGeneralData p) => p.OaequipPayment).HasForeignKey((OaequipPayment d) => d.Oaid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OAEquipPayment_dbo.OAEquipGeneralData_OAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OaequipTableData> entity)
		{
			entity.HasKey((OaequipTableData e) => e.Oatbid).HasName("PK_dbo.OAEquipTableData");
			entity.ToTable("OAEquipTableData");
			entity.HasIndex((OaequipTableData e) => e.Oaid).HasName("IX_OAID");
			entity.HasIndex((OaequipTableData e) => e.ProductModelId).HasName("IX_ProductModelID");
			entity.Property((OaequipTableData e) => e.Oatbid).HasColumnName("OATBID");
			entity.Property((OaequipTableData e) => e.Exclusion).HasMaxLength(160);
			entity.Property((OaequipTableData e) => e.IsModelHod).HasColumnName("IsModelHOD");
			entity.Property((OaequipTableData e) => e.Oaid).HasColumnName("OAID");
			entity.Property((OaequipTableData e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.HasOne((OaequipTableData d) => d.Oa).WithMany((OaequipGeneralData p) => p.OaequipTableData).HasForeignKey((OaequipTableData d) => d.Oaid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OAEquipTableData_dbo.OAEquipGeneralData_OAID");
			entity.HasOne((OaequipTableData d) => d.ProductModel).WithMany((ProductModel p) => p.OaequipTableData).HasForeignKey((OaequipTableData d) => d.ProductModelId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OAEquipTableData_dbo.ProductModel_ProductModelID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Oasapdetails> entity)
		{
			entity.HasKey((Oasapdetails e) => e.Sapid).HasName("PK_dbo.OASAPDetails");
			entity.ToTable("OASAPDetails");
			entity.Property((Oasapdetails e) => e.Sapid).HasColumnName("SAPID");
			entity.Property((Oasapdetails e) => e.Cpid).HasColumnName("CPID");
			entity.Property((Oasapdetails e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Oasapdetails e) => e.CustId).HasColumnName("CustID");
			entity.Property((Oasapdetails e) => e.DispatchedDate).HasColumnType("datetime");
			entity.Property((Oasapdetails e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((Oasapdetails e) => e.Oadate).HasColumnName("OADate").HasColumnType("datetime");
			entity.Property((Oasapdetails e) => e.OrderId).HasColumnName("OrderID");
			entity.Property((Oasapdetails e) => e.Sapcomments).HasColumnName("SAPComments");
			entity.Property((Oasapdetails e) => e.Sapdate).HasColumnName("SAPDate").HasColumnType("datetime");
			entity.Property((Oasapdetails e) => e.Sapno).HasColumnName("SAPNO");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmaccessories> entity)
		{
			entity.HasKey((Ocmaccessories e) => e.AccessoriesId).HasName("PK_dbo.OCMAccessories");
			entity.ToTable("OCMAccessories");
			entity.HasIndex((Ocmaccessories e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.Property((Ocmaccessories e) => e.AccessoriesId).HasColumnName("AccessoriesID");
			entity.Property((Ocmaccessories e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmaccessories e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((Ocmaccessories e) => e.ModifiedOn).HasColumnType("datetime");
			entity.HasOne((Ocmaccessories d) => d.MasterProduct).WithMany((MasterProducts p) => p.Ocmaccessories).HasForeignKey((Ocmaccessories d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OCMAccessories_dbo.MasterProducts_MasterProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmaccessoriesNew> entity)
		{
			entity.HasKey((OcmaccessoriesNew e) => e.AccessoriesId).HasName("PK_dbo.OCMAccessoriesNew");
			entity.ToTable("OCMAccessoriesNew");
			entity.Property((OcmaccessoriesNew e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OcmaccessoriesNew e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmbrake> entity)
		{
			entity.HasKey((Ocmbrake e) => e.BrakeId).HasName("PK_dbo.OCMBrake");
			entity.ToTable("OCMBrake");
			entity.HasIndex((Ocmbrake e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.Property((Ocmbrake e) => e.BrakeId).HasColumnName("BrakeID");
			entity.Property((Ocmbrake e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmbrake e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((Ocmbrake e) => e.ModifiedOn).HasColumnType("datetime");
			entity.HasOne((Ocmbrake d) => d.MasterProduct).WithMany((MasterProducts p) => p.Ocmbrake).HasForeignKey((Ocmbrake d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OCMBrake_dbo.MasterProducts_MasterProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmbrakechamfer> entity)
		{
			entity.HasKey((Ocmbrakechamfer e) => e.BrakechamferId).HasName("PK_dbo.OCMBrakechamfer");
			entity.ToTable("OCMBrakechamfer");
			entity.Property((Ocmbrakechamfer e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmbrakechamfer e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmcapacityKw> entity)
		{
			entity.HasKey((OcmcapacityKw e) => e.CapacityKwid).HasName("PK_dbo.OCMCapacityKW");
			entity.ToTable("OCMCapacityKW");
			entity.Property((OcmcapacityKw e) => e.CapacityKwid).HasColumnName("CapacityKWId");
			entity.Property((OcmcapacityKw e) => e.CapacityKwname).HasColumnName("CapacityKWName");
			entity.Property((OcmcapacityKw e) => e.CapacityTphid).HasColumnName("CapacityTPHId");
			entity.Property((OcmcapacityKw e) => e.CapacityTphname).HasColumnName("CapacityTPHName");
			entity.Property((OcmcapacityKw e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OcmcapacityKw e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((OcmcapacityKw e) => e.ProductModelId).HasColumnName("ProductModelID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmcapacityTph> entity)
		{
			entity.HasKey((OcmcapacityTph e) => e.CapacityTphid).HasName("PK_dbo.OCMCapacityTPH");
			entity.ToTable("OCMCapacityTPH");
			entity.Property((OcmcapacityTph e) => e.CapacityTphid).HasColumnName("CapacityTPHId");
			entity.Property((OcmcapacityTph e) => e.CapacityTphname).HasColumnName("CapacityTPHName");
			entity.Property((OcmcapacityTph e) => e.CapacityTphshortName).HasColumnName("CapacityTPHShortName");
			entity.Property((OcmcapacityTph e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OcmcapacityTph e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmctcoil> entity)
		{
			entity.HasKey((Ocmctcoil e) => e.CtcoilId).HasName("PK_dbo.OCMCTCoil");
			entity.ToTable("OCMCTCoil");
			entity.HasIndex((Ocmctcoil e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.Property((Ocmctcoil e) => e.CtcoilId).HasColumnName("CTCoilID");
			entity.Property((Ocmctcoil e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmctcoil e) => e.CtcoilDescription).HasColumnName("CTCoilDescription");
			entity.Property((Ocmctcoil e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((Ocmctcoil e) => e.ModifiedOn).HasColumnType("datetime");
			entity.HasOne((Ocmctcoil d) => d.MasterProduct).WithMany((MasterProducts p) => p.Ocmctcoil).HasForeignKey((Ocmctcoil d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OCMCTCoil_dbo.MasterProducts_MasterProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmctcoilNew> entity)
		{
			entity.HasKey((OcmctcoilNew e) => e.OcmctcoilId).HasName("PK_dbo.OCMCTCoilNew");
			entity.ToTable("OCMCTCoilNew");
			entity.Property((OcmctcoilNew e) => e.OcmctcoilId).HasColumnName("OCMCTCoilId");
			entity.Property((OcmctcoilNew e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OcmctcoilNew e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((OcmctcoilNew e) => e.OcmctcoilName).HasColumnName("OCMCTCoilName");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmdrive> entity)
		{
			entity.HasKey((Ocmdrive e) => e.DriveId).HasName("PK_dbo.OCMDrive");
			entity.ToTable("OCMDrive");
			entity.HasIndex((Ocmdrive e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.Property((Ocmdrive e) => e.DriveId).HasColumnName("DriveID");
			entity.Property((Ocmdrive e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmdrive e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((Ocmdrive e) => e.ModifiedOn).HasColumnType("datetime");
			entity.HasOne((Ocmdrive d) => d.MasterProduct).WithMany((MasterProducts p) => p.Ocmdrive).HasForeignKey((Ocmdrive d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OCMDrive_dbo.MasterProducts_MasterProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmdriveMs> entity)
		{
			entity.HasKey((OcmdriveMs e) => e.DriveMsid).HasName("PK_dbo.OCMDriveMS");
			entity.ToTable("OCMDriveMS");
			entity.Property((OcmdriveMs e) => e.DriveMsid).HasColumnName("DriveMSId");
			entity.Property((OcmdriveMs e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OcmdriveMs e) => e.DriveMsname).HasColumnName("DriveMSName");
			entity.Property((OcmdriveMs e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmgrainType> entity)
		{
			entity.HasKey((OcmgrainType e) => e.GrainTypeId).HasName("PK_dbo.OCMGrainType");
			entity.ToTable("OCMGrainType");
			entity.Property((OcmgrainType e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OcmgrainType e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmmotor> entity)
		{
			entity.HasKey((Ocmmotor e) => e.Motorid).HasName("PK_dbo.OCMMotor");
			entity.ToTable("OCMMotor");
			entity.HasIndex((Ocmmotor e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.Property((Ocmmotor e) => e.Motorid).HasColumnName("MOTORID");
			entity.Property((Ocmmotor e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmmotor e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((Ocmmotor e) => e.ModifiedOn).HasColumnType("datetime");
			entity.HasOne((Ocmmotor d) => d.MasterProduct).WithMany((MasterProducts p) => p.Ocmmotor).HasForeignKey((Ocmmotor d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OCMMotor_dbo.MasterProducts_MasterProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmpass> entity)
		{
			entity.HasKey((Ocmpass e) => e.PassId).HasName("PK_dbo.OCMPass");
			entity.ToTable("OCMPass");
			entity.Property((Ocmpass e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmpass e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmpassageSticker> entity)
		{
			entity.HasKey((OcmpassageSticker e) => e.PassageStickerId).HasName("PK_dbo.OCMPassageSticker");
			entity.ToTable("OCMPassageSticker");
			entity.HasIndex((OcmpassageSticker e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.Property((OcmpassageSticker e) => e.PassageStickerId).HasColumnName("PassageStickerID");
			entity.Property((OcmpassageSticker e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OcmpassageSticker e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((OcmpassageSticker e) => e.ModifiedOn).HasColumnType("datetime");
			entity.HasOne((OcmpassageSticker d) => d.MasterProduct).WithMany((MasterProducts p) => p.OcmpassageSticker).HasForeignKey((OcmpassageSticker d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OCMPassageSticker_dbo.MasterProducts_MasterProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmpassname> entity)
		{
			entity.HasKey((Ocmpassname e) => e.PassNameId).HasName("PK_dbo.OCMPassname");
			entity.ToTable("OCMPassname");
			entity.Property((Ocmpassname e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmpassname e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmpolisher> entity)
		{
			entity.HasKey((Ocmpolisher e) => e.Opid).HasName("PK_dbo.OCMPolisher");
			entity.ToTable("OCMPolisher");
			entity.Property((Ocmpolisher e) => e.Opid).HasColumnName("OPID");
			entity.Property((Ocmpolisher e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmpolisher e) => e.Ctcoil).HasColumnName("CTCoil");
			entity.Property((Ocmpolisher e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmpolisherReport> entity)
		{
			entity.HasKey((OcmpolisherReport e) => e.Prid).HasName("PK_dbo.OCMPolisherReport");
			entity.ToTable("OCMPolisherReport");
			entity.Property((OcmpolisherReport e) => e.Prid).HasColumnName("PRID");
			entity.Property((OcmpolisherReport e) => e.Ctcoil).HasColumnName("CTCoil");
			entity.Property((OcmpolisherReport e) => e.CtcoilPartNo).HasColumnName("CTCoilPartNo");
			entity.Property((OcmpolisherReport e) => e.Date).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmprocess> entity)
		{
			entity.HasKey((Ocmprocess e) => e.ProcessId).HasName("PK_dbo.OCMProcess");
			entity.ToTable("OCMProcess");
			entity.Property((Ocmprocess e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmprocess e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmprocessname> entity)
		{
			entity.HasKey((Ocmprocessname e) => e.ProcessNameId).HasName("PK_dbo.OCMProcessname");
			entity.ToTable("OCMProcessname");
			entity.Property((Ocmprocessname e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmprocessname e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmreducerRing> entity)
		{
			entity.HasKey((OcmreducerRing e) => e.ReduceRingId).HasName("PK_dbo.OCMReducerRing");
			entity.ToTable("OCMReducerRing");
			entity.HasIndex((OcmreducerRing e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.Property((OcmreducerRing e) => e.ReduceRingId).HasColumnName("ReduceRingID");
			entity.Property((OcmreducerRing e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OcmreducerRing e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((OcmreducerRing e) => e.ModifiedOn).HasColumnType("datetime");
			entity.HasOne((OcmreducerRing d) => d.MasterProduct).WithMany((MasterProducts p) => p.OcmreducerRing).HasForeignKey((OcmreducerRing d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OCMReducerRing_dbo.MasterProducts_MasterProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmreducerRingNew> entity)
		{
			entity.HasKey((OcmreducerRingNew e) => e.OcmreducerRingId).HasName("PK_dbo.OCMReducerRingNew");
			entity.ToTable("OCMReducerRingNew");
			entity.Property((OcmreducerRingNew e) => e.OcmreducerRingId).HasColumnName("OCMReducerRingId");
			entity.Property((OcmreducerRingNew e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OcmreducerRingNew e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((OcmreducerRingNew e) => e.OcmreducerRingName).HasColumnName("OCMReducerRingName");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmsieve> entity)
		{
			entity.HasKey((Ocmsieve e) => e.SieveId).HasName("PK_dbo.OCMSieve");
			entity.ToTable("OCMSieve");
			entity.HasIndex((Ocmsieve e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.Property((Ocmsieve e) => e.SieveId).HasColumnName("SieveID");
			entity.Property((Ocmsieve e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmsieve e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((Ocmsieve e) => e.ModifiedOn).HasColumnType("datetime");
			entity.HasOne((Ocmsieve d) => d.MasterProduct).WithMany((MasterProducts p) => p.Ocmsieve).HasForeignKey((Ocmsieve d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OCMSieve_dbo.MasterProducts_MasterProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmsieveslot> entity)
		{
			entity.HasKey((Ocmsieveslot e) => e.SieveslotId).HasName("PK_dbo.OCMSieveslot");
			entity.ToTable("OCMSieveslot");
			entity.Property((Ocmsieveslot e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmsieveslot e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmstone> entity)
		{
			entity.HasKey((Ocmstone e) => e.StoneId).HasName("PK_dbo.OCMStone");
			entity.ToTable("OCMStone");
			entity.HasIndex((Ocmstone e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.Property((Ocmstone e) => e.StoneId).HasColumnName("StoneID");
			entity.Property((Ocmstone e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmstone e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((Ocmstone e) => e.ModifiedOn).HasColumnType("datetime");
			entity.HasOne((Ocmstone d) => d.MasterProduct).WithMany((MasterProducts p) => p.Ocmstone).HasForeignKey((Ocmstone d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OCMStone_dbo.MasterProducts_MasterProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmstoneGrit> entity)
		{
			entity.HasKey((OcmstoneGrit e) => e.StoneGritId).HasName("PK_dbo.OCMStoneGrit");
			entity.ToTable("OCMStoneGrit");
			entity.Property((OcmstoneGrit e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OcmstoneGrit e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Ocmwhitner> entity)
		{
			entity.HasKey((Ocmwhitner e) => e.Owid).HasName("PK_dbo.OCMWhitner");
			entity.ToTable("OCMWhitner");
			entity.Property((Ocmwhitner e) => e.Owid).HasColumnName("OWID");
			entity.Property((Ocmwhitner e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Ocmwhitner e) => e.Ctcoil).HasColumnName("CTCoil");
			entity.Property((Ocmwhitner e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OcmwhitnerReport> entity)
		{
			entity.HasKey((OcmwhitnerReport e) => e.Wrid).HasName("PK_dbo.OCMWhitnerReport");
			entity.ToTable("OCMWhitnerReport");
			entity.Property((OcmwhitnerReport e) => e.Wrid).HasColumnName("WRID");
			entity.Property((OcmwhitnerReport e) => e.Ctcoil).HasColumnName("CTCoil");
			entity.Property((OcmwhitnerReport e) => e.CtcoilPartNo).HasColumnName("CTCoilPartNo");
			entity.Property((OcmwhitnerReport e) => e.Date).HasColumnType("datetime");
			entity.Property((OcmwhitnerReport e) => e.MandBstone).HasColumnName("MandBStone");
			entity.Property((OcmwhitnerReport e) => e.WorWdMtr).HasColumnName("WorWdMTR");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OutwardMfr> entity)
		{
			entity.HasKey((OutwardMfr e) => e.Mfrid).HasName("PK_dbo.OutwardMFR");
			entity.ToTable("OutwardMFR");
			entity.HasIndex((OutwardMfr e) => e.Cpid).HasName("IX_CPID");
			entity.HasIndex((OutwardMfr e) => e.ProductModelSparesId).HasName("IX_ProductModelSparesID");
			entity.Property((OutwardMfr e) => e.Mfrid).HasColumnName("MFRId");
			entity.Property((OutwardMfr e) => e.Cpid).HasColumnName("CPID");
			entity.Property((OutwardMfr e) => e.Cpname).HasColumnName("CPName");
			entity.Property((OutwardMfr e) => e.DispatchDate).HasColumnType("datetime");
			entity.Property((OutwardMfr e) => e.FaultSpareDate).HasColumnType("datetime");
			entity.Property((OutwardMfr e) => e.FaultSpareRecivedDateAdmin).HasColumnType("datetime").HasDefaultValueSql("('1900-01-01T00:00:00.000')");
			entity.Property((OutwardMfr e) => e.MachineIssueDate).HasColumnType("datetime");
			entity.Property((OutwardMfr e) => e.Mfrno).HasColumnName("MFRNo");
			entity.Property((OutwardMfr e) => e.OutMonthNo).HasDefaultValueSql("((0))");
			entity.Property((OutwardMfr e) => e.ProductModelSparesId).HasColumnName("ProductModelSparesID");
			entity.Property((OutwardMfr e) => e.SparesRecievedDate).HasColumnType("datetime");
			entity.HasOne((OutwardMfr d) => d.Cp).WithMany((ChannelPartners p) => p.OutwardMfr).HasForeignKey((OutwardMfr d) => d.Cpid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OutwardMFR_dbo.ChannelPartners_CPID");
			entity.HasOne((OutwardMfr d) => d.ProductModelSpares).WithMany((ProductModelSpare p) => p.OutwardMfr).HasForeignKey((OutwardMfr d) => d.ProductModelSparesId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OutwardMFR_dbo.ProductModelSpare_ProductModelSparesID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OutwardSpare> entity)
		{
			entity.HasKey((OutwardSpare e) => e.OutwardId).HasName("PK_dbo.OutwardSpare");
			entity.HasIndex((OutwardSpare e) => e.Cpid).HasName("IX_CPID");
			entity.HasIndex((OutwardSpare e) => e.ProductModelSparesId).HasName("IX_ProductModelSparesID");
			entity.Property((OutwardSpare e) => e.OutwardId).HasColumnName("OutwardID");
			entity.Property((OutwardSpare e) => e.Cpid).HasColumnName("CPID");
			entity.Property((OutwardSpare e) => e.DispatchDate).HasColumnType("datetime");
			entity.Property((OutwardSpare e) => e.InvoiceDate).HasColumnType("datetime");
			entity.Property((OutwardSpare e) => e.OutMonthNo).HasDefaultValueSql("((0))");
			entity.Property((OutwardSpare e) => e.ProductModelSparesId).HasColumnName("ProductModelSparesID");
			entity.HasOne((OutwardSpare d) => d.Cp).WithMany((ChannelPartners p) => p.OutwardSpare).HasForeignKey((OutwardSpare d) => d.Cpid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OutwardSpare_dbo.ChannelPartners_CPID");
			entity.HasOne((OutwardSpare d) => d.ProductModelSpares).WithMany((ProductModelSpare p) => p.OutwardSpare).HasForeignKey((OutwardSpare d) => d.ProductModelSparesId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.OutwardSpare_dbo.ProductModelSpare_ProductModelSparesID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OverAllLeadStatus> entity)
		{
			entity.HasKey((OverAllLeadStatus e) => e.Olsid).HasName("PK_dbo.OverAllLeadStatus");
			entity.Property((OverAllLeadStatus e) => e.Olsid).HasColumnName("OLSID");
			entity.Property((OverAllLeadStatus e) => e.Cpid).HasColumnName("CPID");
			entity.Property((OverAllLeadStatus e) => e.Date).HasColumnType("datetime");
			entity.Property((OverAllLeadStatus e) => e.Id).HasColumnName("ID");
			entity.Property((OverAllLeadStatus e) => e.Leid).HasColumnName("LEID");
			entity.Property((OverAllLeadStatus e) => e.Time).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<OverallReport> entity)
		{
			entity.HasKey((OverallReport e) => e.Orid).HasName("PK_dbo.OverallReport");
			entity.Property((OverallReport e) => e.Orid).HasColumnName("ORID");
			entity.Property((OverallReport e) => e.Blc).HasColumnName("BLC");
			entity.Property((OverallReport e) => e.Bmd).HasColumnName("BMD");
			entity.Property((OverallReport e) => e.Bob).HasColumnName("BOB");
			entity.Property((OverallReport e) => e.Bqs).HasColumnName("BQS");
			entity.Property((OverallReport e) => e.Cpid).HasColumnName("CPID");
			entity.Property((OverallReport e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((OverallReport e) => e.EndDate).HasColumnType("datetime");
			entity.Property((OverallReport e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((OverallReport e) => e.Slc).HasColumnName("SLC");
			entity.Property((OverallReport e) => e.Sob).HasColumnName("SOB");
			entity.Property((OverallReport e) => e.Sqs).HasColumnName("SQS");
			entity.Property((OverallReport e) => e.StartDate).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<ProductModel> entity)
		{
			entity.HasIndex((ProductModel e) => e.ProductId).HasName("IX_ProductID");
			entity.Property((ProductModel e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.Property((ProductModel e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((ProductModel e) => e.DeliveryTime).IsRequired().HasMaxLength(40);
			entity.Property((ProductModel e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((ProductModel e) => e.Pr).HasColumnName("PR");
			entity.Property((ProductModel e) => e.Prmodeldesc).HasColumnName("prmodeldesc");
			entity.Property((ProductModel e) => e.ProductId).HasColumnName("ProductID");
			entity.Property((ProductModel e) => e.ProductModelName).IsRequired().HasMaxLength(40);
			entity.Property((ProductModel e) => e.QuoteVaildTill).IsRequired();
			entity.Property((ProductModel e) => e.UnitPrice).IsRequired();
			entity.HasOne((ProductModel d) => d.Product).WithMany((Products p) => p.ProductModel).HasForeignKey((ProductModel d) => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.ProductModel_dbo.Products_ProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<ProductModelSpare> entity)
		{
			entity.HasKey((ProductModelSpare e) => e.ProductModelSparesId).HasName("PK_dbo.ProductModelSpare");
			entity.Property((ProductModelSpare e) => e.ProductModelSparesId).HasColumnName("ProductModelSparesID");
			entity.Property((ProductModelSpare e) => e.AgentPrice).IsRequired().HasDefaultValueSql("('')");
			entity.Property((ProductModelSpare e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((ProductModelSpare e) => e.CustomerPrice).IsRequired().HasDefaultValueSql("('')");
			entity.Property((ProductModelSpare e) => e.DeliveryTime).IsRequired().HasMaxLength(40);
			entity.Property((ProductModelSpare e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((ProductModelSpare e) => e.ProductModelSparesDesc).IsRequired().HasMaxLength(160);
			entity.Property((ProductModelSpare e) => e.ProductModelSparesName).IsRequired().HasMaxLength(40);
			entity.Property((ProductModelSpare e) => e.QuoteVaildTill).IsRequired();
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Products> entity)
		{
			entity.HasKey((Products e) => e.ProductId).HasName("PK_dbo.Products");
			entity.HasIndex((Products e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.Property((Products e) => e.ProductId).HasColumnName("ProductID");
			entity.Property((Products e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Products e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((Products e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((Products e) => e.ProductDescriptor).IsRequired().HasMaxLength(160);
			entity.Property((Products e) => e.ProductName).IsRequired().HasMaxLength(20);
			entity.HasOne((Products d) => d.MasterProduct).WithMany((MasterProducts p) => p.Products).HasForeignKey((Products d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.Products_dbo.MasterProducts_MasterProductID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Profiles> entity)
		{
			entity.HasKey((Profiles e) => e.UserId).HasName("PK__Profiles__1788CC4C32E0915F");
			entity.Property((Profiles e) => e.UserId).ValueGeneratedNever();
			entity.Property((Profiles e) => e.LastUpdatedDate).HasColumnType("datetime");
			entity.Property((Profiles e) => e.PropertyNames).IsRequired();
			entity.Property((Profiles e) => e.PropertyValueBinary).IsRequired();
			entity.Property((Profiles e) => e.PropertyValueStrings).IsRequired();
			entity.HasOne((Profiles d) => d.User).WithOne((Users p) => p.Profiles).HasForeignKey((Profiles d) => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("ProfileEntity_User");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<QgequipGeneralData> entity)
		{
			entity.HasKey((QgequipGeneralData e) => e.Qgid).HasName("PK_dbo.QGEquipGeneralData");
			entity.ToTable("QGEquipGeneralData");
			entity.HasIndex((QgequipGeneralData e) => e.Mdbid).HasName("IX_MDBID");
			entity.Property((QgequipGeneralData e) => e.Qgid).HasColumnName("QGID");
			entity.Property((QgequipGeneralData e) => e.CompanyUniqueId).HasColumnName("CompanyUniqueID");
			entity.Property((QgequipGeneralData e) => e.Cpid).HasColumnName("CPID");
			entity.Property((QgequipGeneralData e) => e.CpquotationNumber).HasColumnName("CPQuotationNumber");
			entity.Property((QgequipGeneralData e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((QgequipGeneralData e) => e.KindAttention).IsRequired().HasMaxLength(320);
			entity.Property((QgequipGeneralData e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((QgequipGeneralData e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((QgequipGeneralData e) => e.QuotationDate).HasColumnType("datetime");
			entity.Property((QgequipGeneralData e) => e.SalesName).HasMaxLength(30);
			entity.Property((QgequipGeneralData e) => e.Subjectinfo).IsRequired().HasMaxLength(160)
				.HasDefaultValueSql("('')");
			entity.Property((QgequipGeneralData e) => e.VisitHistoryId).HasColumnName("visitHistoryId");
			entity.HasOne((QgequipGeneralData d) => d.Mdb).WithMany((MdbgeneralData p) => p.QgequipGeneralData).HasForeignKey((QgequipGeneralData d) => d.Mdbid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.QGEquipGeneralData_dbo.MDBGeneralData_MDBID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<QgequipPayment> entity)
		{
			entity.HasKey((QgequipPayment e) => e.Qgp).HasName("PK_dbo.QGEquipPayment");
			entity.ToTable("QGEquipPayment");
			entity.HasIndex((QgequipPayment e) => e.Qgid).HasName("IX_QGID");
			entity.Property((QgequipPayment e) => e.Qgp).HasColumnName("QGP");
			entity.Property((QgequipPayment e) => e.Annexure).HasColumnName("annexure").HasMaxLength(320);
			entity.Property((QgequipPayment e) => e.Commodity).IsRequired().HasMaxLength(20);
			entity.Property((QgequipPayment e) => e.Cst).IsRequired().HasColumnName("CST")
				.HasMaxLength(400);
			entity.Property((QgequipPayment e) => e.DateofDispatch).IsRequired().HasMaxLength(50);
			entity.Property((QgequipPayment e) => e.Delivery).IsRequired().HasMaxLength(50);
			entity.Property((QgequipPayment e) => e.Freight).IsRequired().HasMaxLength(30);
			entity.Property((QgequipPayment e) => e.Overallprice).HasColumnName("overallprice");
			entity.Property((QgequipPayment e) => e.PaymentTerms).IsRequired().HasMaxLength(100);
			entity.Property((QgequipPayment e) => e.Qgid).HasColumnName("QGID");
			entity.Property((QgequipPayment e) => e.TransitInsu).IsRequired().HasMaxLength(30);
			entity.Property((QgequipPayment e) => e.Transport).IsRequired().HasMaxLength(20);
			entity.Property((QgequipPayment e) => e.Validity).IsRequired().HasMaxLength(70);
			entity.HasOne((QgequipPayment d) => d.Qg).WithMany((QgequipGeneralData p) => p.QgequipPayment).HasForeignKey((QgequipPayment d) => d.Qgid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.QGEquipPayment_dbo.QGEquipGeneralData_QGID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<QgequipTableData> entity)
		{
			entity.HasKey((QgequipTableData e) => e.Qgtbid).HasName("PK_dbo.QGEquipTableData");
			entity.ToTable("QGEquipTableData");
			entity.HasIndex((QgequipTableData e) => e.ProductModelId).HasName("IX_ProductModelID");
			entity.HasIndex((QgequipTableData e) => e.Qgid).HasName("IX_QGID");
			entity.Property((QgequipTableData e) => e.Qgtbid).HasColumnName("QGTBID");
			entity.Property((QgequipTableData e) => e.Exclusion).HasMaxLength(160);
			entity.Property((QgequipTableData e) => e.IsSotstatus).HasColumnName("IsSOTStatus");
			entity.Property((QgequipTableData e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((QgequipTableData e) => e.ProductId).HasColumnName("ProductID");
			entity.Property((QgequipTableData e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.Property((QgequipTableData e) => e.Qgid).HasColumnName("QGID");
			entity.HasOne((QgequipTableData d) => d.ProductModel).WithMany((ProductModel p) => p.QgequipTableData).HasForeignKey((QgequipTableData d) => d.ProductModelId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.QGEquipTableData_dbo.ProductModel_ProductModelID");
			entity.HasOne((QgequipTableData d) => d.Qg).WithMany((QgequipGeneralData p) => p.QgequipTableData).HasForeignKey((QgequipTableData d) => d.Qgid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.QGEquipTableData_dbo.QGEquipGeneralData_QGID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<QgspareGeneralData> entity)
		{
			entity.HasKey((QgspareGeneralData e) => e.Qgid).HasName("PK_dbo.QGSpareGeneralData");
			entity.ToTable("QGSpareGeneralData");
			entity.HasIndex((QgspareGeneralData e) => e.Mdbid).HasName("IX_MDBID");
			entity.Property((QgspareGeneralData e) => e.Qgid).HasColumnName("QGID");
			entity.Property((QgspareGeneralData e) => e.CompanyUniqueId).HasColumnName("CompanyUniqueID");
			entity.Property((QgspareGeneralData e) => e.Cpid).HasColumnName("CPID");
			entity.Property((QgspareGeneralData e) => e.CpquotationNumber).HasColumnName("CPQuotationNumber");
			entity.Property((QgspareGeneralData e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((QgspareGeneralData e) => e.KindAttention).IsRequired().HasMaxLength(320);
			entity.Property((QgspareGeneralData e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((QgspareGeneralData e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((QgspareGeneralData e) => e.QuotationDate).HasColumnType("datetime");
			entity.Property((QgspareGeneralData e) => e.SalesName).HasColumnName("salesName").HasMaxLength(500);
			entity.Property((QgspareGeneralData e) => e.Subject).IsRequired().HasMaxLength(160);
			entity.Property((QgspareGeneralData e) => e.VisitHistoryId).HasColumnName("visitHistoryId");
			entity.HasOne((QgspareGeneralData d) => d.Mdb).WithMany((MdbgeneralData p) => p.QgspareGeneralData).HasForeignKey((QgspareGeneralData d) => d.Mdbid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.QGSpareGeneralData_dbo.MDBGeneralData_MDBID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<QgsparePayment> entity)
		{
			entity.HasKey((QgsparePayment e) => e.Qgp).HasName("PK_dbo.QGSparePayment");
			entity.ToTable("QGSparePayment");
			entity.HasIndex((QgsparePayment e) => e.Qgid).HasName("IX_QGID");
			entity.Property((QgsparePayment e) => e.Qgp).HasColumnName("QGP");
			entity.Property((QgsparePayment e) => e.Annexure).HasColumnName("annexure").HasMaxLength(320);
			entity.Property((QgsparePayment e) => e.Commodity).IsRequired().HasMaxLength(20);
			entity.Property((QgsparePayment e) => e.Cst).IsRequired().HasColumnName("CST")
				.HasMaxLength(70);
			entity.Property((QgsparePayment e) => e.DateofDispatch).IsRequired().HasMaxLength(50);
			entity.Property((QgsparePayment e) => e.Delivery).IsRequired().HasMaxLength(50);
			entity.Property((QgsparePayment e) => e.Freight).IsRequired().HasMaxLength(30);
			entity.Property((QgsparePayment e) => e.Overallprice).HasColumnName("overallprice");
			entity.Property((QgsparePayment e) => e.PaymentTerms).IsRequired().HasMaxLength(100);
			entity.Property((QgsparePayment e) => e.Qgid).HasColumnName("QGID");
			entity.Property((QgsparePayment e) => e.TransitInsu).IsRequired().HasMaxLength(30);
			entity.Property((QgsparePayment e) => e.Transport).IsRequired().HasMaxLength(20);
			entity.Property((QgsparePayment e) => e.Validity).IsRequired().HasMaxLength(70);
			entity.HasOne((QgsparePayment d) => d.Qg).WithMany((QgspareGeneralData p) => p.QgsparePayment).HasForeignKey((QgsparePayment d) => d.Qgid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.QGSparePayment_dbo.QGSpareGeneralData_QGID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<QgspareTableData> entity)
		{
			entity.HasKey((QgspareTableData e) => e.Qgtbid).HasName("PK_dbo.QGSpareTableData");
			entity.ToTable("QGSpareTableData");
			entity.HasIndex((QgspareTableData e) => e.ProductModelSparesId).HasName("IX_ProductModelSparesID");
			entity.HasIndex((QgspareTableData e) => e.Qgid).HasName("IX_QGID");
			entity.Property((QgspareTableData e) => e.Qgtbid).HasColumnName("QGTBID");
			entity.Property((QgspareTableData e) => e.ProductModelSparesId).HasColumnName("ProductModelSparesID");
			entity.Property((QgspareTableData e) => e.Qgid).HasColumnName("QGID");
			entity.HasOne((QgspareTableData d) => d.ProductModelSpares).WithMany((ProductModelSpare p) => p.QgspareTableData).HasForeignKey((QgspareTableData d) => d.ProductModelSparesId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.QGSpareTableData_dbo.ProductModelSpare_ProductModelSparesID");
			entity.HasOne((QgspareTableData d) => d.Qg).WithMany((QgspareGeneralData p) => p.QgspareTableData).HasForeignKey((QgspareTableData d) => d.Qgid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.QGSpareTableData_dbo.QGSpareGeneralData_QGID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<RiceMillHod> entity)
		{
			entity.HasKey((RiceMillHod e) => e.Rmhodid).HasName("PK_dbo.RiceMillHOD");
			entity.ToTable("RiceMillHOD");
			entity.HasIndex((RiceMillHod e) => e.Cpid).HasName("IX_CPID");
			entity.HasIndex((RiceMillHod e) => e.Mdbid).HasName("IX_MDBID");
			entity.Property((RiceMillHod e) => e.Rmhodid).HasColumnName("RMHODID");
			entity.Property((RiceMillHod e) => e.Cpid).HasColumnName("CPID");
			entity.Property((RiceMillHod e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((RiceMillHod e) => e.Hoddate).HasColumnName("HODDate").HasColumnType("datetime");
			entity.Property((RiceMillHod e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((RiceMillHod e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((RiceMillHod e) => e.Roaid).HasColumnName("ROAID");
			entity.HasOne((RiceMillHod d) => d.Cp).WithMany((ChannelPartners p) => p.RiceMillHod).HasForeignKey((RiceMillHod d) => d.Cpid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.RiceMillHOD_dbo.ChannelPartners_CPID");
			entity.HasOne((RiceMillHod d) => d.Mdb).WithMany((MdbgeneralData p) => p.RiceMillHod).HasForeignKey((RiceMillHod d) => d.Mdbid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.RiceMillHOD_dbo.MDBGeneralData_MDBID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<RiceOaequipGeneralData> entity)
		{
			entity.HasKey((RiceOaequipGeneralData e) => e.Roaid).HasName("PK_dbo.RiceOAEquipGeneralData");
			entity.ToTable("RiceOAEquipGeneralData");
			entity.HasIndex((RiceOaequipGeneralData e) => e.Mdbid).HasName("IX_MDBID");
			entity.HasIndex((RiceOaequipGeneralData e) => e.QgequipGeneralDataQgid).HasName("IX_QGEquipGeneralData_QGID");
			entity.HasIndex((RiceOaequipGeneralData e) => e.QgequipTableDataQgtbid).HasName("IX_QGEquipTableData_QGTBID");
			entity.HasIndex((RiceOaequipGeneralData e) => e.RiceMillHodRmhodid).HasName("IX_RiceMillHOD_RMHODID");
			entity.Property((RiceOaequipGeneralData e) => e.Roaid).HasColumnName("ROAID");
			entity.Property((RiceOaequipGeneralData e) => e.BusinessUnitForSap).HasColumnName("BusinessUnitForSAP");
			entity.Property((RiceOaequipGeneralData e) => e.CommitedDelivery).HasColumnName("commitedDelivery");
			entity.Property((RiceOaequipGeneralData e) => e.CompanyUniqueId).HasColumnName("CompanyUniqueID");
			entity.Property((RiceOaequipGeneralData e) => e.Cpid).HasColumnName("CPID");
			entity.Property((RiceOaequipGeneralData e) => e.Cpname).HasColumnName("CPName").HasMaxLength(50);
			entity.Property((RiceOaequipGeneralData e) => e.CpquotationNumber).HasColumnName("CPQuotationNumber");
			entity.Property((RiceOaequipGeneralData e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((RiceOaequipGeneralData e) => e.CustomerSapidDelvryNo).HasColumnName("CustomerSAPIdDelvryNo");
			entity.Property((RiceOaequipGeneralData e) => e.CustomerSapidNo).HasColumnName("CustomerSAPIdNo");
			entity.Property((RiceOaequipGeneralData e) => e.KindAttention).IsRequired().HasMaxLength(320);
			entity.Property((RiceOaequipGeneralData e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((RiceOaequipGeneralData e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((RiceOaequipGeneralData e) => e.Oadate).HasColumnName("OADate").HasColumnType("datetime");
			entity.Property((RiceOaequipGeneralData e) => e.Oanumber).HasColumnName("OANumber");
			entity.Property((RiceOaequipGeneralData e) => e.OarejectComm).HasColumnName("OARejectComm");
			entity.Property((RiceOaequipGeneralData e) => e.Oastatus).HasColumnName("OAStatus");
			entity.Property((RiceOaequipGeneralData e) => e.PancardNo).HasColumnName("PANCardNo");
			entity.Property((RiceOaequipGeneralData e) => e.QgequipGeneralDataQgid).HasColumnName("QGEquipGeneralData_QGID");
			entity.Property((RiceOaequipGeneralData e) => e.QgequipTableDataQgtbid).HasColumnName("QGEquipTableData_QGTBID");
			entity.Property((RiceOaequipGeneralData e) => e.QuotationDate).HasColumnType("datetime");
			entity.Property((RiceOaequipGeneralData e) => e.RiceMillHodRmhodid).HasColumnName("RiceMillHOD_RMHODID");
			entity.Property((RiceOaequipGeneralData e) => e.Rqgid).HasColumnName("RQGID");
			entity.Property((RiceOaequipGeneralData e) => e.Subjectinfo).IsRequired().HasMaxLength(160);
			entity.Property((RiceOaequipGeneralData e) => e.TinNumber).HasMaxLength(20);
			entity.HasOne((RiceOaequipGeneralData d) => d.Mdb).WithMany((MdbgeneralData p) => p.RiceOaequipGeneralData).HasForeignKey((RiceOaequipGeneralData d) => d.Mdbid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.RiceOAEquipGeneralData_dbo.MDBGeneralData_MDBID");
			entity.HasOne((RiceOaequipGeneralData d) => d.QgequipGeneralDataQg).WithMany((QgequipGeneralData p) => p.RiceOaequipGeneralData).HasForeignKey((RiceOaequipGeneralData d) => d.QgequipGeneralDataQgid)
				.HasConstraintName("FK_dbo.RiceOAEquipGeneralData_dbo.QGEquipGeneralData_QGEquipGeneralData_QGID");
			entity.HasOne((RiceOaequipGeneralData d) => d.QgequipTableDataQgtb).WithMany((QgequipTableData p) => p.RiceOaequipGeneralData).HasForeignKey((RiceOaequipGeneralData d) => d.QgequipTableDataQgtbid)
				.HasConstraintName("FK_dbo.RiceOAEquipGeneralData_dbo.QGEquipTableData_QGEquipTableData_QGTBID");
			entity.HasOne((RiceOaequipGeneralData d) => d.RiceMillHodRmhod).WithMany((RiceMillHod p) => p.RiceOaequipGeneralData).HasForeignKey((RiceOaequipGeneralData d) => d.RiceMillHodRmhodid)
				.HasConstraintName("FK_dbo.RiceOAEquipGeneralData_dbo.RiceMillHOD_RiceMillHOD_RMHODID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<RiceOaequipPayment> entity)
		{
			entity.HasKey((RiceOaequipPayment e) => e.Roapid).HasName("PK_dbo.RiceOAEquipPayment");
			entity.ToTable("RiceOAEquipPayment");
			entity.HasIndex((RiceOaequipPayment e) => e.Roaid).HasName("IX_ROAID");
			entity.Property((RiceOaequipPayment e) => e.Roapid).HasColumnName("ROAPID");
			entity.Property((RiceOaequipPayment e) => e.Annexure).HasColumnName("annexure").HasMaxLength(320);
			entity.Property((RiceOaequipPayment e) => e.Commodity).IsRequired().HasMaxLength(20);
			entity.Property((RiceOaequipPayment e) => e.Cst).IsRequired().HasColumnName("CST")
				.HasMaxLength(400);
			entity.Property((RiceOaequipPayment e) => e.DateofDispatch).IsRequired().HasMaxLength(50);
			entity.Property((RiceOaequipPayment e) => e.Delivery).IsRequired().HasMaxLength(50);
			entity.Property((RiceOaequipPayment e) => e.Freight).IsRequired().HasMaxLength(30);
			entity.Property((RiceOaequipPayment e) => e.Overallprice).HasColumnName("overallprice");
			entity.Property((RiceOaequipPayment e) => e.PaymentTerms).IsRequired().HasMaxLength(100);
			entity.Property((RiceOaequipPayment e) => e.Roaid).HasColumnName("ROAID");
			entity.Property((RiceOaequipPayment e) => e.TransitInsu).IsRequired().HasMaxLength(30);
			entity.Property((RiceOaequipPayment e) => e.Transport).IsRequired().HasMaxLength(20);
			entity.Property((RiceOaequipPayment e) => e.Validity).IsRequired().HasMaxLength(70);
			entity.HasOne((RiceOaequipPayment d) => d.Roa).WithMany((RiceOaequipGeneralData p) => p.RiceOaequipPayment).HasForeignKey((RiceOaequipPayment d) => d.Roaid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.RiceOAEquipPayment_dbo.RiceOAEquipGeneralData_ROAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<RiceOaequipTableData> entity)
		{
			entity.HasKey((RiceOaequipTableData e) => e.Roatbid).HasName("PK_dbo.RiceOAEquipTableData");
			entity.ToTable("RiceOAEquipTableData");
			entity.HasIndex((RiceOaequipTableData e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.HasIndex((RiceOaequipTableData e) => e.ProductId).HasName("IX_ProductID");
			entity.HasIndex((RiceOaequipTableData e) => e.ProductModelId).HasName("IX_ProductModelID");
			entity.HasIndex((RiceOaequipTableData e) => e.Roaid).HasName("IX_ROAID");
			entity.Property((RiceOaequipTableData e) => e.Roatbid).HasColumnName("ROATBID");
			entity.Property((RiceOaequipTableData e) => e.Exclusion).HasMaxLength(160);
			entity.Property((RiceOaequipTableData e) => e.IsSotstatus).HasColumnName("IsSOTStatus");
			entity.Property((RiceOaequipTableData e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((RiceOaequipTableData e) => e.ProductId).HasColumnName("ProductID");
			entity.Property((RiceOaequipTableData e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.Property((RiceOaequipTableData e) => e.Roaid).HasColumnName("ROAID");
			entity.HasOne((RiceOaequipTableData d) => d.MasterProduct).WithMany((MasterProducts p) => p.RiceOaequipTableData).HasForeignKey((RiceOaequipTableData d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.RiceOAEquipTableData_dbo.MasterProducts_MasterProductID");
			entity.HasOne((RiceOaequipTableData d) => d.Product).WithMany((Products p) => p.RiceOaequipTableData).HasForeignKey((RiceOaequipTableData d) => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.RiceOAEquipTableData_dbo.Products_ProductID");
			entity.HasOne((RiceOaequipTableData d) => d.ProductModel).WithMany((ProductModel p) => p.RiceOaequipTableData).HasForeignKey((RiceOaequipTableData d) => d.ProductModelId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.RiceOAEquipTableData_dbo.ProductModel_ProductModelID");
			entity.HasOne((RiceOaequipTableData d) => d.Roa).WithMany((RiceOaequipGeneralData p) => p.RiceOaequipTableData).HasForeignKey((RiceOaequipTableData d) => d.Roaid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.RiceOAEquipTableData_dbo.RiceOAEquipGeneralData_ROAID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<RiceOareportDataTable> entity)
		{
			entity.HasKey((RiceOareportDataTable e) => e.ReportTableId).HasName("PK_dbo.RiceOAReportDataTable");
			entity.ToTable("RiceOAReportDataTable");
			entity.Property((RiceOareportDataTable e) => e.ReportTableId).HasColumnName("ReportTableID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<RiceOareportDbsheet> entity)
		{
			entity.HasKey((RiceOareportDbsheet e) => e.ReportRoaid).HasName("PK_dbo.RiceOAReportDBSheet");
			entity.ToTable("RiceOAReportDBSheet");
			entity.Property((RiceOareportDbsheet e) => e.ReportRoaid).HasColumnName("ReportROAID");
			entity.Property((RiceOareportDbsheet e) => e.Billingaddress).HasColumnName("billingaddress");
			entity.Property((RiceOareportDbsheet e) => e.BusinessUnitForSap).HasColumnName("BusinessUnitForSAP");
			entity.Property((RiceOareportDbsheet e) => e.Comments).HasColumnName("comments");
			entity.Property((RiceOareportDbsheet e) => e.CommitedDelivery).HasColumnName("commitedDelivery");
			entity.Property((RiceOareportDbsheet e) => e.CompanyUniqueId).HasColumnName("CompanyUniqueID");
			entity.Property((RiceOareportDbsheet e) => e.Cpid).HasColumnName("CPID");
			entity.Property((RiceOareportDbsheet e) => e.Cpname).HasColumnName("CPName");
			entity.Property((RiceOareportDbsheet e) => e.CpquotationNumber).HasColumnName("CPQuotationNumber");
			entity.Property((RiceOareportDbsheet e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((RiceOareportDbsheet e) => e.CustomerSapidDelvryNo).HasColumnName("CustomerSAPIdDelvryNo");
			entity.Property((RiceOareportDbsheet e) => e.CustomerSapidNo).HasColumnName("CustomerSAPIdNo");
			entity.Property((RiceOareportDbsheet e) => e.Customercontactperson).HasColumnName("customercontactperson");
			entity.Property((RiceOareportDbsheet e) => e.Customerfaxno).HasColumnName("customerfaxno");
			entity.Property((RiceOareportDbsheet e) => e.Customermailaddress).HasColumnName("customermailaddress");
			entity.Property((RiceOareportDbsheet e) => e.Customermobilenumber).HasColumnName("customermobilenumber");
			entity.Property((RiceOareportDbsheet e) => e.Customertelephonenumber).HasColumnName("customertelephonenumber");
			entity.Property((RiceOareportDbsheet e) => e.Deliveraddress).HasColumnName("deliveraddress");
			entity.Property((RiceOareportDbsheet e) => e.Mdbid).HasColumnName("MDBID");
			entity.Property((RiceOareportDbsheet e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((RiceOareportDbsheet e) => e.Oadate).HasColumnName("OADate").HasColumnType("datetime");
			entity.Property((RiceOareportDbsheet e) => e.Oanumber).HasColumnName("OANumber");
			entity.Property((RiceOareportDbsheet e) => e.OarejectComm).HasColumnName("OARejectComm");
			entity.Property((RiceOareportDbsheet e) => e.Oastatus).HasColumnName("OAStatus");
			entity.Property((RiceOareportDbsheet e) => e.PancardNo).HasColumnName("PANCardNo");
			entity.Property((RiceOareportDbsheet e) => e.QuotationDate).HasColumnType("datetime");
			entity.Property((RiceOareportDbsheet e) => e.Roaid).HasColumnName("ROAID");
			entity.Property((RiceOareportDbsheet e) => e.Rqgid).HasColumnName("RQGID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Roles> entity)
		{
			entity.HasKey((Roles e) => e.RoleId).HasName("PK__Roles__8AFACE1A36B12243");
			entity.Property((Roles e) => e.RoleId).ValueGeneratedNever();
			entity.Property((Roles e) => e.Description).HasMaxLength(256);
			entity.Property((Roles e) => e.RoleName).IsRequired().HasMaxLength(256);
			entity.HasOne((Roles d) => d.Application).WithMany((Applications p) => p.Roles).HasForeignKey((Roles d) => d.ApplicationId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("RoleEntity_Application");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<SalesManagerMaster> entity)
		{
			entity.HasKey((SalesManagerMaster e) => e.ManagerId);
			entity.ToTable("salesManagerMaster");
			entity.Property((SalesManagerMaster e) => e.ManagerId).HasColumnName("managerId");
			entity.Property((SalesManagerMaster e) => e.CpIds).HasColumnName("cpIds");
			entity.Property((SalesManagerMaster e) => e.CreatedBy).HasColumnName("createdBy");
			entity.Property((SalesManagerMaster e) => e.CreatedOn).HasColumnName("createdOn").HasColumnType("datetime");
			entity.Property((SalesManagerMaster e) => e.IsActive).HasColumnName("isActive").HasDefaultValueSql("((1))");
			entity.Property((SalesManagerMaster e) => e.IsDeleted).HasColumnName("isDeleted").HasDefaultValueSql("((0))");
			entity.Property((SalesManagerMaster e) => e.ManagerEmailId).HasColumnName("managerEmailId").HasMaxLength(50);
			entity.Property((SalesManagerMaster e) => e.ManagerName).HasColumnName("managerName").HasMaxLength(500);
			entity.Property((SalesManagerMaster e) => e.ManagerPhoneNumber).HasColumnName("managerPhoneNumber").HasMaxLength(50);
			entity.Property((SalesManagerMaster e) => e.ModifiedBy).HasColumnName("modifiedBy");
			entity.Property((SalesManagerMaster e) => e.ModifiedOn).HasColumnName("modifiedOn").HasColumnType("datetime");
			entity.Property((SalesManagerMaster e) => e.UniqueId).HasColumnName("uniqueId").HasMaxLength(50);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<SotTempTbl> entity)
		{
			entity.HasKey((SotTempTbl e) => e.Tsotid).HasName("PK_dbo.SOT_Temp_tbl");
			entity.ToTable("SOT_Temp_tbl");
			entity.Property((SotTempTbl e) => e.Tsotid).HasColumnName("TSOTID");
			entity.Property((SotTempTbl e) => e.AdditionalComments).HasMaxLength(160);
			entity.Property((SotTempTbl e) => e.Byjtchances).HasColumnName("BYJTChances");
			entity.Property((SotTempTbl e) => e.Cpid).HasColumnName("CPID");
			entity.Property((SotTempTbl e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((SotTempTbl e) => e.Expecteddate).HasColumnType("datetime");
			entity.Property((SotTempTbl e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((SotTempTbl e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((SotTempTbl e) => e.ProductId).HasColumnName("ProductID");
			entity.Property((SotTempTbl e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.Property((SotTempTbl e) => e.Qgid).HasColumnName("QGID");
			entity.Property((SotTempTbl e) => e.Topcompetitors).HasColumnName("TOPCompetitors");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<SotbyVol> entity)
		{
			entity.HasKey((SotbyVol e) => e.Sotbvolid).HasName("PK_dbo.SOTByVol");
			entity.ToTable("SOTByVol");
			entity.Property((SotbyVol e) => e.Sotbvolid).HasColumnName("SOTBVOLID");
			entity.Property((SotbyVol e) => e.Cpid).HasColumnName("CPID");
			entity.Property((SotbyVol e) => e.Cpname).HasColumnName("CPName");
			entity.Property((SotbyVol e) => e.ProductModelId).HasColumnName("ProductModelID");
			entity.Property((SotbyVol e) => e.Qty).HasColumnName("qty");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<SotbyVolCp> entity)
		{
			entity.HasKey((SotbyVolCp e) => e.Sotbvol3id).HasName("PK_dbo.SOTByVolCP");
			entity.ToTable("SOTByVolCP");
			entity.Property((SotbyVolCp e) => e.Sotbvol3id).HasColumnName("SOTBVOL3ID");
			entity.Property((SotbyVolCp e) => e.Qty).HasColumnName("qty");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Sotrm> entity)
		{
			entity.ToTable("SOTRM");
			entity.HasIndex((Sotrm e) => e.Cpid).HasName("IX_CPID");
			entity.HasIndex((Sotrm e) => e.MasterProductId).HasName("IX_MasterProductID");
			entity.HasIndex((Sotrm e) => e.ProductId).HasName("IX_ProductID");
			entity.HasIndex((Sotrm e) => e.Qgid).HasName("IX_QGID");
			entity.Property((Sotrm e) => e.Sotrmid).HasColumnName("SOTRMID");
			entity.Property((Sotrm e) => e.AdditionalComments).HasMaxLength(160);
			entity.Property((Sotrm e) => e.Byjtchances).HasColumnName("BYJTChances");
			entity.Property((Sotrm e) => e.Cpid).HasColumnName("CPID");
			entity.Property((Sotrm e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Sotrm e) => e.Expecteddate).HasColumnType("datetime");
			entity.Property((Sotrm e) => e.MasterProductId).HasColumnName("MasterProductID");
			entity.Property((Sotrm e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((Sotrm e) => e.ProductId).HasColumnName("ProductID");
			entity.Property((Sotrm e) => e.Qgid).HasColumnName("QGID");
			entity.Property((Sotrm e) => e.Topcompetitors).HasColumnName("TOPCompetitors");
			entity.HasOne((Sotrm d) => d.Cp).WithMany((ChannelPartners p) => p.Sotrm).HasForeignKey((Sotrm d) => d.Cpid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.SOTRM_dbo.ChannelPartners_CPID");
			entity.HasOne((Sotrm d) => d.MasterProduct).WithMany((MasterProducts p) => p.Sotrm).HasForeignKey((Sotrm d) => d.MasterProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.SOTRM_dbo.MasterProducts_MasterProductID");
			entity.HasOne((Sotrm d) => d.Product).WithMany((Products p) => p.Sotrm).HasForeignKey((Sotrm d) => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.SOTRM_dbo.Products_ProductID");
			entity.HasOne((Sotrm d) => d.Qg).WithMany((QgequipGeneralData p) => p.Sotrm).HasForeignKey((Sotrm d) => d.Qgid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.SOTRM_dbo.QGEquipGeneralData_QGID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Sots> entity)
		{
			entity.HasKey((Sots e) => e.Sotid).HasName("PK_dbo.SOTs");
			entity.ToTable("SOTs");
			entity.HasIndex((Sots e) => e.Qgid).HasName("IX_QGID");
			entity.Property((Sots e) => e.Sotid).HasColumnName("SOTID");
			entity.Property((Sots e) => e.AdditionalComments).HasMaxLength(160);
			entity.Property((Sots e) => e.Byjtchances).HasColumnName("BYJTChances");
			entity.Property((Sots e) => e.Cpid).HasColumnName("CPID");
			entity.Property((Sots e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((Sots e) => e.Expecteddate).HasColumnType("datetime");
			entity.Property((Sots e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((Sots e) => e.Qgid).HasColumnName("QGID");
			entity.Property((Sots e) => e.Topcompetitors).HasColumnName("TOPCompetitors");
			entity.HasOne((Sots d) => d.Qg).WithMany((QgequipGeneralData p) => p.Sots).HasForeignKey((Sots d) => d.Qgid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.SOTs_dbo.QGEquipGeneralData_QGID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<StatesTbl> entity)
		{
			entity.HasKey((StatesTbl e) => e.StateId).HasName("PK_dbo.States_tbl");
			entity.ToTable("States_tbl");
			entity.Property((StatesTbl e) => e.StateId).HasColumnName("StateID");
			entity.Property((StatesTbl e) => e.CreatedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<StoredProceduresMaster> entity)
		{
			entity.Property((StoredProceduresMaster e) => e.Id).HasColumnName("id");
			entity.Property((StoredProceduresMaster e) => e.CreatedBy).HasColumnName("createdBy").HasMaxLength(200);
			entity.Property((StoredProceduresMaster e) => e.CreatedOn).HasColumnName("createdOn").HasColumnType("datetime");
			entity.Property((StoredProceduresMaster e) => e.IsActive).HasColumnName("isActive").HasDefaultValueSql("((1))");
			entity.Property((StoredProceduresMaster e) => e.IsDeleted).HasColumnName("isDeleted").HasDefaultValueSql("((0))");
			entity.Property((StoredProceduresMaster e) => e.ModifiedBy).HasColumnName("modifiedBy").HasMaxLength(200);
			entity.Property((StoredProceduresMaster e) => e.ModifiedOn).HasColumnName("modifiedOn").HasColumnType("datetime");
			entity.Property((StoredProceduresMaster e) => e.StoredProcedureDesc).HasColumnName("storedProcedureDesc");
			entity.Property((StoredProceduresMaster e) => e.StoredProcedureDisplayName).HasColumnName("storedProcedureDisplayName");
			entity.Property((StoredProceduresMaster e) => e.StoredProcedureRefName).HasColumnName("storedProcedureRefName").HasMaxLength(200);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<TargetSettings> entity)
		{
			entity.HasKey((TargetSettings e) => e.Tsid).HasName("PK_dbo.TargetSettings");
			entity.Property((TargetSettings e) => e.Tsid).HasColumnName("TSID");
			entity.Property((TargetSettings e) => e.Cpid).HasColumnName("CPID");
			entity.Property((TargetSettings e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((TargetSettings e) => e.ModifiedOn).HasColumnType("datetime");
			entity.Property((TargetSettings e) => e.TargetMonthId).HasColumnName("TargetMonthID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<TargetSettingsLead> entity)
		{
			entity.HasKey((TargetSettingsLead e) => e.Tsid).HasName("PK_dbo.TargetSettingsLead");
			entity.Property((TargetSettingsLead e) => e.Tsid).HasColumnName("TSID");
			entity.Property((TargetSettingsLead e) => e.Cpid).HasColumnName("CPID");
			entity.Property((TargetSettingsLead e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((TargetSettingsLead e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<TermsAndConditionMaster> entity)
		{
			entity.HasKey((TermsAndConditionMaster e) => e.TermsAndConditionId);
			entity.ToTable("termsAndConditionMaster");
			entity.Property((TermsAndConditionMaster e) => e.TermsAndConditionId).HasColumnName("termsAndConditionId");
			entity.Property((TermsAndConditionMaster e) => e.Comodity).HasColumnName("comodity");
			entity.Property((TermsAndConditionMaster e) => e.CreatedBy).HasColumnName("createdBy").HasMaxLength(50);
			entity.Property((TermsAndConditionMaster e) => e.CreatedOn).HasColumnName("createdOn").HasColumnType("datetime");
			entity.Property((TermsAndConditionMaster e) => e.Delivery).HasColumnName("delivery");
			entity.Property((TermsAndConditionMaster e) => e.Dod).HasColumnName("dod");
			entity.Property((TermsAndConditionMaster e) => e.Freight).HasColumnName("freight");
			entity.Property((TermsAndConditionMaster e) => e.Gst).HasColumnName("gst");
			entity.Property((TermsAndConditionMaster e) => e.IsActive).HasColumnName("isActive").HasDefaultValueSql("((1))");
			entity.Property((TermsAndConditionMaster e) => e.IsDeleted).HasColumnName("isDeleted").HasDefaultValueSql("((0))");
			entity.Property((TermsAndConditionMaster e) => e.ModeOfTransport).HasColumnName("modeOfTransport");
			entity.Property((TermsAndConditionMaster e) => e.ModifiedBy).HasColumnName("modifiedBy").HasMaxLength(50);
			entity.Property((TermsAndConditionMaster e) => e.ModifiedOn).HasColumnName("modifiedOn").HasColumnType("datetime");
			entity.Property((TermsAndConditionMaster e) => e.PackingAndForwarding).HasColumnName("packingAndForwarding");
			entity.Property((TermsAndConditionMaster e) => e.PaymentTerms).HasColumnName("paymentTerms");
			entity.Property((TermsAndConditionMaster e) => e.TermsAndConditionFor).HasColumnName("termsAndConditionFor").HasMaxLength(500);
			entity.Property((TermsAndConditionMaster e) => e.TransitInsurance).HasColumnName("transitInsurance");
			entity.Property((TermsAndConditionMaster e) => e.Validity).HasColumnName("validity");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<TestTable> entity)
		{
			entity.Property((TestTable e) => e.TestTableId).HasColumnName("TestTableID");
			entity.Property((TestTable e) => e.CreatedOn).HasColumnType("datetime");
			entity.Property((TestTable e) => e.ModifiedOn).HasColumnType("datetime");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<UserLogins> entity)
		{
			entity.HasKey((UserLogins e) => e.UserId).HasName("PK_dbo.UserLogins");
			entity.Property((UserLogins e) => e.UserId).HasColumnName("UserID").ValueGeneratedNever();
			entity.Property((UserLogins e) => e.Answer).HasMaxLength(40);
			entity.Property((UserLogins e) => e.Cpid).HasColumnName("CPID");
			entity.Property((UserLogins e) => e.Designation).HasMaxLength(40);
			entity.Property((UserLogins e) => e.Email).HasColumnName("email");
			entity.Property((UserLogins e) => e.FirstName).IsRequired().HasMaxLength(40);
			entity.Property((UserLogins e) => e.Isd1).HasMaxLength(3);
			entity.Property((UserLogins e) => e.LastName).HasMaxLength(40);
			entity.Property((UserLogins e) => e.MiddleName).HasMaxLength(40);
			entity.Property((UserLogins e) => e.PhoneNo).HasMaxLength(9);
			entity.Property((UserLogins e) => e.Std1).HasMaxLength(5);
			entity.Property((UserLogins e) => e.Username).HasMaxLength(40);
			entity.Property((UserLogins e) => e.ZoneId).HasColumnName("ZoneID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<UserProfile> entity)
		{
			entity.HasKey((UserProfile e) => e.UserId).HasName("PK_dbo.UserProfile");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Users> entity)
		{
			entity.HasKey((Users e) => e.UserId).HasName("PK__Users__1788CC4C3A81B327");
			entity.HasIndex((Users e) => e.UserName).HasName("IDX_UserName");
			entity.Property((Users e) => e.UserId).ValueGeneratedNever();
			entity.Property((Users e) => e.LastActivityDate).HasColumnType("datetime");
			entity.Property((Users e) => e.UserName).IsRequired().HasMaxLength(50);
			entity.HasOne((Users d) => d.Application).WithMany((Applications p) => p.Users).HasForeignKey((Users d) => d.ApplicationId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("User_Application");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<UsersInRoles> entity)
		{
			entity.HasKey((UsersInRoles e) => new { e.UserId, e.RoleId }).HasName("PK__UsersInR__AF2760AD3E52440B");
			entity.HasOne((UsersInRoles d) => d.Role).WithMany((Roles p) => p.UsersInRoles).HasForeignKey((UsersInRoles d) => d.RoleId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("UsersInRole_Role");
			entity.HasOne((UsersInRoles d) => d.User).WithMany((Users p) => p.UsersInRoles).HasForeignKey((UsersInRoles d) => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("UsersInRole_User");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<VisitFollowUp> entity)
		{
			entity.ToTable("visitFollowUp");
			entity.Property((VisitFollowUp e) => e.VisitFollowUpId).HasColumnName("visitFollowUpId");
			entity.Property((VisitFollowUp e) => e.CreatedBy).HasColumnName("createdBy");
			entity.Property((VisitFollowUp e) => e.CreatedOn).HasColumnName("createdOn").HasColumnType("datetime");
			entity.Property((VisitFollowUp e) => e.IsActive).IsRequired().HasColumnName("isActive")
				.HasDefaultValueSql("((1))");
			entity.Property((VisitFollowUp e) => e.IsDeleted).HasColumnName("isDeleted").HasDefaultValueSql("((0))");
			entity.Property((VisitFollowUp e) => e.IsReminderSent).HasColumnName("isReminderSent").HasDefaultValueSql("((0))");
			entity.Property((VisitFollowUp e) => e.ModifiedBy).HasColumnName("modifiedBy");
			entity.Property((VisitFollowUp e) => e.ModifiedOn).HasColumnName("modifiedOn").HasColumnType("datetime");
			entity.Property((VisitFollowUp e) => e.NextVisitDate).HasColumnName("nextVisitDate").HasColumnType("datetime");
			entity.Property((VisitFollowUp e) => e.VisitComment).HasColumnName("visitComment").HasMaxLength(500);
			entity.Property((VisitFollowUp e) => e.VisitId).HasColumnName("visitId");
			entity.Property((VisitFollowUp e) => e.VisitPurpose).HasColumnName("visitPurpose");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<VisitHistory> entity)
		{
			entity.ToTable("visitHistory");
			entity.Property((VisitHistory e) => e.VisitHistoryId).HasColumnName("visitHistoryId");
			entity.Property((VisitHistory e) => e.BuId).HasColumnName("buId");
			entity.Property((VisitHistory e) => e.Comments).HasColumnName("comments");
			entity.Property((VisitHistory e) => e.CompanyUniqueId).HasColumnName("companyUniqueId").HasMaxLength(500);
			entity.Property((VisitHistory e) => e.CpEnginneerId).HasColumnName("cpEnginneerId");
			entity.Property((VisitHistory e) => e.CreatedBy).HasColumnName("createdBy");
			entity.Property((VisitHistory e) => e.CreatedOn).HasColumnName("createdOn").HasColumnType("datetime");
			entity.Property((VisitHistory e) => e.IsActive).HasColumnName("isActive").HasDefaultValueSql("((1))");
			entity.Property((VisitHistory e) => e.IsCall).HasColumnName("isCall").HasDefaultValueSql("((0))");
			entity.Property((VisitHistory e) => e.IsDeleted).HasColumnName("isDeleted").HasDefaultValueSql("((0))");
			entity.Property((VisitHistory e) => e.MasterProducts).HasColumnName("masterProducts");
			entity.Property((VisitHistory e) => e.ModifiedBy).HasColumnName("modifiedBy");
			entity.Property((VisitHistory e) => e.ModifiedOn).HasColumnName("modifiedOn").HasColumnType("datetime");
			entity.Property((VisitHistory e) => e.NextVisitDate).HasColumnName("nextVisitDate").HasColumnType("datetime");
			entity.Property((VisitHistory e) => e.ProductModelId).HasColumnName("productModelId");
			entity.Property((VisitHistory e) => e.SalesManagerId).HasColumnName("salesManagerId");
			entity.Property((VisitHistory e) => e.UserId).HasColumnName("userId").HasMaxLength(500);
			entity.Property((VisitHistory e) => e.VisitDateTime).HasColumnName("visitDateTime").HasColumnType("datetime");
			entity.Property((VisitHistory e) => e.VisitPurpose).HasColumnName("visitPurpose");
			entity.Property((VisitHistory e) => e.VisitStatus).HasColumnName("visitStatus").HasMaxLength(500);
			entity.Property((VisitHistory e) => e.VisitType).HasColumnName("visitType");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<VisitPurpose> entity)
		{
			entity.ToTable("visitPurpose");
			entity.Property((VisitPurpose e) => e.VisitPurposeId).HasColumnName("visitPurposeId");
			entity.Property((VisitPurpose e) => e.CreatedBy).HasColumnName("createdBy");
			entity.Property((VisitPurpose e) => e.CreatedOn).HasColumnName("createdOn").HasColumnType("datetime");
			entity.Property((VisitPurpose e) => e.Description).HasColumnName("description");
			entity.Property((VisitPurpose e) => e.IsActive).HasColumnName("isActive").HasDefaultValueSql("((1))");
			entity.Property((VisitPurpose e) => e.IsDeleted).HasColumnName("isDeleted").HasDefaultValueSql("((0))");
			entity.Property((VisitPurpose e) => e.ModifiedOn).HasColumnName("modifiedOn").HasColumnType("datetime");
			entity.Property((VisitPurpose e) => e.Modifiedby).HasColumnName("modifiedby");
			entity.Property((VisitPurpose e) => e.VisitPurpose1).HasColumnName("visitPurpose").HasMaxLength(500);
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Warranty> entity)
		{
			entity.HasKey((Warranty e) => e.Wid).HasName("PK_dbo.Warranty");
			entity.HasIndex((Warranty e) => e.Cpid).HasName("IX_CPID");
			entity.Property((Warranty e) => e.Wid).HasColumnName("WID");
			entity.Property((Warranty e) => e.Cpid).HasColumnName("CPID");
			entity.Property((Warranty e) => e.HandoverDate).HasColumnType("datetime");
			entity.HasOne((Warranty d) => d.Cp).WithMany((ChannelPartners p) => p.Warranty).HasForeignKey((Warranty d) => d.Cpid)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_dbo.Warranty_dbo.ChannelPartners_CPID");
		});
		modelBuilder.Entity(delegate(EntityTypeBuilder<Zone> entity)
		{
			entity.Property((Zone e) => e.ZoneId).HasColumnName("ZoneID");
		});

        modelBuilder.Entity(delegate (EntityTypeBuilder<CHFValueConvs> entity)
        {
            entity.HasKey((CHFValueConvs e) => e.id).HasName("pk_dbo.CHFValueConvs");
            entity.Property((CHFValueConvs e) => e.CurrentCHFValue).HasColumnName("CurrentCHFValue");
        });

    }
}

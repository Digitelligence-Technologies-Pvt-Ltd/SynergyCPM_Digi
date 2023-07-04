using System;
using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class LeadEnquiryRevised
{
	public int Lerid { get; set; }

	public string NameofCollector { get; set; }

	public DateTime LeadDate { get; set; }

	public string MillName { get; set; }

	public string MillType { get; set; }

	public string AddressLine1 { get; set; }

	public string AddressLine2 { get; set; }

	public string City { get; set; }

	public string Pincode { get; set; }

	public string State { get; set; }

	public string Country { get; set; }

	public string Prefix { get; set; }

	public string OwnerName { get; set; }

	public string MobNo { get; set; }

	public string EmailId { get; set; }

	public string Isd { get; set; }

	public string Std { get; set; }

	public string TelNo { get; set; }

	public bool EnquiryTypeExistingMill { get; set; }

	public bool EnquiryTypeNewMill { get; set; }

	public bool EnquiryTypeCustomerServiceUpgrade { get; set; }

	public bool TypeOfMillPaddytoRice { get; set; }

	public bool TypeOfMillBrownRiceToWhiteRice { get; set; }

	public bool TypeOfMillReprocess { get; set; }

	public bool TypeOfPaddyProcessLongGrain { get; set; }

	public bool TypeOfPaddyProcessMediumGrain { get; set; }

	public bool TypeOfPaddyProcessRountGrain { get; set; }

	public bool ConditioningRaw { get; set; }

	public bool ConditioningSteamed { get; set; }

	public bool ConditioningParBoiled { get; set; }

	public string ConditioningParBoiledPaddyMoisture { get; set; }

	public string ConditioningParBoiledBulkDensity { get; set; }

	public bool PaddyVarietyBasmati { get; set; }

	public bool PaddyVarietyNonBasmati { get; set; }

	public string PaddyVarietyVarietyName { get; set; }

	public bool EmdprocessingCapacityMill { get; set; }

	public string EmdprocessingCapacityMillTph { get; set; }

	public string EmdmillOperatingDetailsHoursPerDay { get; set; }

	public bool PreCleaningCapacity { get; set; }

	public bool Tph2025 { get; set; }

	public bool Tph4050 { get; set; }

	public bool Others { get; set; }

	public string OthersTph { get; set; }

	public string PaddyStorageMttotal { get; set; }

	public string TotalMt { get; set; }

	public string NoOfSilos { get; set; }

	public string MillDetailsSuppliersName { get; set; }

	public string YearInstalled { get; set; }

	public bool MillSectionHuller { get; set; }

	public string MillSectionNos { get; set; }

	public string MillSectionKw { get; set; }

	public bool MillSectionHullSeperate { get; set; }

	public string MillSectionHullSeperateNos { get; set; }

	public bool PaddyTable { get; set; }

	public string PaddyTableNos { get; set; }

	public bool ThinThickGrader { get; set; }

	public string ThinThickGraderNos { get; set; }

	public string ThinThickGraderDumps { get; set; }

	public bool Whitner { get; set; }

	public string WhitnerNos { get; set; }

	public string WhitnerKw { get; set; }

	public string WhitnerRpm { get; set; }

	public bool Polisher { get; set; }

	public string PolisherNos { get; set; }

	public string PolisherKw { get; set; }

	public string PolisherRpm { get; set; }

	public bool LengthGrader { get; set; }

	public string LengthGraderNos { get; set; }

	public string GradeSize1 { get; set; }

	public string GradeSize2 { get; set; }

	public string GradeSize3 { get; set; }

	public string GradeSize4 { get; set; }

	public bool ColorSorter { get; set; }

	public string ColorSorterMake { get; set; }

	public string ColorSorterChannels { get; set; }

	public string ColorSorterPrimary { get; set; }

	public string ColorSorterSecondary { get; set; }

	public bool PackingMachine { get; set; }

	public string PackingMachineMake { get; set; }

	public string PackingMachineNos { get; set; }

	public string PackingMachineKgs1 { get; set; }

	public string PackingMachineKgs2 { get; set; }

	public string PackingMachineBrandName { get; set; }

	public bool PlantAutomationTypeRelayOrPlcbased { get; set; }

	public string PlantAutomationTypeRelayOrPlcbasedMake { get; set; }

	public string CustomerRequirement1 { get; set; }

	public string CustomerRequirement2 { get; set; }

	public string CustomerRequirement3 { get; set; }

	public string CustomerRequirement4 { get; set; }

	public string CustomerRequirement5 { get; set; }

	public string CommentsActionExpected { get; set; }

	public DateTime? CreatedOn { get; set; }

	public string CreatedBy { get; set; }

	public DateTime? ModifiedOn { get; set; }

	public string ModifiedBy { get; set; }

	public int IsDeleted { get; set; }

	public int IsStatus { get; set; }

	public int IsDrop { get; set; }

	public int Cpid { get; set; }

	public string LeadTime { get; set; }

	public int IsTime { get; set; }

	public int? IsCount { get; set; }

	public int? IsHod { get; set; }

	public DateTime? NotifyDate { get; set; }

	public string Latitude { get; set; }

	public string Longitude { get; set; }

	public bool Cleaner { get; set; }

	public int CleanerNo { get; set; }

	public bool Magnet { get; set; }

	public int MagnetNo { get; set; }

	public bool DeStoner { get; set; }

	public int DeStonerNo { get; set; }

	public bool ColorSorter1 { get; set; }

	public string ColorSorterMake1 { get; set; }

	public string ColorSorterChannels1 { get; set; }

	public string ColorSorterPrimary1 { get; set; }

	public string ColorSorterSecondary1 { get; set; }

	public string CustReqYeorsNo { get; set; }

	public string Capacity { get; set; }

	public string TypeOfReq { get; set; }

	public bool MachineClassifier { get; set; }

	public bool MachineDestoner { get; set; }

	public bool MachineHullerSeperator { get; set; }

	public bool MachinePaddySeperator { get; set; }

	public bool MachineThickThinGrader { get; set; }

	public bool MachineWhitner { get; set; }

	public bool MachinePolisher { get; set; }

	public bool MachineSorter { get; set; }

	public string TimeFrame { get; set; }

	public string AssignTo { get; set; }

	public string ColorSorterTertiary { get; set; }

	public string ColorSorterTertiary1 { get; set; }

	public bool Huller { get; set; }

	public string HullerNos { get; set; }

	public string HullerKw { get; set; }

	public string CommodityType { get; set; }

	public string EnquiryHandledBy { get; set; }

	public string WhitenerSupplierName { get; set; }

	public string PolisherSupplierName { get; set; }

	public string HullerSupplierName { get; set; }

	public string ColorSorterSupplierName { get; set; }

	public string ColorSorter1SupplierName { get; set; }

	public DateTime VisitDate { get; set; }

	public string WhitnerYear { get; set; }

	public string PolisherYear { get; set; }

	public string HullerYear { get; set; }

	public string QuotesToBeSubmitted { get; set; }

	public string ColorSorter1Year { get; set; }

	public string ColorSorter2Year { get; set; }

	public string SorterModel { get; set; }

	public bool MachineScourerMhxf { get; set; }

	public bool MachineAspirationChannelMvse { get; set; }

	public bool MachineDampenerMozj { get; set; }

	public bool MachineDampenerMozl { get; set; }

	public bool MachineAutomaticMoistureControlMyfe { get; set; }

	public bool MachineRollerMillMddk { get; set; }

	public bool MachinePurifierMqrf { get; set; }

	public bool PreCleanerClassifierTas152 { get; set; }

	public bool DrumSieveMkzm9510 { get; set; }

	public bool PreCleanerClassifierLkga20 { get; set; }

	public bool MachineClassifierMtra { get; set; }

	public bool MachineDestonerMtsc { get; set; }

	public string Gmcompitator { get; set; }

	public string Glcompitator { get; set; }

	public string Leadtype { get; set; }

	public virtual ICollection<LeadFollowUptbl> LeadFollowUptbl { get; set; }

	public LeadEnquiryRevised()
	{
		LeadFollowUptbl = new HashSet<LeadFollowUptbl>();
	}
}

using System.Collections.Generic;

namespace SynergyWebServices.DAL;

public class Zone
{
	public int ZoneId { get; set; }

	public string ZoneName { get; set; }

	public string ZonalMangerName { get; set; }

	public int IsDeactive { get; set; }

	public virtual ICollection<ChannelPartners> ChannelPartners { get; set; }

	public Zone()
	{
		ChannelPartners = new HashSet<ChannelPartners>();
	}
}

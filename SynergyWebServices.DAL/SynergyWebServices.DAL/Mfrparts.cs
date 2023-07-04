namespace SynergyWebServices.DAL;

public class Mfrparts
{
	public int Mfrpid { get; set; }

	public int Mfrid { get; set; }

	public int ProductModelSparesId { get; set; }

	public int Quantity { get; set; }

	public string ModelDesc { get; set; }

	public virtual Mfr Mfr { get; set; }

	public virtual ProductModelSpare ProductModelSpares { get; set; }
}

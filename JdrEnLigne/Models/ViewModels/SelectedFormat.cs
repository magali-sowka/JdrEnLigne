namespace JdrEnLigne.Models.ViewModels
{
	public class SelectedFormat
	{
		public Discriminator Format { get; set; }
		public bool Selected { get; set; }

		public SelectedFormat(Discriminator format, bool selected)
		{
			Format = format;
			Selected = selected;
		}
	}
}

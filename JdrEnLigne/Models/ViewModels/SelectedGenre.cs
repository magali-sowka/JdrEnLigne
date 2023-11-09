namespace JdrEnLigne.Models.ViewModels
{
    public class SelectedGenre
    {
        private int genreId;
        private string libelle;
        private bool selected;

        public SelectedGenre(int genreId, string libelle, bool selected)
        {
            this.genreId = genreId;
            this.libelle = libelle;
            this.selected = selected;
        }
        public int GenreId
        {
            get { return genreId; }
        }
        public string Libelle
        {
            get { return libelle; }
        }
        public bool Selected
        {
            get { return selected; }
        }
    }
}

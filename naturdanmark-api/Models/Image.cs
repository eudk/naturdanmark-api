namespace naturdanmark_api.Models
{
    public class Image
    {
        public const int MB = 1024 * 1024;
        public const int MAX_SIZE = 8 * MB;
        public int ObservationID { get; set; }
        public byte[] Photo { get; set; }

        public Image(byte[] photo, int id = 0)
        {
            ObservationID = id;
            Photo = photo;
        }

        public void validate()
        {
            if (Photo == null) {
                throw new ArgumentNullException(nameof(Photo));
            }

            if (Photo.Length > MAX_SIZE) {
                throw new ArgumentException(nameof(Photo));
            }
        }
    }
}

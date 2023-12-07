using System.ComponentModel.DataAnnotations;

namespace naturdanmark_api.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public int ObservationID { get; set; }
        public string Photo { get; set; }

        public Image(string photo = null, int observationID = 1, int id = 0)
        {
            Id = id;
            ObservationID = observationID;
            Photo = photo;
        }

        public void validate()
        {
            if (Photo == null) {
                throw new ArgumentNullException(nameof(Photo));
            }

            if (Photo.Length > 1024*1024*8) { //8MB
                throw new ArgumentException(nameof(Photo));
            }
        }
    }
}

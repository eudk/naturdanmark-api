using System.ComponentModel.DataAnnotations;

namespace naturdanmark_api.Models
{
    public class Image
    {
        [Key]
        public int ObservationID { get; set; }
        public byte[]? Foto { get; set; }

        public Image(byte[] foto = null, int observationID = 0)
        {
            ObservationID = observationID;
            Foto = foto;
        }

        public void validate()
        {
            if (Foto == null) {
                throw new ArgumentNullException(nameof(Foto));
            }

            if (Foto.Length > 1024*1024*8) { //8MB
                throw new ArgumentException(nameof(Foto));
            }
        }
    }
}

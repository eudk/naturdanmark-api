using System.Security.Cryptography.X509Certificates;

namespace naturdanmark_api.Models
{
    public class Observation
    {
        public int ID { get; set; }

        public string AnimalName { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public double longtitudes { get; set; }

        public double lattitudes { get; set; }

        public string? Picture { get; set; }

        public void ValidateAnimalName()
        {
            if(AnimalName==null)
            {
                throw new ArgumentNullException();
            }
            if(AnimalName=="")
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidateLength()
        {
            if(longtitudes > 180 || longtitudes < -180)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidateBredde()
        {
            if(lattitudes > 90 || lattitudes < -90)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}

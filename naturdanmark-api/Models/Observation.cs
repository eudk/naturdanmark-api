using System.Security.Cryptography.X509Certificates;

namespace naturdanmark_api.Models
{
    public class Observation
    {
        public int ID { get; set; }

        public string AnimalName { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Længde { get; set; }

        public string Bredde { get; set; }

        public string? Billede { get; set; }

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
            if (Længde == null)
            {
                throw new ArgumentNullException();
            }
            if (Længde == "")
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidateBredde()
        {
            if (Bredde == null)
            {
                throw new ArgumentNullException();
            }
            if (Bredde == "")
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}

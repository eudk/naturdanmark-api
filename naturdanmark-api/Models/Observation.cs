using System.Security.Cryptography.X509Certificates;

namespace naturdanmark_api.Models
{
    public class Observation
    {
        public int ID { get; set; }

        public string AnimalName { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public double Længde { get; set; }

        public double Bredde { get; set; }

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
            if(Længde>180 || Længde< -180)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidateBredde()
        {
            if(Bredde>90 || Bredde< -90)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}

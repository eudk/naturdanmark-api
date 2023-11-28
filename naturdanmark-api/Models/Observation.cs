using System.Security.Cryptography.X509Certificates;

namespace naturdanmark_api.Models
{
    public class Observation
    {
        public int ID { get; set; }

        public string AnimalName { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string? Picture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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

        /// <summary>
        /// Kaster en exception hvis Longtitudes ikke er mellem 180 og -180 grader
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> kaster exception videre</exception>
        public void ValidateLongtitudes()
        {
            if(Longitude > 180 || Longitude < -180)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// en funktion som bruges til at se om Lattiude er mellem 90 og -90 grader
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">laver en exception hvis Lattiude er mellem 90 og -90 grader</exception>
        public void ValidateLattitudes()
        {
            if(Latitude > 90 || Latitude < -90)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Funktion som bruges til at validere en observation ved at køre alle validere funktioner igennem
        /// </summary>
        public void ValidateAll()
        {
            ValidateAnimalName();
            ValidateLattitudes();
            ValidateLongtitudes();
        }
    }
}

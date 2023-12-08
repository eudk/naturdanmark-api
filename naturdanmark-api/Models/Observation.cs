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

        public DateTime PostingDate { get; set; }

        public string UserName { get; set; }

        /// <summary>
        /// Implementatuon of Haversine's formula to calculate distance. Returns 0 if longitude or latitude is null
        /// </summary>
        public double DistanceFrom(double? latitude,  double? longitude)
        {
            if (longitude == null || latitude == null)
            {
                return 0;
            }
            double lon2 = (double)longitude;
            double lat2 = (double)latitude;
            
            int R = 6371000;
            double φ1 = Latitude * Math.PI / 180;
            double φ2 = lat2 * Math.PI / 180;
            double Δφ = (lat2 - Latitude) * Math.PI / 180;
            double Δλ = (lon2 - Longitude) * Math.PI / 180;

            double a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                       Math.Cos(φ1) * Math.Cos(φ2) *
                       Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
            double d = R * c;

            return d;
        }
        
        /// <summary>
        /// Kaster en Exception hvis AnimalName i en Observation er en tom string eller lig med Null
        /// </summary>
        /// <exception cref="ArgumentNullException">hvis AnimalName er lig med Nul kastes denne exception</exception>
        /// <exception cref="ArgumentOutOfRangeException">hvis AnimalName er en tom string kastes denne exception</exception>
        public void ValidateAnimalName()
        {
            if (AnimalName == null)
            {
                throw new ArgumentNullException();
            }
            if (AnimalName == "")
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Kaster en exception hvis Longtitudes ikke er mellem 180 og -180 grader
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> kaster exception videre</exception>
        public void ValidateLongitude()
        {
            if (Longitude > 180 || Longitude < -180)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// en funktion som bruges til at se om Lattiude er mellem 90 og -90 grader
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">laver en exception hvis Lattiude er mellem 90 og -90 grader</exception>
        public void ValidateLatitude()
        {
            if (Latitude > 90 || Latitude < -90)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidateDateTime()
        {
            if (Date.Date < DateTime.Now.Date.AddDays(-7))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Date > DateTime.Now.AddMinutes(15))
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidateUsername()
        {
            if (UserName == null)
            {
                throw new ArgumentNullException();
            }
            if (UserName == "")
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
            ValidateLatitude();
            ValidateLongitude();
            ValidateDateTime();
            ValidateUsername();
        }
    }
}

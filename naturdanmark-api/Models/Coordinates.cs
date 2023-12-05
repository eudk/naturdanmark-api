namespace naturdanmark_api.Models
{
    public class Coordinates
    {

        public int DeviceID { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public DateTime Date { get; set; }

        public void ValidateLongitude()
        {
            if (Longitude > 180 || Longitude < -180)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidateLatitude()
        {
            if (Latitude > 90 || Latitude < -90)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}

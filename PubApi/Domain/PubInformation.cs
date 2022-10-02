namespace PubApi.Domain
{
    public class PubInformation
    {
        public string Name { get; }
        public string Category { get; }
        public bool IsClosed { get; }
        public string Url { get; }
        public DateTime ReviewDate { get; }
        public string ReviewExcerpt { get; }
        public string ThumbnailUrl { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public string Address { get; }
        public string PhoneNumber { get; }
        public string TwitterHandle { get; }
        public decimal StarsBeer { get; }
        public decimal StarsAtmosphere { get; }
        public decimal StarsAmenities { get; }
        public decimal StarsValue { get; }
        public string Tags { get; }

        public PubInformation(string name, string category, string url, DateTime reviewDate, string reviewExcerpt, string thumbnailUrl, double latitude, double longitude, string address, string phoneNumber, string twitterHandle, decimal starsBeer, decimal starsAtmosphere, decimal starsAmenities, decimal starsValue, string tags)
        {
            Name = name;
            Category = category;
            IsClosed = category.Contains("Closed");
            Url = url;
            ReviewDate = reviewDate;
            ReviewExcerpt = reviewExcerpt;
            ThumbnailUrl = thumbnailUrl;
            Latitude = latitude;
            Longitude = longitude;
            Address = address;
            PhoneNumber = phoneNumber;
            TwitterHandle = twitterHandle;
            StarsBeer = starsBeer;
            StarsAtmosphere = starsAtmosphere;
            StarsAmenities = starsAmenities;
            StarsValue = starsValue;
            Tags = tags;
        }
    }
}
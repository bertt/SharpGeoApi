namespace SharpGeoApi.Core
{
    public class Provider
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public string Data { get; set; }

        public string Id_Field { get; set; }

        public Geometry Geometry { get; set; }

    }
}

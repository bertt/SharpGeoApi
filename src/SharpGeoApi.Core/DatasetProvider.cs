namespace SharpGeoApi.Core
{
    public class DatasetProvider
    {
        public string Name { get; set; }
        public string Data { get; set; }

        public string Id_Field { get; set; }

        public Geometry Geometry { get; set; }

        public string Table { get; set; }
    }
}

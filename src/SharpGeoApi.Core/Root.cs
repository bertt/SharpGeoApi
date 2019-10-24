using System.Collections.Generic;
using System.Linq;

namespace SharpGeoApi.Core
{
    public class Root
    {
        public Root()
        {
            this.Identification = new Identification();
            this.License = new License();
            this.Provider = new Provider();
            this.Contact = new Contact();
        }

        public Provider Provider { get; set; }
        public Identification Identification { get; set; }
        public License License { get; set; }
        public Contact Contact { get; set; }

        public List<Link> Links { get; set; }
        public string GetUrl(string rel)
        {
            var link = (from links in Links where links.Rel == rel select links.Href).FirstOrDefault();
            return link + "?f=html";
        }
    }
}

﻿using System.Collections.Generic;

namespace SharpGeoApi.Core
{
    public class FeatureCollection
    {
        public List<Link> Links { get; set; }
        public string Id { get; set; }
        public string ItemType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Keywords { get; set; }
        public Extent Extent { get; set; }
    }
}

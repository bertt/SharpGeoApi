# SharpGeoApi

OGC compliant Server providing an API to geospatial data 

Spec: http://docs.opengeospatial.org/is/17-069r3/17-069r3.html

## Milestones

First milestone: serve local GeoJSON files 

Second milestone: Add GDAL/OGR backend for more formats 

## Sample api requests:

/ : Returns landing page

/api: returns OpenApi spec

/conformance: returns conformance doc

/processes: returns processes 

/collections: returns all collections

/collections/{name}: return collection with id = name

/collections/{name}/items: return items of collection with id = name

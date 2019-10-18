# SharpGeoApi

OGC compliant Server providing an API to geospatial data 

Spec: http://docs.opengeospatial.org/is/17-069r3/17-069r3.html

## Milestones

First milestone: serve local GeoJSON files 

Second milestone: Add GDAL/OGR backend for more formats 

## Developing

Developing in Visual Studio Code:

```
$ git clone https://github.com/bertt/SharpGeoApi.git
$ cd SharpGeoApi
$ code .
```

In VSCode press run/debug and browser opens at https://localhost:5001/

## Content negotiation

Default response content-type is application/json. Mediatype text/html is supported in querystring using the f=html parameter or in the request header (accept: text/html).

## Sample api requests:

/ : Returns landing page

/api: returns OpenApi spec

/conformance: returns conformance doc

/processes: returns processes 

/collections: returns all collections

/collections/{name}: return collection with id = name

/collections/{name}/items: return items of collection with id = name

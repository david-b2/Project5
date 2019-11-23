using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml.Linq;
using System.Xml;

namespace Project5
{
    public static class Location
    {
        //returns address to nearest store
        public static List<string> FindNearestStore(string storename, string zipcode, string radius)
        {
            //convert miles to meters
            double meters = Convert.ToDouble(radius) * 1609.34;
            
            //radius must be between 0 and 50000 meters
            if(meters > 50000)
            {
                meters = 50000;
            }
            else if(meters < 0)
            {
                meters = 0;
            }
            //get latitude and longitude of provided zipcode
            string key = "AIzaSyAXERNUNYdtb9MnYhvWSMh8pf1b8l4SIo0";
            List<string> results = new List<string>();
            try
            {
                string coordinates = locationToLatLong(key, zipcode);
                string[] separated = coordinates.Split('_');
                string latitude = separated[0];
                string longitude = separated[1];

                //call on google places API to find nearest stores with in a 20 mile radius (32186.9 meters)
                //form REST API request url
                string requestUri = string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/xml?location={0},{1}&radius={4}&type=store&keyword={2}&key={3}",
                                                  latitude, longitude, storename, key, meters.ToString());

                XmlDocument doc = new XmlDocument();
                
                try
                {
                    //load xml content into doc 
                    doc.Load(requestUri);
                    results = getResultsList(doc);
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                }

                /*WebRequest restRqst = WebRequest.Create(requestUri);

                //call on Google Places to convert location to latitude and longitude
                WebResponse restRsp = restRqst.GetResponse();
                XDocument xdoc = XDocument.Load(restRsp.GetResponseStream());

                //get address from the vicinity element in the resulting xml file
                XElement result = xdoc.Element("PlaceSearchResponse").Element("result");
                XElement address = result.Element("vicinity");

                return address.Value;*/
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }

            return results;
        }

        public static List<string> getResultsList(XmlDocument doc)
        {
            List<string> results = new List<string>();
            //root node
            XmlNode root = doc.DocumentElement;
            foreach (XmlNode element in root.SelectNodes("result"))
            {
                //get name of the location
                string locationName = element.SelectSingleNode("name").InnerText;
                //get address of the location
                string address = element.SelectSingleNode("vicinity").InnerText;
                results.Add(locationName + " : " + address);
            }
            return results;
        }

        public static string locationToLatLong(string key, string location)
        {
            //convert the zipcode given into a latitude and longitude
            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key={1}", Uri.EscapeDataString(location), key);

            WebRequest restRqst = WebRequest.Create(requestUri);
            //call on Google GeoCode to convert location to latitude and longitude
            WebResponse restRsp = restRqst.GetResponse();
            XDocument xdoc = XDocument.Load(restRsp.GetResponseStream());

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement lat = locationElement.Element("lat");
            XElement lng = locationElement.Element("lng");

            string latStr = lat.Value;
            string lngStr = lng.Value;

            return latStr + "_" + lngStr;
        }
    }
}
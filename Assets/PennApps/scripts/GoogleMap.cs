using UnityEngine;
using System.Collections;

public class GoogleMap : MonoBehaviour
{

    private int delay = 0;
    public enum MapType
    {
        RoadMap,
        Satellite,
        Terrain,
        Hybrid
    }
    public bool loadOnStart = true;
    public bool autoLocateCenter = true;
    public GoogleMapLocation centerLocation;
    public int zoom = 13;
    public MapType mapType;
    public int size = 512;
    public bool doubleResolution = false;
    public GoogleMapMarker[] markers;
    public GoogleMapPath[] paths;

    void Start()
    {
        mapType = GoogleMap.MapType.Hybrid;
        markers = new GoogleMapMarker[3];
        markers[0] = new GoogleMapMarker();
        markers[0].locations = new GoogleMapLocation[1];
        markers[0].locations[0] = new GoogleMapLocation();
        markers[0].locations[0].address = "";
        markers[0].locations[0].latitude = 40.7127837f;
        markers[0].locations[0].longitude = -74.0059413f;
        markers[0].size = GoogleMapMarker.GoogleMapMarkerSize.Mid;
        markers[0].color = GoogleMapColor.red;
        markers[0].label = "begin";
        markers[1] = new GoogleMapMarker();
        markers[1].locations = new GoogleMapLocation[1];
        markers[1].locations[0] = new GoogleMapLocation();
        markers[1].locations[0].address = "";
        markers[1].locations[0].latitude = 40.7327837f;
        markers[1].locations[0].longitude = -74.0059413f;
        markers[1].size = GoogleMapMarker.GoogleMapMarkerSize.Mid;
        markers[1].color = GoogleMapColor.red;
        markers[1].label = "end";

        markers[2] = new GoogleMapMarker();
        markers[2].locations = new GoogleMapLocation[1];
        markers[2].locations[0] = new GoogleMapLocation();
        markers[2].locations[0].address = "";
        markers[2].locations[0].latitude = 40.7227837f;
        markers[2].locations[0].longitude = -74.0059413f;
        markers[2].size = GoogleMapMarker.GoogleMapMarkerSize.Mid;
        markers[2].color = GoogleMapColor.blue;
        markers[2].label = "drone";

        paths = new GoogleMapPath[1];
        paths[0] = new GoogleMapPath();
        paths[0].color = GoogleMapColor.black;
        paths[0].fill = true;
        paths[0].fillColor = GoogleMapColor.blue;
        paths[0].locations = new GoogleMapLocation[2];
        paths[0].locations[0] = markers[0].locations[0];
        paths[0].locations[1] = markers[2].locations[0];

        paths[0] = new GoogleMapPath();
        paths[0].color = GoogleMapColor.black;
        paths[0].locations = new GoogleMapLocation[2];
        paths[0].locations[0] = markers[2].locations[0];
        paths[0].locations[1] = markers[1].locations[0];


        if (loadOnStart) Refresh();

        StartCoroutine(_MoveDrone(0.01f, 0.2f, 10));
    }

    IEnumerator _MoveDrone(float rate, float progress, int frameDelay)
    {
        while (progress < 1.0)
        {
            progress += rate;
            markers[2].locations[0].latitude = progress * markers[0].locations[0].latitude + (1 - progress) * markers[1].locations[0].latitude;
            markers[2].locations[0].longitude = progress * markers[0].locations[0].longitude + (1 - progress) * markers[1].locations[0].longitude;
            for (int i = 0; i < frameDelay; ++i) yield return 0;
        }
    }

    public void Refresh()
    {
        if (autoLocateCenter && (markers.Length == 0 && paths.Length == 0))
        {
            Debug.LogError("Auto Center will only work if paths or markers are used.");
        }
        StartCoroutine(_Refresh());
    }

    IEnumerator _Refresh()
    {
        var url = "http://maps.googleapis.com/maps/api/staticmap";
        var qs = "";
        if (!autoLocateCenter)
        {
            if (centerLocation.address != "")
                qs += "center=" + WWW.UnEscapeURL(centerLocation.address);
            else
            {
                qs += "center=" + WWW.UnEscapeURL(string.Format("{0},{1}", centerLocation.latitude, centerLocation.longitude));
            }

            qs += "&zoom=" + zoom.ToString();
        }
        qs += "&size=" + WWW.UnEscapeURL(string.Format("{0}x{0}", size));
        qs += "&scale=" + (doubleResolution ? "2" : "1");
        qs += "&maptype=" + mapType.ToString().ToLower();
        var usingSensor = false;
#if UNITY_IPHONE
        usingSensor = Input.location.isEnabledByUser && Input.location.status == LocationServiceStatus.Running;
#endif
        qs += "&sensor=" + (usingSensor ? "true" : "false");

        foreach (var i in markers)
        {
            qs += "&markers=" + string.Format("size:{0}|color:{1}|label:{2}", i.size.ToString().ToLower(), i.color, i.label);
            foreach (var loc in i.locations)
            {
                if (loc.address != "")
                    qs += "|" + WWW.UnEscapeURL(loc.address);
                else
                    qs += "|" + WWW.UnEscapeURL(string.Format("{0},{1}", loc.latitude, loc.longitude));
            }
        }

        foreach (var i in paths)
        {
            qs += "&path=" + string.Format("weight:{0}|color:{1}", i.weight, i.color);
            if (i.fill) qs += "|fillcolor:" + i.fillColor;
            foreach (var loc in i.locations)
            {
                if (loc.address != "")
                    qs += "|" + WWW.UnEscapeURL(loc.address);
                else
                    qs += "|" + WWW.UnEscapeURL(string.Format("{0},{1}", loc.latitude, loc.longitude));
            }
        }

        Debug.Log(qs);
        var req = new WWW(url + "?" + qs);
        yield return req;
        GetComponent<Renderer>().material.mainTexture = req.texture;
    }

    void Update()
    {
        delay++;
        if (delay == 25)
        {
            Refresh();
            delay = 0;
        }
    }
}

public enum GoogleMapColor
{
    black,
    brown,
    green,
    purple,
    yellow,
    blue,
    gray,
    orange,
    red,
    white
}

[System.Serializable]
public class GoogleMapLocation
{
    public string address;
    public float latitude;
    public float longitude;
}

[System.Serializable]
public class GoogleMapMarker
{
    public enum GoogleMapMarkerSize
    {
        Tiny,
        Small,
        Mid
    }
    public GoogleMapMarkerSize size;
    public GoogleMapColor color;
    public string label;
    public GoogleMapLocation[] locations;

}

[System.Serializable]
public class GoogleMapPath
{
    public int weight = 5;
    public GoogleMapColor color;
    public bool fill = false;
    public GoogleMapColor fillColor;
    public GoogleMapLocation[] locations;
}

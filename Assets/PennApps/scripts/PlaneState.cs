using UnityEngine;
using System.Collections;

public class PlaneState : MonoBehaviour {

    public static GoogleMapMarker[] markers = new GoogleMapMarker[3];

    public static void sendUpdate(float lat0, float long0, float lat1, float long1)
    {
        PlaneState.getMarkers()[0].locations[0].latitude = lat0;
        PlaneState.getMarkers()[0].locations[0].longitude = long0;
        PlaneState.getMarkers()[1].locations[0].latitude = lat1;
        PlaneState.getMarkers()[1].locations[0].longitude = long1;
    }

    public static GoogleMapMarker[] getMarkers() {
        return markers;
    }
}

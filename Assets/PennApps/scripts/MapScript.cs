//using UnityEngine;
//using System.Collections;

//public class MapScript : MonoBehaviour {

//	public GoogleMap googleMap;
//	void Start () {
//		googleMap = gameObject.AddComponent <GoogleMap>() as GoogleMap;
//		googleMap.mapType = GoogleMap.MapType.Satellite;
//		googleMap.markers = new GoogleMapMarker[2];
//		googleMap.markers[0] = new GoogleMapMarker();
//		googleMap.markers[0].locations = new GoogleMapLocation[1];
//		googleMap.markers [0].locations [0] = new GoogleMapLocation ();
//		googleMap.markers[0].locations[0].latitude = 40.7127837f;
//		googleMap.markers[0].locations[0].longitude = -74.0059413f;
//		googleMap.markers[0].size = GoogleMapMarker.GoogleMapMarkerSize.Mid;
//		googleMap.markers[0].color = GoogleMapColor.red;
//		googleMap.markers[0].label = "begin";
//		googleMap.markers[1] = new GoogleMapMarker();
//		googleMap.markers[1].locations = new GoogleMapLocation[1];
//		googleMap.markers [1].locations [0] = new GoogleMapLocation ();
//		googleMap.markers[1].locations[0].latitude = 40.7227837f;
//		googleMap.markers[1].locations[0].longitude = -74.0059413f;
//		googleMap.markers[1].size = GoogleMapMarker.GoogleMapMarkerSize.Mid;
//		googleMap.markers[1].color = GoogleMapColor.red;
//		googleMap.markers[1].label = "end";

//		googleMap.paths = new GoogleMapPath[1];
//		googleMap.paths [0] = new GoogleMapPath ();
//		googleMap.paths[0].color = GoogleMapColor.black;
//		googleMap.paths[0].locations = new GoogleMapLocation[2];
//		googleMap.paths [0].locations [0] = googleMap.markers [0].locations [0];
//		googleMap.paths [0].locations [1] = googleMap.markers [1].locations [0];
//	}
	
//	// Update is called once per frame
//	void Update () {
//		googleMap.gameObject.SetActive (true);
//	}
//}

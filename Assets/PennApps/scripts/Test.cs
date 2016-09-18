using UnityEngine;
using System.Collections;
using SocketIO;
using System;
using System.Linq;
using System.Collections.Generic;
[RequireComponent (typeof (AudioSource))]  

public class Test : MonoBehaviour {
	// Use this for initialization
	private SocketIOComponent socket;

    public static Plane currentPlane;

    void changeView (SocketIOEvent e) {
        Debug.Log("CHANGE VIEW");
        currentPlane = new Plane(e.data.GetField("timestamp").ToString(), e.data.GetField("lat").ToString(), 
            e.data.GetField("long_").ToString(), e.data.GetField("endLat").ToString(), 
            e.data.GetField("endLong").ToString(), e.data.GetField("altitude").ToString(), 
            e.data.GetField("eta").ToString(), e.data.GetField("temp").ToString());

        Debug.Log( "TIME: " + currentPlane.timestamp ) ;
        
        PlaneState.sendUpdate(float.Parse(currentPlane.lat0), float.Parse(currentPlane.lon0), 
            float.Parse(currentPlane.lat1), float.Parse(currentPlane.lon1));
	}

	void Start () {
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();
        Debug.Log("START CONNECTION");

        socket.On("CHANGE_VIEW", changeView);
	}

	
}
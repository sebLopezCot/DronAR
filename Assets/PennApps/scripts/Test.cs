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
	//A boolean that flags whether there's a connected microphone  

	//The maximum and minimum available recording frequencies  
	private int minFreq;  
	private int maxFreq;  

	//A handle to the attached AudioSource  
	private AudioSource goAudioSource; 
	public static ArrayList Elements = new ArrayList();


	public void addObject(SocketIOEvent e) {
		removeObject (e);
		print ("ADDING - " + e.name + ": " + e.data);
			string equation;
		Debug.Log (e.name + " TYPE: " + e.data.GetField ("type").ToString());
		if (e.data.GetField ("type").ToString().Equals("\"graph\"")) {
				equation = (e.data.GetField ("equation").ToString());
			if (equation.Contains ("\"")) {
				equation = equation.Substring (1, equation.Length - 2);
			}
			} else {
				equation = null;
			}	
		print (e.data.GetField ("rotate").ToString () + "DEGREES");
		Element newElem = new Element(
				e.data.GetField ("type").ToString(),
			Int32.Parse(sanitize(e.data.GetField ("rotate").ToString())),
			Int32.Parse(sanitize(e.data.GetField ("zoom").ToString())),
			Int32.Parse(sanitize(e.data.GetField ("x").ToString())),
			Int32.Parse(sanitize(e.data.GetField ("y").ToString())),
			Int32.Parse(sanitize(e.data.GetField ("z").ToString())),
			Int32.Parse(sanitize(e.data.GetField ("rotate_rate").ToString())),
				equation);
			Elements.Add (newElem); //when initialized, no new characteristics

		print ("WTF");
		foreach (Element el in Elements) {
			print (el.GetType ());
		}
		print ("----");

		Loader.shouldUpdate = true;
	}

	public string sanitize(string str) {
		if (str.Contains ("\"")) {
			str = str.Substring (1, str.Length - 2);
		}
		return str;
	}

	public void removeObject(SocketIOEvent e) {
		print ("REMOVING - " + e.name + ": " + e.data);
		ArrayList toRemove = new ArrayList();
		foreach (Element s in Elements) {
			print ("COMPARING: " + s.GetType () + " --- to --- " + e.data.GetField ("type"));
			print (s.GetType ().Equals (e.data.GetField ("type").ToString()));
			if (s.GetType().Equals (e.data.GetField("type").ToString())) {
				toRemove.Add (s);
				print("WILL REMOVEEEEE: " + s.GetType());
			} 
		} 

		foreach (Element s in toRemove) {
			Elements.Remove (s);
			print("REMOOOOOVING: " + s.GetType());
		}

		Loader.shouldUpdate = true;
	}

	void Start () {
		print ("hihihihii");
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On ("ADD_VIEW", addObject);
		socket.On ("REMOVE_VIEW", removeObject);
	}

	// Update is called once per frame
	void Update () {
		//potentially add update code here
	}
}
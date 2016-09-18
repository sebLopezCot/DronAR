using UnityEngine;
using System.Collections;

public class fixpi : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var pivot = transform.Find("pivot");
		this.transform.RotateAround(pivot.position, Vector3.up, 2);
	}
}

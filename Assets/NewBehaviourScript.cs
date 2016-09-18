using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(0, 0.5F, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

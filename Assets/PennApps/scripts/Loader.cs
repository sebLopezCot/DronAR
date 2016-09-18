//using UnityEngine;
//using System.Collections;
//using Vuforia;

//public class Loader : MonoBehaviour, ITrackableEventHandler {

//	private TrackableBehaviour mTrackableBehaviour;
//	public static bool shouldUpdate = true;
//	//private Transform myModelTrf;

//	private class ElementContainer {
//		public Element element;
//		public Transform trans;
//		public Vector3 base_scale;
//		public Vector3 base_pos;
//		public Quaternion base_rotate;

//		public ElementContainer(Element _element, Transform _trans, Vector3 scale, Vector3 pos, Quaternion rotate) {
//			element = _element;
//			trans = _trans;
//			base_scale = scale;
//			base_pos = pos;
//			base_rotate = rotate;
//		}
//	}

//	private ArrayList Elements = new ArrayList ();

//	private Element[] fake_elems = {
//		new Element ("skull", 0, 1, 0, 0, 0, 0, null),
//		new Element ("glucose", 0, 1, 0, 0, 0, 0, null),
//		new Element ("chess", 0, 1, 0, 0, 0, 0, null),
//		new Element ("graph", 0, 1, 0, 0, 0, 0, "[Y]=[X]"),
//		new Element ("physics2", 0, 1, 0, 0, 0, 0, null),
//		new Element ("physics", 0, 1, 0, 0, 0, 0, null)
//	};
//	private int fake_index = 1;

//	public Transform chess;
//	private Vector3 chess_size = new Vector3 (4f, 4f, 4f);
//	private Quaternion chess_rotate = Quaternion.identity;
//	private Vector3 chess_position = new Vector3(0f, 0f, 0f);

//	public Transform skull;
//	private Vector3 skull_size = new Vector3 (0.015f, 0.015f, 0.015f);
//	private Quaternion skull_rotate = Quaternion.Euler(new Vector3(-90.0f, 0f, 0f));
//	private Vector3 skull_pos = new Vector3 (0.08f, 13f, 2.59f);
//	//private Vector3 skull_size = new Vector3 (0.005f, 0.005f, 0.005f);
//	//private Quaternion skull_rotate = Quaternion.Euler(new Vector3(-90.0f, 0f, 0f));
//	//private Vector3 skull_pos = new Vector3 (0.08f, 4.51f, 0.59f);

//	public Transform physics;
//	private Vector3 physics_size = new Vector3 (1f, 1f, 1f);
//	private Quaternion physics_rotate = Quaternion.identity;
//	private Vector3 physics_pos = new Vector3 (0f, 0f, 0f);

//	public Transform physics2;
//	private Vector3 physics2_size = new Vector3 (0.5f, 0.5f, 0.5f);
//	private Quaternion physics2_rotate = Quaternion.identity;
//	private Vector3 physics2_pos = new Vector3 (1.965f, 3.6525f, 0.35f);

//	public Transform glucose;
//	private Vector3 glucose_size = new Vector3 (0.5f, 0.5f, 0.5f);
//	private Quaternion glucose_rotate = Quaternion.Euler (new Vector3 (-0.9642f, 0.0976f, 1.6003f));
//	private Vector3 glucose_pos = new Vector3 (-1.836f, -0.902f, -0.241f);

//	public Transform graph;
//	private Vector3 graph_size = new Vector3 (1f, 1f, 1f);
//	private Vector3 graph_pos = new Vector3 (0f, 0f, 0f);
//	private Quaternion graph_rotate = Quaternion.identity;

//	void Start () {
//		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
//		if (mTrackableBehaviour) {
//			mTrackableBehaviour.RegisterTrackableEventHandler(this);
//		}
//	}

//	void Update () {
//		if (Test.Elements.Count > 0) {
//			if (shouldUpdate) {
//				shouldUpdate = false;
//				Debug.Log ("Updating drawing");
//				OnTrackingFound ();
//			}
//		} else {
//			Debug.Log ("Not connected to server, drawing something else instead");
//			if (Input.anyKeyDown && !Input.GetKeyDown ("space")) {
//				fake_index = (fake_index + 1) % fake_elems.Length;
//				OnTrackingFound ();
//			}
//		}
//	}

//	public void OnTrackableStateChanged(
//		TrackableBehaviour.Status previousStatus,
//		TrackableBehaviour.Status newStatus) { 
//		if (newStatus == TrackableBehaviour.Status.DETECTED ||
//			newStatus == TrackableBehaviour.Status.TRACKED ||
//			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
//		{
//			OnTrackingFound();
//		}
//	} 

//	private ElementContainer GetContainer(Element elem) {
//		if (elem == null) {
//			return null;
//		}

//		Transform trans;
//		Vector3 scale;
//		Vector3 pos;
//		Quaternion rotate;

//		string switchString = elem.GetType ();
//		if (switchString.Contains ("\"")) {
//			switchString = switchString.Substring (1, switchString.Length - 2);
//		}

//		Debug.Log (switchString);


//		switch (switchString) {
//			case "chess":
//				trans = GameObject.Instantiate (chess) as Transform;
//				trans.parent = mTrackableBehaviour.transform;
//				pos = chess_position;
//				rotate = chess_rotate;
//				scale = chess_size;
//				break;

//			case "skull":
//				trans = GameObject.Instantiate (skull) as Transform;
//				trans.parent = mTrackableBehaviour.transform;
//				pos = skull_pos;
//				rotate = skull_rotate;
//				scale = skull_size;
//				break;

//			case "physics2":
//				trans = GameObject.Instantiate (physics2) as Transform;
//				trans.parent = mTrackableBehaviour.transform;
//				pos = physics2_pos;
//				rotate = physics2_rotate;
//				scale = physics2_size;
//				break;

//			case "physics":
//				trans = GameObject.Instantiate (physics) as Transform;
//				trans.parent = mTrackableBehaviour.transform;
//				pos = physics_pos;
//				rotate = physics_rotate;
//				scale = physics_size;
//				break;

//		case "glucose":
//			Debug.Log ("TESSST");
//				trans = GameObject.Instantiate (glucose) as Transform;
//				trans.parent = mTrackableBehaviour.transform;
//				pos = glucose_pos;
//				rotate = glucose_rotate;
//				scale = glucose_size;
//				break;

//		case "graph":
//			trans = GameObject.Instantiate (graph) as Transform;
//			trans.parent = mTrackableBehaviour.transform;
//			pos = graph_pos;
//			rotate = graph_rotate;
//			scale = graph_size;
//			Debug.Log (elem.GetEquation ());
//			GrapherCUSTOM.funky = elem.GetEquation ();
//			Debug.Log (GrapherCUSTOM.funky);
//				break;

//			default:
//				return null;
//		}

//		return new ElementContainer (elem, trans, scale, pos, rotate);
//	}

//	private void OnTrackingFound() {
//		Debug.Log ("TrackingFound");
//		foreach (ElementContainer ec in Elements) {
//			if (ec.trans != null) {
//				Destroy (ec.trans.gameObject);
//			}
//		}

//		Elements = new ArrayList ();
//		if (Test.Elements.Count > 0) {
//			Debug.Log ("Real elements");

//			foreach (Element elem in Test.Elements) {
//				ElementContainer ec = GetContainer (elem);

//				if (ec != null && elem != null) {
//					Elements.Add (ec);
//				}
//			}
//		} else {
//			Debug.Log ("Fake elements: " + fake_index + "/" + fake_elems.Length);
//			Debug.Log (fake_elems [fake_index]);
//			Debug.Log(GetContainer (fake_elems [fake_index]));
//			Elements.Add (GetContainer (fake_elems [fake_index]));
//		}
			

//		foreach (ElementContainer ec in Elements) {
//			draw (ec);

//			if (ec.trans != null) {
//				ec.trans.gameObject.SetActive(true);
//			}
//		}
			


//		//myModelTrf.localPosition = cur_pos/*+ new Vector3 (cur_elem.GetX (), cur_elem.GetY (), cur_elem.GetZ ())*/;
//		//myModelTrf.localScale = cur_scale/* * cur_elem.GetZoom ()*/;
//		//myModelTrf.localRotation = cur_rotate /* Quaternion.Euler(cur_rotate.eulerAngles + (Vector3.up * cur_elem.GetRotate()))*/;
//	}

//	private void draw(ElementContainer ec) {
//		ec.trans.localPosition = ec.base_pos + new Vector3 (ec.element.GetX (), ec.element.GetY (), ec.element.GetZ ());
//		Debug.Log("DAWDAWDWDW: " + ec.element.GetZoom());
//		ec.trans.localScale = ec.base_scale * ec.element.GetZoom();
//		ec.trans.localRotation = Quaternion.Euler(ec.base_rotate.eulerAngles + (Vector3.up * ec.element.GetRotate()));
//	}
//}
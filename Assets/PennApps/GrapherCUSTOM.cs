using UnityEngine;
using AK;

public class GrapherCUSTOM : MonoBehaviour {

	public static string funky = "y=x";

	[Range(10, 100)]
	public int resolution = 10;

	public float size = 1f;

	private int currentResolution;
	private ParticleSystem.Particle[] points;

	private void Start () {
		transform.localPosition = new Vector3 (-size / 8f, 0f, -size / 8f);
	}

	private void CreatePoints () {
		currentResolution = resolution;
		points = new ParticleSystem.Particle[resolution * resolution];
		float increment = size / (resolution - 1);
		int i = 0;
		for (int x = 0; x < resolution; x++) {
			for (int z = 0; z < resolution; z++) {
				Vector3 p = new Vector3(x * increment, 0f, z * increment);
				points[i].position = p;
				points[i].color = new Color(p.x / size, 0f, p.z / size);
				points[i++].size = 0.1f;
			}
		}
	}

	void Update () {
		if (currentResolution != resolution || points == null) {
			CreatePoints();
		}
		float t = Time.timeSinceLevelLoad;
		for (int i = 0; i < points.Length; i++) {
			Vector3 p = points[i].position;
			p.y = Custom(funky, p, t) * 1.5f;
			points[i].position = p;
			Color c = points[i].color;
			c.g = p.y;
			points[i].color = c;
		}
		GetComponent<ParticleSystem>().SetParticles(points, points.Length);
	}

	private static float Custom (string eq, Vector3 p, float t) {
		if (eq.Length < 2) {
			return 0;
		}

		if(eq.Substring(0, 2).ToLower().Equals("y=")) {
			string equation = eq.Substring (2);

			ExpressionSolver solver = new ExpressionSolver();
			solver.SetGlobalVariable("x",p.x);
			solver.SetGlobalVariable("z",p.z);
			solver.SetGlobalVariable("t",t);
			Expression value = solver.SymbolicateExpression(equation);
			return (float)value.Evaluate ();
		}

		return 0;
	}
}
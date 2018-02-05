using UnityEngine;
using System.Collections;

public class stateObjects : MonoBehaviour {

	public bool rotate;
	public bool flashing;

	public float minimum = 10.0F;
	public float maximum = 20.0F;

	void Update () {
		if (rotate) {
			Vector3 euler = transform.localEulerAngles;
			euler.z += 2f;
			transform.localEulerAngles = euler;
		}
		if (flashing) {
			transform.localScale = new Vector2(Mathf.PingPong(Time.time, maximum-minimum)+minimum, Mathf.PingPong(Time.time, maximum-minimum)+minimum);
		}
	}
}

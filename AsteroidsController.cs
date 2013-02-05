using UnityEngine;
using System.Collections;

public class CapsuleController : MonoBehaviour {
	public ParticleSystem exhaust;
	public float thrust = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("up")) {
			rigidbody.AddRelativeForce(Vector3.up * thrust);
			exhaust.enableEmission = true;
		}
		else {
			exhaust.enableEmission = false;
		}
		if(Input.GetKey ("left")) {
			transform.RotateAround(new Vector3(0,0,1), Time.deltaTime * 3f);
		}
		if(Input.GetKey ("right")) {
			transform.RotateAround(new Vector3(0,0,1), -Time.deltaTime * 3f);
		}
	
	}
}

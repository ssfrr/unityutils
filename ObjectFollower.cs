using UnityEngine;
using System.Collections;

public class ObjectFollower : MonoBehaviour {
	/*
	 * This behavior enables following an object. It uses a PID
	 * control system to apply force to the object. Note that this
	 * assumes that we have a rigidbody to work with. Make sure to add
	 * a drag factor or else the following will oscillate.
	 */
	public GameObject followed;
	public float minFlyHeight = 10;
	// the position and velocity factors determines how much the position
	// and velocity of the tracked object contribute to the force applied
	// to the camera.
	public float positionFactor = 1;
	public float velocityFactor = 0;
	
	// These determine how the height setting works
	public float speedThreshold = 2;
	public float speedCoefficient = 1;

	void Start () {
		// start us out above the tracked object
		transform.localPosition = new Vector3(followed.transform.localPosition.x,
												followed.transform.localPosition.y, 
												followed.transform.localPosition.z - getFlyHeight());
	}
	
	void Update () {
		rigidbody.AddForce(getFollowingForce());
	}
	
	float getFlyHeight() {
		float speed = followed.rigidbody.velocity.magnitude;
		if(speed < speedThreshold) {
			return minFlyHeight;
		}
		else {
			return minFlyHeight + (speed - speedThreshold) * speedCoefficient;
		}
	}
	
	Vector3 getFollowingForce() {
        Vector3 targetPosition = new Vector3(followed.transform.localPosition.x,
                                     followed.transform.localPosition.y,
                                     followed.transform.localPosition.z - getFlyHeight());
		// Diff is the position of the followed object relative to us
		Vector3 positionDiff = targetPosition - transform.position;
		Vector3 velocityDiff = followed.rigidbody.velocity - rigidbody.velocity;
		// ignore the z component of the velocity vector
		velocityDiff.z = 0;

		return positionFactor * positionDiff + velocityFactor * velocityDiff;
	}
}

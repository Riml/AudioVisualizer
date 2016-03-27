using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {

	public float speed;
<<<<<<< HEAD
	public Transform rotateAround;

	// Use this for initialization
	void Start () {
		speed = 50.0f;
=======

	// Use this for initialization
	void Start () {
		speed = 300.0f;
>>>>>>> b01553da1046560a1e0bed49f704c2280f5d89b6
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		//transform.Rotate (speed * Time.deltaTime, 0, 0);
		transform.RotateAround (rotateAround.position, Vector3.left, speed * Time.deltaTime);

=======
		transform.Rotate (speed * Time.deltaTime, speed * Time.deltaTime * 0.7f, speed * Time.deltaTime * 0.2f);
>>>>>>> b01553da1046560a1e0bed49f704c2280f5d89b6
	}
}

using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {

	public float speed;
	public Transform rotateAround;

	// Use this for initialization
	void Start () {
		speed = 50.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (speed * Time.deltaTime, 0, 0);
		transform.RotateAround (rotateAround.position, Vector3.left, speed * Time.deltaTime);

	}
}

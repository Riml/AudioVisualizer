using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		speed = 300.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (speed * Time.deltaTime, speed * Time.deltaTime * 0.7f, speed * Time.deltaTime * 0.2f);
	}
}

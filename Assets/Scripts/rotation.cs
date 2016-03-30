using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {

	public float speed= 300.0f;
    public Transform rotateAround;

    // Use this for initialization
    void Start () {
		//speed = 300.0f;

	}
	
	// Update is called once per frame
	void Update () {

		//transform.Rotate (speed * Time.deltaTime, 0, 0);
		transform.RotateAround (rotateAround.position, Vector3.left, speed * Time.deltaTime);


		//transform.Rotate (speed * Time.deltaTime, speed * Time.deltaTime * 0.7f, speed * Time.deltaTime * 0.2f);

	}
}

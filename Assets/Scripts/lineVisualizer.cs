using UnityEngine;
using System.Collections;

public class lineVisualizer : MonoBehaviour {

	public int detail; // Level of detail of the audio information
	public float amplitude; // Audio level
	private float startPosition; // Start position of the visualizer

	// Use this for initialization
	void Start () {
		detail = 500;
		amplitude = 0.1f;
		startPosition = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		float[] info = new float[detail]; // intialize the array to hold a certain amount of information i.e. detail
		AudioListener.GetOutputData (info, 0); // populate the array with data from the audio listener
		float packagedData = 0.0f;

		for (int x = 0; x < info.Length; x++) {
			packagedData += System.Math.Abs(info[x]); // Assign the value of the audio output data to a value
		}

		transform.position = new Vector3(0, startPosition + packagedData * amplitude, 0); // Moves the line visualizer along
	}
}

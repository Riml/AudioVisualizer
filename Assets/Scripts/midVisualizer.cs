using UnityEngine;
using System.Collections;

public class midVisualizer : MonoBehaviour {
	
	public int detail; // Level of detail of the audio information (samples)
	public float minValue; // Min value of the bars of the visualizer
	public float amplitude; // Audio level
	private Vector3 startScale; // Start scale of the visualizer
	private float offset; // Offset of the bar visualizer
	private float maxOffset; // Max offset for the bar visualizer
	public GameObject visualizer; // Game object used as visualizer
	
	// Use this for initialization
	void Start () {
		detail = 8192;
		minValue = 1.0f;
		amplitude = 0.1f;
		startScale = transform.localScale;
		offset = 1.0f;
		maxOffset = 255;
	}
	
	// Update is called once per frame
	void Update () {
		float[] info = new float[detail]; // intialize the array to hold a certain amount of information i.e. detail
		AudioListener.GetOutputData (info, 0); // populate the array with data from the audio listener
		float packagedData = 0.0f;
		
		for (int x = 0; x < info.Length; x++) {
			packagedData += System.Math.Abs (info[x]); // Assign the value of the audio output data to a value
		}
		transform.localScale = updateVisualizerScale (packagedData); // Moves the bars up and down
		visualizer.GetComponent<Renderer> ().material.color = updateVisualizerColour (); // Set the colour of the visualizer*/
	}
	
	// Gets colour for visualizer
	private Color updateVisualizerColour(){
		return new Color (0, 1 - (offset / 100), 0 + (offset / 100), 0.5f);
	}
	
	// Get the amplitude and return the bar scale
	private Vector3 updateVisualizerScale(float audioLevel){
		offset = maxOffset * (audioLevel/detail);
		if (offset < 5) {
			offset = 5;
		} 
		else if (offset > 200) {
			offset = 200;
		}
		return new Vector3 (offset * 0.6f, offset * 0.6f, offset * 0.6f);
	}
}
using UnityEngine;  
using System.Collections;  

public class LineVisualizer : MonoBehaviour  
{  
	public float xOffset;										// Offset for the visualization along the x axis
	private AudioSource aSource;  								// Audio Source
	private float[] samples = new float[256]; 					// Sample Rate
	private LineRenderer lRenderer;  							// Line renderer to draw the information
	private Transform audioVisTransform;						// Transform of audio visualizer
	public GameObject cube;  									// Prefab to determine line height, mesh will not be rendered
	private Vector3 cubePos;  									// Temp cube position to draw the line points with
	private Transform[] cubesTransform;  						// Store the Transforms of all instantiated cubes   
	private Vector3 gravity = new Vector3(0.0f,0.25f,0.0f);  	// The velocity that the cubes will drop 

	void Awake ()  
	{  
		this.audioVisTransform = GetComponent<Transform> ();
		this.aSource = GetComponent<AudioSource>();  
		this.lRenderer = GetComponent<LineRenderer>();  
	}  

	void Start()  
	{  
		lRenderer.SetVertexCount(samples.Length); 				// Set the number of vertexes for the line based on sample rate
		cubesTransform = new Transform[samples.Length];  		// Set the number of cube transforms based on sample rate
		GameObject tempCube;  									// Temp cube to be accessed as most recent clone

		// For each sample instatiate each 'cube' that will determine line height
		for(int i = 0; i < samples.Length; i++)  
		{  
			tempCube = (GameObject) Instantiate(cube, new Vector3(audioVisTransform.position.x + i, audioVisTransform.position.y, audioVisTransform.position.z),Quaternion.identity);  
			cubesTransform[i] = tempCube.GetComponent<Transform>();  
			cubesTransform[i].parent = audioVisTransform;  
		}  
	}  

	void Update ()  
	{  
		aSource.GetSpectrumData(this.samples, 0, FFTWindow.BlackmanHarris);  // Grab the samples from the frequency bands

		//For each sample  
		for(int i = 0; i < samples.Length; i++)  
		{  
			// Set cube position
			cubePos.Set(cubesTransform[i].position.x, Mathf.Clamp(samples[i]*(300 + i*i), 0, 300), cubesTransform[i].position.z);  

			// If the new position is greater set it, otherwise let it fall
			if(cubePos.y >= cubesTransform[i].position.y)  
				cubesTransform[i].position = cubePos;  
			else  
				cubesTransform[i].position -= gravity;  
				 
			lRenderer.SetPosition(i, cubePos - new Vector3(xOffset, 0, 0)); // Draw the line
		}  
	}  
}  
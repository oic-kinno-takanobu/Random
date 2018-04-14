using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sketch : MonoBehaviour {

    [SerializeField]
    Material sketchMat;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(null, destination, sketchMat);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

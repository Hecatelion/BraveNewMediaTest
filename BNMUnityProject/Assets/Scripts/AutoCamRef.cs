using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamRef : MonoBehaviour
{
	Camera cam;

    void Start()
    {
		cam = GameObject.FindObjectOfType<Camera>();
		Debug.Log(cam.name);
    }

    void Update()
    {
        
    }
}

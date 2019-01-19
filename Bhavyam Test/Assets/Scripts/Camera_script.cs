using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : Element {

    
    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - app.view.player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = app.view.player.transform.position + offset;		
	}
}

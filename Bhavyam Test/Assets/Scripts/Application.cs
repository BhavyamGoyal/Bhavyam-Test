using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Element : MonoBehaviour
{
    public Application app { get { return GameObject.FindObjectOfType<Application>(); } }
}
public class Application : MonoBehaviour {

    public Model model;
    public View view;
    public Controller controller;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	
}

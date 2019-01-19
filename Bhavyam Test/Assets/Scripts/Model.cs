using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {

	// Use this for initialization
	public int highScore = 0;
    public float timer = 60f;
    public int score = 0;
    public int prev_cube = 0;
    public int streak = 1;
    public Data type = new Data();
   
    public List<Cubes> typeOfCubes = new List<Cubes>();


   

}

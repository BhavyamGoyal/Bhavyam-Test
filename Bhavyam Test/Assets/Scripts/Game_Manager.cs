using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {
    public float timer = 60f;
    Data type = new Data();
    private GameObject cubePrefab;
    List<Cubes> typeOfCubes = new List<Cubes>();
    // Use this for initialization
    private void Awake()
    {
     
        cubePrefab = Resources.Load("Cube") as GameObject;
    }
    void Start () {
       
       
        //Debug.Log(Application.persistentDataPath);
        //save_data();
        read_data();
       
        int r = Random.Range(0, 4);
        typeOfCubes.Add(type.cube[r]);
        Debug.Log(type.cube[r].colour);
        int r2 = Random.Range(0, 4);
        while (r == r2)
        {
            r2 = Random.Range(0, 4);
        }
        typeOfCubes.Add(type.cube[r2]);
        Debug.Log(type.cube[r2].colour);
        for (int i=0; i < 10; i++)
        {
            int t = Random.Range(0, 2);
            GameObject cube = Instantiate(cubePrefab, new Vector3(Random.Range(-45, 45), 0.5f, Random.Range(-45, 45)), new Quaternion(0, 0, 0, 0),null)as GameObject;
            cube.GetComponent<Cube_object>().score = typeOfCubes[t].score;
            MeshRenderer cubemesh = cube.GetComponent<MeshRenderer>();
            Color newCol;
            ColorUtility.TryParseHtmlString(typeOfCubes[t].Colour, out newCol);
            
           // Debug.Log(t);
            cubemesh.material.color = newCol;
        }
    }
    private void Update()
    {
        timer = timer - Time.deltaTime;
    }
    void read_data()
    {
        TextAsset contents = Resources.Load<TextAsset>("data");
        type = JsonUtility.FromJson<Data>(contents.text);
                Debug.Log(contents.text);

         
    }
}

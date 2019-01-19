using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : Element {

	// Use this for initialization

    public void set_environment()
    {
        read_data();
        int r = Random.Range(0, 4);
        app.model.typeOfCubes.Add(app.model.type.cube[r]);
        Debug.Log(app.model.type.cube[r].colour);
        int r2 = Random.Range(0, 4);
        while (r == r2)
        {
            r2 = Random.Range(0, 4);
        }
        app.model.typeOfCubes.Add(app.model.type.cube[r2]);
        Debug.Log(app.model.type.cube[r2].colour);
        for (int i = 0; i < 10; i++)
        {
            int t = Random.Range(0, 2);
            GameObject cube = Instantiate(app.view.cubePrefab, new Vector3(Random.Range(-45, 45), 0.5f, Random.Range(-45, 45)), new Quaternion(0, 0, 0, 0), app.view.plane.transform) as GameObject;
            cube.GetComponent<Cube_object>().score = app.model.typeOfCubes[t].score;
            MeshRenderer cubemesh = cube.GetComponent<MeshRenderer>();
            Color newCol;
            ColorUtility.TryParseHtmlString(app.model.typeOfCubes[t].Colour, out newCol);

            // Debug.Log(t);
            cubemesh.material.color = newCol;
        }
    }
	public void ball_hit_cube(Collision collision)
    {
        
        int cube_score = collision.gameObject.GetComponent<Cube_object>().score;
        if (app.model.prev_cube == cube_score)
        {
            app.model.streak++;
            app.model.score = app.model.score + (cube_score * app.model.streak);
        }
        else
        {
            app.model.streak = 1;
            app.model.score = app.model.score + cube_score;
            app.model.prev_cube = cube_score;
        }
        app.view.currentScore.text = "Current Score :" + app.model.score;
        Destroy(collision.gameObject);
    }
    public void read_data()
    {
        TextAsset contents = Resources.Load<TextAsset>("data");
        app.model.type = JsonUtility.FromJson<Data>(contents.text);
        Debug.Log(contents.text);
    }
    private void Start()
    {
        
        set_environment();
        app.model.highScore = PlayerPrefs.GetInt("HighScore",0);
        app.view.HighScore.text = "High Score :" + app.model.highScore;
    }

    public void Update()
    {
        if (app.model.timer < 0)
        {
            SceneManager.LoadScene("Menu_scene");
        }
        app.view.timer.text = Mathf.Floor(app.model.timer).ToString();
        if (app.model.score > app.model.highScore)
        {
            PlayerPrefs.SetInt("HighScore", app.model.score);
            app.view.HighScore.text = "High Score :" + app.model.score; 
        }
        app.model.timer = app.model.timer - Time.deltaTime;

    }
}

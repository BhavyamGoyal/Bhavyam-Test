using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_script : MonoBehaviour {
    public int score = 0;
    int prev_cube = 0;
    int streak = 1;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (gameObject.transform.position.y < -5)
        {
            SceneManager.LoadScene("Menu_scene");
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal")*10;
        float moveVertical = Input.GetAxis("Vertical")*10;
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement);

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        { int cube_score = collision.gameObject.GetComponent<Cube_object>().score;
            if (prev_cube == cube_score)
            {
                streak++;
                score = score + (cube_score * streak);
            }
            else
            {
                streak = 1;
                score = score + cube_score;
                prev_cube = cube_score;
            }
            Destroy(collision.gameObject);
        }
    }
}

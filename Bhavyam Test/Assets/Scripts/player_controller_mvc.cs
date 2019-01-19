using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_controller_mvc : Element
{
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
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
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * 10;
        float moveVertical = Input.GetAxis("Vertical") * 10;
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement);

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            app.controller.ball_hit_cube(collision);
        }
    }
}

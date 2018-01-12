using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {

    public float speed = 150;
    public string axis = "Horizontal";

	void FixedUpdate () {
        // Get movement input
        float h = Input.GetAxisRaw(axis);

        // Set Velocity (movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }

    public void resetRacket() {
        Vector2 temp = new Vector2(0, -105);
        GetComponent<Rigidbody2D>().transform.position = temp;
        //GetComponent<Rigidbody2D>().position.Set(0, -100);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 100.0f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void launchBall() {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    public void resetBall() {
        Vector2 temp = new Vector2(0, -95);
        GetComponent<Rigidbody2D>().transform.position = temp;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    void OnCollisionEnter2D(Collision2D col) {
        // This function is called whenever the ball
        // collides with something

        if (col.gameObject.name == "racket") {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "border_bottom") {
            GameManager.instance.SendMessage("ballOut");
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
            float racketWidth) {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }
}

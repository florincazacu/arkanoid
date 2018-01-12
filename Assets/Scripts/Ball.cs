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
}

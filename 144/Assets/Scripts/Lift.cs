using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {
    private float speed = 0;
    private Rigidbody2D my_body;

    void Start() {
        my_body = GetComponent<Rigidbody2D>();
    }
    void Update() {
        my_body.velocity = new Vector2(0, speed);
    }
    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Player") {
            speed = 1.0f;
        }       
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.tag == "Lift_goal") {
            speed = 0;
        }
    }
}
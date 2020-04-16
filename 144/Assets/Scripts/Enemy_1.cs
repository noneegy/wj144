using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 player_start_pos;
    private float speed = 1.5f;   
    private Rigidbody2D my_body;
    void Start() {
        my_body = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(-2f, 2f, 1); 
    }

    void Update() {
        my_body.velocity = new Vector2(speed, 0);
    }

    public void respawn_player() {
        GameObject player2 = Instantiate(player, player_start_pos, Quaternion.identity);
        player2.GetComponent<BoxCollider2D>().enabled = true;
        player2.GetComponent<Player>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.tag == "Player") {
            Destroy(target.gameObject);
            //death_cntr++;
            //TODO:: die scene
            respawn_player();
        }

        if (target.gameObject.tag == "Invincible") {

        }

        if (target.gameObject.tag == "Enemy_goal") {
            speed = -speed;
            if (my_body.velocity.x < 0) {
                transform.localScale = new Vector3(-2f, 2f, 1);
            } else if (my_body.velocity.x > 0) {
                transform.localScale = new Vector3(2f, 2f, 1);
            }
        }
    }
}
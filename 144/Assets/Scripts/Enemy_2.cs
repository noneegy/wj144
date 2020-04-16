using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private Vector3 player_start_pos;
   
    private float speed = 1.5f;
    private Rigidbody2D my_body;
    private int attack;
    
    void Start() {
        my_body = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(-2f, 2f, 1);
        attack = 0;
    }

    void Update() {
        my_body.velocity = new Vector2(speed, 0);
        attack++;
        if(attack == 400) {          
            Instantiate(rock, transform.position, transform.rotation);
            attack = 0;
        }
    }

    public void respawn_player() {
        GameObject player2 = Instantiate(player, player_start_pos, Quaternion.identity);
        player2.GetComponent<BoxCollider2D>().enabled = true;
        player2.GetComponent<Player>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.tag == "Player") {
            Destroy(target.gameObject);
            respawn_player();
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
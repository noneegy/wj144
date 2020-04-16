using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private KeyCode[] left, right;

    private Text time_text;
    private Text tutorial_text;
    private Text finish_text;

    private Rigidbody2D my_body;
    private Animator anim;
    private SpriteRenderer my_sprite;
    private int time;
    private bool is_finished;
    void Start() {
        my_body = GetComponent<Rigidbody2D>();
        my_sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetBool("Walk", false);
        anim.SetBool("Light", true);
        time_text = GameObject.FindGameObjectWithTag("Time").GetComponent<Text>();   
        time = 0;
        tutorial_text = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<Text>();
        tutorial_text.enabled = true;
        finish_text = GameObject.FindGameObjectWithTag("Finish_text").GetComponent<Text>();
        finish_text.enabled = false;
    }

    void Update() {
        if (!is_finished) {         
            Player_moves();
            
            time = (int)Time.timeSinceLevelLoad;
            Set_time_text(time);
        } else {
            Time.timeScale = 0;
        }
     }

    void Player_moves() {
        if (Input.GetKey(left[0]) || Input.GetKey(left[1])) {
            my_body.velocity = new Vector2(-speed, my_body.velocity.y);
           anim.SetBool("Walk", true);
        } else if (Input.GetKey(right[0]) || Input.GetKey(right[1])) {
            my_body.velocity = new Vector2(speed, my_body.velocity.y);
           anim.SetBool("Walk", true);
        } else {
            my_body.velocity = new Vector2(0, my_body.velocity.y);
            anim.SetBool("Walk", false);
        }

        if (my_body.velocity.x < 0) {
            transform.localScale = new Vector3(-2f, 2f, 1);
        } else if (my_body.velocity.x > 0) {
            transform.localScale = new Vector3(2f, 2f, 1);
        }
    }

    public void Set_time_text(int time) {
        if(time_text != null) {
            time_text.text = "" + time;
        }       
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.tag == "Tree") {
            anim.SetBool("Light", false);
            this.gameObject.tag = "Invincible";
            //Destroy(tutorial_text);
            tutorial_text.enabled = false;
        }
        if (target.gameObject.tag == "NotTree") {
            anim.SetBool("Light", true);
            this.gameObject.tag = "Player";
        }
        if (target.gameObject.tag == "Finish") {
            is_finished = true;
            finish_text.enabled = true;
            finish_text.text += time_text.text;           
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    private Transform player;   
    public float min_x, max_x;
    public float min_y, max_y;
    public float camera_start_y;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if (player != null) {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            if (player.position.y > camera_start_y) {
                temp.y = 3.3f;
            } else {
                temp.y = min_y;
            }

            if (temp.x < min_x) {
                temp.x = min_x;
            } else if (temp.x > max_x) {
                temp.x = max_x;
            }
            if (temp.y > max_y) {
                temp.y = max_y;
            } else if (temp.y < min_y) {
                temp.y = min_y;
            }

            transform.position = temp;
        } else if(GameObject.FindGameObjectWithTag("Player")) {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
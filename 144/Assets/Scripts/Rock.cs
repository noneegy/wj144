using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 player_start_pos;
    //[SerializeField]
    //private AudioSource attack_sound;
    public void respawn_player() {
        GameObject player2 = Instantiate(player, player_start_pos, Quaternion.identity);
        player2.GetComponent<BoxCollider2D>().enabled = true;
        player2.GetComponent<Player>().enabled = true;
    }
    void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Player") {
            //attack_sound.Play();
            Destroy(target.gameObject);
            respawn_player();
        }
        if (target.gameObject.tag == "Ground") {
          //  attack_sound.Play();
            Destroy(gameObject);
        }
    }
}
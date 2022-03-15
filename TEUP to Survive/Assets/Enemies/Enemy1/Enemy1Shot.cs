using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Shot : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameSettings gameSettings;
    private GameObject player;

    private float shotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];
        player = GameObject.FindGameObjectWithTag("Player");

        shotSpeed = -2.5f;

        rb.velocity = new Vector2(gameSettings.scrollSpeed + shotSpeed, 0);
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        // update movement of shot to go with camera movement
        rb.velocity = new Vector2(gameSettings.scrollSpeed + shotSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "LeftBorder") { // out of borders
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player" && (!player.GetComponent<PlayerMovement>().unstoppable)){
            Destroy(player.gameObject);
            // POR AGORA ESTÁ A SAIR DO JOGO QUANDO PERDE!
           UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}

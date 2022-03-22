using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private GameSettings gameSettings;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];
        player = GameObject.FindGameObjectWithTag("Player");
       
        rb.velocity = new Vector2(gameSettings.scrollSpeed,0);
    }

    // Update is called once per frame
    void Update() {}

    void FixedUpdate() {
        // update movement of obstacle to go with camera movement
        rb.velocity = new Vector2(rb.velocity.x - gameSettings.speedIncrement, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "LeftBorder"){
            Destroy(this.gameObject);
        }else if (collision.tag == "Player" && (!player.GetComponent<PlayerPowerUps>().IsUnstoppable())){
            Destroy(player.gameObject);
            // POR AGORA ESTÁ A SAIR DO JOGO QUANDO PERDE!
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
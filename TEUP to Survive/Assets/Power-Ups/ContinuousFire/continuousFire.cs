using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousFire : MonoBehaviour
{
    [SerializeField] private BoxCollider2D continuousFireCollider;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float duration;
    private GameSettings gameSettings;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        continuousFireCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];
        player = GameObject.FindGameObjectWithTag("Player");
       
        rb.velocity = new Vector2(gameSettings.scrollSpeed,0);
    }

    // Update is called once per frame
    void Update() {}

    void FixedUpdate() {
        rb.velocity = new Vector2(rb.velocity.x - gameSettings.speedIncrement, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "LeftBorder"){
            Destroy(this.gameObject);
        }else if (collision.tag == "Player"){
            // player.GetComponent<PlayerMovement>().enableContinuousFire(duration);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

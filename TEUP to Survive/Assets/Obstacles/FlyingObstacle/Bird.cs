using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private GameObject player;
    private BirdSound birdSound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        birdSound = FindObjectsOfType<BirdSound>()[0];
        birdSound.On();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        birdSound.Off();
        if(collision.tag == "LeftBorder"){
            Destroy(this.gameObject);
        }else if (collision.tag == "Player" && (!player.GetComponent<PlayerPowerUps>().IsUnstoppable())){
            Destroy(player.gameObject);
            // POR AGORA ESTÁ A SAIR DO JOGO QUANDO PERDE!
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}

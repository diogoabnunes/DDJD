using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstoppablePowerUp : MonoBehaviour
{
    [SerializeField] private float duration;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "LeftBorder"){
            Destroy(this.gameObject);
        }else if (collision.tag == "Player"){
            player.GetComponent<PlayerPowerUps>().ActivateUnstoppable(duration);
            Destroy(this.gameObject);
        }
    }
}

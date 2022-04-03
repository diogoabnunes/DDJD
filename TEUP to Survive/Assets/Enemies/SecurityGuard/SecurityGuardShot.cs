using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGuardShot : MonoBehaviour
{
    private GameObject player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "LeftBorder" ||  collision.tag == "Obstacle") Destroy(this.gameObject);
        else if (collision.tag == "Player" && (!player.GetComponent<PlayerPowerUps>().IsUnstoppable())) collision.GetComponent<Player>().TakeShot();
    }
}

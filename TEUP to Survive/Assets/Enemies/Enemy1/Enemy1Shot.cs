using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Shot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "LeftBorder" ||  collision.tag == "Obstacle") Destroy(this.gameObject);
        else if (collision.tag == "Player") collision.GetComponent<Player>().TakeShot();
    }
}

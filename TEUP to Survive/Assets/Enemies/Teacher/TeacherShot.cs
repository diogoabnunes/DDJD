using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherShot : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    void Start(){
        int index = Random.Range(0, sprites.Length);
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "LeftBorder" || collision.tag == "Obstacle") Destroy(this.gameObject);
        else if (collision.tag == "Player") collision.GetComponent<Player>().TakeShot();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] public class Obstacle1Asset {
    public Sprite sprite;
    public string animationName;
}

public class Obstacle1Assets : MonoBehaviour
{
    [SerializeField] private Obstacle1Asset[] assets;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        int i = Random.Range(0,assets.Length);
        
        if(assets[i].animationName == "") anim.SetTrigger("Exit");
        else anim.SetTrigger(assets[i].animationName);
        
        this.gameObject.GetComponent<SpriteRenderer>().sprite = assets[i].sprite;
    }
}

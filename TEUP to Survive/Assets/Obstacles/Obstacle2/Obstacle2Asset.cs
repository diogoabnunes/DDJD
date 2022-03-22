using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Asset : MonoBehaviour
{
     [SerializeField] private Sprite[] assets;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0,assets.Length);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = assets[i];
    }
}

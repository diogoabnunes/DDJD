using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMovement : MonoBehaviour
{
    private Collectible collectible;
    // Start is called before the first frame update
    void Start()
    {
        collectible = gameObject.GetComponent<Collectible>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, collectible.player.transform.position, collectible.moveSpeed * Time.deltaTime);
    }
    
}

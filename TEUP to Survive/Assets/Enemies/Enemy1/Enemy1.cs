using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    [SerializeField] private GameObject shot;

    private float coolDown; // how much to wait for the next shot
    private float nextShot; // instant of the next shot

    private float numShotsCanTake; // number of shots that can take before dies

    private float direction; // moving up or down

    // Start is called before the first frame update
    void Start()
    {
        coolDown = 1f;
        nextShot = 0f;   

        numShotsCanTake = 1f;

        direction = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShot) {
            Shot();
            nextShot = Time.time + nextShot;
        }
    }

    void FixedUpdate() {

    }

    void Shot() {
        Instantiate(shot, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "TigerShot"){
            numShotsCanTake--;

            if (numShotsCanTake == 0) {
                Destroy(this.gameObject);
            }
        }
    }
}

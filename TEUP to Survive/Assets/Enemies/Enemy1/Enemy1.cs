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
    private const float UP = 1f, DOWN = -1f;
    private const float speedMovement = 0.1f;

    void Start()
    {
        coolDown = 2f;
        nextShot = 0f;   

        numShotsCanTake = 1f;

        direction = UP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShot) {
            Shot();
            nextShot = Time.time + coolDown;
        }
    }

    void FixedUpdate() {
        Move();
    }

    void Shot() {
        Instantiate(shot, transform.position, transform.rotation);
    }

    void Move() {
        transform.position = transform.position + new Vector3(0, direction * speedMovement, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "TigerShot"){
            numShotsCanTake--;
            Debug.Log("Atingindo!!!!");
            if (numShotsCanTake == 0) {
                Destroy(this.gameObject);
            }
        }
        else if (collision.tag == "TopBorder") {
            direction = DOWN;
        }
        else if (collision.tag == "BottomBorder") {
            direction = UP;
        }
    }
}

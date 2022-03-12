using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool unstoppable;// power-up effect (coffee??)
    [SerializeField] private GameObject tigerShot;

    private bool jump = false;
    private float lastShot;
    private float coolDownShot;

    // Start is called before the first frame update
    void Start()
    {
       unstoppable = false; 
       lastShot = -1f;
       coolDownShot = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKey(KeyCode.Return) && CanShot())
        {
            Shot();
        }
    }

    void FixedUpdate() {
        if (jump) {
            rb.AddForce(Vector2.up * 7.5f * speed);
            jump = false;
        }
    }

    private bool CanShot() {
        if (lastShot == -1 || (Time.time - lastShot) > coolDownShot) {
            lastShot = Time.time;
            return true;
        }

        return false;
    }

    private void Shot() {
        Instantiate(tigerShot, transform.position, transform.rotation);
    }
}

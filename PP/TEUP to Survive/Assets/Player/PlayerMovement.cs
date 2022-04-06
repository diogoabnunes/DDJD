using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private bool jump;
    private Animator animator;
    private Animator animatorContinuousFire;

    void Start()
    {
        jump = false; 
        animator = transform.GetChild(1).GetComponent<Animator>();
        animatorContinuousFire = transform.GetChild(2).GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) jump = true;
    }

    void FixedUpdate() {
        if (jump) {
            animator.SetBool("IsMoving", false);
            animator.SetBool("JetPackOn", true);
            animatorContinuousFire.SetBool("IsMoving", false);
            animatorContinuousFire.SetBool("JetPackOn", true);
            rb.AddForce(Vector2.up * 7.5f * speed);
            jump = false;
        }else{
            animator.SetBool("JetPackOn", false);
            animatorContinuousFire.SetBool("JetPackOn", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "BottomBorder") {
            animator.SetBool("IsMoving", true);
            animatorContinuousFire.SetBool("IsMoving", true);
        }
    }
}

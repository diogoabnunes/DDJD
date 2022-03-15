using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{   
    private bool unstoppable;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        unstoppable = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update(){}

    public bool IsUnstoppable(){
        return unstoppable;
    }

    public void ActivateUnstoppable(float duration){
        StartCoroutine(Unstoppable(duration));
    }

    IEnumerator Unstoppable(float duration){
        unstoppable = true;
        yield return new WaitForSeconds(duration);
        unstoppable = false;
    }

    public void ActivateContinuousFire(float duration){
        StartCoroutine(ContinuousFire(duration));
    }

    IEnumerator ContinuousFire(float duration){
        float coolDown = player.GetComponent<PlayerFire>().GetCoolDown();
        player.GetComponent<PlayerFire>().SetShotCoolDown(0.2f);
        yield return new WaitForSeconds(duration);
        player.GetComponent<PlayerFire>().SetShotCoolDown(coolDown);
    }
}

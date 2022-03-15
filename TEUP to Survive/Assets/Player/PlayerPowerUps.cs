using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{   
    private bool unstoppable;
    private bool continuousFire;
    // Start is called before the first frame update
    void Start()
    {
        unstoppable = false;
        continuousFire = false;
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
}

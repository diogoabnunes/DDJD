using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{   
    private bool unstoppable;
    private GameObject player;
    private GameObject collectiblesDetector;
    
    private GameObject magnetEffect;

    private float startBlinkEffect = 3f;

    // Start is called before the first frame update
    void Start()
    {
        unstoppable = false;
        player = GameObject.FindGameObjectWithTag("Player");
        magnetEffect = GameObject.FindGameObjectWithTag("MagnetEffect");
        collectiblesDetector = GameObject.FindGameObjectWithTag("Collectibles Detector");
        collectiblesDetector.SetActive(false);
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

    public void ActivateAttraction(float duration){
        StartCoroutine(Attraction(duration));
    }

    IEnumerator Attraction(float duration){
        collectiblesDetector.SetActive(true);
        if(duration > startBlinkEffect){
            yield return new WaitForSeconds(duration - startBlinkEffect);
            magnetEffect.GetComponent<BlinkEffect>().enabled = true;
            yield return new WaitForSeconds(startBlinkEffect);
        }else{
            magnetEffect.GetComponent<BlinkEffect>().enabled = true;
            yield return new WaitForSeconds(duration);
        }
        magnetEffect.GetComponent<BlinkEffect>().enabled = false;
        magnetEffect.GetComponent<BlinkEffect>().ResetColor();
        collectiblesDetector.SetActive(false);
    }
}

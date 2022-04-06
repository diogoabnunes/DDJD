using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{   
    private bool unstoppable;
    private GameObject player;
    private GameObject collectiblesDetector;
    
    private GameObject magnetEffect;
    private GameObject continuousFireEffect;
    private GameObject unstoppableEffect;

    private float startBlinkEffect = 3f;

    // Start is called before the first frame update
    void Start()
    {
        unstoppable = false;
        player = GameObject.FindGameObjectWithTag("Player");
        magnetEffect = GameObject.FindGameObjectWithTag("MagnetEffect");
        continuousFireEffect = GameObject.FindGameObjectWithTag("ContinuousFireEffect");
        unstoppableEffect = GameObject.FindGameObjectWithTag("UnstoppableEffect");
        collectiblesDetector = GameObject.FindGameObjectWithTag("Collectibles Detector");

        collectiblesDetector.SetActive(false);
        continuousFireEffect.SetActive(false);
        unstoppableEffect.SetActive(false);
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
        unstoppableEffect.SetActive(true);
        unstoppable = true;
        if(duration > startBlinkEffect){
            yield return new WaitForSeconds(duration - startBlinkEffect);
            unstoppableEffect.GetComponent<BlinkEffect>().enabled = true;
            yield return new WaitForSeconds(startBlinkEffect);
        }else{
            unstoppableEffect.GetComponent<BlinkEffect>().enabled = true;
            yield return new WaitForSeconds(duration);
        }
        unstoppable = false;
        unstoppableEffect.GetComponent<BlinkEffect>().enabled = false;
        unstoppableEffect.GetComponent<BlinkEffect>().ResetColor();
        unstoppableEffect.SetActive(false);
    }

    public void ActivateContinuousFire(float duration){
        StartCoroutine(ContinuousFire(duration));
    }

    IEnumerator ContinuousFire(float duration){
        continuousFireEffect.SetActive(true);
        float coolDown = player.GetComponent<PlayerFire>().GetCoolDown();
        player.GetComponent<PlayerFire>().SetShotCoolDown(0.2f);
        if(duration > startBlinkEffect){
            yield return new WaitForSeconds(duration - startBlinkEffect);
            continuousFireEffect.GetComponent<BlinkEffect>().enabled = true;
            yield return new WaitForSeconds(startBlinkEffect);
        }else{
            continuousFireEffect.GetComponent<BlinkEffect>().enabled = true;
            yield return new WaitForSeconds(duration);
        }
        player.GetComponent<PlayerFire>().SetShotCoolDown(coolDown);
        continuousFireEffect.GetComponent<BlinkEffect>().enabled = false;
        continuousFireEffect.GetComponent<BlinkEffect>().ResetColor();
        continuousFireEffect.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerJetPack : MonoBehaviour
{
    [SerializeField] private Sprite tigerJetPackOn;
    private bool jetPackOn;
    private Sprite tigerJetPackOff;
    
    
    // Start is called before the first frame update
    void Start()
    {
        tigerJetPackOff = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        jetPackOn = false;
    }
    
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.Space)){
            jetPackOn = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = tigerJetPackOn;
        }else if(jetPackOn){
            Debug.Log("Deligar");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = tigerJetPackOff;
            jetPackOn = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Destroy(this.gameObject, 1f);   
      transform.position +=  new Vector3(0,0.5f,0);
    }
}

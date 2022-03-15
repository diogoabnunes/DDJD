using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool unstoppable;// power-up effect (coffee??)
    
    void Start()
    {
        unstoppable = false;
    }

    public void TakeShot() {
        Destroy(this.gameObject);
        // POR AGORA ESTÁ A SAIR DO JOGO QUANDO PERDE!
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

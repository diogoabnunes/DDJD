using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] [Range(0, 10)] private float speed = 1f;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed,1));
    }

    public void ResetColor(){
        sprite.color = startColor;
    }
}

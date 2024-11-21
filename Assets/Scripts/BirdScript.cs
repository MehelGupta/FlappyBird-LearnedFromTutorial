using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public Rigidbody2D myRigidbody;
    public float flapStrength;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), .15f, .15f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)==true || Input.GetMouseButtonDown(0))
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.tag == "Obstacle")
        {
            FindFirstObjectByType<GameManager>().GameOver();
        }
        else if(other.gameObject.tag == "Scoring")
        {
            FindFirstObjectByType<GameManager>().IncreaseScore();
        }
    }
}

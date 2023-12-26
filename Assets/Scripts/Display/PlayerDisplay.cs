using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D parentRigidbody2D;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentRigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (parentRigidbody2D.velocity.x > 0)
            spriteRenderer.flipX = false;
        else if (parentRigidbody2D.velocity.x < 0)
            spriteRenderer.flipX = true;
    }
}

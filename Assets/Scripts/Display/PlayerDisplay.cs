using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplay : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D parentRigidbody2D;

    [SerializeField] SpriteRenderer eyes;
    [SerializeField] Transform leg1;
    [SerializeField] Transform leg2;

    [SerializeField] Sprite eyesOpen;
    [SerializeField] Sprite eyesClose;

    float oldRot1;
    float oldRot2;

    bool flash = true;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentRigidbody2D = GetComponentInParent<Rigidbody2D>();

        oldRot1 = leg1.rotation.eulerAngles.z;
        oldRot2 = leg2.rotation.eulerAngles.z;

        StartCoroutine(EyesFlashesCoroutine());
    }
    IEnumerator EyesFlashesCoroutine()
    {
        while (flash)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
            eyes.sprite = eyesClose;
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
            eyes.sprite = eyesOpen;
        }
    }
    private void Update()
    {
        if (parentRigidbody2D.velocity.magnitude > 1f)
        {
            leg1.rotation = Quaternion.Euler(0, 0, oldRot1 - 20f);
            leg2.rotation = Quaternion.Euler(0, 0, oldRot2 - 20f);
        } 
        else
        {
            leg1.rotation = Quaternion.Euler(0, 0, oldRot1);
            leg2.rotation = Quaternion.Euler(0, 0, oldRot2);
        }
    }
}

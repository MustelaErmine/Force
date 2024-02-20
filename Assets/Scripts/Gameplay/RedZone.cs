using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movable>() != null)
        {
            collision.GetComponent<Movable>().canMove++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Movable>() != null)
        {
            collision.GetComponent<Movable>().canMove--;
        }
    }
}

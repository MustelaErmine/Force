using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movable>() != null)
        {
            collision.GetComponent<Movable>().blockers.Add(GetHashCode());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Movable>() != null)
        {
            collision.GetComponent<Movable>().blockers.Remove(GetHashCode());
        }
    }
}

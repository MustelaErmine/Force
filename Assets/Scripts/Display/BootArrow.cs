using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootArrow : MonoBehaviour, IArrowDisplay
{
    Transform display, thisTransform;
    public void ApplyForce(float force)
    {
        display.localEulerAngles = new Vector3(0, 0, force * -90f);
        if (force < 1e-5)
            thisTransform.position = new Vector2(20, 20);
    }

    public void ApplyPosition(Vector2 objectPosition, Vector2 mousePosition)
    {
        thisTransform.position = objectPosition;
        Vector3 diff = mousePosition - objectPosition;
        float angle = -Mathf.Atan(diff.x / diff.y) / Mathf.PI * 180;
        if (diff.y < 0)
            angle = angle - 180;
        thisTransform.localEulerAngles = new Vector3(0, 0, angle + 90);
    }

    void Start()
    {
        thisTransform = transform;
        display = transform.GetChild(0);
    }
}

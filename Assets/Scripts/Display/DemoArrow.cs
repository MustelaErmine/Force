using UnityEngine;

public class DemoArrow : MonoBehaviour, IArrowDisplay
{
    new Transform transform;
    SpriteMask arrowMask;

    void Start ()
    {
        arrowMask = GetComponentInChildren<SpriteMask>();
        transform = GetComponent<Transform>();
    }
    public void ApplyForce (float force)
    { 
        arrowMask.transform.localPosition = new Vector2(0, (1 - force) * -0.52f);
        arrowMask.transform.localScale = new Vector2(4, 1 + (5.5f - 1) * force);
        if (force < 1e-5)
        {
            transform.position = new Vector2(20, 20);
        }
    }
    public void ApplyPosition(Vector2 characterPosition, Vector2 mousePosition)
    {
        transform.position = (characterPosition + mousePosition) / 2;
        Vector3 diff = mousePosition - characterPosition;
        float angle = -Mathf.Atan(diff.x / diff.y) / Mathf.PI * 180;
        if (diff.y < 0)
            angle = angle - 180;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
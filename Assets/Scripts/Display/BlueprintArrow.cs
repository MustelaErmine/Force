using UnityEngine;
using UnityEngine.U2D;

public class BlueprintArrow : MonoBehaviour, IArrowDisplay
{
    new Transform transform;
    Transform mask, display;
    public void ApplyForce(float force)
    {
        display.localPosition = new Vector3(0, force, 0);

        if (force < 1e-5)
        {
            transform.position = new Vector2(20, 20);
        }
    }

    public void ApplyPosition(Vector2 objectPosition, Vector2 mousePosition)
    {
        transform.position = objectPosition;
        Vector3 diff = mousePosition - objectPosition;
        float angle = -Mathf.Atan(diff.x / diff.y) / Mathf.PI * 180;
        if (diff.y < 0)
            angle = angle - 180;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void Start()
    {
        display = GetComponentInChildren<SpriteShapeController>().transform;
        mask = GetComponentInChildren<SpriteMask>().transform;
        transform = GetComponent<Transform>();
    }
}

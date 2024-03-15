using UnityEngine;

public interface IArrowDisplay
{
    public void ApplyForce(float force);
    public void ApplyPosition(Vector2 objectPosition, Vector2 mousePosition);
}

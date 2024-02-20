using UnityEngine;

public interface IArrowDisplay
{
    public float Force { set; }
    public void ApplyPosition(Vector2 characterPosition, Vector2 mousePosition);
}

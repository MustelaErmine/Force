using UnityEngine;

public interface IArrow
{
    public float Force { set; }
    public void ApplyPosition(Vector2 characterPosition, Vector2 mousePosition);
}

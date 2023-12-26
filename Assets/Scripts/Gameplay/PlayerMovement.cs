using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    new Transform transform;
    Transform arrow;

    float force = 0;
    const float forcePerSecond = 0.75f;
    const float forceCoeff = 1500f;

    void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !GameplayMenu.pause)
        {
            force += forcePerSecond * Time.deltaTime;
            force = Mathf.Min(1, force);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            ArrowSpawner.arrow.ApplyPosition(transform.position, mousePosition);
            ArrowSpawner.arrow.Force = force;
        } 
        if (Input.GetMouseButtonUp(0) && !GameplayMenu.pause)
        {
            if (force > 0.01f)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 diff = mousePosition - transform.position;
                Jump(diff.normalized * force);
            }
            force = 0;
            ArrowSpawner.arrow.Force = force;
        }
    }
    void Jump(Vector3 where)
    {
        where.z = 0;
        rigidbody2D.AddForce(where * forceCoeff, ForceMode2D.Force);
    }
}

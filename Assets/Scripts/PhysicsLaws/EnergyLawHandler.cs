using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyLawHandler : PhysicsLawHandler
{
    public override LawEnum MyLaw => LawEnum.ConservationOfEnergy;

    bool mode;
    new Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    new void Start()
    {
        base.Start();
    }

    protected override void EnableLaw()
    {
        mode = false;
    }
    protected override void DisableLaw()
    {
        mode = true;
    }
    private void Update()
    {
        if (mode)
        {
            rigidbody2D.velocity = new Vector2(0, Mathf.Clamp(rigidbody2D.velocity.y, -9.81f, 0f));
        }
    }
}

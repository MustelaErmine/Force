using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityLawHandler : PhysicsLawHandler
{
    public override LawEnum MyLaw => LawEnum.Gravity;

    private Vector2 oldGravity = new Vector2(0f, -9.81f);

    new void Start()
    {
        base.Start();
    }
    
    protected override void EnableLaw()
    {
        Physics2D.gravity = oldGravity;
    }
    protected override void DisableLaw()
    {
        oldGravity = Physics2D.gravity;
        Physics2D.gravity = Vector2.zero;
    }
}

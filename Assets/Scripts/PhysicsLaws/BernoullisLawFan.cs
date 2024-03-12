using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BernoullisLawFan : PhysicsLawHandler
{

    public override LawEnum MyLaw => LawEnum.Bernoullis;

    bool mode;

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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (mode && collision.GetComponent<Rigidbody2D>())
        {
            Vector2 vector = new Vector2(Random.value - 0.5f, Random.value - 0.5f).normalized;
            collision.GetComponent<Rigidbody2D>().AddForce(vector * 10f);
        }
    }
}

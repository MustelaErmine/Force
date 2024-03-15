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
        StartCoroutine(Coroutine());
    }

    protected override void EnableLaw()
    {
        mode = false;
    }
    protected override void DisableLaw()
    {
        mode = true;
    }
    IEnumerator Coroutine()
    {
        while (true)
        {
            if (mode)
            {
                yield return new WaitForSeconds(0.02f);
                rigidbody2D.velocity *= 0.99f;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}

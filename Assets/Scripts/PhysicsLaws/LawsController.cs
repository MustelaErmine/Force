using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LawsController : MonoBehaviour
{
    public static LawsController instance;

    public List<LawEnum> inScene;
    public List<LawEnum> enabledLaws;

    public UnityEvent<LawEnum[]> lawsUpdated;

    public bool CanContinue { get => true; }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lawsUpdated.Invoke(enabledLaws.ToArray());
    }

    public void EnableLaw(LawEnum law)
    {
        if (!enabledLaws.Contains(law))
        {
            enabledLaws.Add(law);
        }
        lawsUpdated.Invoke(enabledLaws.ToArray());
    }
    public void DisableLaw(LawEnum law)
    {
        if (enabledLaws.Contains(law))
        {
            enabledLaws.Remove(law);
        }
        lawsUpdated.Invoke(enabledLaws.ToArray());
    }
}

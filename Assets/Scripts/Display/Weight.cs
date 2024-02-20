using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weight : Movable
{
    public float Mass { 
        set
        {
            _mass = value;
            _rb.mass = _mass;
            _textMeshPro.text = $"{_mass} kg";
        }
        get => _mass;
    }
    private float _mass;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private TextMeshPro _textMeshPro;
    void Start()
    {
        base.Start();
        Mass = _rb.mass;
    }
}

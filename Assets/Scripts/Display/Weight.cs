using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public float Mass { 
        set
        {
            _mass = value;
            _rb.mass = _mass;
            _textMeshPro.text = $"{_mass}";
        }
        get => _mass;
    }
    private float _mass;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private TextMeshPro _textMeshPro;
    void Start()
    {
        Mass = _rb.mass;
    }
}

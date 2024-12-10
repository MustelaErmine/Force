using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movable : MonoBehaviour, IPointerClickHandler
{
    bool _isChosen = false;
    public bool IsChosen
    {
        get => _isChosen; set
        {
            _isChosen = value;
            if (_isChosen)
            {
                outline.color = Color.yellow;
            }
            else
            {
                outline.color = Color.white;
            }
        }
    }
    [SerializeField] SpriteRenderer outline;
    public void OnPointerClick(PointerEventData eventData)
    {
        IsChosen = true;
        CastHandler.ChosenMovable = this;
    }

    Rigidbody2D _rigidbody2D;
    Transform _transform;

    float force = 0;
    const float forcePerSecond = 0.75f;
    const float forceCoeff = 300f;

    public HashSet<int> blockers = new HashSet<int>();

    protected void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CastHandler.ChosenMovable == this && Input.GetMouseButton(0) && !GameplayMenu.pause)
        {
            force += forcePerSecond * Time.deltaTime;
            force = Mathf.Min(1, force);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            CastHandler.instanse.arrow.ApplyPosition(_transform.position, mousePosition);
            CastHandler.instanse.arrow.ApplyForce(force);
        }
        if (CastHandler.ChosenMovable == this && Input.GetMouseButtonUp(0) && !GameplayMenu.pause)
        {
            if (force > 0.01f)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 diff = mousePosition - _transform.position;
                diff.z = 0;
                Jump(diff.normalized * force);
            }
            force = 0;
            CastHandler.instanse.arrow.ApplyForce(force);
        }
    }
    void Jump(Vector3 where)
    {
        if (blockers.Count != 0) { return; }

        StarsHandler.instance.IncreaseMoves();

        where.z = 0;
        _rigidbody2D.AddForce(where * forceCoeff, ForceMode2D.Force);

        if (where.magnitude < 0.8f)
            CastHandler.instanse.PlaySlide();
        else
            CastHandler.instanse.PlayFast();
    }
}
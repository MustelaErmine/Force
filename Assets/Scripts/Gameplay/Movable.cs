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
    const float forceCoeff = 1500f;

    public int canMove = 0;

    protected void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CastHandler.ChosenMovable == this && Input.GetMouseButton(0) && !GameplayMenu.pause && canMove == 0)
        {
            force += forcePerSecond * Time.deltaTime;
            force = Mathf.Min(1, force);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            CastHandler.arrow.ApplyPosition(_transform.position, mousePosition);
            CastHandler.arrow.Force = force;
        }
        if (CastHandler.ChosenMovable == this && Input.GetMouseButtonUp(0) && !GameplayMenu.pause && canMove == 0)
        {
            if (force > 0.01f)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 diff = mousePosition - _transform.position;
                Jump(diff.normalized * force);
            }
            force = 0;
            CastHandler.arrow.Force = force;
        }
    }
    void Jump(Vector3 where)
    {
        where.z = 0;
        _rigidbody2D.AddForce(where * forceCoeff, ForceMode2D.Force);
    }
}
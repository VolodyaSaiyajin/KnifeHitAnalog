using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UsedKnife : MonoBehaviour
{
    
    public bool KnifeHitKnife => _knifeHitKnife;
    public bool IsActive => _isActive;

    private ScoreCounter _scoreCounter;

    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private float _knifeRicochet = 1f;

    private KnifeStack _knifeStack;
    
    [SerializeField] protected Vector2 _capsuleColliderOffset;
    [SerializeField] protected Vector2 _capsuleColliderSize;


    private CapsuleCollider2D _capsuleCollider;
    private bool _isActive;
    private bool _knifeHitKnife;

    private void Start()
    {
        _knifeStack = FindObjectOfType<KnifeStack>();
        _scoreCounter = FindObjectOfType<ScoreCounter>();
        _rb2d = GetComponent<Rigidbody2D>();
        _capsuleColliderOffset = new Vector2(0.0384099893f, -1.49900138f);
        _capsuleColliderSize = new Vector2(0.372321725f, 1.71944439f);
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnEnable()
    {
        _isActive = true;
    }

    public void TryThrow(float throwSpeed)
    {
        if (IsActive)
        {
            _rb2d.AddForce(Vector2.up * throwSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out UsedKnife _))
        {
            Debug.Log("hit knife");
            OnKnifeHitKnife();
        }
        else if (collision.gameObject.TryGetComponent(out CircleGO _))
        {
            OnCircleHit(collision);
        }

    }

    private void OnCircleHit(Collision2D collision)
    {
        _scoreCounter.SetScore();

        _rb2d.velocity = Vector3.zero;

        _rb2d.bodyType = RigidbodyType2D.Kinematic;

        transform.SetParent(collision.collider.transform);

        SetCapsuleCollider();

        if (_knifeStack.CurrentKnifeCount >= 0 && _knifeStack.CurrentKnifeCount <= _knifeStack.MaxKnifes)
        {
            _knifeStack.RemoveKnifeFromStack();
        }


    }

    private void OnKnifeHitKnife()
    {
        _isActive = false;
        _rb2d.velocity = Vector3.zero;
        _knifeHitKnife = true;
        _rb2d.AddForce(new Vector2(0f, -_knifeRicochet), ForceMode2D.Impulse);
        _knifeStack.OnKnifeHit();
        SetCapsuleCollider();
    }

    private void SetCapsuleCollider()
    {
        _capsuleCollider.offset = _capsuleColliderOffset;

        _capsuleCollider.size = _capsuleColliderSize;
    }
}

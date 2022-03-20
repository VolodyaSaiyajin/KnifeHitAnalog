
using UnityEngine;

public abstract class Circle : CircleGO
{
    [Header("Circle Game Object")]
    [SerializeField] protected CircleGO _circle;
    [SerializeField] protected KnifeStack _knifeStack;

    [Header("Settings difficulty")]

    [SerializeField] protected float speedModifier;

    [SerializeField] protected float minRotationSpeed;
    [SerializeField] protected bool _isRotate;
    [SerializeField] protected float maxRotationSpeed;
    [Header("Just for look")]

    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected float halfMeanValueSpeed;
    [SerializeField] protected float meanValueSpeed;

    protected Transform _circleTransform;

    private void Start()
    {
        _circleTransform = _circle.gameObject.GetComponent<Transform>();
    }

    public abstract void RotateCircle();
}

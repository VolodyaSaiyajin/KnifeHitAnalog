
using UnityEngine;

public abstract class Knife : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    
    [Header("Current knife")]
    [SerializeField] protected float throwSpeed;
    [SerializeField] protected KnifeStack knifeStack;

    public abstract void Throw();
}

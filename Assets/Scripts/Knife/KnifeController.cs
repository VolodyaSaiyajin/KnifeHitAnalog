using UnityEngine;
using UnityEngine.Events;

public class KnifeController : Knife
{
    private UsedKnife _usedKnife;
    private void Start()
    {
        _usedKnife = FindObjectOfType<UsedKnife>();
    }

    private void Update()
    {
        Throw();
    }


    public override void Throw()
    {

        if (Input.GetMouseButtonDown(0) &&
            _usedKnife.IsActive)
        {
            var knifeClone = knifeStack.CurrentCnife.GetComponent<UsedKnife>();
            knifeClone.TryThrow(throwSpeed);
        }
    }

}

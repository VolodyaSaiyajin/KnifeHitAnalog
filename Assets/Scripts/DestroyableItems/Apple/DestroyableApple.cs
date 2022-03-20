using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableApple : MonoBehaviour, IDestroyable
{
    public int Coin { get; private set; }

    DestroyableApple()
    {
        Coin = 10;
    }
}

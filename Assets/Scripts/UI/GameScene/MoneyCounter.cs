using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    private void Update()
    {

        Debug.Log(Coins);
    }

    public int Coins { get; set; }

    public void SetCoins(int receivedCoin)
    {
        Coins += receivedCoin;
    }
}

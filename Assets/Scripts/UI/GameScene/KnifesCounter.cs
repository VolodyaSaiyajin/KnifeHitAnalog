using TMPro;
using UnityEngine;

public class KnifesCounter : MonoBehaviour
{
    private TextMeshProUGUI _knifesScoreText;
    [SerializeField ] private KnifeStack _knifeStack;

    private int _counter;

    private void Start()
    {
        _knifesScoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _counter = _knifeStack.KnifeCount;
        CountKnifes();
    } 

    private void CountKnifes()
    {
        _knifesScoreText.text = $"Knifes: {_counter}";
    }
}

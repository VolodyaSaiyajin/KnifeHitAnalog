using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI _knifesScoreText;

    private int _score;

    private void Start()
    {
        _knifesScoreText = GetComponent<TextMeshProUGUI>();
        CountScore();
    }

    private void Update()
    {
        CountScore();
    }

    private void CountScore()
    {
        _knifesScoreText.text = $"{_score}";
    }

    public void SetScore()
    {
        _score += 10;
    }
}

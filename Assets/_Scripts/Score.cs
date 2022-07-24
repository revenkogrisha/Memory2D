using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _reward = 10;
    [SerializeField] private TextMesh _scoreText;

    private int Amount = 0;

    private void Start()
    {
        _scoreText.text = $"Score: {Amount}";
    }

    public void Match()
    {
        Amount += _reward;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = $"Score: {Amount}";
    }
}

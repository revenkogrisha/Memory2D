using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _reward = 10;
    [SerializeField] private ScoreView _scoreView;

    private int Amount = 0;

    private void Awake()
    {
        _scoreView.UpdateText(Amount);
    }

    public void Match()
    {
        Amount += _reward;
        _scoreView.UpdateText(Amount);
    }

    private void UpdateText() => _scoreView.UpdateText(Amount);
}

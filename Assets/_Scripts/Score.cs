using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int _reward = 10;
    [SerializeField] private CardCoincidenceChecker _checker;
    [SerializeField] private ScoreView _scoreView;

    private int Amount = 0;

    #region MonoBehaviour

    private void Awake()
    {
        _scoreView.UpdateText(Amount);
    }

    private void OnEnable()
    {
        _checker.OnMatch += Match;
    }
    
    private void OnDisable()
    {
        _checker.OnMatch -= Match;
    }

    #endregion

    public void Match()
    {
        Amount += _reward;
        _scoreView.UpdateText(Amount);
    }
}

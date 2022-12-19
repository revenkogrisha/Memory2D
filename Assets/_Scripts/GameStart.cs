using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private CardGenerator _generator;
    [SerializeField] private CardCoincidenceChecker _checker;
    [SerializeField] private Score _score;

    #region MonoBehaviour

    private void Start()
    {
        var cards = _generator.GenerateCards();
        _checker.Init(cards);
    }

    #endregion
}

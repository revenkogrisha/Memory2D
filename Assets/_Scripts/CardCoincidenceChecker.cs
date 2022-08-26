using System.Collections;
using UnityEngine;

public class CardCoincidenceChecker : MonoBehaviour
{
    [SerializeField] private Score _score;

    private MemoryCard _currentCard;
    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;

    public void SetRevealedCard(MemoryCard card)
    {
        _currentCard = card;

        if (_firstRevealed == null)
        {
            SetFirstCard();
        }
        else if (_secondRevealed == null)
        {
            SetSecondCard();
            StartCoroutine(CheckMatch());
            ResetBothCards();
        }
    }

    private void SetFirstCard()
    {
        _firstRevealed = _currentCard;
        _currentCard.Reveal();
    }
    
    private void SetSecondCard()
    {
        _secondRevealed = _currentCard;
        _currentCard.Reveal();
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.Id == _secondRevealed.Id)
        {
            _score.Match();
        }
        else
        {
            yield return new WaitForSeconds(.5f);

            HideBothCards();
        }
    }

    private void HideBothCards()
    {
        _firstRevealed.Hide();
        _secondRevealed.Hide();
    }

    private void ResetBothCards()
    {
        _firstRevealed = null;
        _secondRevealed = null;
    }
}

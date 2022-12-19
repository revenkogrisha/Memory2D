using System;
using System.Collections;
using UnityEngine;

public class CardCoincidenceChecker : MonoBehaviour
{
    private MemoryCard _currentCard;
    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;
    private readonly float _hideDelay = 0.5f;

    public event Action OnMatch;

    public void SetRevealedCard(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            SetFirstCard(card);
        }
        else if (_secondRevealed == null)
        {
            SetSecondCard(card);
            StartCoroutine(CheckMatch());
        }
    }

    private void SetFirstCard(MemoryCard card)
    {
        _firstRevealed = card;
        _currentCard.Reveal();
    }
    
    private void SetSecondCard(MemoryCard card)
    {
        _secondRevealed = card;
        _currentCard.Reveal();
    }

    private IEnumerator CheckMatch()
    {
        if (!_firstRevealed || !_secondRevealed)
            throw new Exception("One of revealed cards is null!");

        if (_firstRevealed.Id == _secondRevealed.Id)
        {
            OnMatch?.Invoke();
        }
        else
        {
            yield return new WaitForSeconds(_hideDelay);

            HideBothCards();
        }

        ResetBothCards();
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

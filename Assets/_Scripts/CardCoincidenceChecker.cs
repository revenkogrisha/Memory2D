using System;
using System.Collections;
using UnityEngine;

public class CardCoincidenceChecker : MonoBehaviour
{
    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;
    private readonly float _hideDelay = 0.5f;
    private MemoryCard[] _cards;

    public event Action OnMatch;

    #region MonoBehaviour

    public void OnDisable()
    {
        if (_cards != null)
            foreach (var card in _cards)
                card.OnRevealed -= SetRevealedCard;
    }

    #endregion

    public void Init(MemoryCard[] cards)
    {
        foreach (var card in cards)
            card.OnRevealed += SetRevealedCard;

        _cards = cards;
    }

    public void SetRevealedCard(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
            card.Reveal();
        }
        else if (_secondRevealed == null)
        {
            _secondRevealed = card;
            card.Reveal();

            StartCoroutine(CheckMatch());
        }
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

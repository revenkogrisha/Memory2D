using System.Collections;
using UnityEngine;

public class CardCoincidenceChecker : MonoBehaviour
{
    [SerializeField] private Score _score;

    private MemoryCard _card;
    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;

    public void CardWasTrieToRevealed(MemoryCard card)
    {
        _card = card;

        if (_firstRevealed == null)
        {
            SetUpFirstCard();
        }
        else if (_secondRevealed == null)
        {
            SetUpSecondCard();
        }
    }

    private void SetUpFirstCard()
    {
        _firstRevealed = _card;
        _card.Reveal();
    }
    
    private void SetUpSecondCard()
    {
        _secondRevealed = _card;
        _card.Reveal();

        StartCoroutine(CheckMatch());
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

            UnrevealBothCards();
        }

        UpdateBothCards();
    }

    private void UnrevealBothCards()
    {
        _firstRevealed.Unreveal();
        _secondRevealed.Unreveal();
    }

    private void UpdateBothCards()
    {
        _firstRevealed = null;
        _secondRevealed = null;
    }
}

using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject _cardBack;
    [SerializeField] private CardCoincidenceChecker _cardChecker;

    private int _id;

    public int Id
    {
        get
        {
            return _id;
        }
    }

    private void Awake()
    {
        _cardChecker = FindObjectOfType<CardCoincidenceChecker>();
    }

    private void OnMouseDown()
    {
        if (_cardBack.activeSelf)
        {
            _cardChecker.CardWasTrieToRevealed(this);
        }
    }

    public void SetCard(int id, Sprite image) 
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void Reveal()
    {
        _cardBack.SetActive(false);
    }

    public void Unreveal()
    {
        _cardBack.SetActive(true);
    }
}

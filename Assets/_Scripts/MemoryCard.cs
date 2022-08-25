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
            _cardChecker.SetRevealedCard(this);
        }
    }

    public void Setup(int id, Sprite image)
    {
        _id = id;
        var renderer = GetComponent<SpriteRenderer>();
        if (renderer != null)
            renderer.sprite = image;
        else
            throw new System.Exception("Renderer is null!");
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

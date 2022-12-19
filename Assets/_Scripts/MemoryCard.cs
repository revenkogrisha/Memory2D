using System;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject _cardBack;

    private int _id;

    public int Id => _id;

    public event Action<MemoryCard> OnRevealed;

    private void OnMouseDown()
    {
        if (_cardBack.activeSelf)
        {
            OnRevealed?.Invoke(this);
        }
    }

    public void Setup(int id, Sprite image)
    {
        _id = id;
        var renderer = GetComponent<SpriteRenderer>();
        if (!renderer)
            throw new System.Exception("Renderer is null!");

        renderer.sprite = image;
    }

    public void Reveal()
    {
        _cardBack.SetActive(false);
    }

    public void Hide()
    {
        _cardBack.SetActive(true);
    }
}

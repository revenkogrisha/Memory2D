using UnityEngine;
using System;

[Obsolete]
public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private string _message;
    private Color _highlightColor = Color.cyan;
    private SpriteRenderer _sprite;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _sprite = GetComponent<SpriteRenderer>();

        if (_sprite == null)
            throw new Exception("SpriteRenderer is null!");
    }

    private void OnMouseEnter()
    {
        _sprite.color = _highlightColor;
    }

    private void OnMouseExit()
    {
        _sprite.color = Color.white;
    }

    private void OnMouseDown()
    {
        _transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    private void OnMouseUp()
    {
        _transform.localScale = Vector3.zero;
        _target.SendMessage(_message);
    }
}

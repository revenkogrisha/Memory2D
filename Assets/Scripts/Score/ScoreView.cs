using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMesh _text;

    public void UpdateText(int amount)
    {
        _text.text = $"Score: {amount}";
    }
}
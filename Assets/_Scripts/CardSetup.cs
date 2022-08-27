using UnityEngine;

public class CardSetup : MonoBehaviour
{
    [SerializeField] private CardGenerator _generator;
    [SerializeField] private Sprite[] _images;

    private readonly int[] _numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
    private readonly Vector2 _offset = new(2f, 2.5f);

    private void Awake()
    {
        _numbers.ShuffleArray();
    }

    public MemoryCard SetupCard(MemoryCard card, Vector2 grid)
    {
        int index = (int)grid.y * _generator.GridCols + (int)grid.x;
        int id = _numbers[index];

        card.Setup(id, _images[id]);

        return card;
    }

    public void SetCardPosition(MemoryCard card, Vector2 grid)
    {
        float posX = (_offset.x * grid.x) + _generator.StartPos.x;
        float posY = -(_offset.y * grid.y) + _generator.StartPos.y;

        card.transform.position = new Vector3(posX, posY, _generator.StartPos.z);
    }
}

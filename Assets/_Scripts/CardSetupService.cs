using UnityEngine;

public class CardSetupService
{
    private readonly int[] _numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
    private readonly Vector2 _offset = new(2f, 2.5f);
    private readonly Sprite[] _images;
    private readonly Vector3 _startPosition;
    private readonly int _gridCols;

    public CardSetupService(Sprite[] images, Vector2 startPosition, int cols)
    {
        _numbers.ShuffleArray();
        _startPosition = startPosition;
        _images = images;
        _gridCols = cols;
    }

    public MemoryCard SetupCard(MemoryCard card, Vector2 grid)
    {
        int index = (int)grid.y * _gridCols + (int)grid.x;
        int id = _numbers[index];

        card.Setup(id, _images[id]);

        return card;
    }

    public void SetCardPosition(MemoryCard card, Vector2 grid)
    {
        float posX = (_offset.x * grid.x) + _startPosition.x;
        float posY = -(_offset.y * grid.y) + _startPosition.y;

        card.transform.position = new Vector3(posX, posY, _startPosition.z);
    }
}

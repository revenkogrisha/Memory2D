using UnityEngine;

public class CardGenerator : MonoBehaviour
{

    [SerializeField] private MemoryCard _originalCard;
    [SerializeField] private Sprite[] _images;

    private const int _gridRows = 2;
    private const int _gridCols = 4;
    private readonly Vector2 _offset = new(2f, 2.5f);
    private readonly int[] _numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };

    private MemoryCard _card;
    private Vector2 _grid;

    private Vector3 StartPos => _originalCard.transform.position;

    private void Start()
    {
        _numbers.ShuffleArray();
        GenerateCards();
    }

    public void GenerateCards()
    {
        for (int i = 0; i < _gridCols; i++)
        {
            for (int j = 0; j < _gridRows; j++)
            {
                _grid = new(i, j);
                _card = Instantiate(_originalCard);

                SetupCard();
                SetCardPosition();
            }
        }
    }

    private void SetupCard()
    {
        int index = (int)_grid.y * _gridCols + (int)_grid.x;
        int id = _numbers[index];

        _card.SetCard(id, _images[id]);
    }

    private void SetCardPosition()
    {
        float posX = (_offset.x * _grid.x) + StartPos.x;
        float posY = -(_offset.y * _grid.y) + StartPos.y;

        _card.transform.position = new Vector3(posX, posY, StartPos.z);
    }
}

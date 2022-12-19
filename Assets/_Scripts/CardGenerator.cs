using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private MemoryCard _cardPrefab;
    [SerializeField] Vector3 _startPosition;
    [SerializeField] private Sprite[] _images;

    private int _gridRows = 2;
    private int _gridCols = 4;
    private CardSetupService _setup;


    private void Awake()
    {
        _setup = new(_images, _startPosition, _gridCols);
    }

    public void GenerateCards()
    {
        for (int i = 0; i < _gridCols; i++)
        {
            for (int j = 0; j < _gridRows; j++)
            {
                var grid = new Vector2(i, j);
                var card = Instantiate(_cardPrefab);

                _setup.SetupCard(card, grid);
                _setup.SetCardPosition(card, grid);
            }
        }
    }
}

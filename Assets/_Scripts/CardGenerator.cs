using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] private MemoryCard _cardPrefab;
    [SerializeField] private CardSetup _setup;
    
    public int GridRows { get; } = 2;
    public int GridCols { get; } = 4;
    public Vector3 StartPos => _cardPrefab.transform.position;

    private void Start()
    {
        GenerateCards();
    }

    public void GenerateCards()
    {
        for (int i = 0; i < GridCols; i++)
        {
            for (int j = 0; j < GridRows; j++)
            {
                var grid = new Vector2(i, j);
                var card = Instantiate(_cardPrefab);

                _setup.SetupCard(card, grid);
                _setup.SetCardPosition(card, grid);
            }
        }
    }
}

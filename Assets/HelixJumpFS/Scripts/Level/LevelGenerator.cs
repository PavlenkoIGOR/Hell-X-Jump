using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform _axis;
    [SerializeField] private Floor _floorPrefab;

    [Header("Settings")]
    [Tooltip("Стандартное количество этажей")]
    [SerializeField] private int _defaultFloorAmount;
    [Tooltip("Расстояние между уровнями")][SerializeField] private float _floorHeight;
    [SerializeField] private int _emptySegmentQuantity = 2;
    [SerializeField] private int _minQuantityTrapSegment = 1;
    [SerializeField] private int _maxQuantityTrapSegment = 5;

    private float _floorAmount = 0;
    public float FloorAmount => _floorAmount;

    private float _lastFloorY = 0;
    public float LastFloorY => _lastFloorY;


    public void Generate(int level)
    {
        DestroyChild();

        _floorAmount = _defaultFloorAmount + level;
        _axis.transform.localScale = new Vector3(1, _floorAmount * _floorHeight, 1);

        Color defaultSegmentColor = new Color(UnityEngine.Random.value, Random.value, Random.value);

        for (int i = 0; i < _floorAmount; i++)
        {
            Floor floor = Instantiate(_floorPrefab, transform);
            floor.transform.Translate(0, i * _floorHeight, 0);
            floor.name = "Floor" + i;
            
            if (i == 0)
            {
                floor.SetFinishAllSegment();
            }
            if (i > 0 && i < _floorAmount - 1)
            {
                floor.SetRandomRotation();
                floor.AddEmptySegment(_emptySegmentQuantity);
                floor.AddRandomTrapSegment(Random.Range(_minQuantityTrapSegment, _maxQuantityTrapSegment+1));
            }
            if (i == _floorAmount - 1)
            {
                floor.AddEmptySegment(_emptySegmentQuantity);
                _lastFloorY = floor.transform.position.y;
            }



            //случайный цвет для всех сегментов
            foreach (Transform child in floor.transform)
            {
                Segment segment = child.GetComponent<Segment>();
                if (segment != null && segment.Type == SegmentType.Default)
                {
                    Renderer segmentRenderer = child.GetComponent<Renderer>();
                    if (segmentRenderer != null)
                    {
                        segmentRenderer.material.color = defaultSegmentColor;
                    }
                }
            }

        }
    }

    private void DestroyChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetChild(0) == _axis)
            {
                continue;
            }
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}

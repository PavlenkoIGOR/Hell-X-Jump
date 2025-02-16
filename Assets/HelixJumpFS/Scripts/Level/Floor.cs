using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private List<Segment> _defaultSegments;


    public void AddEmptySegment(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _defaultSegments[i].SetEmpty();
        }

        //обратный цикл, так как при удалении массив двигается влево
        for (int i = amount; i >= 0; i--)
        {
            _defaultSegments.RemoveAt(i);
        }
    }

    public void AddRandomTrapSegment(int amount)
    {
        for (int i = 0; i < amount; i++) 
        {
            int index = Random.Range(0, _defaultSegments.Count);

            _defaultSegments[index].SetTrap();
            _defaultSegments.RemoveAt(index);
        }
    }

    public void SetRandomRotation()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    public void SetFinishAllSegment()
    {
        for (int i = 0; i < _defaultSegments.Count; i++)
        {
            _defaultSegments[i].SetFinish();
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class SecgmetsList : MonoBehaviour
{
    [SerializeField] private List<Segment_Scriptable> _segments = new List<Segment_Scriptable>(3);

    private List<Segment_Scriptable> _segmentsInLevel = new List<Segment_Scriptable>(12);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _segmentsInLevel.Clear();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

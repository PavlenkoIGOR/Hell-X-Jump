using UnityEngine;

[CreateAssetMenu(fileName = "Segment_Scriptable", menuName = "Scriptable Objects/Segment_Scriptable")]
public class Segment_Scriptable : ScriptableObject
{
    public SegmentType segmentType;
    public Transform segmentTransform;
}

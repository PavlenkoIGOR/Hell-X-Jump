using UnityEngine;

public class InputManager : BallEvents
{
    [SerializeField] private Rotator _inputRotator;
    protected override void OnBallCollisionSegment(SegmentType segmentType)
    {
        if (segmentType == SegmentType.Finish || segmentType == SegmentType.Trap)
        {
            _inputRotator.enabled = false;
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMovement))]
public class BallController : OneColliderTrigger
{
    private BallMovement _ballMovement;

    [HideInInspector] public UnityEvent<SegmentType> onCollisionSegment;
    [HideInInspector] public UnityEvent<Segment> onSegment;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ballMovement = GetComponent<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnOneTriggerEnter(Collider other)
    {
        Segment _segment = other.GetComponent<Segment>();

        if (_segment != null) 
        {
            if (_segment.Type == SegmentType.Empty) 
            {
                _ballMovement.Fall(other.transform.position.y);
                onSegment.Invoke(_segment);
            }
            if (_segment.Type == SegmentType.Default)
            {
                _ballMovement.Jump();
            }
            if (_segment.Type == SegmentType.Trap || _segment.Type == SegmentType.Finish)
            {
                _ballMovement.Stop();
            }

            onCollisionSegment.Invoke(_segment.Type);
            
        }
    }
}

using UnityEngine;

public abstract class BallEvents : MonoBehaviour
{
    [SerializeField] protected BallController _ballController;
    
    protected virtual void Awake()
    {
        _ballController.onCollisionSegment.AddListener(OnBallCollisionSegment);
        _ballController.onSegment.AddListener(OnBallCollisionSegment);
    }

    protected virtual void OnDestroy()
    {
        _ballController.onCollisionSegment.RemoveListener(OnBallCollisionSegment);
        _ballController.onSegment.AddListener(OnBallCollisionSegment);
    }
    
    protected virtual void OnBallCollisionSegment(SegmentType segmentType)
    {

    }
    protected virtual void OnBallCollisionSegment(Segment segment)
    {

    }
}

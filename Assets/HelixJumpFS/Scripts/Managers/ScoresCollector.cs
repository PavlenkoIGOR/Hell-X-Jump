using UnityEngine;

public class ScoresCollector : BallEvents
{
    [SerializeField] private LevelProgress _levelProgress;
    
    private int _scores;
    public int Scores => _scores;
    protected override void OnBallCollisionSegment(SegmentType segmentType)
    {
        if (segmentType == SegmentType.Empty)
        {
            _scores+=_levelProgress.CurrentLevel;
        }
    }
}

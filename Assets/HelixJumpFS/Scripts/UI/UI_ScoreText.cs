using TMPro;
using UnityEngine;

public class UI_ScoreText : BallEvents
{
    [SerializeField] private TMP_Text _scoresText;
    [SerializeField] private ScoresCollector _scoresCollector;

    protected override void OnBallCollisionSegment(SegmentType segmentType)
    {
        if (segmentType != SegmentType.Trap)
        {
            _scoresText.text = _scoresCollector.Scores.ToString();
        }
    }
}

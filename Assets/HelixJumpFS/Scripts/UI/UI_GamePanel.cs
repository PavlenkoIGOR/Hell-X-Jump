using UnityEngine;

public class UI_GamePanel : BallEvents
{
    [SerializeField] private GameObject _passedPanel;
    [SerializeField] private GameObject _defeatPanel;
    private void Start()
    {
        _passedPanel.SetActive(false);
        _defeatPanel.SetActive(false);
    }

    protected override void OnBallCollisionSegment(SegmentType segmentType)
    {
        //base.OnBallCollisionSegment(segmentType);


        if (segmentType == SegmentType.Trap)
        {
            _defeatPanel.SetActive(true);
        }

        if (segmentType == SegmentType.Finish)
        {
            _passedPanel.SetActive(true);
        }
    }
}

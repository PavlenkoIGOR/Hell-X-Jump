using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelProgress : BallEvents
{
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _nextLevelText;
    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private Image _progressBar;

    private float _step;


    private void Start()
    {
        _currentLevelText.text = _levelProgress.CurrentLevel.ToString();
        _nextLevelText.text = (_levelProgress.CurrentLevel+1).ToString();
        _progressBar.fillAmount = 0;
        _step = 1/_levelGenerator.FloorAmount;
    }

    protected override void OnBallCollisionSegment(SegmentType segmentType)
    {
        if (segmentType == SegmentType.Empty || segmentType == SegmentType.Finish)
        {
            _progressBar.fillAmount += _step;
        }
    }
}

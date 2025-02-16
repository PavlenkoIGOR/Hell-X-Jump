using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : BallEvents
{
    private int _currentLevel = 1;
    public int CurrentLevel => _currentLevel;

    [SerializeField] private ScoresCollector _scoresCollector;
    [SerializeField] private MaxScores _maxScores;

    protected override void Awake()
    {
        base.Awake();

        Load();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Reset();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (_scoresCollector.Scores >= _maxScores.totalMaxScores)
            {
                _maxScores.totalMaxScores = _scoresCollector.Scores;
            }
        }
    }

#endif
    protected override void OnBallCollisionSegment(SegmentType segmentType)
    {
        if (segmentType == SegmentType.Finish)
        {
            _currentLevel++;
            Save();
        }
    }


    private void Save()
    {
        PlayerPrefs.SetInt("LevelProgress:CurrentLevel", _currentLevel);
    }
    private void Load()
    {
        _currentLevel = PlayerPrefs.GetInt("LevelProgress:CurrentLevel", 1);
    }
#if UNITY_EDITOR
    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
#endif
}

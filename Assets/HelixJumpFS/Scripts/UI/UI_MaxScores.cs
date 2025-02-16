using TMPro;
using UnityEngine;

public class UI_MaxScores : MonoBehaviour
{
    [SerializeField]private MaxScores _maxScores;
    [SerializeField] private TMP_Text _maxScoreTMP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _maxScoreTMP.text = "Max scores: " + _maxScores.totalMaxScores.ToString();
    }
}

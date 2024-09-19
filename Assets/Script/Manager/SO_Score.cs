using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScoreData/ScoreData", order = 2)]

public class SO_Score : ScriptableObject
{
    public int CurrentScore;
    public int MaxScore;
}

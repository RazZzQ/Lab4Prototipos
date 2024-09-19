using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "HeathPlayer", menuName = "HeathPlayer/HeathPlayerData", order = 0)]

public class PlayerHealth : ScriptableObject
{
    public int CurrentLife;
    public int MaxLife;
}

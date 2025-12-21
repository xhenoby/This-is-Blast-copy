using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelConfig", menuName = "CustomScriptables/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField]
    public Columns[] Lines = new Columns[10];
}

[Serializable]
public class Columns
{
    public List<ColorEnum> cubesColor;
}

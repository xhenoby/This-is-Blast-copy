using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    [SerializeField] LevelConfig levelConfig;
    [SerializeField] Cube cubePrefab;
    [SerializeField] CubePosition[] CubePositions;
    [SerializeField] LevelProgress levelProgress;
    public bool LevelLoaded { get; private set; }
    void Awake()
    {
        InstanciateCubes();
    }
    void InstanciateCubes()
    {
        int cubesAmount = 0;
        for (int i = 0; i < levelConfig.Lines.Length; i++)
        {
            for (int j = 0; j < levelConfig.Lines[i].cubesColor.Count; j++)
            {
                cubesAmount++;
                Cube newCube = Instantiate(cubePrefab, CubePositions[i].Content);
                newCube.CubeColor = levelConfig.Lines[i].cubesColor[j];
                CubePositions[i].CubeList.Add(newCube);
            }
            CubePositions[i].currentCubeColor = CubePositions[i].CubeList[0].CubeColor;
        }
        levelProgress.Initialize(cubesAmount);
        LevelLoaded = true;
    }
}

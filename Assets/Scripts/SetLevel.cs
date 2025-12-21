using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    [SerializeField]
    LevelConfig levelConfig;

    [SerializeField]
    Cube cubePrefab;

    [SerializeField]
    CubePosition[] CubePositions;
    public bool LevelLoaded { get; private set; }
    void Awake()
    {
        StartCoroutine(InstanciateCubes());
    }
    IEnumerator InstanciateCubes()
    {
        for (int i = 0; i < levelConfig.Lines.Length; i++)
        {
            for (int j = 0; j < levelConfig.Lines[i].cubesColor.Count; j++)
            {
                Cube newCube = Instantiate(cubePrefab, CubePositions[i].Content);
                newCube.CubeColor = levelConfig.Lines[i].cubesColor[j];
                CubePositions[i].CubeList.Add(newCube);
                yield return new WaitForEndOfFrame();
            }
        }
        LevelLoaded = true;
    }
}

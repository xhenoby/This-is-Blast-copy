using System.Collections.Generic;
using UnityEngine;

public class CubePosition : MonoBehaviour
{
    [HideInInspector] public bool isBeingShoot;
    public ColorEnum currentCubeColor { get; private set; }
    public List<Cube> CubeList { get; private set; }= new List<Cube>();
    public Transform Content;
    public void BallHasHit()
    {
        CubeList[0].Hit();
        CubeList.RemoveAt(0);
        if (CubeList.Count > 0)
        {
            currentCubeColor = CubeList[0].CubeColor;
            isBeingShoot = false;
        }
    }
}

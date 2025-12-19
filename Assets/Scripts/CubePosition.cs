using System.Collections.Generic;
using UnityEngine;

public class CubePosition : MonoBehaviour
{
    public bool isBeingShoot;
    public ColorEnum currentCubeColor;
    public List<Cube> CubeList;
    public void BallHasHit()
    {
        CubeList[0].DestroyCube();
        CubeList.RemoveAt(0);
        if (CubeList.Count > 0)
        {
            currentCubeColor = CubeList[0].CubeColor;
            isBeingShoot = false;
        }
    }
}

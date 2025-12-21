using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    [SerializeField] Ball BallPrefab;
    [SerializeField] int BallPoolMax;
    [SerializeField] List<Ball> BallPoolList;

    void Start()
    {
        BallPoolList = new List<Ball>();
        for (int i = 0; i < BallPoolMax; i++)
        {
            InstanciateBall();
        }
    }
    Ball InstanciateBall()
    {
        Ball newBall = Instantiate(BallPrefab, transform);
        newBall.pool = this;
        AddToPool(newBall);
        return newBall;
    }
    public void AddToPool(Ball LastBall)
    {
        BallPoolList.Add(LastBall);
    }
    public Ball GetFromPool()
    {
        Ball firstBall;

        try
        {
            firstBall = BallPoolList[0];
        }
        catch (System.IndexOutOfRangeException)
        {
            firstBall = InstanciateBall();
        }

        BallPoolList.RemoveAt(0);

        return firstBall;
    }
}

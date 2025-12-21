using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallShooter : MonoBehaviour
{
    public ColorEnum spawnerColor;
    [SerializeField] BallPool pool;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] List<CubePosition> objectives;
    [SerializeField] float shootVelocity;
    [SerializeField] float timeBetweemShoots;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootClip;
    UnityEvent CheckObjectivesEvent;
    float t;

    private void Start()
    {
        //t = timeBetweemShoots;
        //if (CheckObjectivesEvent == null)
        //{
        //    CheckObjectivesEvent = new UnityEvent();
        //}
        //CheckObjectivesEvent.AddListener(TriggerCoroutine);
        //TriggerCoroutine();
    }
    void TriggerCoroutine()
    {
        StartCoroutine(CheckObjectives());
    }
    private void Update()
    {
        t -= Time.deltaTime;
    }
    IEnumerator CheckObjectives()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            yield return new WaitUntil(() => (t <= 0));

            if (spawnerColor == objectives[i].currentCubeColor && !objectives[i].isBeingShoot)
            {
                objectives[i].isBeingShoot = true;
                ShootBall(objectives[i].transform);
                t = timeBetweemShoots;
            }
        }
        CheckObjectivesEvent.Invoke();
    }
    void ShootBall(Transform objective)
    {
        audioSource.PlayOneShot(shootClip);
        Vector3 objectDirection = objective.position - SpawnPoint.position;
        Ball ballToShoot = pool.GetFromPool();
        ballToShoot.transform.position = SpawnPoint.position;
        ballToShoot.rdbd.linearVelocity = objectDirection.normalized * shootVelocity;
        ballToShoot.gameObject.SetActive(true);
    }
}

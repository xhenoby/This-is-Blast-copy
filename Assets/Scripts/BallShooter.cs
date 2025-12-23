using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class BallShooter : MonoBehaviour
{
    [Header("Settings")]
    public ColorEnum spawnerColor;
    [SerializeField] float shootVelocity;
    [SerializeField] float timeBetweemShoots;
    [SerializeField] ShooterSide shooterSide;

    [Header("References")]
    [SerializeField] BallPool pool;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] AudioSource audioSource;
    [SerializeField] List<CubePosition> objectives;
    [SerializeField] TextMeshProUGUI numberOfBalls;

    [Header("Assets")]
    [SerializeField] AudioClip shootClip;
    [SerializeField] AudioClip moveClip;
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip MoveShooterAnimation;
    [SerializeField] AnimationClip ExitShooterAnimationLeft;
    [SerializeField] AnimationClip ExitShooterAnimationRight;

    [SerializeField] int numberOfShootsLeft;
    UnityEvent CheckObjectivesEvent;
    float t;
    bool ShootingEnable;

    private void Start()
    {
        t = 0;
        if (CheckObjectivesEvent == null)
        {
            CheckObjectivesEvent = new UnityEvent();
        }
        CheckObjectivesEvent.AddListener(TriggerCoroutine);
        numberOfBalls.text = numberOfShootsLeft.ToString();
    }
    public void MoveShooter()
    {
        animator.Play(MoveShooterAnimation.name);
        audioSource.PlayOneShot(moveClip);
    }
    public void ExitShooter()
    {
        if (shooterSide == ShooterSide.left)
        {
            animator.Play(ExitShooterAnimationLeft.name);
        }

        if (shooterSide == ShooterSide.right)
        {
            animator.Play(ExitShooterAnimationRight.name);
        }
    }
    public void TriggerCoroutine()
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

            if (numberOfShootsLeft <= 0)
            {
                ExitShooter();
                yield break;
            }
            if (Random.Range(0, 6) == 0 && i < objectives.Count - 1)//Ramdomize shooting target a bit
            {
                i++;
            }
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
        numberOfShootsLeft -= 1;
        numberOfBalls.text = numberOfShootsLeft.ToString();

        audioSource.volume = 0.25f;
        audioSource.pitch = Random.Range(0.3f, 0.9f);
        audioSource.PlayOneShot(shootClip);

        Vector3 objectDirection = objective.position - SpawnPoint.position;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Vector3.SignedAngle(objectDirection, Vector3.up,Vector3.back));

        Ball ballToShoot = pool.GetFromPool();
        ballToShoot.transform.position = SpawnPoint.position;
        ballToShoot.rdbd.linearVelocity = objectDirection.normalized * shootVelocity;
        ballToShoot.gameObject.SetActive(true);
    }
}
enum ShooterSide
{
    left, middleLeft, middleRight, right
}
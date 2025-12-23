using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public BallPool pool;
    public Rigidbody rdbd { get; private set; }

    private void Start()
    {
        rdbd = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CubePosition>().BallHasHit();
        gameObject.SetActive(false);
        pool.AddToPool(this);
    }
}

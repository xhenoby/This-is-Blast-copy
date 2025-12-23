using UnityEngine;

public class Cube : MonoBehaviour
{
    public ColorEnum CubeColor;
    [SerializeField] private MeshRenderer CubeRenderer;
    [SerializeField] private Material[] ColorMaterials;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip dieAnimation;
    [SerializeField] ParticleSystem particleSystem;
    private void Start()
    {
        CubeRenderer.material = ColorMaterials[(int)CubeColor];
    }
    public void Hit()
    {
        animator.Play(dieAnimation.name);
        particleSystem.Play();
    }
    public void DestroyCube()
    {
        Destroy(gameObject);
    }
}

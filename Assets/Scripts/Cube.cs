using UnityEngine;

public class Cube : MonoBehaviour
{
    public ColorEnum CubeColor;
    [SerializeField] private MeshRenderer CubeRenderer;
    [SerializeField] private Material[] ColorMaterials;
    private void Start()
    {
        CubeRenderer.material = ColorMaterials[(int)CubeColor];
    }
    public void Hit()
    {

    }
    public void DestroyCube()
    {
        Destroy(gameObject);
    }
}

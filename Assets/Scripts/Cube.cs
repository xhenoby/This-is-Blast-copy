using UnityEngine;

public class Cube : MonoBehaviour
{
    public ColorEnum CubeColor;
    public void DestroyCube()
    {
        Destroy(gameObject);
    }
}

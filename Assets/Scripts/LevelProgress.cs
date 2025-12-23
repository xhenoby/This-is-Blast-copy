using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float maxValue;
    [SerializeField] float currentCubesAmount;
    public void Initialize(int cubesAmount)
    {
        maxValue = cubesAmount;
    }
    public void UpdateSlider()
    {
        currentCubesAmount++;
        slider.value = currentCubesAmount / maxValue;
    }
}

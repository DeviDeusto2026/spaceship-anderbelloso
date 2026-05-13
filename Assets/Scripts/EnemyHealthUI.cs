using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public Slider slider;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void ActualizarSalud(float vidaActual, float vidaMaxima)
    {
        slider.value = vidaActual / vidaMaxima;
    }

    void Update()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
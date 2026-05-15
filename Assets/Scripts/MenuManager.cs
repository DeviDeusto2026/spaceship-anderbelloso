using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class MenuManager : MonoBehaviour
{
    public string nombreEscenaJuego = "PlayScene";

    public void IniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscenaJuego);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
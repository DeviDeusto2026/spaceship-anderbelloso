using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas

public class GameOverManager : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayScene");
    }
}
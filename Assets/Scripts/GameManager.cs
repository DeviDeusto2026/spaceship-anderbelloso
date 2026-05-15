using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int enemigosDerrotados = 0;
    private int killNecesarias = 8;

    public GameObject jefePrefab;
    public Transform puntoSpawnJefe;
    public EnemySpawner spawner;
    public TextMeshProUGUI textoKills;

    public bool jefeInvocado = false;
    public bool bossKilled = false;
    private bool victoriaFinal = false;

    public GameObject panelGameOver;
    public GameObject panelVictoria;

    void Start()
    {
        ActualizarInterfaz();
        if (spawner != null) spawner.IniciarSpawning(killNecesarias);
    }

    void Update()
    {
        if (bossKilled && !victoriaFinal)
        {
            GameObject minionVivo = GameObject.FindWithTag("Enemy");

            if (minionVivo == null)
            {
                victoriaFinal = true;
                Debug.Log("¡VICTORIA REAL! Jefe y súbditos eliminados.");
                Win();
            }
        }
    }

    public void EnemyKilled()
    {
        if (enemigosDerrotados < killNecesarias)
        {
            enemigosDerrotados++;
            ActualizarInterfaz();

            if (enemigosDerrotados == killNecesarias && !jefeInvocado)
            {

                jefeInvocado = true;
                if (spawner != null) spawner.DetenerSpawn();
                Invoke("SpawnBoss", 1f);
            }
        }
    }

    public void BossKilled()
    {
        bossKilled = true;
        Debug.Log("El Jefe ha caído. Limpiando restos...");
    }

    void ActualizarInterfaz()
    {
        if (textoKills != null)
        {
            textoKills.text = "Enemigos restantes: " + (killNecesarias - enemigosDerrotados);
        }
    }

    private void SpawnBoss()
    {
        Instantiate(jefePrefab, puntoSpawnJefe.position, puntoSpawnJefe.rotation);
    }


    public void GameOver()
    {
        if (victoriaFinal) return;

        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void Win()
    {
        panelVictoria.SetActive(true);
        Time.timeScale = 0f;


        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
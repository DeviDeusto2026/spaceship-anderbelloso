using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int enemigosDerrotados = 0;
    private int killNecesarias = 8;
    private int bossesDerrotados = 0;
    private int bossesNecesarios = 1;
    public GameObject jefePrefab;
    public Transform puntoSpawnJefe;
    public EnemySpawner spawner;
    public TextMeshProUGUI textoKills;

    void Start()
    {
        ActualizarInterfaz();

        if (spawner != null)
        {
            spawner.IniciarSpawning(killNecesarias);
        }
    }

    public void EnemyKilled()
    {
        enemigosDerrotados++;
        ActualizarInterfaz();

        if (killNecesarias == enemigosDerrotados)
        {
            if (spawner != null)
            {
                spawner.DetenerSpawn();
            }
            SpawnBoss();
        }
    }

    public void BossKilled()
    {
        bossesDerrotados++;

        if (bossesNecesarios == bossesDerrotados)
        {
            Debug.Log("VICTORY");
            SceneManager.LoadScene("PlayScene");
        }
    }

    void ActualizarInterfaz()
    {
        if (textoKills != null)
        {
            textoKills.text = "Enemigos: " + enemigosDerrotados + " / " + killNecesarias;
        }
    }

    private void SpawnBoss()
    {
        Instantiate(jefePrefab, puntoSpawnJefe.position, puntoSpawnJefe.rotation);
    }
}

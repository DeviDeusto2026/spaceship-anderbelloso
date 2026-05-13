using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int enemigosDerrotados = 0;
    private int killNecesarias = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void EnemyKilled()
    {
        enemigosDerrotados++;

        if (killNecesarias == enemigosDerrotados)
        {
            SpawnBoss();
        }
    }

    private void SpawnBoss()
    {
        Debug.Log("BOSS");
    }
}

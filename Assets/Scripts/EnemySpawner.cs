using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public float tiempoEntreSpawn = 3f;
    public float radioSpawn = 50f;
    public float distanciaMinima = 10f;

    public Transform playerTransform;
    private int enemigosCreados = 0;
    private int maxEnemigos = 0;

    public void IniciarSpawning(int cantidadTotal)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) playerTransform = player.transform;

        maxEnemigos = cantidadTotal;
        enemigosCreados = 0;
        InvokeRepeating("Spawn", 2f, tiempoEntreSpawn);
    }

    void Spawn()
    {
        if (enemigosCreados >= maxEnemigos)
        {
            DetenerSpawn();
            return;
        }

        if (playerTransform != null)
        {
            Vector2 circuloAleatorio = Random.insideUnitCircle.normalized;

            float distancia = Random.Range(distanciaMinima, radioSpawn);

            Vector3 offset = new Vector3(circuloAleatorio.x, 0, circuloAleatorio.y) * distancia;
            Vector3 posFinal = playerTransform.position + offset;

            Instantiate(enemigoPrefab, posFinal, Quaternion.identity);

            enemigosCreados++;
        }
    }

    public void DetenerSpawn()
    {
        CancelInvoke("Spawn");
    }

}
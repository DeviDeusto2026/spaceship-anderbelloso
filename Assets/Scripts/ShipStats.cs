using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShipStats : MonoBehaviour
{
    public int vidas = 3;
    public UI hudCorazones;

    private bool puedoRecibirDano = true;
    public float tiempoInvulnerable = 1.5f;


    void Start()
    {
        if (hudCorazones != null)
        {
            hudCorazones.InicializarCorazones(vidas);
            hudCorazones.ActualizarCorazones(vidas);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            RecibirDano();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            RecibirDano();
        }
    }

    void RecibirDano()
    {
        if (!puedoRecibirDano) return;
        vidas--;

        if (hudCorazones != null)
        {
            hudCorazones.ActualizarCorazones(vidas);
        }

        if (vidas <= 0)
        {
            Time.timeScale = 0f;
            FindFirstObjectByType<GameManager>().GameOver();
        }
        else
        {
            StartCoroutine(Invulnerabilidad());
        }
    }

    IEnumerator Invulnerabilidad()
    {
        puedoRecibirDano = false;
        yield return new WaitForSeconds(tiempoInvulnerable);
        puedoRecibirDano = true;
    }
}
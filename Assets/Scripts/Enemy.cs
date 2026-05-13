using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    public float velocidad = 10f;
    public int vidaMaxima = 3;
    public int vidas;
    public EnemyHealthUI barraDeVida;

    void Start()
    {
        GameObject playerShip = GameObject.FindGameObjectWithTag("Player");
        if (playerShip != null) player = playerShip.transform;
        vidas = vidaMaxima;
        barraDeVida.ActualizarSalud(vidas, vidaMaxima);
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            vidas--;
            barraDeVida.ActualizarSalud(vidas, vidaMaxima);
            Destroy(other.gameObject);

            if (vidas <= 0)
            {
                FindFirstObjectByType<GameManager>().EnemyKilled();
                Destroy(gameObject);
            }
        }
    }
}

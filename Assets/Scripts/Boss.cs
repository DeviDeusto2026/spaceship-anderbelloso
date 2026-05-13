using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Transform player;
    public float velocidad = 10f;
    public int vidaMaxima = 20;
    public int vidas;
    public int navesMenores = 5;
    public EnemyHealthUI barraDeVida;

    private EnemySpawner spawner;

    void Start()
    {
        GameObject playerShip = GameObject.FindGameObjectWithTag("Player");
        if (playerShip != null) player = playerShip.transform;

        spawner = FindFirstObjectByType<EnemySpawner>();

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
            Destroy(other.gameObject);
            barraDeVida.ActualizarSalud(vidas, vidaMaxima);

            if (vidas > 0 && vidas % 4 == 0 && spawner != null)
            {

                spawner.IniciarSpawning(navesMenores);
            }

            if (vidas <= 0)
            {
                GameManager gm = FindFirstObjectByType<GameManager>();
                if (gm != null) gm.BossKilled();

                Destroy(gameObject);
            }
        }
    }
}
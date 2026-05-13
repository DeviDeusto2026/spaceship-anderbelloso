using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    public float velocidad = 10f;
    public int vidas = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerShip = GameObject.FindGameObjectWithTag("Player");
        if (playerShip != null) player = playerShip.transform;
    }

    // Update is called once per frame
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
            Debug.Log("Vida enemiga restante: " + vidas);

            if (vidas <= 0)
            {
               FindFirstObjectByType<GameManager>().EnemyKilled();

                Destroy(gameObject);
            }
        }
    }
}

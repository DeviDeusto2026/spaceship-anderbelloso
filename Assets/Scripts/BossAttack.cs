using UnityEngine;

public class BossAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bullet;
    public Transform gun;
    public float force;
    public float shootCooldown= 3f;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("Shoot", 2f, shootCooldown);
    }

    private void Shoot()
    {
        GameObject go = Instantiate(bullet, gun.position, gun.rotation);
        go.transform.Rotate(90, 0, 0, Space.Self);
        go.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        Destroy(go, 3f);
    }
}

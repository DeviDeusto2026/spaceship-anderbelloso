using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform gun;
    public float force;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject go = Instantiate(bullet, gun.position, gun.rotation);
            go.transform.Rotate(90, 0, 0, Space.Self);
            go.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
            Destroy(go, 3f);
        }
    }
}

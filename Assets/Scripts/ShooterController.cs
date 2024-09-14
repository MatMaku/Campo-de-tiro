using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public float shootForce = 10f;
    public Transform shootPoint;
    private ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Por defecto es el botón izquierdo del ratón
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject ball = objectPooler.GetPooledObject();
        if (ball != null)
        {
            ball.transform.position = shootPoint.position;
            ball.transform.rotation = shootPoint.rotation;

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = shootPoint.forward * shootForce;
            }
        }
    }
}

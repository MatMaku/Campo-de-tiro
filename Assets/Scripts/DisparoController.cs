using System.Collections.Generic;
using UnityEngine;

public class DisparoController : MonoBehaviour
{
    public GameObject pelotaPrefab; // Arrastra aquí el Prefab de la pelota
    public Transform puntoDeDisparo; // Donde la pelota será disparada desde
    public float fuerzaDeDisparo = 10f;
    public int maxPelotas = 10;

    private Queue<GameObject> pelotas = new Queue<GameObject>();

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Reemplaza "Fire1" con tu botón de disparo si es necesario
        {
            DispararPelota();
        }
    }

    void DispararPelota()
    {
        if (pelotas.Count >= maxPelotas)
        {
            Destroy(pelotas.Dequeue()); // Destruye la pelota más antigua
        }

        GameObject nuevaPelota = Instantiate(pelotaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Rigidbody rb = nuevaPelota.GetComponent<Rigidbody>();
        rb.AddForce(puntoDeDisparo.forward * fuerzaDeDisparo, ForceMode.Impulse);
        pelotas.Enqueue(nuevaPelota);
    }
}

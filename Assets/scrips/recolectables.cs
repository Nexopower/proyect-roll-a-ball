using UnityEngine;

public class Recolectable : MonoBehaviour
{
    public int puntos = 1; // por defecto da 1 punto
    public AudioClip sonido;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            jugadorController jugador = other.GetComponent<jugadorController>();
            if (jugador != null)
            {
                GameObject tempGO = new GameObject("SonidoRecolectable");
                AudioSource tempSource = tempGO.AddComponent<AudioSource>();
                tempSource.clip = sonido;
                tempSource.time = 0.25f; // Reproducir desde el segundo 2
                tempSource.Play();
                Destroy(tempGO, sonido.length - 0.25f); // Eliminar cuando termine
                jugador.SumarPuntos(puntos);
            }

            gameObject.SetActive(false);
        }
    }
}

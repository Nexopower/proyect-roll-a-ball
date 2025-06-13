using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class jugadorController : MonoBehaviour
{

    private Rigidbody rb;
    public float velocidad;
    public int objetivo;

    private int contador;

    public Text textocontador, textoganar;
    public float tiempoRestante = 120f; // Tiempo inicial, puedes cambiarlo desde el Inspector
    public Text textoTemporizador;      // Referencia al UI Text

    private bool tiempoActivo = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        settextocontador();
        textoganar.text = "";

    }

    void FixedUpdate()
    {

        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

        rb.AddForce(movimiento * velocidad);
    }


    void settextocontador()
    {
        textocontador.text = "Contador: " + contador.ToString();
        if (contador >= objetivo)
        {
            textoganar.text = "¡Has ganado!";
            StartCoroutine(PasarAVictoria());
        }
    }

    public void SumarPuntos(int cantidad)
    {
        contador += cantidad;
        settextocontador();
    }

    IEnumerator PasarAVictoria()
    {
        // Guardar el índice actual
        PlayerPrefs.SetInt("NivelActual", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        yield return new WaitForSeconds(2f); // Mostrar mensaje de victoria 2 segundos
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victoria");
    }
    // Update is called once per frame
    void Update()
    {
        if (tiempoActivo)
        {
            tiempoRestante -= Time.deltaTime;
            MostrarTiempo(tiempoRestante);

            if (tiempoRestante <= 0)
            {
                tiempoActivo = false;
                tiempoRestante = 0;
                IrAGameOver();
            }
        }
    }
       void MostrarTiempo(float tiempo)
    {
        tiempo = Mathf.Max(0, tiempo);
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        textoganar.text = string.Format("Tiempo: {0:00}:{1:00}", minutos, segundos);
    }

    void IrAGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

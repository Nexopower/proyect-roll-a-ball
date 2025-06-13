using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoriaManager : MonoBehaviour
{
    public void SiguienteNivel()
    {
        int nivelActual = PlayerPrefs.GetInt("NivelActual", 1);
        SceneManager.LoadScene(nivelActual + 1);
    }

    public void Reintentar()
    {
        int nivelActual = PlayerPrefs.GetInt("NivelActual", 1);
        SceneManager.LoadScene(nivelActual);
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

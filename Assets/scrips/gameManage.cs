using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManage : MonoBehaviour
{
    public void Jugar()
    {
        // Carga el primer nivel del juego, por ejemplo "Nivel1"
        SceneManager.LoadScene("nivel1");
    }

    public void Opciones()
    {
        // Carga la escena de opciones
        SceneManager.LoadScene("MenuOpcion");
    }

    public void Salir()
    {
        // Cierra el juego (funciona solo en la build, no en el editor)
        Application.Quit();
    }

    public void Volver()
    {
        SceneManager.LoadScene("Menu");
    }
}

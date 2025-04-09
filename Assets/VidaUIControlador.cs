using UnityEngine;
using UnityEngine.UI;

public class VidaUIControlador : MonoBehaviour
{
    private Image imagenVida;
    private int vidaTotal = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imagenVida = transform.Find("Vida").GetComponent <Image>();
        vidaTotal = GetComponentInParent<MovimientoJugador>().getVida();
    }

  public void Actualizarvida(int vidaActual)
 {
    imagenVida.fillAmount = (float)vidaActual / vidaTotal;
 }
}
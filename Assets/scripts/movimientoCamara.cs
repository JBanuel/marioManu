using UnityEngine;

public class movimientoCamara : MonoBehaviour
{
    public Transform objetivo;
    public float velocidadCamara = 0.025f;  
    public Vector3 desplazamiento;
    
    public float alturaFija = 5f; 

    private void LateUpdate()
    {
        if (objetivo == null) return;

        Vector3 posicionDeseada = objetivo.position + desplazamiento;

        posicionDeseada.y = alturaFija;

        Vector3 posicionSuavisada = Vector3.Lerp(transform.position, posicionDeseada, velocidadCamara);
        
        transform.position = posicionSuavisada;
    }
}
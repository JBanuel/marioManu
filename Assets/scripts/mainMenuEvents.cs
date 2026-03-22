using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class mainMenuEvents : MonoBehaviour
{
    private UIDocument _document;
    
    // Declarar variables para cada botón
    private Button _jugarButton;
    private Button _ayudaButton;
    private Button _creditosButton;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        // Asignar cada botón a su variable correspondiente usando su nombre en el UI Builder
        _jugarButton = _document.rootVisualElement.Q<Button>("JugarButton");
        _ayudaButton = _document.rootVisualElement.Q<Button>("AyudaButton");
        _creditosButton = _document.rootVisualElement.Q<Button>("CreditosButton");

        // Registrar los eventos de clic para cada botón
        _jugarButton.RegisterCallback<ClickEvent>(OnJugarClick);
        _ayudaButton.RegisterCallback<ClickEvent>(OnAyudaClick);
        _creditosButton.RegisterCallback<ClickEvent>(OnCreditosClick);
    }

    private void OnDisable()
    {
        // Desregistrar los eventos es una buena práctica para evitar errores de memoria
        _jugarButton.UnregisterCallback<ClickEvent>(OnJugarClick);
        _ayudaButton.UnregisterCallback<ClickEvent>(OnAyudaClick);
        _creditosButton.UnregisterCallback<ClickEvent>(OnCreditosClick);
    }

    // Métodos que se ejecutan al hacer clic
    private void OnJugarClick(ClickEvent evt)
    {
        Debug.Log("Presionaste el botón Jugar");
        SceneManager.LoadScene("SampleScene");
    }

    private void OnAyudaClick(ClickEvent evt)
    {
        Debug.Log("Presionaste el botón Ayuda");
        // Aquí irá la lógica para mostrar el menú de ayuda
    }

    private void OnCreditosClick(ClickEvent evt)
    {
        Debug.Log("Presionaste el botón Créditos");
        // Aquí irá la lógica para mostrar los créditos
    }
}
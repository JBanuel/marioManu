using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    private UIDocument _document;
    
    // Declarar variables para cada botón
    private Button _jugarButton;


    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        // Asignar cada botón a su variable correspondiente usando su nombre en el UI Builder
        _jugarButton = _document.rootVisualElement.Q<Button>("MenuButton");


        // Registrar los eventos de clic para cada botón
        _jugarButton.RegisterCallback<ClickEvent>(OnBackClick);

    }

    private void OnDisable()
    {
        // Desregistrar los eventos 
        _jugarButton.UnregisterCallback<ClickEvent>(OnBackClick);

    }

    // Métodos que se ejecutan al hacer clic
    private void OnBackClick(ClickEvent evt)
    {
        SceneManager.LoadScene("mainMenu");
    }


}
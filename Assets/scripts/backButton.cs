using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    private UIDocument _document;
    
    private Button _jugarButton;


    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _jugarButton = _document.rootVisualElement.Q<Button>("MenuButton");


        _jugarButton.RegisterCallback<ClickEvent>(OnBackClick);

    }

    private void OnDisable()
    {
        _jugarButton.UnregisterCallback<ClickEvent>(OnBackClick);

    }

    private void OnBackClick(ClickEvent evt)
    {
        SceneManager.LoadScene("mainMenu");
    }


}
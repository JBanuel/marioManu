using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; 

public class MainMenuController : MonoBehaviour
{
    private UIDocument _document;
    
    // Contenedores
    private VisualElement _menuContainer;
    private VisualElement _helpContainer;
    private VisualElement _creditosContainer;
    private VisualElement _creditsMask;
    
    // Elemento a animar
    private Label _creditsText;
    
    // Botones
    private Button _jugarButton;
    private Button _ayudaButton;
    private Button _creditosButton;
    private Button _volverAyudaButton;
    private Button _volverCreditosButton;

    public float scrollSpeed = 150f;
    private float _creditsYOffset;
    private bool _isShowingCredits = false;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        VisualElement root = _document.rootVisualElement;

        //Encontrar contenedores y elementos de créditos
        _menuContainer = root.Q<VisualElement>("MenuContainer");
        _helpContainer = root.Q<VisualElement>("HelpContainer");
        _creditosContainer = root.Q<VisualElement>("CreditosContainer");
        _creditsMask = root.Q<VisualElement>("CreditsMask");
        _creditsText = root.Q<Label>("CreditsText");

        //Encontrar botones
        _jugarButton = root.Q<Button>("JugarButton"); 
        _ayudaButton = root.Q<Button>("AyudaButton");
        _creditosButton = root.Q<Button>("CreditosButton");
        _volverAyudaButton = root.Q<Button>("VolverAyudaButton");
        _volverCreditosButton = root.Q<Button>("VolverCreditosButton");

        //Suscribir eventos
        if (_jugarButton != null) _jugarButton.clicked += CargarJuego; 
        if (_ayudaButton != null) _ayudaButton.clicked += MostrarAyuda;
        if (_creditosButton != null) _creditosButton.clicked += MostrarCreditos;
        if (_volverAyudaButton != null) _volverAyudaButton.clicked += MostrarMenu;
        if (_volverCreditosButton != null) _volverCreditosButton.clicked += MostrarMenu;
    }

    private void OnDisable()
    {
        if (_jugarButton != null) _jugarButton.clicked -= CargarJuego; 
        if (_ayudaButton != null) _ayudaButton.clicked -= MostrarAyuda;
        if (_creditosButton != null) _creditosButton.clicked -= MostrarCreditos;
        if (_volverAyudaButton != null) _volverAyudaButton.clicked -= MostrarMenu;
        if (_volverCreditosButton != null) _volverCreditosButton.clicked -= MostrarMenu;
    }

    private void Update()
    {
        if (_isShowingCredits && _creditsText != null && _creditsMask != null)
        {
            _creditsYOffset -= scrollSpeed * Time.deltaTime;

            if (_creditsYOffset < -_creditsText.layout.height)
            {
                _creditsYOffset = _creditsMask.layout.height;
            }

            _creditsText.transform.position = new Vector3(0, _creditsYOffset, 0);
        }
    }


    private void CargarJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void MostrarAyuda()
    {
        _menuContainer.style.display = DisplayStyle.None;
        _helpContainer.style.display = DisplayStyle.Flex;
    }

    private void MostrarCreditos()
    {
        _menuContainer.style.display = DisplayStyle.None;
        _creditosContainer.style.display = DisplayStyle.Flex;
        
        _isShowingCredits = true;
        _creditsText.RegisterCallback<GeometryChangedEvent>(InitCreditsPosition);
    }

    private void InitCreditsPosition(GeometryChangedEvent evt)
    {
        _creditsText.UnregisterCallback<GeometryChangedEvent>(InitCreditsPosition);
        _creditsYOffset = _creditsMask.layout.height;
        _creditsText.transform.position = new Vector3(0, _creditsYOffset, 0);
    }

    private void MostrarMenu()
    {
        _helpContainer.style.display = DisplayStyle.None;
        _creditosContainer.style.display = DisplayStyle.None;
        _menuContainer.style.display = DisplayStyle.Flex;
        
        _isShowingCredits = false;
    }
}
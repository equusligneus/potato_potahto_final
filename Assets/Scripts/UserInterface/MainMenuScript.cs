using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MainMenuScript : MonoBehaviour
{
    public InputActionAsset inputs;
    public CreditsScript credits;
    public RuntimeFader faderRef;
    private UIDocument document;

    // Start is called before the first frame update
    void Awake()
    {
        if (inputs)
            inputs.Enable();
        document = GetComponent<UIDocument>();
        SetUIActive(true);
        StartCoroutine(SceneController.Begin(faderRef));
    }

	private void OnEnable()
	{
        var start = document.rootVisualElement.Q<Button>("btn_start");
        if (start != default)
            start.clicked += Start_clicked;

        var credits = document.rootVisualElement.Q<Button>("btn_credits");
        if (credits != default)
            credits.clicked += Credits_clicked;

        var quit = document.rootVisualElement.Q<Button>("btn_quit");
        if (quit != default)
            quit.clicked += Quit_clicked;
    }

	private void Credits_clicked()
	{
        if (!credits)
            return;

        credits.SetUIActive(true);
        SetUIActive(false);
	}

	private void Quit_clicked()
	{
        StartCoroutine(SceneController.Quit(faderRef));
	}

	private void Start_clicked()
	{
        StartCoroutine(SceneController.LoadScene(1, faderRef));
	}

    public void SetUIActive(bool _active)
	{
        gameObject.SetActive(_active);
    }
}

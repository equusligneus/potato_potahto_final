using UnityEngine;

public class InGameStateWatcher : MonoBehaviour
{
    public RuntimeGameState gameStateRef;
	public RuntimeFader faderRef;

    // Start is called before the first frame update
    void Start()
    {
        if(gameStateRef)
			gameStateRef.OnValueChanged += GameStateRef_OnValueChanged;
    }

	private void OnDestroy()
	{
		if (gameStateRef)
			gameStateRef.OnValueChanged -= GameStateRef_OnValueChanged;
	}

	private void GameStateRef_OnValueChanged(GameState _value)
	{
		if (!gameStateRef)
			return;

		switch (gameStateRef.Value)
		{
			case GameState.Winning:
			case GameState.MainMenu:
			case GameState.Quitting:
				StartCoroutine(SceneController.LoadScene(2, faderRef));
				break;
			default:
				break;
		}
	}
}

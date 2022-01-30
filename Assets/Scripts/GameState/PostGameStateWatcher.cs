using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class PostGameStateWatcher : MonoBehaviour
{
    public RuntimeGameState gameStateRef;
	public RuntimeFader faderRef;

	[TextArea(2, 5)]
	public string winning;

	[TextArea(2, 5)]
	public string losing;

	// Start is called before the first frame update
	void Start()
    {
		var label = GetComponent<UIDocument>().rootVisualElement.Q<Label>("txt_postgame");

		if(gameStateRef && label != default)
		{
			if(gameStateRef.Value == GameState.Winning)
				label.text = winning;
			else
				label.text = losing;
		}
		StartCoroutine(SwitchRoutine(gameStateRef.Value));
    }

	private IEnumerator SwitchRoutine(GameState _gameState)
	{
		yield return new WaitForSeconds(10f);

		if (_gameState == GameState.Quitting)
		{
			StartCoroutine(SceneController.Quit(faderRef));
		}
		else
		{
			StartCoroutine(SceneController.LoadScene(0, faderRef));
		}
	}
}

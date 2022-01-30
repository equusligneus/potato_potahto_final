using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    public static IEnumerator Begin(RuntimeFader _faderRef)
	{
        if (_faderRef)
        {
            _faderRef.Brighten();
            yield return new WaitForSeconds(_faderRef.Duration);
        }
    }

    public static IEnumerator Quit(RuntimeFader _faderRef)
	{
        if(_faderRef)
		{
            _faderRef.Darken();
            yield return new WaitForSeconds(_faderRef.Duration);
		}

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public static IEnumerator LoadScene(int _nextSceneIndex, RuntimeFader _faderRef)
	{
        if (_faderRef)
        {
            _faderRef.Darken();
            yield return new WaitForSeconds(_faderRef.Duration);
        }
        SceneManager.LoadScene(_nextSceneIndex);
        if (_faderRef)
        {
            _faderRef.Brighten();
            yield return new WaitForSeconds(_faderRef.Duration);
        }
    }
}

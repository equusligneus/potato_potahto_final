using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{

    public void Reload()
    {
        Debug.Log("click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

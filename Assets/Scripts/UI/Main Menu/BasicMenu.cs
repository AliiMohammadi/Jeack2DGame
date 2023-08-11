using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasicMenu : MonoBehaviour 
{
    public virtual void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public virtual void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public virtual void Exit()
    {
        Application.Quit();
    }
}

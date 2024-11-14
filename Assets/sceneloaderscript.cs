using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneloaderscript : MonoBehaviour
{
    public void LoadSceneStuff()
    {
        SceneManager.LoadScene("Level");
    }
}

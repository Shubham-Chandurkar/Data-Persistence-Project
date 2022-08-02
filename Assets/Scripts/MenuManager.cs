using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public InputField fieldValueName;
    public Text menuText;
    // Start is called before the first frame update
    void Start()
    {
        GlobalScript.instance.LoadInfo();
        menuText.text = "Best Score : " + GlobalScript.instance.bestPlayerName + " : " + GlobalScript.instance.bestPlayerPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toMain()
    {
      
        GlobalScript.instance.playerName = fieldValueName.text;
        
        SceneManager.LoadScene(1);
    }
    public void toQuit()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }
}

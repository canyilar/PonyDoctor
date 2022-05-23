using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    int wallet = 0;

    [SerializeField]
    Image flash;

    public void OnEnable()
    {
        flash.color = new Color(1, 1, 1, 1);
        flash.DOColor(new Color(1, 1, 1, 0), 0.5f);
    }

    public void ChangeScene(string sceneName)
    {
        flash.DOColor(new Color(1, 1, 1, 1), 0.5f).OnComplete (() => SceneManager.LoadScene(sceneName));
    }


 

}

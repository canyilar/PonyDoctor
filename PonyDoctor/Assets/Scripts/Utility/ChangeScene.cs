using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    Image flash;
    public void Change(string sceneName)
    {
        flash.DOColor(new Color(1, 1, 1, 1), 0.5f).OnComplete(() => SceneManager.LoadScene(sceneName));

    }

}

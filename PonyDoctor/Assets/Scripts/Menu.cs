using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    int wallet = 0;

   public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   public void BuyItem(int itemIndex)
    {

    }

}

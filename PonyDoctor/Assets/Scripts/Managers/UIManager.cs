using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton

    private static UIManager instance;
    public static UIManager Instance => instance;

    #endregion

    [SerializeField] private GameObject finger;

    void Awake()
    {
        instance = this;
    }

    public void ActivateFingerImage()
    {
        finger.SetActive(true);
    }

    public void DisableFingerImage()
    {
        finger.SetActive(false);
    }
}

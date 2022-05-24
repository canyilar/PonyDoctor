using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager instance;
    public static GameManager Instance => instance;

    #endregion

    [SerializeField, Range(1, 5)] private int cameraSlideSpeed = 2;
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject[] stateObjects;

    /// <summary>
    /// Determines if player can do any action (Interaction etc.).
    /// </summary>
    public bool actionAvaible { get; set; }

    private Camera mainCam;

    void Awake()
    {
        instance = this;

        mainCam = Camera.main;
        ActivateStateObjects();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            DoAction();
        }
    }

    private void DoAction()
    {
        switch (gameState)
        {
            case GameState.CleanHorseShoe:
                CleanHorseShoe();
                break;
            case GameState.PaintHorseShoe:
                PaintHorseShoe();
                break;
        }
    }

    private void CleanHorseShoe()
    {
        var touch = Input.GetTouch(0);

        var screenPos = mainCam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, mainCam.transform.position.z));
        var mouseDelta = touch.deltaPosition;

        if (Mathf.Abs(mouseDelta.y) > 20)
        {
            print("AAAAA");
        }
    }

    [ContextMenu("OnActionCompleted")]
    public void OnActionCompleted()
    {
        IncrementActionIndex();

        ActivateStateObjects();
        DoSlideCamera(stateObjects[(int)gameState].transform.position.x);
        actionAvaible = false;
    }

    private void ActivateStateObjects()
    {
        foreach (var obj in stateObjects)
        {
            obj.SetActive(false);
        }
        stateObjects[(int)gameState].SetActive(true);
    }

    private void PaintHorseShoe()
    {

    }

    /// <summary>
    /// Changes the game state to next state.
    /// </summary>
    public void IncrementActionIndex()
    {
        gameState++;

        if ((int)gameState > 4)
            gameState = 0;
    }

    public void DoSlideCamera(float slideAmount)
    {
        mainCam.transform.DOMoveX(slideAmount, 1);
    }


    public void SlideCamera(float slideAmount)
    {
        StartCoroutine(SlideCameraCO(slideAmount));
    }

    private IEnumerator SlideCameraCO(float slideAmount)
    {
        var nextCamPos = mainCam.transform.position.x + slideAmount;
        while (mainCam.transform.position.x < nextCamPos)
        {
            mainCam.transform.Translate(Vector3.right * Time.deltaTime * cameraSlideSpeed, Space.Self);
            yield return null;
        }
    }

    public int GetGameStateInt()
    {
        return (int)gameState;
    }

    public GameState GetGameState()
    {
        return gameState;
    }
}

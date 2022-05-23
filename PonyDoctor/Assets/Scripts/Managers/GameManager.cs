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

    /// <summary>
    /// Determines if player can do any action (Interaction etc.).
    /// </summary>
    public bool actionAvaible { get; set; }

    private Camera mainCam;

    void Awake()
    {
        instance = this;

        mainCam = Camera.main;
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

using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager instance;
    public static GameManager Instance => instance;

    #endregion

    [SerializeField] private GameState gameState;

    void Awake()
    {
        instance = this;
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
        if (Input.GetTouch(0).deltaPosition != Vector2.zero)
        {
            print("Deðil");
        }
        else
        {
            print("Zero");
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

    public int GetGameStateInt()
    {
        return (int)gameState;
    }

    public GameState GetGameState()
    {
        return gameState;
    }
}

public enum GameState
{
    RemoveHorseShoe,
    CleanHorseShoe,
    CutHorseNail,
    PaintHorseShoe,
    PutHorseShoe
}

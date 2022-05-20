using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

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

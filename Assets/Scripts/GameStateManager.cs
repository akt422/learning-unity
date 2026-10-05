public static class GameStateManager
{
    private static GameState CurrentState = GameState.Gameplay;

    public static void SetState(GameState newState)
    {
        CurrentState = newState;
    }

    public static GameState GetState()
    {
        return CurrentState;
    }
}
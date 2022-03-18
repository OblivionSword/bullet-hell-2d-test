
public class LoseState : IState
{
    private bool playerLose;

    public LoseState(bool playerLose)
    {
        this.playerLose = playerLose;
    }

    public void Enter()
    {
        playerLose = true;
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}

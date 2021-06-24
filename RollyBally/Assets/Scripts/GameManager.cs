using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int playerScore = 0;
    public static int eaterScore = 0;

    public int victoryLimit = 10;

    bool gameEnded = false;
    public void EndGame() {

        if(gameEnded == false) {
            gameEnded = true;
            Debug.Log("Moved to Game Over!");
            SceneManager.LoadScene("GameOver");
        }
        
    }

    public void Victory() {
        if(gameEnded == false) {
            gameEnded = true;
            Debug.Log("Moved to Victory Scene!");
            SceneManager.LoadScene("VictoryScreen");
        }
        
    }

    public void Restart() {
        playerScore = 0;
        eaterScore = 0;
        gameEnded = false;

        SceneManager.LoadScene("GameView");
    }

    public void QuitApplication() {
        Application.Quit();
    }

    public void IncreasePlayerScore() {
        playerScore++;
        //ScoreKeeper.instance.AddToPlayerScore();
        Debug.Log("Player's score: " + playerScore);

        if(playerScore == victoryLimit) {
            Victory();
        }
    }

    public void IncreaseEaterScore() {
        eaterScore++;
        //ScoreKeeper.instance.AddToEaterScore();

        Debug.Log("Eater's score: " + eaterScore);

        if(eaterScore == victoryLimit) {
            EndGame();
        }
    }

}

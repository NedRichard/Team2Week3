using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int playerScore = 0;
    public static int eaterScore = 0;

    bool gameEnded = false;
    public void EndGame() {

        if(gameEnded==false) {
            gameEnded=true;
            Debug.Log("Moved to Game Over!");
            //SceneManager.LoadScene("GameOver");
        }
        
    }

    public void Restart() {
        playerScore = 0;
        eaterScore = 0;

        SceneManager.LoadScene("JoniTest");
    }

    void QuitApplication() {
        Application.Quit();
    }

    public void IncreasePlayerScore() {
        playerScore++;
        ScoreKeeper.instance.AddToPlayerScore();
        //Debug.Log("Player's score: " + playerScore);

        if(playerScore == 10) {
            EndGame();
        }
    }

    public void IncreaseEaterScore() {
        eaterScore++;
        ScoreKeeper.instance.AddToEaterScore();

        //Debug.Log("Eater's score: " + eaterScore);

        if(eaterScore == 10) {
            EndGame();
        }
    }

}

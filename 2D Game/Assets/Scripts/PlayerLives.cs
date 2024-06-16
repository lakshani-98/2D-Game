using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public int startingLives = 3; 
    private int currentLives; 
    public GameObject[] heartImages;

    void Start()
    {
        currentLives = startingLives;
        UpdateHeartsUI();
    }

    // Method to decrease lives count when the player collides with a vehicle
    public void DecreaseLives()
    {
        currentLives--;
        UpdateHeartsUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    // Method to update the UI to reflect the current number of lives
    void UpdateHeartsUI()
{
    for (int i = heartImages.Length - 1; i >= 0; i--)
    {
        int heartIndex = heartImages.Length - 1 - i;

        if (heartIndex >= currentLives)
        {
            heartImages[i].SetActive(false);
        }
       
        else
        {
            heartImages[i].SetActive(true);
        }
    }
}


    // Method to handle game over
    void GameOver()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

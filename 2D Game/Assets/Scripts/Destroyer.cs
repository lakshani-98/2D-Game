using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class Destroyer : MonoBehaviour
{
    public float timeToKill = 2.0f; 
    void Start()
    {
         GetComponent<Text>().text = SceneManager.GetActiveScene().name;
         Destroy(this.gameObject, timeToKill);     
    }
}

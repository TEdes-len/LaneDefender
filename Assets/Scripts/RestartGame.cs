using UnityEngine;
using UnityEngine.SceneManagement;
   

public class RestartGame : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");  
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

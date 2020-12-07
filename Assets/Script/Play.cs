using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void next_intro()
    {
        SceneManager.LoadScene("intro1");
    }

    public void goto_avianflu()
    {
        SceneManager.LoadScene("intro_avianflu");
    }

    public void mulai_game1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    [SerializeField] private string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void mulai_game2()
    {
        SceneManager.LoadScene("Level2p");
    }

    public void mulai_game3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void quit_game()
    {
        Application.Quit();
    }
}

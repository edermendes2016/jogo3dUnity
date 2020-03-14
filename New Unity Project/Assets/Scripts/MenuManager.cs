using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlayJogo()
    {
        SceneManager.LoadScene("game scene");
    }

    public void QuitJogo()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

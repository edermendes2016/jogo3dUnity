using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Slider sliderVida;
    public float vidaJogador;
    GameObject canvas;
    public bool estaPausado;

    // variaveis de itens coletados
    public int plastico;
    public int papel;
    public int metal;
    public int vidro;

    // variaveis de itens ja colocados no lixo
    int plasticoColetado;
    int papelColetado;
    int metalColetado;
    int vidroColetado;

    public Text plasticoColet;
    public Text papelColet;
    public Text metalColet;
    public Text vidroColet;

    public Text plastico2;
    public Text papel2;
    public Text vidro2;
    public Text metal2;

    public Button continuar;
    public Button voltarAoMenu;
    public Text Pause;


    public void DesabilitarUIDerrota()
    {
        canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(false);
    }

    public void DesabilitarUIVitoria()
    {
        canvas = GameObject.Find("Canvas");     
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(5).gameObject.SetActive(false);
    }

    public void HabilitarUIDerrota()
    {
        canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        canvas.transform.GetChild(2).gameObject.SetActive(true);
        canvas.transform.GetChild(4).gameObject.SetActive(true);
    }

    public void HabilitarUIVitoria()
    {
        canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(2).gameObject.SetActive(true);
        canvas.transform.GetChild(5).gameObject.SetActive(true);
    }
    private void Awake()
    {
        DesabilitarUIDerrota();
        DesabilitarUIVitoria();
        canvas = GameObject.Find("Canvas");
        plasticoColet.enabled = false;
        metalColet.enabled = false;
        papelColet.enabled = false;
        vidroColet.enabled = false;
        estaPausado = false;
        continuar.gameObject.SetActive(false);
        voltarAoMenu.gameObject.SetActive(false);
        Pause.enabled = false;
    }

    IEnumerator HabilitarAvisoColetPlastico()
    {
        plasticoColet.enabled = true;
        yield return new WaitForSeconds(3.0f);
        plasticoColet.enabled = false;
    }
    IEnumerator HabilitarAvisoColetMetal()
    {
        metalColet.enabled = true;
        yield return new WaitForSeconds(3.0f);
        metalColet.enabled = false;
    }
    IEnumerator HabilitarAvisoColetPapel()
    {
        papelColet.enabled = true;
        yield return new WaitForSeconds(3.0f);
        papelColet.enabled = false;
    }
    IEnumerator HabilitarAvisoColetVidro()
    {
        vidroColet.enabled = true;
        yield return new WaitForSeconds(3.0f);
        vidroColet.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        vidaJogador = 100;
        plastico2.text = "0/4";
        papel2.text = "0/3";
        vidro2.text = "0/2";
        metal2.text = "0/???";
        
    }

    public void ColetarPlastico()
    {
        plastico++;
        StartCoroutine(HabilitarAvisoColetPlastico());
    }
    public void ColetarPapel()
    {
        papel++;
        StartCoroutine(HabilitarAvisoColetPapel());
    }
    public void ColetarMetal()
    {
        metal++;
        StartCoroutine(HabilitarAvisoColetMetal());
    }
    public void ColetarVidro()
    {
        vidro++;
        StartCoroutine(HabilitarAvisoColetVidro());
    }

    public void SepararPlastico()
    {
        plasticoColetado = plasticoColetado + plastico;
        plastico2.text = plasticoColetado.ToString() + "/4";
    }
    public void SepararPapel()
    {
        papelColetado = papelColetado + papel;
        papel2.text = papelColetado.ToString() + "/3";
    }
    public void SepararVidro()
    {
        vidroColetado = vidroColetado + vidro;
        vidro2.text = vidroColetado.ToString() + "/2";
    }
    public void SepararMetal()
    {
        metalColetado = metalColetado + metal;
        metal2.text = metalColetado.ToString() + "/???";
    }

    public void ZerarPlastico()
    {
        plastico = 0;
    }
    public void ZerarMetal()
    {
        metal = 0;
    }
    public void ZerarVidro()
    {
        vidro = 0;
    }
    public void ZerarPapel()
    {
        papel = 0;
    }

    public void GanharJogo()
    {
        if (vidroColetado >= 2 && plasticoColetado >= 4 && metalColetado >= 4 && papelColetado >= 3)
        {
            HabilitarUIVitoria();
            Time.timeScale = 0;
        }
    }

    public void PerderJogo()
    {
        if(vidaJogador <= 0)
        {
            StartCoroutine(PausarJogoNaDerrota());
        }
    }

    IEnumerator PausarJogoNaDerrota()
    {
        HabilitarUIDerrota();
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
    }

    public void BotaoRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("game scene");
    }

    public void BotaoIrMenu()
    {
        SceneManager.LoadScene("menu scene");
    }

    public void BotaoSair()
    {
        Application.Quit();
    }
    public void PauseDoJogo()
    {
        if (!estaPausado)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                estaPausado = true;
                continuar.gameObject.SetActive(true);
                voltarAoMenu.gameObject.SetActive(true);
                Pause.enabled = true;
                Time.timeScale = 0;
            }
        }
    }

    public void DespausarJogo()
    {
        estaPausado = false;
        continuar.gameObject.SetActive(false);
        voltarAoMenu.gameObject.SetActive(false);
        Pause.enabled = false;
        Time.timeScale = 1;
        
    }
    // Update is called once per frame
    void Update()
    {
        PerderJogo();
        GanharJogo();
        sliderVida.value = vidaJogador;
        PauseDoJogo();
    }
}

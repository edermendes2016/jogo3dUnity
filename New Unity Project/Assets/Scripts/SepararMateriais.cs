using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SepararMateriais : MonoBehaviour
{
    private GameObject gc;

    public Text separarPlastico;
    public Text separarPapel;
    public Text separarVidro;
    public Text separarMetal;

    public enum Material
    {
        plastico,
        papel,
        vidro,
        metal
    };

    public Material mat = new Material();

    void Awake()
    {
        separarMetal.enabled = false;
        separarPapel.enabled = false;
        separarVidro.enabled = false;
        separarPlastico.enabled = false;
    }

    IEnumerator AvisoMaterial()
    {
        if (mat == Material.plastico)
        {
            separarPlastico.enabled = true;
            yield return new WaitForSeconds(2.5f);
            separarMetal.enabled = false;
        }
        if (mat == Material.metal)
        {
            separarMetal.enabled = true;
            yield return new WaitForSeconds(2.5f);
            separarMetal.enabled = false;
        }
        if (mat == Material.papel)
        {
            separarPapel.enabled = true;
            yield return new WaitForSeconds(2.5f);
            separarMetal.enabled = false;
        }
        if (mat == Material.vidro)
        {
            separarVidro.enabled = true;
            yield return new WaitForSeconds(2.5f);
            separarMetal.enabled = false;
        }
    }
    void Start()
    {
        gc = GameObject.Find("GameController");
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (mat == Material.plastico && gc.GetComponent<GameController>().plastico > 0)
                {
                    gc.GetComponent<GameController>().SepararPlastico();
                    gc.GetComponent<GameController>().ZerarPlastico();
                    Debug.Log("plastico");
                    StartCoroutine(AvisoMaterial());
                }
                if (mat == Material.papel && gc.GetComponent<GameController>().papel > 0)
                {
                    gc.GetComponent<GameController>().SepararPapel();
                    gc.GetComponent<GameController>().ZerarPapel();
                    StartCoroutine(AvisoMaterial());
                }
                if (mat == Material.vidro && gc.GetComponent<GameController>().vidro > 0)
                {
                    gc.GetComponent<GameController>().SepararVidro();
                    gc.GetComponent<GameController>().ZerarVidro();
                    StartCoroutine(AvisoMaterial());
                }
                if (mat == Material.metal && gc.GetComponent<GameController>().metal > 0)
                {
                    gc.GetComponent<GameController>().SepararMetal();
                    gc.GetComponent<GameController>().ZerarMetal();
                    StartCoroutine(AvisoMaterial());
                }
            }
        }
    }

    void Update()
    {

    }
}

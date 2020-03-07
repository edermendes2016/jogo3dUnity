using UnityEngine;


public class ColetorDeItem : MonoBehaviour
{
    private GameObject gc;
    bool jaColetou;

    public enum Material
    {
        plastico,
        papel,
        vidro,
        metal
    };

    public Material mat = new Material();

    void Start()
    {
        gc = GameObject.Find("GameController");
        jaColetou = false;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (mat == Material.plastico && !jaColetou)
                {
                    gc.GetComponent<GameController>().ColetarPlastico();
                    jaColetou = true;
                    Destroy(this.gameObject, 1.0f);
                }
                if (mat == Material.papel && !jaColetou)
                {
                    gc.GetComponent<GameController>().ColetarPapel();
                    jaColetou = true;
                    Destroy(this.gameObject, 1.0f);
                }
                if (mat == Material.vidro && !jaColetou)
                {
                    gc.GetComponent<GameController>().ColetarVidro();
                    jaColetou = true;
                    Destroy(this.gameObject, 1.3f);
                }
                if (mat == Material.metal && !jaColetou)
                {
                    gc.GetComponent<GameController>().ColetarMetal();
                    jaColetou = true;
                    Destroy(this.gameObject, 1.2f);
                }
            }
        }
    }

}
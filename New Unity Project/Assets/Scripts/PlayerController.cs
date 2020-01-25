using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float h, v;
    Animator anim;
    public float divisorDeForca;
    private GameObject gamec;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Animador()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");


        if (v > 0 && gamec.GetComponent<GameController>().vidaJogador > 0)
        {
            anim.SetInteger("estado", 1);
        }

        else if (v <= 0 && gamec.GetComponent<GameController>().vidaJogador > 0)
        {
            anim.SetInteger("estado", 0);
        }
    }
        public void AdicionarForca()
        {
            h = Input.GetAxisRaw("Horizontal") * 2;
            v = Input.GetAxisRaw("Vertical");

            if (v > 0)
            {
                transform.Translate(new Vector3(0, 0, v / divisorDeForca));

            }

            if (h > 0)
            {

                transform.Rotate(0, h, 0);//
            }

            if (h < 0)
            {
                transform.Rotate(0, h, 0);//
            }
        }

        // Start is called before the first frame update
        void Start()
    {
        gamec = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if(gamec.GetComponent<GameController>().vidaJogador <= 0)
            {
                anim.SetInteger("estado", 3);
            }

        AdicionarForca();
        Animador();
    }
}

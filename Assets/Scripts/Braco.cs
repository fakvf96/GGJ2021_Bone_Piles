using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Braco : MonoBehaviour
{
    public bool pegouBraco;
    public bool pegouTorço;
    public bool pegouPernaD;
    public bool pegouPernaE;
    
    
    public GameObject braço;
    public GameObject torço;
    public GameObject pernaD;
    public GameObject pernaE;
    public float movimento;
    public Animator anim;
    
    private Collider2D colisor;
   
    public int vida;

    void Start()
    {
        movimento = GetComponent<Move>().moveSpeed;
        anim = GetComponent<Animator>();
        colisor = GetComponent<Collider2D>();
        
        pegouBraco = false;
        pegouTorço = false;
        pegouPernaD = false;
        pegouPernaE = false;
        
        vida = 2 ;
    }

  
    void Update()
    {
        PegaMembro();
        
    }

    public void TomaDano()
    {

        if (vida >= 1)
        {
            vida = 1;

        }

    }

    public void PegaMembro()
    {
        if (pegouBraco == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                braço.gameObject.SetActive(false);
                anim.SetTrigger("pegoubraço");
                movimento = GetComponent<Move>().moveSpeed = 6f;
                if (vida != 3)
                {
                    vida = 3;
                }     
            }
        }

        if(pegouTorço == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                movimento = GetComponent<Move>().moveSpeed = 7f;
                torço.gameObject.SetActive(false);
                anim.SetTrigger("pegoutorço");
                
                if (vida != 4)
                {
                    vida = 4;
                }
            }
        }

        if (pegouPernaD == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                movimento = GetComponent<Move>().moveSpeed = 8f;
                pernaD.gameObject.SetActive(false);
                anim.SetTrigger("pegoupernaD");

                if (vida != 5)
                {
                    vida = 5;
                }
            }
        }
            
        if (pegouPernaE == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                movimento = GetComponent<Move>().moveSpeed = 9f;
                pernaE.gameObject.SetActive(false);
                anim.SetTrigger("pegoupernaE");

                if (vida != 6)
                {
                    vida = 6;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("braço"))
        {
            colisor.enabled = true;
            pegouBraco = true;
        }

        if (player.gameObject.CompareTag("torço"))
        {
            colisor.enabled = true;
            pegouTorço = true;
        }

        if (player.gameObject.CompareTag("pernaD"))
        {
            colisor.enabled = true;
            pegouPernaD = true;
        }

        if (player.gameObject.CompareTag("pernaE"))
        {
            colisor.enabled = true;
            pegouPernaE = true;
        }
    }
    public void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("braço"))
        {
            pegouBraco = false;
        }

        if (player.gameObject.CompareTag("torço"))
        {
            pegouTorço = false;
        }

        if (player.gameObject.CompareTag("pernaD"))
        {
            pegouPernaD = false;
        }

        if (player.gameObject.CompareTag("pernaE"))
        {
            pegouPernaE = false;
        }

       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Braco : MonoBehaviour
{
    public bool pegouBraco;
    public bool pegouTor�o;
    public bool pegouPernaD;
    public bool pegouPernaE;
    public bool tomouDano;

    public GameObject drop;
    public GameObject bra�o;
    public GameObject tor�o;
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
        pegouTor�o = false;
        pegouPernaD = false;
        pegouPernaE = false;
        tomouDano = false;

        vida = 1;
    }

  
    void Update()
    {
        PegaMembro();
          
    }

    public void TomaDano()
    {
        //cab�a
        if(tomouDano == true)
        {
            tomouDano = true;
            if(vida >= 0)
            {
                vida -= 1;
                anim.SetTrigger("queimadofrente");
                movimento = GetComponent<Move>().moveSpeed = 0f;
                SceneManager.LoadScene("MainMenu");
            }
        }

        //bra�o
        if(tomouDano == true)
        {
            if(vida >= 1)
            {
                vida -= 1;
                anim.SetTrigger("cabe�a");
                bra�o.transform.position = drop.transform.position;
                bra�o.gameObject.SetActive(true);
                movimento = GetComponent<Move>().moveSpeed = 10;
            }
        }

        //tor�o
        if (tomouDano == true)
        {
            if (vida >= 3)
            {
                vida -= 1;
                anim.SetTrigger("pegoubra�o");
                tor�o.transform.position = drop.transform.position;
                tor�o.gameObject.SetActive(true);
                movimento = GetComponent<Move>().moveSpeed = 11f;
            }
        }

        //pernaD
        if (tomouDano == true)
        {
            if (vida >= 4)
            {
                vida -= 1;
                anim.SetTrigger("pegoutor�o");
                pernaD.transform.position = drop.transform.position;
                pernaD.gameObject.SetActive(true);
                movimento = GetComponent<Move>().moveSpeed = 12f;
            }
        }

        //pernaE
        if (tomouDano == true)
        {
            if (vida >= 5)
            {
                vida -= 1;
                anim.SetTrigger("pernaD");
                pernaE.transform.position = drop.transform.position;
                pernaE.gameObject.SetActive(true);
                movimento = GetComponent<Move>().moveSpeed = 13f;
            }
        }

    }

    public void PegaMembro()
    {
        if (pegouBraco == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                bra�o.gameObject.SetActive(false);
                anim.SetTrigger("pegoubra�o");
                movimento = GetComponent<Move>().moveSpeed = 14f;
                if (vida != 2)
                {
                    vida = 2;
                }     
            }
        }

        if(pegouTor�o == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                movimento = GetComponent<Move>().moveSpeed = 12f;
                tor�o.gameObject.SetActive(false);
                anim.SetTrigger("pegoutor�o");
                
                if (vida != 3)
                {
                    vida = 3;
                }
            }
        }

        if (pegouPernaD == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                movimento = GetComponent<Move>().moveSpeed = 13f;
                pernaD.gameObject.SetActive(false);
                anim.SetTrigger("pegoupernaD");

                if (vida != 4)
                {
                    vida = 4;
                }
            }
        }
            
        if (pegouPernaE == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                movimento = GetComponent<Move>().moveSpeed = 14f;
                pernaE.gameObject.SetActive(false);
                anim.SetTrigger("pegoupernaE");

                if (vida != 5)
                {
                    vida = 5;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("bra�o"))
        {
            colisor.enabled = true;
            pegouBraco = true;
        }

        if (player.gameObject.CompareTag("tor�o"))
        {
            colisor.enabled = true;
            pegouTor�o = true;
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

        if (player.gameObject.CompareTag("Bullet"))
        {
            tomouDano = true;
        }

        if (player.gameObject.CompareTag("saw"))
        {
            tomouDano = true;
        }

        if (player.gameObject.CompareTag("Trap"))
        {
            tomouDano = true;
        }
    }
    public void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("bra�o"))
        {
            pegouBraco = false;
        }

        if (player.gameObject.CompareTag("tor�o"))
        {
            pegouTor�o = false;
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

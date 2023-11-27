using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Text textHP;
    public Text textCoint;
    public Text textDiamond;
    public int numberHP = 0;
    private int numberCoint = 0;
    private int numberDiamond = 0;
    public int addHealth = 20;
    private Health healthPlayer;
    public GameObject diamondSystem;
    public GameObject cointSystem;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    void Start()
    {
        healthPlayer = GetComponent<Health>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && numberHP>0 && healthPlayer.currentHealth<100)
        {
            numberHP--;
            healthPlayer.AddHealth(addHealth);
            audioManager.PlaySFX(audioManager.addHealth);
        }
        textHP.text = numberHP.ToString();
        textDiamond.text = numberDiamond.ToString();
        textCoint.text = numberCoint.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("HP"))
        {
            numberHP++;
            //Destroy(collision.gameObject);
        }*/
        if (collision.CompareTag("Arrow"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Coint"))
        {
            numberCoint +=50;
            Debug.Log("text:"+numberCoint);
            Destroy(cointSystem);
        }
        if (collision.CompareTag("Diamond"))
        {
            numberDiamond ++;
            Debug.Log("text:" + numberDiamond);
            Destroy(diamondSystem);
        }

    }
}

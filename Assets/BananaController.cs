using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaController : MonoBehaviour
{
    [SerializeField] Text Muzzzzzz;
    public int muz = 0;
    public int stack= 1;
    public GameObject errorText;
    void Start()
    {
        errorText.SetActive(false);
        PlayerPrefs.SetInt("muz", muz);
        Muzzzzzz = GameObject.Find("MuzSayaci").GetComponent<Text>();
        PlayerPrefs.SetInt("Stack", stack);
    }

    // Update is called once per frame
    void Update()
    {
        Muzzzzzz.text = PlayerPrefs.GetInt("muz").ToString();

        TikliyorumYaaaa();
        PlayerPrefs.Save();

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            errorText.SetActive(false);
        }

    }

   void TikliyorumYaaaa()
    {
        if (Input.GetMouseButtonDown(0))
        {
            muz = muz + (1*stack) ;
            PlayerPrefs.SetInt("muz", muz);
        }
    }
    public float timer = 2f;

    public void MoreBananaButton()
    {
        if (muz > 100)
        {
            stack = PlayerPrefs.GetInt("Stack") + 1;
            muz = muz - 100;
            PlayerPrefs.SetInt("Stack", stack);
        }
        else
        {
            errorText.SetActive(true);
            timer = 2f;

            
            
        }
                    
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaController : MonoBehaviour
{
    [SerializeField] Text Muzzzzzz;
    [SerializeField] Text ErrorText;

    [SerializeField] int muz = 0;
    [SerializeField] int stack = 1;
    [SerializeField] GameObject errorText;
    [SerializeField] float timer = 2f;
    [SerializeField] int needmuz = 100;

    void Start()
    {
        errorText.SetActive(false);

        // Kaydedilen deðerleri yükleyin
        muz = PlayerPrefs.GetInt("muz", 0);
        stack = PlayerPrefs.GetInt("Stack", 1);

        Muzzzzzz = GameObject.Find("MuzSayaci").GetComponent<Text>();
        UpdateMuzText();
    }

    void Update()
    {
        UpdateMuzText();
        TikliyorumYaaaa();

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
            muz = muz + (1 * stack);
            PlayerPrefs.SetInt("muz", muz);
            PlayerPrefs.Save();
            UpdateMuzText();
        }
    }

    public void MoreBananaButton()
    {
        if (muz >= (needmuz * stack))
        {
            muz -= (needmuz*stack);
            stack++;
            PlayerPrefs.SetInt("Stack", stack);
            PlayerPrefs.SetInt("muz", muz);
            PlayerPrefs.Save(); 
            UpdateMuzText();
        }
        else
        {
            ErrorText.text = "Need " + needmuz*stack +" Panana.";
            errorText.SetActive(true);
            timer = 2f;
        }
    }

    void UpdateMuzText()
    {
        Muzzzzzz.text = muz.ToString();
    }
}

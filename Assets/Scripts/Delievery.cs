using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delievery : MonoBehaviour
{

    bool hasPackage = false;
    [SerializeField] int numberOfPackages = 0;
    [SerializeField] int secondsToDestroy = 0;

    [SerializeField] int packagesToWin = 13;

    [SerializeField] TMP_Text WinText;

    private void Start()
    {
        WinText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the tag is package, then print "package detected"

        if (collision.CompareTag("Package") && !hasPackage)
        {
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, secondsToDestroy);
            hasPackage = true;
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject, secondsToDestroy);
            hasPackage = false;
            numberOfPackages++;
            if (numberOfPackages >= packagesToWin)
            {
                WinText.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }

       

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

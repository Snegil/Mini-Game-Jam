using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathScript : MonoBehaviour
{
    [SerializeField]
    List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    [SerializeField]
    string deathMessage;

    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            return;
        }
        if (dead)
        {
            GetComponent<PlayerInput>().enabled = false;
            StartCoroutine(DeathText());
            dead = false;
        }
    }
    IEnumerator DeathText() 
    {   
        for (int j = 0; j < 16; j++)
        {
            for (int i = 0; i < texts.Count; i++)
            {
            texts[i].text += deathMessage;
            yield return new WaitForSeconds(0.1f);
            }    
        }
        Application.Quit();
    }
    public void DeclaredDead()
    {
        dead = true;
    }
}

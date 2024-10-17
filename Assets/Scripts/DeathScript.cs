using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            StartCoroutine(DeathText());
            dead = false;
        }
    }
    IEnumerator DeathText() 
    {   
        for (int j = 0; j < 6; j++)
        {
            for (int i = 0; i < texts.Count; i++)
            {
            texts[i].text += deathMessage;
            yield return new WaitForSeconds(0.2f);
            }    
        }        
        Application.Quit();
    }
    public void DeclaredDead()
    {
        dead = true;
    }
}

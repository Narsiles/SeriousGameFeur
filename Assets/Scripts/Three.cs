using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three : MonoBehaviour
{
    [SerializeField] GameObject uiQuest1;
    [SerializeField] GameObject uiQuest2;
    [SerializeField] GameObject uiQuest3;

    private bool questOneIsAccepted = false;
    [SerializeField] private bool questTwoIsAccepted = false;
    private bool questTreeIsAccepted = false;

    [SerializeField] private bool questOneIsCompleted = false;
    [SerializeField] private bool questTwoIsCompleted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && questOneIsAccepted == false)
        {
            uiQuest1.SetActive(true);
        }
        else if (other.CompareTag("Player") && questTwoIsAccepted == false && questOneIsCompleted == true)
        {
            uiQuest2.SetActive(true);
        }
        else if(other.CompareTag("Player") && questTreeIsAccepted == false && questTwoIsCompleted == true)
        {
            Debug.Log(questTreeIsAccepted);
            Debug.Log(questTwoIsCompleted);
            uiQuest3.SetActive(true);
        }
    }

    public void QuestOneAccept()
    {
        questOneIsAccepted = true;
        uiQuest1.SetActive(false);
        FindObjectOfType<PlayerController>().TakeShowel();
    }

    public void QuestTwoAccept()
    {
        questTwoIsAccepted = true;
        uiQuest2.SetActive(false);
    }
    public void QuestTreeAccept()
    {
        questTreeIsAccepted = true;
        uiQuest3.SetActive(false);
    }

    public void Completed1()
    {
        questOneIsCompleted = true;
    }

    public void Completed2()
    {
        questTwoIsCompleted = true;
        Debug.Log("quest2completed true");
    }
}

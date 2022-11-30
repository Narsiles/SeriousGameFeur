using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Script : MonoBehaviour
{
    public void QuestOneAccept()
    {
        FindObjectOfType<GameManager>().SpawnGarden1();
        FindObjectOfType<Three>().QuestOneAccept();
        FindObjectOfType<NavArrow>().QuestOneAccept();
    }

    public void QuestTwoAccept()
    {
        FindObjectOfType<GameManager>().SpawnGarden2();
        FindObjectOfType<Three>().QuestTwoAccept();
        FindObjectOfType<NavArrow>().QuestTwoAccept();
    }

    public void QuestTreeAccept()
    {
        FindObjectOfType<GameManager>().SpawnGarden3();
        FindObjectOfType<Three>().QuestTreeAccept();
        FindObjectOfType<NavArrow>().QuestTreeAccept();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RPSManager : MonoBehaviour
{
    [SerializeField] private GameObject[] hands;
    [SerializeField] private Text gestureTxt;
    private bool isPlaying;
    private GameObject currentHand;

    public void OnClick()
    {
        Debug.Log("start");
        
        if (isPlaying)
            return;

        isPlaying = true;
        foreach (var item in hands)
        {
            item.SetActive(false);
        }
        MenuManager.Instance.OpenMenu("Start");
        StartCoroutine("DelayHand");
    }

    IEnumerator DelayHand()
    {
        yield return new WaitForSeconds(3);
        currentHand = hands[Random.Range(0, hands.Length)];
        currentHand.SetActive(true);

        if (currentHand.GetComponent<RPSHand>().Judge(gestureTxt.text) == "win")
        {
            MenuManager.Instance.OpenMenu("Win");
        }
        else if (currentHand.GetComponent<RPSHand>().Judge(gestureTxt.text) == "lose")
        {
            MenuManager.Instance.OpenMenu("Lose");
        }
        else
        {
            MenuManager.Instance.OpenMenu("Tie");
        }

        isPlaying = false;
    }
}

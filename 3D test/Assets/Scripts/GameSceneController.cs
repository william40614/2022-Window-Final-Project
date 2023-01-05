using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] public Transform food;
    [SerializeField] public GameObject tomato;
    [SerializeField] public TMP_Text TMP;
    public int sroce = 0;
    // Start is called before the first frame update
    private void Start()
    {
        TMP = GameObject.Find("Canvas").GetComponentInChildren<TMP_Text>();
        
        TMP.SetText(sroce.ToString());
    }
    public GameObject newItemInstantiate(Transform player, string _string)
    {
        Debug.Log(_string);
        GameObject newItem ;
        newItem = GameObject.Find(_string);
        newItem.transform.position = player.position;
        return newItem;
    }
    public void sroceplus()
    {
        sroce++;
        TMP.SetText(sroce.ToString());
    }
}

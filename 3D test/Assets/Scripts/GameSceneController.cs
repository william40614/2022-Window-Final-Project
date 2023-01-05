using Photon.Pun;
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
    [SerializeField] public GameObject menu;
    TMP_Text timer;
    PhotonView PV;
    int t_seconds , t_min = 1, t_sec = 0;
    public int sroce = 0;
    // Start is called before the first frame update
    private void Start()
    {
        PV = GetComponent<PhotonView>();
        TMP = GameObject.Find("Canvas").transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        TMP.SetText(sroce.ToString());
        timer = GameObject.Find("Canvas").transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
        StartCoroutine(Countdown());
    }
    public GameObject newItemInstantiate(Transform player, string _string)
    {
        if (!PV.IsMine)
            return null;
        Debug.Log(_string);
        GameObject newItem ;
        newItem = GameObject.Find(_string);
        newItem.transform.position = player.position;
        return newItem;
    }
    public void sroceplus()
    {
        if (!PV.IsMine)
            return ;
        sroce++;
        TMP.SetText(sroce.ToString());
        if (sroce == 1)
        {
            menu.active = true;
            menu.transform.GetChild(0).gameObject.active = true;
        }
    }

    public void exitgame()
    {
        Application.Quit();
    }
    IEnumerator Countdown()
    {
        timer.text = string.Format("{0}:{1}", t_min.ToString("00"), t_sec.ToString("00"));
        t_seconds = (t_min) * 60 + t_sec;
        while(t_seconds > 0)
        {
            yield return new WaitForSeconds(1);
            t_seconds--;
            t_sec--;
            if(t_sec < 0 && t_min > 0)
            {
                t_min--;
                t_sec = 59;
            }
            else if(t_sec < 0 && t_min == 0)
            {
                t_sec = 0;
            }
            timer.text = string.Format("{0}:{1}", t_min.ToString("00"), t_sec.ToString("00"));
        }
        yield return new WaitForSeconds(1);
        menu.active = true;
        menu.transform.GetChild(1).gameObject.active = true;
        Time.timeScale = 0;
    }
}

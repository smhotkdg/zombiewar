using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerSrc : MonoBehaviour
{

    // Use this for initialization
    public List<AudioSource> ListBGM;
    public List<AudioSource> ListFx;

    Globalvariable gv;
    private void Awake()
    {
        gv = Globalvariable.Instance;
    }
    public void UpdateSound()
    {
        if (gv.iFx == 0)
        {
            for (int i = 0; i < ListFx.Count; i++)
            {
                ListFx[i].mute = false;
            }
        }
        else
        {
            for (int i = 0; i < ListFx.Count; i++)
            {
                ListFx[i].mute = true;
            }
        }

        if (gv.iBGM == 0)
        {
            for (int i = 0; i < ListBGM.Count; i++)
            {
                ListBGM[i].mute = false;
            }
        }
        else
        {
            for (int i = 0; i < ListBGM.Count; i++)
            {
                ListBGM[i].mute = true;
            }
        }
        if (bPlay == false)
        {
            rand = Random.Range(0, ListBGM.Count);
            ListBGM[rand].Play();
            StartCoroutine(BGMPlay());
            bPlay = true;
        }

    }
    bool bPlay = false;
    int rand = 0;
    IEnumerator BGMPlay()
    {
        yield return new WaitForSeconds(1f);
        if (ListBGM[rand].isPlaying == false)
        {
            rand = Random.Range(0, ListBGM.Count);
            ListBGM[rand].Play();
        }
        StartCoroutine(BGMPlay());
    }
    void Start()
    {
        UpdateSound();
    }

    // Update is called once per frame
    void Update()
    {

    }
    bool bStartSound = false;

    public void StartFx(string name)
    {
        switch (name)
        {
            case "Button":
                if(ListFx[0].isPlaying ==false)
                    ListFx[0].Play();
                break;
            case "Meth":
                if (ListFx[1].isPlaying == false)
                    ListFx[1].Play();
                break;
            case "Money":
                if (ListFx[2].isPlaying == false)
                    ListFx[2].Play();
                break;
            case "UpgradeFail":
                if (ListFx[3].isPlaying == false)
                    ListFx[3].Play();
                break;
            case "UpgradeSuccess":
                if (ListFx[4].isPlaying == false)
                    ListFx[4].Play();
                break;
        }
    }

    public void SetBGM(int i)
    {
        gv.iBGM = i;
        gv.SaveiBGM();
    }
    public void SetFx(int i)
    {
        gv.iFx = i;
        gv.SaveiFx();
    }
}

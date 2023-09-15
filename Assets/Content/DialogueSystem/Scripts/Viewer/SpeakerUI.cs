using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerUI : MonoBehaviour
{
    public Image portrait;
    public TMP_Text fullname;
    public TMP_Text dialog;

    private Character speaker;
    public Character Speaker
    {
        get { return speaker; }
        set
        {
            speaker = value;
            portrait.sprite = speaker.portrait;
            fullname.text = speaker.name;
        }
    }

    public string Dialog
    {
        set { dialog.text = value; }
    }

    public bool HasSpeaker()
    {
        return speaker != null;
    }

    public bool SpeakerIs(Character character)
    {
        return speaker == character;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}

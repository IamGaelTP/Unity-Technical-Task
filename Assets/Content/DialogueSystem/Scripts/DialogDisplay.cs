using UnityEngine;
using System;

public class DialogDisplay : MonoBehaviour
{
    public Conversation conversation;

    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    private int activeLineIndex = 0;

    public static event Action<bool> isOnDialogue;

    private void OnEnable()
    {
        InteractionTrigger.onSpeakerInteraction += StartConversation;
    }

    private void OnDisable()
    {
        InteractionTrigger.onSpeakerInteraction -= StartConversation;
    }

    void StartConversation()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;

        AdvanceConversation();
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            AdvanceConversation();
        }
    }

    private void AdvanceConversation()
    {
        if(activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speakerUILeft.Hide();
            speakerUIRight.Hide();
            activeLineIndex = 0;

            isOnDialogue?.Invoke(false);
            conversation.CallFinishEvent();

            if(conversation.speakerRight.characterType == eCharacterType.NPC)
            {
                NPC npc = (NPC)conversation.speakerRight;
                npc.GrantInventoryItem();
            }
        }
    }

    private void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if(speakerUILeft.SpeakerIs(character))
        {
            SetDialog(speakerUILeft, speakerUIRight, line.text);
        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line.text);
        }
    }

    private void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Dialog = text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
        isOnDialogue?.Invoke(true);
    }


}

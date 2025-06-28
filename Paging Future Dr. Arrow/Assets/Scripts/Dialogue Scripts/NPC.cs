using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    public Conversation convo;
    public string InteractionPrompt { get => prompt; }

    public bool Interact(Interactor interactor)
    {
            DialogueManager.StartConversation(convo);
    }
}

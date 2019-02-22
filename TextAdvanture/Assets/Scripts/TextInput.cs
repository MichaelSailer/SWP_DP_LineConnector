using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    GameController controller;
    public InputField input;

    private void Awake()
    {
        input.onEndEdit.AddListener(AcceptStringInput);
        controller = GetComponent<GameController>();
    }
    void AcceptStringInput(string userInput)
    {

        userInput = userInput.ToLower();
        controller.logStrignwithReturn(userInput);
        InputCompleted();
    }
    void InputCompleted()
    {
        controller.DisplayLogText();
        input.ActivateInputField();
        input.text = null;
    }
}

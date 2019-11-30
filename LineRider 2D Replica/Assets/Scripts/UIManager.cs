using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * UI Manager responsible changing UI elements apperance through out runtime.
 */

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button brushButton;
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button moveButton;
    [SerializeField]
    private Button undoButton;

    [SerializeField]
    private Sprite playButtonActive;
    [SerializeField]
    private Sprite playButtonUnActive;

    [SerializeField]
    private Color pickedColor;
    [SerializeField]
    private Color unpickedColor;

    public void EnableActivePlayButton()
    {
        playButton.image.sprite = playButtonActive;
    }

    public void EnableUnActivePlayButton()
    {
        playButton.image.sprite = playButtonUnActive;
    }

    public void EnableBlueBrushButton()
    {
        ColorBlock cb = brushButton.colors;
        cb.normalColor = pickedColor;
        cb.highlightedColor = pickedColor;
        cb.selectedColor = pickedColor;
        brushButton.colors = cb;
    }

    public void EnableBlackBrushButton()
    {
        ColorBlock cb = brushButton.colors;
        cb.normalColor = unpickedColor;
        cb.highlightedColor = unpickedColor;
        cb.selectedColor = unpickedColor;
        brushButton.colors = cb;
    }

    public void EnableBlueMoveButton()
    {
        ColorBlock cb = moveButton.colors;
        cb.normalColor = pickedColor;
        cb.highlightedColor = pickedColor;
        cb.selectedColor = pickedColor;
        moveButton.colors = cb;
    }

    public void EnableBlackMoveButton()
    {
        ColorBlock cb = moveButton.colors;
        cb.normalColor = unpickedColor;
        cb.highlightedColor = unpickedColor;
        cb.selectedColor = unpickedColor;
        moveButton.colors = cb;
    }


    public void DisableToolButtons()
    {
        brushButton.interactable = false;
        moveButton.interactable = false;
        undoButton.interactable = false;
    }

    public void EnableToolButtons()
    {
        brushButton.interactable = true;
        moveButton.interactable = true;
        undoButton.interactable = true;
    }
}

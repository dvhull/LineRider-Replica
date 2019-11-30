using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject playerTrailManager;
    public GameObject Player;
    public GameObject Camera;
    public GameObject UIManager;
    public GameObject DrawManager;

    private UIManager UIManagerScript;
    private Player playerScript;
    private Camera cameraScript;
    private PlayerTrailManager playerTrailManagerScript;
    private DrawManager drawManagerScript;

    // What tool/mode is currently active.
    private bool running;
    private bool painting;
    private bool moving;

    private void Start()
    {
        playerScript = Player.GetComponent<Player>();
        cameraScript = Camera.GetComponent<Camera>();
        playerTrailManagerScript = playerTrailManager.GetComponent<PlayerTrailManager>();
        UIManagerScript = UIManager.GetComponent<UIManager>();
        drawManagerScript = DrawManager.GetComponent<DrawManager>();
        running = false;
        painting = false;
        moving = false;
    }
    public void BrushButtonClicked()
    {
        if (painting)
        {
            UIManagerScript.EnableBlackBrushButton();
            drawManagerScript.DisableBrushMode();
            painting = false;
        }
        else
        {
            UIManagerScript.EnableBlueBrushButton();
            drawManagerScript.EnableBrushMode();
            painting = true;

            UIManagerScript.EnableBlackMoveButton();
            cameraScript.DisableMoveMode();
            moving = false;
        }
    }

    public void MoveButtonClicked()
    {
        if (moving)
        {
            UIManagerScript.EnableBlackMoveButton();
            cameraScript.DisableMoveMode();
            moving = false;

        }

        else
        {
            UIManagerScript.EnableBlueMoveButton();
            cameraScript.EnableMoveMode();
            moving = true;

            drawManagerScript.DisableBrushMode();
            UIManagerScript.EnableBlackBrushButton();
            painting = false;
        }
    }

    public void UndoButtonClicked()
    {
        drawManagerScript.UndoLastLine();
    }

    public void PlayButtonClicked()
    {
        if (running)
        {
            playerScript.LoadStartPosition();
            cameraScript.DisableRunningMode();
            playerTrailManagerScript.StopRunning();

            UIManagerScript.EnableToolButtons();
            UIManagerScript.EnableUnActivePlayButton();

            running = false;

            if (painting)
            {
                drawManagerScript.EnableBrushMode();
            }

            if (moving)
            {
                cameraScript.EnableMoveMode();
            }
        }

        else
        {
            playerScript.DropDown();
            cameraScript.EnableRunningMode();
            playerTrailManagerScript.StartRunning();

            UIManagerScript.DisableToolButtons();
            UIManagerScript.EnableActivePlayButton();

            drawManagerScript.DisableBrushMode();
            cameraScript.DisableMoveMode();
            running = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerTrail Controller responsible for changing opacity, color, and transform
 * through out runtime. 
 */

public class PlayerTrail : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer playerTrailImage;

    /* Note: percentage is in decimal form. For example if you pass in a float
     * value of .8f the opacity will display as 80%. 
     */
    public void ChangeOpacity(float percentage)
    {
        Color currentColor = playerTrailImage.color;
        // This changes the alpha of our current color.
        currentColor.a = percentage;
        playerTrailImage.color = currentColor;
    }

    public void ChangeRed()
    {
        playerTrailImage.color = new Color(1, 0, 0, 1);
    }

    public void ChangeGreen()
    {
        playerTrailImage.color = new Color(0, 1, 0, 1);
    }

    public void SetTransform(Transform playerPosition)
    {
        transform.position = playerPosition.position;
        transform.rotation = playerPosition.rotation;
    }
}

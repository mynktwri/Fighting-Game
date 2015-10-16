using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class LifeBar : MonoBehaviour
    {

        private float barDisplay = 0f;
        private Vector2 pos = new Vector2(20, 40);
        private Vector2 size = new Vector2(60, 20);
        private Texture2D progressBarEmpty, progressBarFull;

        private void OnGUI()
        {

            // draw the background:
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);

            // draw the filled-in part:
            GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
            GUI.EndGroup();

            GUI.EndGroup();

        }

        private void Update()
        {
            // for this example, the bar display is linked to the current time,
            // however you would set this value based on your desired display
            // eg, the loading progress, the player's health, or whatever.
            barDisplay =  Time.time * 0.05f;
        }
    }
}
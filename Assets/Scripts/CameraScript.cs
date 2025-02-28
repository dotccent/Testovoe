using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private float targetSizeX = 1920f;  // целевое разрешение экрана по X
    private float targetSizeY = 1080f;  // целевое разрешение экрана по Y

    private void Awake()
    {
        CameraResize();
    }

    private void CameraResize()  // метод для корректировки разрешения экрана
    {
        float screenRatio = (float) Screen.width / (float) Screen.height; // значение соотношения сторон текущего разрешения
        float targetRatio = targetSizeX / targetSizeY;  // значение соотношения сторон целевого разрешения

        if (screenRatio >= targetRatio)
        {
            Resize();
        }
        else 
        {
            float differentSize = targetRatio / screenRatio;
            Resize(differentSize);
        }
    }

    private void Resize(float differentSize = 1.0f)
    {
        Camera.main.orthographicSize = targetSizeY / 200 * differentSize;
    }
}

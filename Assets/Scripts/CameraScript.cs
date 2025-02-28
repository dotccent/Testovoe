using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private float targetSizeX = 1920f;  // ������� ���������� ������ �� X
    private float targetSizeY = 1080f;  // ������� ���������� ������ �� Y

    private void Awake()
    {
        CameraResize();
    }

    private void CameraResize()  // ����� ��� ������������� ���������� ������
    {
        float screenRatio = (float) Screen.width / (float) Screen.height; // �������� ����������� ������ �������� ����������
        float targetRatio = targetSizeX / targetSizeY;  // �������� ����������� ������ �������� ����������

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

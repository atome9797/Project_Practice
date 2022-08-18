using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public float rotCamXAxisSpeed = 20f; // ī�޶� x�� ȸ���ӵ�

    public float rotCamYAxisSpeed = 10f; // ī�޶� y�� ȸ���ӵ�

    private float limitMinX = -80; // ī�޶� x�� ȸ�� ���� (�ּ�)
    private float limitMaxX = 50; // ī�޶� x�� ȸ�� ���� (�ִ�)
    private float eulerAngleX;
    public float eulerAngleY;
    public GameObject _eye;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed; // ���콺 �� / �� �̵����� ī�޶� y�� ȸ��
        eulerAngleX -= mouseY * rotCamYAxisSpeed; // ���콺 �� / �Ʒ� �̵����� ī�޶� x�� ȸ��

        // ī�޶� x�� ȸ���� ��� ȸ�� ������ ����
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(0, eulerAngleY, 0);
        _eye.transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }

        if (angle > 360)
        {
            angle -= 360;
        }

        //0~ 360�� �����ֱ� ���� 
        return Mathf.Clamp(angle, min, max);
    }
}

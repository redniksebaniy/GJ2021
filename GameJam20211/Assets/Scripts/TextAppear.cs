using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    public bool existance = true; //�: ��� �������� ���������� �� ������ �� ������ ������
    public GameObject target; //�: ��� ����� ���������

    public void dissapear()
    {
        if (existance) //�: ���� �� ����
        {
            target.SetActive(false);
            existance = false; //�: ��������� ������ � ������ bool
        }
        else
        {
            target.SetActive(true);
            existance = true; //�: ���� ��� �� �������� ��� �������������
        }
    }
} //!�����! *****.SetActive(true) ������ ������ ������� � ������� � ����������, ���� �� ������� ������ �� ��������� �� ��� ��� ������� ���� ����������

//�: ������ ������� ������� � ������� ���� ����������������� ����� ������ target ������

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearFlecha : MonoBehaviour
{
    static public bool existanceF = true; //�: ��� �������� ���������� �� ������ �� ������ ������
    public GameObject target; //�: ��� ����� ���������

    void Start()
    {
        if (existanceF == false) target.SetActive(false);
    }

    public void dissapear()
    {
        if (existanceF) //�: ���� �� ����
        {
            target.SetActive(false);
            existanceF = false; //�: ��������� ������ � ������ bool
        }
        else
        {
            target.SetActive(true);
            existanceF = true; //�: ���� ��� �� �������� ��� �������������
        }
    }
} //!�����! *****.SetActive(true) ������ ������ ������� � ������� � ����������, ���� �� ������� ������ �� ��������� �� ��� ��� ������� ���� ����������

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearPenta : MonoBehaviour
{
    static public bool existanceP = true; //�: ��� �������� ���������� �� ������ �� ������ ������
    public GameObject target; //�: ��� ����� ���������

    void Start()
    {
        if (existanceP == false) target.SetActive(false);
    }

    public void dissapear()
    {
        if (existanceP) //�: ���� �� ����
        {
            target.SetActive(false);
            existanceP = false; //�: ��������� ������ � ������ bool
        }
        else
        {
            target.SetActive(true);
            existanceP = true; //�: ���� ��� �� �������� ��� �������������
        }
    }
} //!�����! *****.SetActive(true) ������ ������ ������� � ������� � ����������, ���� �� ������� ������ �� ��������� �� ��� ��� ������� ���� ����������

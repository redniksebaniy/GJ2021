using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearKnife : MonoBehaviour
{
    static public bool existanceK = true; //�: ��� �������� ���������� �� ������ �� ������ ������
    public GameObject target; //�: ��� ����� ���������

    void Start()
    {
        if (existanceK == false) target.SetActive(false);
    }

    public void dissapear()
    {
        if (existanceK) //�: ���� �� ����
        {
            target.SetActive(false);
            existanceK = false; //�: ��������� ������ � ������ bool
        }
        else
        {
            target.SetActive(true);
            existanceK = true; //�: ���� ��� �� �������� ��� �������������
        }
    }
} //!�����! *****.SetActive(true) ������ ������ ������� � ������� � ����������, ���� �� ������� ������ �� ��������� �� ��� ��� ������� ���� ����������

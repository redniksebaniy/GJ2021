using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearOuija : MonoBehaviour
{
    static public bool existanceO = true; //�: ��� �������� ���������� �� ������ �� ������ ������
    public GameObject target; //�: ��� ����� ���������

    void Start()
    {
        if (existanceO == false) target.SetActive(false);
    }

    public void dissapear()
    {
        if (existanceO) //�: ���� �� ����
        {
            target.SetActive(false);
            existanceO = false; //�: ��������� ������ � ������ bool
        }
        else
        {
            target.SetActive(true);
            existanceO = true; //�: ���� ��� �� �������� ��� �������������
        }
    }
} //!�����! *****.SetActive(true) ������ ������ ������� � ������� � ����������, ���� �� ������� ������ �� ��������� �� ��� ��� ������� ���� ����������

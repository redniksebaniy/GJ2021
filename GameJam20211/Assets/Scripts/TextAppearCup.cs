using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearCup : MonoBehaviour
{
    static public bool existanceC = true; //�: ��� �������� ���������� �� ������ �� ������ ������
    public GameObject target; //�: ��� ����� ���������

    void Start()
    {
        if (existanceC == false) target.SetActive(false);
    }

    public void dissapear()
    {
        if (existanceC) //�: ���� �� ����
        {
            target.SetActive(false);
            existanceC = false; //�: ��������� ������ � ������ bool
        }
        else
        {
            target.SetActive(true);
            existanceC = true; //�: ���� ��� �� �������� ��� �������������
        }
    }
} //!�����! *****.SetActive(true) ������ ������ ������� � ������� � ����������, ���� �� ������� ������ �� ��������� �� ��� ��� ������� ���� ����������

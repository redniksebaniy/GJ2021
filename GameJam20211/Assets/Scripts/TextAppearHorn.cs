using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearHorn : MonoBehaviour
{
    static public bool existanceH = true; //�: ��� �������� ���������� �� ������ �� ������ ������
    public GameObject target; //�: ��� ����� ���������

    void Start()
    {
        if (existanceH == false) target.SetActive(false);
    }

    public void dissapear()
    {
        if (existanceH) //�: ���� �� ����
        {
            target.SetActive(false);
            existanceH = false; //�: ��������� ������ � ������ bool
        }
        else
        {
            target.SetActive(true);
            existanceH = true; //�: ���� ��� �� �������� ��� �������������
        }
    }
} //!�����! *****.SetActive(true) ������ ������ ������� � ������� � ����������, ���� �� ������� ������ �� ��������� �� ��� ��� ������� ���� ����������

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearAlchemy : MonoBehaviour
{
    static public bool existanceA = true; //�: ��� �������� ���������� �� ������ �� ������ ������
    public GameObject target; //�: ��� ����� ���������

    void Start()
    {
        if (existanceA == false) target.SetActive(false);
    }

    public void dissapear()
    {
        if (existanceA) //�: ���� �� ����
        {
            target.SetActive(false);
            existanceA = false; //�: ��������� ������ � ������ bool
        }
        else
        {
            target.SetActive(true);
            existanceA = true; //�: ���� ��� �� �������� ��� �������������
        }
    }
} //!�����! *****.SetActive(true) ������ ������ ������� � ������� � ����������, ���� �� ������� ������ �� ��������� �� ��� ��� ������� ���� ����������

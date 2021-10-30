using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearKey : MonoBehaviour
{
    static public bool existanceKey = true; //�: ��� �������� ���������� �� ������ �� ������ ������

    [SerializeField] public GameObject target;
    [SerializeField] public GameObject targetactivate;
    [SerializeField] public GameObject targetsound;//�: ��� ����� ���������

    public AudioSource sound;

    void Start()
    {
        sound = targetsound.GetComponent<AudioSource>();
        if (existanceKey == false) target.SetActive(false);
    }

    public void dissapear()
    {
        if (existanceKey) //�: ���� �� ����
        {
            targetactivate.SetActive(true);
            sound.Play();
            target.SetActive(false);
            existanceKey = false; //�: ��������� ������ � ������ bool
        }
        else
        {
            target.SetActive(true);
            existanceKey = true; //�: ���� ��� �� �������� ��� �������������
        }
    }
} //!�����! *****.SetActive(true) ������ ������ ������� � ������� � ����������, ���� �� ������� ������ �� ��������� �� ��� ��� ������� ���� ����������

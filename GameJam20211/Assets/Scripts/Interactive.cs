using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera; //�: ������� ������ ������ � ������
    [SerializeField] private GameObject PlayerObj;

    public GameObject TextUIDown; //M: ������ UI � ������� "�� � ��������������" ������� ����.
    private PlayerMovement _playermovement; //�: ������� ��������(?) ������������ ������ � ������ ��������������
    private MouseLook _mouselook;

    private Ray _ray;
    private RaycastHit _hit;
    private float _maxDistanceRay = 3f;
    

    [SerializeField] string tag;
    bool canvas = false;
    Vector3 camPos; //�: ���������� ��� ��������� ������� ������

    private void Start()
    {
        camPos = _fpsCamera.transform.localPosition; //�: ��������� ����������� ��������� ������

        _playermovement = PlayerObj.GetComponent<PlayerMovement>(); //�: ������� ������� � ��������
        _mouselook = _fpsCamera.GetComponent<MouseLook>();
    }

    private void Update()
    {
        _ray = _fpsCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); //�: �������� ����
        TextUIDown.SetActive(false); //�: ������ ������� �����������


        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay)) //�: � ����������� �� ����, ���� ������� �����, �������� ������ ��� ����� ���
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
        else
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.white);
        Interact();
    }
    
    private void Interact()
    {
        if (_hit.transform != null)
        {
            
            tag = _hit.transform.tag;
            switch (tag)
            {
                case "Teleport":
                    {
                        TextUIDown.SetActive(true); //�: ��������� �� ������ �������������� - ������� ����������
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<Teleporter>().TimeJump();
                        }
                        break;
                    }
                case "InteractiveCanvas":
                    {
                        TextUIDown.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E)) //�: � ������ ������� ������������� ������ � ����������� ����� ��������
                        {
                            _fpsCamera.transform.position += _ray.direction * 0.75f;
                            _playermovement.setSpeed(0f);
                            _mouselook.setMouseSen(0f); //�: ���� �������� �� ���� ��-�� ����(������ �� ��������� ���� ������ ������ � �������� � ������ ������).
                            _hit.transform.GetComponent<CanvasActivate>().CanvasOn();
                        }
                        else if (Input.GetKeyUp(KeyCode.E))
                        {
                            _fpsCamera.transform.localPosition = camPos;
                            _playermovement.setSpeed(5f);
                            _mouselook.setMouseSen(200f);
                            _hit.transform.GetComponent<CanvasActivate>().CanvasOFF(); 
                        }
                        break;
                    }
                case "Interactive":
                    {
                        TextUIDown.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E)) //�: � ������ ������� ������������� ������ � ����������� ����� ��������
                        {
                            _fpsCamera.transform.position += _ray.direction * 0.75f;
                            _playermovement.setSpeed(0f);
                            _mouselook.setMouseSen(0f); //�: ���� �������� �� ���� ��-�� ����(������ �� ��������� ���� ������ ������ � �������� � ������ ������).
                        }
                        else if (Input.GetKeyUp(KeyCode.E))
                        {
                            _fpsCamera.transform.localPosition = camPos;
                            _playermovement.setSpeed(5f);
                            _mouselook.setMouseSen(200f);
                        }
                        break;
                    }
                case "Dissapear":
                    {
                        TextUIDown.SetActive(true); //�: ��������� �� ������ �������������� - ������� ����������
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppear>().dissapear(); //�: �������� ����� �������(��� ������)
                        }
                        break;
                    }
                case "Sounder":
                    {
                        if (Input.GetKeyDown(KeyCode.E)) _hit.transform.GetComponent<SoundPlay>().play();
                        break;
                    }
                default: if (Input.GetKey(KeyCode.E)) TextUIDown.SetActive(false); break;
            }
        }
        }
}

    
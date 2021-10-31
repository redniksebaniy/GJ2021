using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera; //�: ������� ������ ������ � ������
    [SerializeField] private GameObject PlayerObj;

    public GameObject TextUIDown; //M: ������ UI � ������� "�� � ��������������" ������� ����.
    private PlayerMovement _playermovement; //�: ������� ��������(?) ������������ ������ � ������ ��������������
    private MouseLook _mouselook;

    private Ray _ray;
    private RaycastHit _hit;
    public float _maxDistanceRay = 3f;

    [SerializeField] public static int inv = 0; 
    Vector3 camPos; //�: ���������� ��� ��������� ������� ������

    public static int AddItem()
    {

        inv++;
        Debug.Log(inv);
        if (inv == 8)
        {
            SceneManager.LoadScene(9);
        }
        return inv;
    }

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
            switch (_hit.transform.tag)
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
                            _playermovement.setSpeed(10f);
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
                            _playermovement.setSpeed(10f);
                            _mouselook.setMouseSen(200f);
                        }
                        break;
                    }
                case "Cup":
                    {
                        TextUIDown.SetActive(true); //�: ��������� �� ������ �������������� - ������� ����������
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearCup>().dissapear(); //�: �������� ����� �������(��� ������)
                            AddItem();
                        }

                        break;
                    }
                case "Knife":
                    {
                        TextUIDown.SetActive(true); //�: ��������� �� ������ �������������� - ������� ����������
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearKnife>().dissapear(); //�: �������� ����� �������(��� ������)
                            AddItem();
                        }

                        break;
                    }
                case "Horn":
                    {
                        TextUIDown.SetActive(true); //�: ��������� �� ������ �������������� - ������� ����������
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearHorn>().dissapear(); //�: �������� ����� �������(��� ������)
                            AddItem();
                        }

                        break;
                    }
                case "Flecha":
                    {
                        TextUIDown.SetActive(true); //�: ��������� �� ������ �������������� - ������� ����������
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearFlecha>().dissapear(); //�: �������� ����� �������(��� ������)
                            AddItem();
                        }

                        break;
                    }
                case "Penta":
                    {
                        TextUIDown.SetActive(true); //�: ��������� �� ������ �������������� - ������� ����������
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearPenta>().dissapear(); //�: �������� ����� �������(��� ������)
                            AddItem();
                        }

                        break;
                    }
                case "Alchemy":
                    {
                        TextUIDown.SetActive(true); //�: ��������� �� ������ �������������� - ������� ����������
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearAlchemy>().dissapear(); //�: �������� ����� �������(��� ������)
                            AddItem();
                        }

                        break;
                    }
                case "Ouija":
                    {
                        TextUIDown.SetActive(true); //�: ��������� �� ������ �������������� - ������� ����������
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearOuija>().dissapear(); //�: �������� ����� �������(��� ������)
                            AddItem();
                        }

                        break;

                    }
                case "Sounder":
                    {
                        TextUIDown.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E)) _hit.transform.GetComponent<SoundPlay>().play();
                        break;
                    }
                case "Key":
                    {
                        TextUIDown.SetActive(true); //�: ��������� �� ������ �������������� - ������� ����������
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearKey>().dissapear(); //�: �������� ����� �������(��� ������)
                            AddItem();
                        }
                        break;
                    }
                default: if (Input.GetKey(KeyCode.E)) TextUIDown.SetActive(false); break;
            }
        }
        }
}

    
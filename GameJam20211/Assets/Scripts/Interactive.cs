using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] GameObject PlayerObj; //������� ������ ������
    private Ray _ray;
    public GameObject target1;
    private RaycastHit _hit;

    [SerializeField] private float _maxDistanceRay;

    private PlayerMovement _playermovement;

    private MouseLook _mouselook;

    private void Start()
    {
        _playermovement = PlayerObj.GetComponent<PlayerMovement>(); //���� �������� ������ � �������, ����� ����� ���� ������� ������� set
        _mouselook = _fpsCamera.GetComponent<MouseLook>();
    }

    private void Update()
    {
        //Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.white); //����� ��� �������� ������ ����� ��� �� ���������
        Ray();
        DrawRay();
        Interact();
    }

    private void Ray()
    {
        _ray = _fpsCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue);
            if (Input.GetKeyUp(KeyCode.E)) //�������� ������ ����� ������� ���. ��������, ��������� ������� �������� ���� � �������� �������.
            {
                _fpsCamera.transform.localPosition = new Vector3(0f, 0.5f, 0f);
                _playermovement.setSpeed(12f);
                _mouselook.setmouseSen(200f);
            }
        }
    }

    private void Interact()
    {
        if(_hit.transform != null && _hit.transform.GetComponent<TV>())
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
            if(Input.GetKeyDown(KeyCode.E))
            {
                _hit.transform.GetComponent<TV>().TimeJump();
            }
        }
        else if (_hit.transform != null && _hit.transform.GetComponent<PC>())
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
            if (Input.GetKeyDown(KeyCode.E)) //� ������ ������� ������������� ������(����� �����, ������ ��� ������ _ray.direction �� ��������) � ����� �������� ������
            {
                _fpsCamera.transform.Translate(_ray.direction.z * 0.75f, _ray.direction.y * 0.75f + 0.2f, _ray.direction.x * 0.75f);
                _playermovement.setSpeed(0f);
                _mouselook.setmouseSen(10f);
            }
            else if (Input.GetKeyUp(KeyCode.E)) //��������� ������ => ���������� � �����
            {
                _fpsCamera.transform.localPosition = new Vector3(0f, 0.5f, 0f);
                _playermovement.setSpeed(12f);
                _mouselook.setmouseSen(200f);
            }
        }
    }
}

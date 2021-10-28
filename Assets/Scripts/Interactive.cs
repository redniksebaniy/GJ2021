using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    [SerializeField] GameObject PlayerObj; //находим объект игрока
    private Ray _ray;
    public GameObject target1;
    private RaycastHit _hit;

    [SerializeField] private float _maxDistanceRay;

    private PlayerMovement _playermovement;

    private MouseLook _mouselook;

    private void Start()
    {
        _playermovement = PlayerObj.GetComponent<PlayerMovement>(); //типа получаем доступ к скрипту, чтобы можно было вызвать команды set
        _mouselook = _fpsCamera.GetComponent<MouseLook>();
    }

    private void Update()
    {
        //Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.white); //Чисто для удобства сделал белый луч по умолчанию
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
            if (Input.GetKeyUp(KeyCode.E)) //Отпуская кнопку будет сделана доп. проверка, благодаря которой избегаем бага с зависшей камерой.
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
            if (Input.GetKeyDown(KeyCode.E)) //в момент нажатия телепортируем камеру(очень ебано, потому что просто _ray.direction не работает) и новые значения ставим
            {
                _fpsCamera.transform.Translate(_ray.direction.z * 0.75f, _ray.direction.y * 0.75f + 0.2f, _ray.direction.x * 0.75f);
                _playermovement.setSpeed(0f);
                _mouselook.setmouseSen(10f);
            }
            else if (Input.GetKeyUp(KeyCode.E)) //отпускаем кнопку => возвращаем в норму
            {
                _fpsCamera.transform.localPosition = new Vector3(0f, 0.5f, 0f);
                _playermovement.setSpeed(12f);
                _mouselook.setmouseSen(200f);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera; //П: находим объект камеры и игрока
    [SerializeField] private GameObject PlayerObj;

    public GameObject TextUIDown; //M: Объект UI с текстом "На Е взаимодействие" засунул сюда.
    private PlayerMovement _playermovement; //П: Объекты скриптов(?) передвижения игрока и камеры соответственно
    private MouseLook _mouselook;

    private Ray _ray;
    private RaycastHit _hit;
    private float _maxDistanceRay = 3f;

    [SerializeField] string tag;
    Vector3 camPos; //П: переменная для изменения позиции камеры

    private void Start()
    {
        camPos = _fpsCamera.transform.localPosition; //П: сохраняем изначальное положение камеры

        _playermovement = PlayerObj.GetComponent<PlayerMovement>(); //П: находим скрипты у объектов
        _mouselook = _fpsCamera.GetComponent<MouseLook>();
    }

    private void Update()
    {
        _ray = _fpsCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); //П: создание луча
        TextUIDown.SetActive(false); //М: Держим надпись выключенной

        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay)) //П: в зависимости от того, куда смотрит игрок, рисуется зелёный или белый луч
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
                        TextUIDown.SetActive(true); //М: Наводимся на объект взаимодействия - надпись появляется
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<Teleporter>().TimeJump();
                        }
                        break;
                    }
                case "Interactive":
                    {
                        TextUIDown.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E)) //П: в момент нажатия телепортируем камеру и присваиваем новые значения
                        {
                            _fpsCamera.transform.position += _ray.direction * 0.75f;
                            _playermovement.setSpeed(0f);
                            _mouselook.setMouseSen(10f);
                        }
                        break;
                    }
                case "Dissapear":
                    {
                        TextUIDown.SetActive(true); //М: Наводимся на объект взаимодействия - надпись появляется
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppear>().dissapear(); //М: вызываем метод скрипта(чек скрипт)
                        }
                        break;
                    }
                default: if (Input.GetKey(KeyCode.E)) TextUIDown.SetActive(false); break;
            }
        }
            if (Input.GetKeyUp(KeyCode.E)) //П: в момент отжатия)) кнопки всё возвращаем в норму
            {
                _fpsCamera.transform.localPosition = camPos;
                _playermovement.setSpeed(5f);
                _mouselook.setMouseSen(200f);
            }
        }
}

    
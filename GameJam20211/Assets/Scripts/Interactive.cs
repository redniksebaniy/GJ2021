using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera; //П: находим объект камеры и игрока
    [SerializeField] private GameObject PlayerObj;

    public GameObject TextUIDown; //M: Объект UI с текстом "На Е взаимодействие" засунул сюда.
    private PlayerMovement _playermovement; //П: Объекты скриптов(?) передвижения игрока и камеры соответственно
    private MouseLook _mouselook;

    private Ray _ray;
    private RaycastHit _hit;
    public float _maxDistanceRay = 3f;

    [SerializeField] public static int inv = 0; 
    Vector3 camPos; //П: переменная для изменения позиции камеры

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
            switch (_hit.transform.tag)
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
                case "InteractiveCanvas":
                    {
                        TextUIDown.SetActive(true);
                        if (Input.GetKeyDown(KeyCode.E)) //П: в момент нажатия телепортируем камеру и присваиваем новые значения
                        {
                            _fpsCamera.transform.position += _ray.direction * 0.75f;
                            _playermovement.setSpeed(0f);
                            _mouselook.setMouseSen(0f); //М: Пока поставил на ноль из-за бага(Канвас не пропадает если курсор убрать с монитора и отжать кнопку).
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
                        if (Input.GetKeyDown(KeyCode.E)) //П: в момент нажатия телепортируем камеру и присваиваем новые значения
                        {
                            _fpsCamera.transform.position += _ray.direction * 0.75f;
                            _playermovement.setSpeed(0f);
                            _mouselook.setMouseSen(0f); //М: Пока поставил на ноль из-за бага(Канвас не пропадает если курсор убрать с монитора и отжать кнопку).
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
                        TextUIDown.SetActive(true); //М: Наводимся на объект взаимодействия - надпись появляется
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearCup>().dissapear(); //М: вызываем метод скрипта(чек скрипт)
                            AddItem();
                        }

                        break;
                    }
                case "Knife":
                    {
                        TextUIDown.SetActive(true); //М: Наводимся на объект взаимодействия - надпись появляется
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearKnife>().dissapear(); //М: вызываем метод скрипта(чек скрипт)
                            AddItem();
                        }

                        break;
                    }
                case "Horn":
                    {
                        TextUIDown.SetActive(true); //М: Наводимся на объект взаимодействия - надпись появляется
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearHorn>().dissapear(); //М: вызываем метод скрипта(чек скрипт)
                            AddItem();
                        }

                        break;
                    }
                case "Flecha":
                    {
                        TextUIDown.SetActive(true); //М: Наводимся на объект взаимодействия - надпись появляется
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearFlecha>().dissapear(); //М: вызываем метод скрипта(чек скрипт)
                            AddItem();
                        }

                        break;
                    }
                case "Penta":
                    {
                        TextUIDown.SetActive(true); //М: Наводимся на объект взаимодействия - надпись появляется
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearPenta>().dissapear(); //М: вызываем метод скрипта(чек скрипт)
                            AddItem();
                        }

                        break;
                    }
                case "Alchemy":
                    {
                        TextUIDown.SetActive(true); //М: Наводимся на объект взаимодействия - надпись появляется
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearAlchemy>().dissapear(); //М: вызываем метод скрипта(чек скрипт)
                            AddItem();
                        }

                        break;
                    }
                case "Ouija":
                    {
                        TextUIDown.SetActive(true); //М: Наводимся на объект взаимодействия - надпись появляется
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearOuija>().dissapear(); //М: вызываем метод скрипта(чек скрипт)
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
                        TextUIDown.SetActive(true); //М: Наводимся на объект взаимодействия - надпись появляется
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _hit.transform.GetComponent<TextAppearKey>().dissapear(); //М: вызываем метод скрипта(чек скрипт)
                            AddItem();
                        }
                        break;
                    }
                default: if (Input.GetKey(KeyCode.E)) TextUIDown.SetActive(false); break;
            }
        }
        }
}

    
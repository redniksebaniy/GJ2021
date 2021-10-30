using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppearKey : MonoBehaviour
{
    static public bool existanceKey = true; //М: Тут помечаем существует ли объект на данный момент

    [SerializeField] public GameObject target;
    [SerializeField] public GameObject targetactivate;
    [SerializeField] public GameObject targetsound;//М: Что будет пропадать

    public AudioSource sound;

    void Start()
    {
        sound = targetsound.GetComponent<AudioSource>();
        if (existanceKey == false) target.SetActive(false);
    }

    public void dissapear()
    {
        if (existanceKey) //М: Если он есть
        {
            targetactivate.SetActive(true);
            sound.Play();
            target.SetActive(false);
            existanceKey = false; //М: Выключаем объект и меняем bool
        }
        else
        {
            target.SetActive(true);
            existanceKey = true; //М: Если нет то включаем его соответсвенно
        }
    }
} //!ВАЖНО! *****.SetActive(true) просто ставит галочку у объекта в инспекторе, если мы вырубим объект со скриптами то все его скрипты тоже рубануться

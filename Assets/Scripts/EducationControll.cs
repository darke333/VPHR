using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class EducationControll : MonoBehaviour
{
    public PumpWork Pumper;
    public float time;
    public int temperature;
    public GameObject[] Heated;
    public GameObject[] PumpTriggers;
    public TextMeshPro TMPMiddle;
    public TextMeshPro TMPLeft;
    public TextMeshPro TMPRight;
    public int index;
    public bool HeaterIn;
    public bool HeatedIn;
    public bool PumpOut;
    bool Heat;
    bool FullHeated;
    public bool NeedleIn;
    public bool AmpulPrepeared;
    public bool AmpulInserted;
    public int countTimes;
    public bool END;
    public int DangerLevel;
    public int ReleasedAmpuls;
    public int HeatedInCount; // смотрит, сколько ампул вставили в нагревательную трубку. Сделано для подсчета красныз ампул
    //bool[] Choise;

    // Start is called before the first frame update
    void Start()
    {
        ReleasedAmpuls = 0; 
        END = false;
        Pumper.enabled = false;
        AmpulInserted = false;
        AmpulPrepeared = false;
        PumpOut = false;
        NeedleIn = false;
        Heat = false;
        HeatedIn = false;
        HeaterIn = false;
        FullHeated = false;
        ChoseGaz();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("RightEnd"))
        {
            obj.GetComponent<Collider>().enabled = false;
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("LeftEnd"))
        {
            obj.GetComponent<Collider>().enabled = false;
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul1"))
        {
            obj.GetComponent<Collider>().enabled = false;
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul2"))
        {
            obj.GetComponent<Collider>().enabled = false;
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul3"))
        {
            obj.GetComponent<Collider>().enabled = false;
        }
        ActivateTriggers();
    }

    public void CountHeatedAmpuls(int change)
    {
        HeatedInCount += change;

        if (index == 1 || index == 4 || index == 7)
        {
            if(HeatedInCount == 2)
            {
                HeatedIn = true;

            }
            else
            {
                HeatedIn = false;
            }
        }
        if (index == 2 || index == 5 || index == 8)
        {
            if (HeatedInCount == 1)
            {
                HeatedIn = true;

            }
            else
            {
                HeatedIn = false;
            }
        }
        if (index == 3 || index == 6 || index == 9)
        {
            if (HeatedInCount == 1)
            {
                HeatedIn = true;

            }
            else
            {
                HeatedIn = false;
            }
        }
    }

    void ActivateTriggers()
    {
        if (index == 1 || index == 4 || index == 7)
        {
            Heated[1].SetActive(false);
            Heated[2].SetActive(false);
            PumpTriggers[1].SetActive(false);
            PumpTriggers[2].SetActive(false);

        }
        if (index == 2 || index == 5 || index == 8)
        {
            Heated[0].SetActive(false);
            Heated[2].SetActive(false);
            Heated[3].SetActive(false);
            PumpTriggers[0].SetActive(false);
            PumpTriggers[2].SetActive(false);
        }
        if (index == 3 || index == 6 || index == 9)
        {
            Heated[0].SetActive(false);
            Heated[1].SetActive(false);
            Heated[3].SetActive(false);
            PumpTriggers[0].SetActive(false);
            PumpTriggers[1].SetActive(false);
        }
    }

    public void ChoseGaz()
    {
        index = Random.Range(1, 9);
        //index = 1;
        DangerLevel = Random.Range(1, 100) % 4;
    }

    void StartTask()
    {
        string s = "";
        if (index == 1 || index == 4 || index == 7)
        {
            s = "зарина, зомана и V-газов";
        }
        if (index == 2 || index == 5 || index == 8)
        {
            s = "фосгена, дифосгена, синильной кислоты и хлорциана";
        }
        if (index == 3 || index == 6|| index == 9)
        {
            s = "иприта";
        }
        TMPLeft.text = "Задание: определить наличие " + s + " в воздухе";
    }

    void StartTemp()
    {
        string l = "";
        if (index == 1 || index == 4 || index == 7)
        {
            l = " > 0";
        }
        if (index == 2 || index == 5 || index == 8)
        {
            l = " > - 10 (Условно не замерзшее)";
        }
        if (index == 3 || index == 6 || index == 9)
        {
            l = "> 10";
        }
        temperature = Random.Range(-20, +10);
        string s = temperature.ToString();
        TMPRight.text = "Температура: " + s + "\n" + "Необходимая температура: " + l;
        time = -1000000;
    }

    void StartText()
    {
        string s = "";
        if (index == 1 || index == 4 || index == 7)
        {
            s = "(красные)";
        }
        if (index == 2 || index == 5 || index == 8)
        {
            s = "(зеленые)";
        }
        if (index == 3 || index == 6 || index == 9)
        {
            s = "(желтые)";
        }
        TMPMiddle.text = "Извлеките пакет с нужными ампулами " + s;
    }

    public void AmpulPackReleased(int i)
    {
        if (index == 1 || index == 4 || index == 7)
        {
            if (i == 0)
            {
                TMPMiddle.text = "Извлеките две ампулы";
            }
        }
        if (index == 2 || index == 5 || index == 8)
        {
            if (i == 2)
            {
                TMPMiddle.text = "Извлеките ампулу";
            }
        }
        if (index == 3 || index == 6 || index == 9)
        {
            if (i == 1)
            {
                TMPMiddle.text = "Извлеките ампулу";
            }
        }
    }

    public void AmpulReleaseCount(int colorNumber)
    {        
        if ((index == 1 || index == 4 || index == 7) && colorNumber ==3 )
        {
            ReleasedAmpuls++;
            if (ReleasedAmpuls == 2)
            {
                AmpulFreeText();
            }
        }
        if ((index == 2 || index == 5 || index == 8) && colorNumber == 1)
        {
            ReleasedAmpuls++;
            if (ReleasedAmpuls == 1)
            {
                AmpulFreeText();
            }
        }
        if ((index == 3 || index == 6 || index == 9) && colorNumber == 2)
        {
            ReleasedAmpuls++;
            if (ReleasedAmpuls == 1)
            {
                AmpulFreeText();
            }
        }
    }

    public void EndPushedTracker()
    {
        if ((index == 1 || index == 4 || index == 7))
        {
            int i = 0;
            bool EndPushed = false;
            foreach(GameObject ampul in GameObject.FindGameObjectsWithTag("Ampul3"))
            {
                AmpulAtributs atributs = ampul.GetComponent<AmpulAtributs>();
                if (atributs.EndRemoved >= 2)
                {
                    i++;
                }
                if (atributs.EndPinned)
                {
                    EndPushed = true;
                }
            }
            if (i == 2 && EndPushed)
            {
                AmpulPrepeared = true;
            }
        }
        if ((index == 2 || index == 5 || index == 8))
        {
            bool EndPushed = false;
            foreach (GameObject ampul in GameObject.FindGameObjectsWithTag("Ampul1"))
            {
                AmpulAtributs atributs = ampul.GetComponent<AmpulAtributs>();
                if (atributs.EndPinned)
                {
                    EndPushed = true;
                }
            }
            if (EndPushed)
            {
                AmpulPrepeared = true;
            }
        }
        if ((index == 3 || index == 6 || index == 9))
        {

            int i = 0;
            foreach (GameObject ampul in GameObject.FindGameObjectsWithTag("Ampul2"))
            {
                AmpulAtributs atributs = ampul.GetComponent<AmpulAtributs>();
                if (atributs.EndRemoved == 2)
                {
                    i++;
                }
            }
            if (i == 1)
            {
                AmpulPrepeared = true;
            }
        }
    }

    

    public void AmpulFreeText()
    {
        if (index == 1 || index == 4 || index == 7)
        {
            if (temperature < 0)
            {
                Heat = true;
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul3"))
                {
                    obj.GetComponent<AmpulAtributs>().Heated = false;
                }
            }
            else
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul3"))
                {
                    obj.GetComponent<AmpulAtributs>().Heated = true;

                }
                Heated[1].SetActive(false);
                Heated[2].SetActive(false);
                Heated[0].SetActive(false);
                FullHeated = true;
                if (!PumpOut)
                {
                    ReleasePump();
                }
            }

        }
        if (index == 2 || index == 5 || index == 8)
        {
            if (temperature < -10)
            {
                Heat = true;
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul1"))
                {
                    obj.GetComponent<AmpulAtributs>().Heated = false;
                }
            }
            else
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul1"))
                {
                    obj.GetComponent<AmpulAtributs>().Heated = true;
                }
                Heated[1].SetActive(false);
                Heated[2].SetActive(false);
                Heated[0].SetActive(false);
                FullHeated = true;

                if (!PumpOut)
                {
                    ReleasePump();
                }
            }
        }
        if (index == 3 || index == 6 || index == 9)
        {
            if (temperature < 10)
            {
                Heat = true;
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul2"))
                {
                    obj.GetComponent<AmpulAtributs>().Heated = false;
                }

            }
            else
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Ampul2"))
                {
                    obj.GetComponent<AmpulAtributs>().Heated = true;
                }
                Heated[1].SetActive(false);
                Heated[2].SetActive(false);
                Heated[0].SetActive(false);
                FullHeated = true;

                if (!PumpOut)
                {
                    ReleasePump();
                }
            }

        }
    }

    void UpTemp()
    {
        TMPMiddle.text = "Температура слишком низкая. Вставьте нужную ампулу и нагреватель (металлический цилиндр) в гарелку (черное цилиндрическое устройство с иглой)";
    }



    void NeedleAction()
    {
        TMPMiddle.text = "Проткните нагреватель иглой";
    }

    void ReleasePump()
    {        
        TMPMiddle.text = "Отодвиньте фиксатор насоса";
    }


    void PrepeareAmpul()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EndAmpulTrigger"))
        {
            obj.GetComponent<Heater_V2>().enabled = false;
        }
        string s = "";
        if (index == 1 || index == 4 || index == 7)
        {
            s = " и проткните ближнюю к индикатору сторону одной (опытной) ампулы (маркированные цветом ампулы отверстия с белой стороны насоса)" ;
            TMPMiddle.text = "Отделите концы обоих апул (маленькие круглые отверстия с черного конца насоса)" + "\n"  + s;
        }
        if (index == 2 || index == 5 || index == 8)
        {
            s = " и проткните противоположную от индикатора сторону ампулы  (маркированные цветом ампулы отверстия с белой стороны насоса)";
            TMPMiddle.text = "Отделите концы апул (маленькие круглые отверстия с черного конца насоса)" + "\n"  + s;
        }
        if (index == 3 || index == 6 || index == 9)
        {
            TMPMiddle.text = "Отделите концы апул (маленькие круглые отверстия с черного конца насоса)";
        }
    }
    
    void PumpInsert()
    {
        TMPMiddle.text = "Вставьте ампулу в насос";
    }

    void EndFunc()
    {
        string s = "";
        if (index == 1 || index == 4 || index == 7)
        {
            switch (DangerLevel)
            {
                case 0:
                    s = "В воздухе опасных концентраций зарина, зомана или V-газов НЕ обнаружено (обратите внимание на цвет наполнителя, он стал желтого цвета)";
                    s += "\n" + "Будем считать, что тестовая (вскрытая ампула без прокачки) окрасилась в желтый";
                    break;
                case 1:
                    s = "В воздухе обнаружены опасные концентраций зарина, зомана или V-газов  (обратите внимание на цвет наполнителя, он стал красного цвета)";
                    s += "\n" + "Будем считать, что тестовая (вскрытая ампула без прокачки) окрасилась в желтый";

                    break;
                case 2:
                    s = "В воздухе обнаружены опасные концентраций зарина, зомана или V-газов  (обратите внимание на цвет наполнителя, он стал красного цвета)";
                    s += "\n" + "Будем считать, что тестовая (вскрытая ампула без прокачки) окрасилась в желтый";

                    break;
                case 3:
                    s = "В воздухе обнаружены опасные концентраций зарина, зомана или V-газов  (обратите внимание на цвет наполнителя, он стал красного цвета)";
                    s += "\n" + "Будем считать, что тестовая (вскрытая ампула без прокачки) окрасилась в желтый";
                    break;
            }
        }
        if (index == 2 || index == 5 || index == 8)
        {
            switch (DangerLevel)
            {
                case 0:
                    s = "В воздухе опасных концентраций фосгена, дифосгена, синильной кислоты или хлорциана НЕ обнаружено (обратите внимание на цвет наполнителя, он остался белого цвета)";
                    break;
                case 1:
                    s = "В воздухе обнаружены опасные концентраций фосгена, дифосгена, синильной кислоты или хлорциана (обратите внимание на цвет наполнителя, он немного окрасился в синий)";

                    break;
                case 2:
                    s = "В воздухе обнаружены очень опасные концентраций фосгена, дифосгена, синильной кислоты или хлорциана (обратите внимание на цвет наполнителя, он окрасился в синий на половину)";

                    break;
                case 3:
                    s = "В воздухе обнаружены смертельные концентраций фосгена, дифосгена, синильной кислоты или хлорциана (обратите внимание на цвет наполнителя, он полностью окрасился в синий)";
                    break;
            }
        }
        if (index == 3 || index == 6 || index == 9)
        {
            switch (DangerLevel)
            {
                case 0:
                    s = "В воздухе опасных концентраций иприта НЕ обнаружено (обратите внимание на цвет наполнителя, он остался желтого цвета)";
                    break;
                case 1:
                    s = "В воздухе обнаружены опасные концентраций иприта (обратите внимание на цвет наполнителя, он немного окрасился в красный)";

                    break;
                case 2:
                    s = "В воздухе обнаружены очень опасные концентраций иприта (обратите внимание на цвет наполнителя, он окрасился в красный на половину)";

                    break;
                case 3:
                    s = "В воздухе обнаружены смертельные концентраций иприта (обратите внимание на цвет наполнителя, он полностью окрасился в красный цветы)";
                    break;
            }
        }
        TMPMiddle.text = s;
    }

    void PumpAction()
    {
        string s = "";
        if (index == 1 || index == 4 || index == 7)
        {
            countTimes = 7;
            s = "Cовершите  6-8 покачиваний (для простоты количество покачиваний уменьшено в 5 раз) ";
        }
        if (index == 2 || index == 5 || index == 8)
        {
            s = "Cовершите  2-3 покачиваний (для простоты количество покачиваний уменьшено в 5 раз) ";
            countTimes = 3;
        }
        if (index == 3 || index == 6 || index == 9)
        {
            s = "Cовершите  12 покачиваний (для простоты количество покачиваний уменьшено в 5 раз) ";
            countTimes = 12;
        }
        TMPMiddle.text = s;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (END)
        {
            EndFunc();
        }
        else
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                StartTask();
                StartTemp();
                StartText();
            }
            if (Heat)
            {
                if (HeaterIn && HeatedIn)
                {
                    if (NeedleIn)
                    {
                        if (!PumpOut)
                        {
                            ReleasePump();
                        }
                        Heat = false;
                        FullHeated = true;

                    }
                    else
                    {
                        NeedleAction();
                    }
                }
                else
                {
                    UpTemp();
                }
            }
            if (AmpulInserted)
            {
                PumpAction();
            }
            else
            {
                if (AmpulPrepeared)
                {
                    PumpInsert();
                }
                else
                {
                    if (FullHeated && PumpOut)
                    {
                        PrepeareAmpul();
                    }
                }
            }
        }

     

    }
}

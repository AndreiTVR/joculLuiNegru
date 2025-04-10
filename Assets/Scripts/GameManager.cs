using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Enemy[] enemies;
    public Player player;
    [SerializeField]GameObject[] selectDiffMenu;
    [SerializeField]GameObject[] questionMenu;
    public Question[] easyQuestions;
    public Question[] mediumQuestions;
    public Question[] hardQuestions;
    int currentLevel = 0;
    int currentDiff;
    int question;
    [SerializeField] Transform enemySpawnPoint;
    private void Start()
    {
        //instantiaza primul inamic si te lasa sa alegi dificultatea pt prima intrebare
        Instantiate(enemies[currentLevel],enemySpawnPoint);
        for(int i=0; i<selectDiffMenu.Length; i++)
        selectDiffMenu[i].SetActive(true);
        //Butonul pe care il vei alege va chema una din cele 3 metode de mai jos
        for(int i=0; i<questionMenu.Length; i++)
        questionMenu[i].SetActive(false);
    }
    public void LoadEasyQuestion()
    {
        //Modificam fiecare text/buton din meniu si il facem vizibil, acelasi lucru se intampla si pt medium, si pt hard
        currentDiff = 1;
        question = Random.Range(0, easyQuestions.Length);
        questionMenu[0].GetComponent<TextMeshProUGUI>().text = easyQuestions[question].question;
        questionMenu[1].GetComponent<TextMeshProUGUI>().text = easyQuestions[question].answerA;
        questionMenu[2].GetComponent<TextMeshProUGUI>().text = easyQuestions[question].answerB;
        questionMenu[3].GetComponent<TextMeshProUGUI>().text = easyQuestions[question].answerC;
        questionMenu[4].GetComponent<TextMeshProUGUI>().text = easyQuestions[question].answerD;
        for (int i = 0; i < selectDiffMenu.Length; i++)
            selectDiffMenu[i].SetActive(false);
        for (int i = 0; i < questionMenu.Length; i++)
            questionMenu[i].SetActive(true);
    }
    public void LoadMediumQuestion()
    {
        currentDiff = 2;
        question = Random.Range(0, mediumQuestions.Length);
        questionMenu[0].GetComponent<TextMeshProUGUI>().text = mediumQuestions[question].question;
        questionMenu[1].GetComponent<TextMeshProUGUI>().text = mediumQuestions[question].answerA;
        questionMenu[2].GetComponent<TextMeshProUGUI>().text = mediumQuestions[question].answerB;
        questionMenu[3].GetComponent<TextMeshProUGUI>().text = mediumQuestions[question].answerC;
        questionMenu[4].GetComponent<TextMeshProUGUI>().text = mediumQuestions[question].answerD;
        for (int i = 0; i < selectDiffMenu.Length; i++)
            selectDiffMenu[i].SetActive(false);
        for (int i = 0; i < questionMenu.Length; i++)
            questionMenu[i].SetActive(true);
    }
    public void LoadHardQuestion()
    {
        currentDiff = 3;
        question = Random.Range(0, hardQuestions.Length);
        questionMenu[0].GetComponent<TextMeshProUGUI>().text = hardQuestions[question].question;
        questionMenu[1].GetComponent<TextMeshProUGUI>().text = hardQuestions[question].answerA;
        questionMenu[2].GetComponent<TextMeshProUGUI>().text = hardQuestions[question].answerB;
        questionMenu[3].GetComponent<TextMeshProUGUI>().text = hardQuestions[question].answerC;
        questionMenu[4].GetComponent<TextMeshProUGUI>().text = hardQuestions[question].answerD;
        for (int i = 0; i < selectDiffMenu.Length; i++)
            selectDiffMenu[i].SetActive(false);
        for (int i = 0; i < questionMenu.Length; i++)
            questionMenu[i].SetActive(true);
    }
    public void CheckAnswer(string answer)
    {
        //verificam dificultatea pe care ne aflam si vedem daca am ales raspunsul corect
        //aceasta metoda va fi chemata doar la apasare de buton, FOARTE IMPORTANT! VARIABILA CORRECT ANSWER SI PARAMETRUL DE ANSWER DIN FIECARE
        //BUTON VA FI A,B,C SAU D, NIMIC ALTCEVA.
        if (currentDiff == 1)
            if (answer == easyQuestions[question].correctAnswer)
            {
                enemies[currentLevel].health -= 1;
            }
            else player.health -= 1;
        else if (currentDiff == 2)
            if (answer == mediumQuestions[question].correctAnswer)
                enemies[currentLevel].health -= 2;
            else player.health -= 2;
        else if (currentDiff == 3)
            if (answer == hardQuestions[question].correctAnswer)
                enemies[currentLevel].health -= 3;
            else player.health -= 3;
        if (enemies[currentLevel].health <= 0) KillEnemy();
        else if (player.health <= 0) Debug.Log("Negrule, aicea te las pe tine sa alegi cum vrei sa se piarda");
        for (int i = 0; i < questionMenu.Length; i++)
            questionMenu[i].SetActive(false);
        for (int i = 0; i < selectDiffMenu.Length; i++)
            selectDiffMenu[i].SetActive(true);

    }

    void KillEnemy()
    {
        Destroy(enemies[currentLevel]);
        currentLevel++;
        Instantiate(enemies[currentLevel], enemySpawnPoint);
    }
}

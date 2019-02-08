using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIClassroom : MonoBehaviour
{

    [SerializeField]
    GameObject Canvas;
    [SerializeField]
    GameObject UIControlls;
    string part1;
    string part2;
    string part3;
    string part4;
    string part5;
    string part6;
    string part7;
    int textCount = 0;
    [SerializeField]
    Text TeacherText;
    [SerializeField]
    GameObject secondTime;




    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().finishedMines)
        {
            secondTime.SetActive(true);
            textCount = 4;
        }

        part1 = "Hello kid";
        part2 = "I see you're the only one today";
        part3 = "Some children work at the mines, I would love to teach them things here at school";
        part4 = "You seem special!";
        part5 = "You found them";
        part6 = "Thanks for bringing them back to class";
        part7 = "Now try out the new stuff you learned";
        TeacherText.text = part1;
    }

    void StartUI()
    {
        Canvas.SetActive(true);
        UIControlls.SetActive(false);
    }

    public void UpdateText()
    {
        textCount++;
        switch (textCount)
        {
            case 1:
                TeacherText.text = part2;
                break;
            case 2:
                TeacherText.text = part3;
                break;
            case 3:
                TeacherText.text = part4;
                break;
            case 4:
                SceneManager.LoadScene("FirstMineLevel");
                break;
            case 5:
                TeacherText.text = part5;
                break;
            case 6:
                TeacherText.text = part6;
                break;
            case 7:
                TeacherText.text = part7;
                break;
            case 8:
                SceneManager.LoadScene("SchoolLevel1");
                break;
            default:
                break;
       }
    }

}

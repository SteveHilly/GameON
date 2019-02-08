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
    int textCount = 0;
    [SerializeField]
    Text TeacherText;




    private void Start()
    {
        part1 = "Hello kid";
        part2 = "I see you're the only one today";
        part3 = "Some children work at the mines, I would love to teach them things here at school";
        part4 = "You seem special!";
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
            default:
                break;
       }
    }

}

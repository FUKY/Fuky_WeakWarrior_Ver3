using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSkillController : MonoBehaviour {
    public Image coolDown;
    private bool coolingDown;
    public float waitTime;

    private PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        coolDown.fillAmount = 0f;
    }

    void Update()
    {
        if (player.skillIsOn == false)
        {
            coolDown.fillAmount += 1.0f / waitTime * Time.deltaTime;
        }
        else  //Click button -> reset fillAmount
        {
            coolDown.fillAmount = 0f;
            player.skillIsOn = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightPlayerController : MonoBehaviour
{
    private int monsterHitPoints;
    private int monsterArmor;
    private int playerHitPoints;
    private int playerArmor;
    private int monsterDamage;
    private int playerDamage;

    public TextMeshProUGUI mHitPoints;
    public TextMeshProUGUI pHitPoints;
    public TextMeshProUGUI mArmor;
    public TextMeshProUGUI pArmor;
    public TextMeshProUGUI mDamage;
    public TextMeshProUGUI pDamage;
    

    // Start is called before the first frame update
    void Start()
    {
        monsterArmor = Random.Range(10, 18);
        playerArmor = Random.Range(10, 18);
        monsterHitPoints = Random.Range(10, 21);
        playerHitPoints = Random.Range(10, 21);
        playerDamage = Random.Range(1, 6);
        monsterDamage = Random.Range(1, 6);

        mHitPoints.text = "Monster Hit Points: " + monsterHitPoints.ToString();
        pHitPoints.text = "Player Hit Points: " + playerHitPoints.ToString();
        mArmor.text = "Monster Armor: " + monsterArmor.ToString();
        pArmor.text = "Player Armor: " + playerArmor.ToString();
        pDamage.text = "Player Damage: " + playerDamage.ToString();
        mDamage.text = "Monster Damage: " + monsterDamage.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

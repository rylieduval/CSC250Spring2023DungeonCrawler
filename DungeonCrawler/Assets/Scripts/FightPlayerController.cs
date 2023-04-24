using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FightPlayerController : MonoBehaviour
{
    private int monsterHitPoints;
    private int monsterArmor;
    private int playerHitPoints;
    private int playerArmor;
    private int monsterDamage;
    private int playerDamage;
    private int D20Roll;

    public TextMeshProUGUI mHitPoints;
    public TextMeshProUGUI pHitPoints;
    public TextMeshProUGUI mArmor;
    public TextMeshProUGUI pArmor;
    public TextMeshProUGUI mDamage;
    public TextMeshProUGUI pDamage;
    public TextMeshProUGUI PWinText;

    public bool hitStarting = false;
    public bool isAHit = false;
    public bool canMove = true;
    public bool monsterMove = false;

    private Rigidbody rb;


    public GameObject opponent;
    public GameObject monsterStartingSpot;



    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();

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
        if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove == true && monsterMove == false)
        {
            canMove = false;
            D20Roll = Random.Range(1, 21);

            this.rb.AddForce(Vector3.left * 400);

            if (D20Roll >= monsterArmor)
            {
                print("HIT");
                isAHit = true;

            }
            else
            {
                print("MISS");
            }
        }

        if (monsterMove == true)
        {
            opponent.transform.position = this.rb.transform.position;

            D20Roll = Random.Range(1, 21);

            if (D20Roll >= playerArmor)
            {
                print("MONSTER SMASH");
                monsterMove = false;
                playerHitPoints = playerHitPoints - monsterDamage;
                pHitPoints.text = "Player Hit Points: " + playerHitPoints.ToString();
            }
            else
            {
                print("MISS");
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster") && monsterMove == false)
        {
            hitStarting = true;
            this.rb.velocity = Vector3.right * 10;

            if (isAHit == true)
            {
                monsterHitPoints = monsterHitPoints - playerDamage;

                mHitPoints.text = "Monster Hit Points: " + monsterHitPoints.ToString();

                isAHit = false;
            }
            if (monsterHitPoints <= 0)
            {
                monsterHitPoints = 0;
                mHitPoints.text = "Monster Hit Points: " + monsterHitPoints.ToString();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PSS") && hitStarting == true)
        {
            canMove = true;
            this.rb.velocity = Vector3.zero;
            this.rb.Sleep();

            hitStarting = false;

            if (monsterHitPoints <= 0)
            {
                PWinText.text = "PLAYER WINS!";
                
            }

            monsterMove = true;
           
        }
    }
}

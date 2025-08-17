using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoulManager : MonoBehaviour
{
    [SerializeField]
    private PlayerResource playerResource;
    [SerializeField]
    private PlayerAction playerAction;
    [SerializeField]
    private PlayerUIManager playerUIManager;

    private int maxHP;
    private float attackDamage;
    private float defenseDamage;
    private float attackSpeed;
    private float speed;
    private float jumpForce;
    private float cooldown;
    private int maxPotion;

    [SerializeField]
    private TMP_Text[] skillPointCountText;
    [SerializeField]
    private Image[] skillimages;
    private int[] skillPointMax;
    private int[] skillPointCount;
    private int skillNumber;

    [SerializeField]
    private TMP_Text statusMaxHP;
    [SerializeField]
    private TMP_Text statusAttackDanmage;
    [SerializeField]
    private TMP_Text statusDefenseDamage;
    [SerializeField]
    private TMP_Text statusAttackSpeed;
    [SerializeField]
    private TMP_Text statusSpeed;
    [SerializeField]
    private TMP_Text statusJumpPower;
    [SerializeField]
    private TMP_Text statusSkillCool;
    [SerializeField]
    private TMP_Text statusMaxPotion;

    [SerializeField]
    private TMP_Text Soul;

    private void Start()
    {
        //GameManager.Instance.Soul += 500;
        skillPointMax = new int[18] {5,5,1,5,5,1,5,5,5,5,1,5,5,5,5,3,5,5};
        skillPointCount = new int[18];
        UpdateSoulCount();
        UpdateStatusMaxHP();
        UpdateStatusAttack();
        UpdateStatusDefense();
        UpdateStatusAttackSpeed();
        UpdateStatusSpeed();
        UpdateStatusJumpPower();
        UpdateStatusSkillCool();
        UpdateStatusMaxPotion();
    }

    public void UpdateSoulCount()
    {
        Debug.Log("소울 최신화");
        Soul.text = $"{GameManager.Instance.Soul}";
    }

    public bool UseSoul(int value) 
    {
        int soulCount = GameManager.Instance.Soul;
        GameManager.Instance.Soul -= value;
        if (GameManager.Instance.Soul == soulCount)
        {
            Debug.Log("소울이 부족하여 사용에 실패했습니다.");
            return false;
        }
        UpdateSoulCount();
        return true;
    }
    void UpdateStatusMaxHP()
    {
        maxHP = playerResource.FindMaxHP();
        playerAction.maxHP = maxHP;
        statusMaxHP.text = maxHP.ToString();
    }

    void UpdateStatusAttack()
    {
        attackDamage = playerResource.FindAttackDamage();
        playerAction.attackDamage = attackDamage;
        statusAttackDanmage.text = attackDamage.ToString();
    }
    void UpdateStatusDefense()
    {
        defenseDamage = playerResource.FindDefenseDamage();
        playerAction.defenseDamage = defenseDamage;
        statusDefenseDamage.text = defenseDamage.ToString();
    }

    void UpdateStatusAttackSpeed()
    {
        attackSpeed = playerResource.FindAttackSpeed();
        playerAction.attactSpeed = attackSpeed;
        statusAttackSpeed.text = $"{attackSpeed:F1}/s";
    }

    void UpdateStatusSpeed()
    {
        speed = playerResource.FindSpeed();
        playerAction.speed = speed;
        statusSpeed.text = speed.ToString();
    }

    void UpdateStatusJumpPower()
    {
        jumpForce = playerResource.FindJumpForce();
        playerAction.jumpForce = jumpForce;
        statusJumpPower.text = jumpForce.ToString();
    }

    void UpdateStatusSkillCool()
    {
        cooldown = playerResource.FindCoolDown();
        playerAction.cooldown = cooldown;
        cooldown = cooldown * 100;
        statusSkillCool.text = $"{cooldown}%";
    }

    void UpdateStatusMaxPotion()
    {
        maxPotion = playerResource.FindMaxPotion();
        playerAction.maxPotion = maxPotion;
        statusMaxPotion.text = $"{maxPotion}";
    }

    void UpStatusMaxHP(int value)
    {
        maxHP = playerResource.UpMaxHp(value);
        playerAction.currentHP = playerAction.currentHP + value;
        playerUIManager.InitHPUI(maxHP, playerAction.currentHP);
        UpdateStatusMaxHP();
    }
    
    void UpStatusAttack(float value)
    {
        attackDamage = playerResource.UpAttackDamage(value);
        UpdateStatusAttack();
    }

    void UpStatusDefense(float value)
    {
        defenseDamage = playerResource.UpDefenseDamage(value);
        UpdateStatusDefense();
    }

    void UpStatusAttackSpeed(float value)
    {
        attackSpeed = playerResource.UpAttackSpeed(value);
        UpdateStatusAttackSpeed();
    }

    void UpStatusSpeed(float value)
    {
        speed = playerResource.UpSpeed(value);
        UpdateStatusSpeed();
    }

    void UpStatusJumpPower(float value)
    {
        jumpForce = playerResource.UpJumpForce(value);
        UpdateStatusJumpPower();
    }

    void UpStatusSkillCool(float value)
    {
        cooldown = playerResource.UpCoolDown(value);
        UpdateStatusSkillCool();
    }

    void UpStatusMaxPotion(int value)
    {
        maxPotion = playerResource.UpMaxPotion(value);
        UpdateStatusMaxPotion();
    }
    public void skill1()
    {
        skillNumber = 0;

        if (skillPointMax[skillNumber] > skillPointCount[skillNumber])
        {
            bool haveSoul = UseSoul(15);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusAttack(2f);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
    }
    public void skill2()
    {
        skillNumber = 1;
        if (skillPointMax[skillNumber] > skillPointCount[skillNumber] && skillPointCount[skillNumber-1] >= 3)
        {
            bool haveSoul = UseSoul(20);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusAttackSpeed(0.1f);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
        else if (skillPointCount[skillNumber - 1] < 3)
        {
            Debug.Log("아직 찍을 수 없는 스킬입니다.");
        }
    }

    public void skill3()
    {
        skillNumber = 2;

        if (skillPointMax[skillNumber] > skillPointCount[skillNumber] && skillPointCount[skillNumber - 1] >= 5 && skillPointCount[skillNumber - 2] >= 5)
        {
            bool haveSoul = UseSoul(50);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusAttack(5);
            UpStatusAttackSpeed(0.5f);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
        else
        {
            Debug.Log("아직 찍을 수 없는 스킬입니다.");
        }
    }

    public void skill4()
    {
        skillNumber = 3;

        if (skillPointMax[skillNumber] > skillPointCount[skillNumber])
        {
            bool haveSoul = UseSoul(15);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255,255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusMaxHP(10);
        }else if(skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
    }

    public void skill5()
    {
        skillNumber = 4;
        if (skillPointMax[skillNumber] > skillPointCount[skillNumber] && skillPointCount[skillNumber - 1] >= 3)
        {
            bool haveSoul = UseSoul(20);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusDefense(1f);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
        else if (skillPointCount[skillNumber - 1] < 3)
        {
            Debug.Log("아직 찍을 수 없는 스킬입니다.");
        }
    }

    public void skill6()
    {
        skillNumber = 5;

        if (skillPointMax[skillNumber] > skillPointCount[skillNumber] && skillPointCount[skillNumber - 1] >= 5 && skillPointCount[skillNumber - 2] >= 5)
        {
            bool haveSoul = UseSoul(50);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusMaxHP(10);
            UpStatusDefense(5f);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
        else
        {
            Debug.Log("아직 찍을 수 없는 스킬입니다.");
        }
    }

    public void skill7()
    {
        skillNumber = 6;

        if (skillPointMax[skillNumber] > skillPointCount[skillNumber])
        {
            bool haveSoul = UseSoul(15);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusSpeed(2);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
    }

    public void skill8()
    {
        skillNumber = 7;
        if (skillPointMax[skillNumber] > skillPointCount[skillNumber] && skillPointCount[skillNumber - 1] >= 3)
        {
            bool haveSoul = UseSoul(20);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusSpeed(1f);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
        else if (skillPointCount[skillNumber - 1] < 3)
        {
            Debug.Log("아직 찍을 수 없는 스킬입니다.");
        }
    }

    public void skill9()
    {
        skillNumber = 8;

        if (skillPointMax[skillNumber] > skillPointCount[skillNumber])
        {
            bool haveSoul = UseSoul(15);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusJumpPower(2);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
    }
    public void skill10()
    {
        skillNumber = 9;
        if (skillPointMax[skillNumber] > skillPointCount[skillNumber] && skillPointCount[skillNumber - 1] >= 3)
        {
            bool haveSoul = UseSoul(20);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusJumpPower(1f);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
        else if (skillPointCount[skillNumber - 1] < 3)
        {
            Debug.Log("아직 찍을 수 없는 스킬입니다.");
        }
    }

    public void skill11()
    {
        skillNumber = 10;

        if (skillPointMax[skillNumber] > skillPointCount[skillNumber])
        {
            if(skillPointCount[skillNumber - 1] >= 5 && skillPointCount[skillNumber - 2] >= 5 && skillPointCount[skillNumber - 3] >= 5 && skillPointCount[skillNumber - 4] >= 5) { 
                bool haveSoul = UseSoul(50);

                if (!haveSoul)
                {
                    return;
                }

                if (skillPointCount[skillNumber] == 0)
                {
                    skillimages[skillNumber].color = new Color(255, 255, 255, 255);
                }
                skillPointCount[skillNumber]++;
                skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
                UpStatusSpeed(10);
                UpStatusJumpPower(5f);
            }
            else
            {
                Debug.Log("아직 찍을 수 없는 스킬입니다.");
            }
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
        else
        {
            Debug.Log("아직 찍을 수 없는 스킬입니다.");
        }
    }
    public void skill12()
    {
        skillNumber = 11;

        if (skillPointMax[skillNumber] > skillPointCount[skillNumber])
        {
            bool haveSoul = UseSoul(30);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            UpStatusSkillCool(0.1f);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
    }

    public void skill16()
    {
        skillNumber = 15;

        if (skillPointMax[skillNumber] > skillPointCount[skillNumber])
        {
            bool haveSoul = UseSoul(30);

            if (!haveSoul)
            {
                return;
            }

            if (skillPointCount[skillNumber] == 0)
            {
                skillimages[skillNumber].color = new Color(255, 255, 255, 255);
            }
            skillPointCount[skillNumber]++;
            skillPointCountText[skillNumber].text = $"{skillPointCount[skillNumber]}";
            if (skillPointCount[skillNumber] == skillPointMax[skillNumber])
            {
                UpStatusMaxPotion(1);
            }
            UpStatusMaxPotion(1);
        }
        else if (skillPointMax[skillNumber] <= skillPointCount[skillNumber])
        {
            Debug.Log("이미 최대치인 스킬입니다.");
        }
    }
}

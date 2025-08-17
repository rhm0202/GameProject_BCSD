using TMPro;
using UnityEngine;

public class SoulManager : MonoBehaviour
{
    [SerializeField]
    private PlayerResource playerResource;

    private int maxHP;
    private float attackDamage;
    private float defenseDamage;
    private float attackSpeed;
    private float speed;
    private float jumpForce;
    private float cooldown;
    private int maxPotion;

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

    private void Start()
    {
        UpdateStatusMaxHP();
        UpdateStatusAttack();
        UpdateStatusDefense();
        UpdateStatusAttackSpeed();
        UpdateStatusSpeed();
        UpdateStatusJumpPower();
        UpdateStatusSkillCool();
        UpdateStatusMaxPotion();
    }

    void UpdateStatusMaxHP()
    {
        maxHP = playerResource.FindMaxHP();
        statusMaxHP.text = maxHP.ToString();
    }

    void UpdateStatusAttack()
    {
        attackDamage = playerResource.FindAttackDamage();
        statusAttackDanmage.text = attackDamage.ToString();
    }
    void UpdateStatusDefense()
    {
        defenseDamage = playerResource.FindDefenseDamage();
        statusDefenseDamage.text = defenseDamage.ToString();
    }

    void UpdateStatusAttackSpeed()
    {
        attackSpeed = playerResource.FindAttackSpeed();
        statusAttackSpeed.text = $"{attackSpeed}/s";
    }

    void UpdateStatusSpeed()
    {
        speed = playerResource.FindSpeed();
        statusSpeed.text = speed.ToString();
    }

    void UpdateStatusJumpPower()
    {
        jumpForce = playerResource.FindJumpForce();
        statusJumpPower.text = jumpForce.ToString();
    }

    void UpdateStatusSkillCool()
    {
        cooldown = playerResource.FindCoolDown();
        cooldown = cooldown * 100;
        statusSkillCool.text = $"{cooldown}%";
    }

    void UpdateStatusMaxPotion()
    {
        maxPotion = playerResource.FindMaxPotion();
        statusMaxPotion.text = $"{maxPotion}";
    }
}

using Spine;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "PlayerResourceData", menuName = "Game/PlayerResource")]

//버프 등 플레이 중간에 변경되는 요소를 배제하기 위한 플레이어의 정보, 소울을 통한 영구적 강화시 변경

public class PlayerResource : ScriptableObject
{
    //플레이어 최대체력
    [SerializeField]
    private int maxHP = 50;

    //플레이어 공격력
    [SerializeField]
    private float attackDamage = 5f;

    //플레이어 방어력
    [SerializeField]
    private float defenseDamage = 0f;

    //플레이어 공격속도
    [SerializeField]
    private float attackSpeed = 1f;

    //플레이어 이동속도
    [SerializeField]
    private float speed = 5f;

    //플레이어 점프력
    [SerializeField]
    private float jumpForce = 7f;

    //플레이어 쿨다운
    [SerializeField]
    private float cooldown = 0f;

    //플레이어 최대 소지 포션
    [SerializeField]
    private int maxPotion = 0;


    //플레이어의 스텟을 반환해주는 함수
    public int FindMaxHP()
    {
        return maxHP;
    }

    public float FindAttackDamage()
    {
        return attackDamage;
    }

    public float FindDefenseDamage()
    {
        return defenseDamage;
    }

    public float FindAttackSpeed()
    {
        return attackSpeed;
    }

    public float FindSpeed()
    {
        return speed;
    }

    public float FindJumpForce()
    {
        return jumpForce;
    }

    public float FindCoolDown()
    {
        return cooldown;
    }

    public int FindMaxPotion()
    {
        return maxPotion;
    }

    //플레이어 스텟을 올리는 함수
    public int UpMaxHp(int value)
    {
        maxHP += value;
        return maxHP;
    }

    public float UpAttackDamage(float value)
    {
        attackDamage += value;
        return attackDamage;
    }

    public float UpDefenseDamage(float value)
    {
        defenseDamage += value;
        return defenseDamage;
    }
    public float UpAttackSpeed(float value)
    {
        attackSpeed += attackSpeed*value;
        Debug.Log($"{value}");
        return attackSpeed;
    }
    public float UpSpeed(float value)
    {
        speed += value;
        return speed;
    }
    public float UpJumpForce(float value)
    {
        jumpForce += value;
        return jumpForce;
    }
    public float UpCoolDown(float value)
    {
        cooldown += value;
        return cooldown;
    }

    public int UpMaxPotion(int value)
    {
        maxPotion += value;
        return maxPotion;
    }
}
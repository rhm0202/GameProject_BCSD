using Spine;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "PlayerResourceData", menuName = "Game/PlayerResource")]

//버프 등 플레이 중간에 변경되는 요소를 배제하기 위한 플레이어의 정보, 소울을 통한 영구적 강화시 변경

public class PlayerResource : ScriptableObject
{
    //플레이어 체력
    public int maxHP = 50;

    //플레이어 이동속도
    public float speed = 5f;

    //플레이어 점프력
    public float jumpForce = 7f;

    //플레이어 공격속도
    public float attackSpeed = 0.2f;

    //플레이어 공격력
    public float attackDamage = 5f;

    //플레이어 스텟을 올리는 함수
    public int UpMaxHp(int value)
    {
        maxHP += value;
        return maxHP;
    }
    public float UpSpeed(int value)
    {
        speed += value;
        return speed;
    }
    public float UpJumpForce(int value)
    {
        jumpForce += value;
        return jumpForce;
    }
    public float UpAttackSpeed(int value)
    {
        attackSpeed += value;
        return attackSpeed;
    }
    public float UpAttackDamage(int value)
    {
        attackDamage += value;
        return attackDamage;
    }



}
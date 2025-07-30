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
    public int currentHP = 50;

    //플레이어 이동속도
    public float speed = 5f;

    //플레이어 점프력
    public float jumpForce = 7f;

    //플레이어 공격속도
    public float attactSpeed = 0.2f;

    //플레이어 공격력
    public float attactDamage = 5f;

    //플레이어 공격 체크용 함수
    private bool isAttact;

    //체력 초기화
    public void FullHeal()
    {
        currentHP = maxHP;
    }

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
    public float UpAttactSpeed(int value)
    {
        attactSpeed += value;
        return attactSpeed;
    }
    public float UpAttactDamage(int value)
    {
        attactDamage += value;
        return attactDamage;
    }


    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;

        if (currentHP == 0)
        {
            GameOver();
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP) currentHP = maxHP;
    }

    public void Attact()
    {

    }

    void GameOver()
    {
        currentHP = maxHP;
        SceneManager.LoadScene("GameOver");
    }
}
using Spine;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "PlayerResourceData", menuName = "Game/PlayerResource")]


public class PlayerResource : ScriptableObject
{
    //�÷��̾� ü��
    private int maxHP = 50;
    public int currentHP = 50;

    //�÷��̾� �̵��ӵ�
    public float speed = 5f;

    //�÷��̾� ������
    public float jumpForce = 7f;

    //�÷��̾� ���ݼӵ�
    public float attactSpeed = 1f;

    //�÷��̾� ���ݷ�
    public float attactDamage = 5f;

    //�÷��̾� ���� üũ�� �Լ�
    private bool isAttact;

    //ü�� �ʱ�ȭ
    public void FullHeal()
    {
        currentHP = maxHP;
    }

    //�÷��̾� ������ �ø��� �Լ�
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
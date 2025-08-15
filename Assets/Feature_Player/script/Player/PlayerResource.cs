using Spine;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "PlayerResourceData", menuName = "Game/PlayerResource")]

//���� �� �÷��� �߰��� ����Ǵ� ��Ҹ� �����ϱ� ���� �÷��̾��� ����, �ҿ��� ���� ������ ��ȭ�� ����

public class PlayerResource : ScriptableObject
{
    //�÷��̾� ü��
    public int maxHP = 50;

    //�÷��̾� �̵��ӵ�
    public float speed = 5f;

    //�÷��̾� ������
    public float jumpForce = 7f;

    //�÷��̾� ���ݼӵ�
    public float attackSpeed = 0.2f;

    //�÷��̾� ���ݷ�
    public float attackDamage = 5f;

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
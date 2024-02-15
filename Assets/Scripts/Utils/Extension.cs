using System;
using UnityEngine;

public static class Extension
{
    // Ȯ�� �޼��� ����

    /* <���̾��ũ> */

    // � ����� Ư���� ���̾�� ������ �� �ְ� ������Ʈ�� ����
    // �ش� ���̾� ���� ���������� 0, ���������� 1
    // LayerMask layerMask : 32��Ʈ�� int�� ����ü (1,3,6�� ���̾� üũ -> 0000(*6��) 0100 1010)
    // int layer : ���̾� ��ȣ

    // = �޼ҵ� =
    // int LayerMask.NameToLayer(string layerName);
    // string LayerMask.LayerToName(int layer);
    // int LayerMask.GetMask(params string[] layerNames);

    // Ȯ���� ���̾�� 6�� ���̾� => int layer = 6;
    // üũ�� ���̾�� 1,3,6�� ���̾� => 1001010
    // 1. ���� 1�� Ȯ���� ���̾��ũ�� ��ȣ��ŭ ��Ʈ����        1 << layer      1 << 6      1000000
    // 2. 1���� ���̾��ũ�� & ����                         1000000 & 1001010 = 1000000
    // 3. Ȯ���� ���̾� �ڸ��� 1���� Ȯ�� (0�� �ƴ��� Ȯ��)

    // layerMask.Contain(layer)

    // �����浹ü ���� �ÿ���
    //private int groundCount;
    // �����ڵ忡�� groundCount++; groundCount--; ���

    /* n�� ���̾� ���� ���� Ȯ�� */

    public static bool Contain(this LayerMask layerMask, int layer)
    {
        return ((1 << layer) & layerMask) != 0;
    }
}

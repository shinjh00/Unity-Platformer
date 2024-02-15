using System;
using UnityEngine;

public static class Extension
{
    // 확장 메서드 모음

    /* <레이어마스크> */

    // 어떤 기능을 특정한 레이어에만 적용할 수 있게 오브젝트를 구분
    // 해당 레이어 값이 꺼져있으면 0, 켜져있으면 1
    // LayerMask layerMask : 32비트의 int형 구조체 (1,3,6번 레이어 체크 -> 0000(*6개) 0100 1010)
    // int layer : 레이어 번호

    // = 메소드 =
    // int LayerMask.NameToLayer(string layerName);
    // string LayerMask.LayerToName(int layer);
    // int LayerMask.GetMask(params string[] layerNames);

    // 확인할 레이어는 6번 레이어 => int layer = 6;
    // 체크된 레이어는 1,3,6번 레이어 => 1001010
    // 1. 숫자 1을 확인할 레이어마스크의 번호만큼 비트연산        1 << layer      1 << 6      1000000
    // 2. 1번과 레이어마스크를 & 연산                         1000000 & 1001010 = 1000000
    // 3. 확인할 레이어 자리가 1인지 확인 (0이 아닌지 확인)

    // layerMask.Contain(layer)

    // 복합충돌체 구현 시에는
    //private int groundCount;
    // 실행코드에서 groundCount++; groundCount--; 사용

    /* n번 레이어 포함 여부 확인 */

    public static bool Contain(this LayerMask layerMask, int layer)
    {
        return ((1 << layer) & layerMask) != 0;
    }
}

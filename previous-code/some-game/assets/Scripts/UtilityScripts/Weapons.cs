/* 
 * �������ã�
 * ��Ϊһ���������װ��һЩ�������ԣ������ڴ�����������ͼ̳�
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dream.Scripts.ThingScripts.Weapons
{
    //������
    public class Weapons
    {
        string name;//��������
        float weapons_ATK;//����������

        //���캯��
        public Weapons()
        {
            name = "weapon";
            weapons_ATK = 0f;
        }
        //���εĹ��캯��
        public Weapons(string m_Name,float m_Attack)
        {
            name = m_Name;
            weapons_ATK = m_Attack;
        }
    }
}
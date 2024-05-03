
﻿using System;

internal class Enemy
{
    public string Name { get; }
    public int Level { get; set; } // 재원님 set 설정 
    public int Hp { get; set; }
    public int NowHp { get; set; }
    public int Exp { get; set; } // 재원님 추가 설정
    public int Atk { get; set; } // 재원님 set 설정
    public bool IsDead { get; set; }

    public Enemy(string name, int level, int hp, int nowHp,int atk, int exp, bool isDead = false)

    {
        Name = name;
        Level = level;
        Hp = hp;
        NowHp = nowHp;
        Atk = atk;
        Exp = exp; // 재원님 추가설정
        IsDead = isDead;
    }


    internal void PrintEnemyStatDescription(bool withNumber = false, int idx = 0)
    {

    }

    internal void Died()
    {
        string alive = $"Hp {Hp}";
        IsDead = true;
        alive.Replace($"Hp {Hp}", "Dead");
    }

    public Enemy Clone()
    {
        var clone = new Enemy(Name, Level, Hp, NowHp , Atk, Exp);
        return clone;
    }
}

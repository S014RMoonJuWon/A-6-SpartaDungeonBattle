using System;

internal class Enemy
{
    public string Name { get; }
    public int Level { get; }
    public int Hp { get; set; }

    public int NowHp { get; set; }
    public int Atk { get; }
    public bool IsDead { get; set; }

    public Enemy(string name, int level, int hp, int nowHp,int atk, bool isDead = false)
    {
        Name = name;
        Level = level;
        Hp = hp;
        NowHp = nowHp;
        Atk = atk;
        IsDead = isDead;
    }

    internal void PrintEnemyStatDescription(bool withNumber = false, int idx = 0)
    {

    }

    internal void Died()
    {
        IsDead = true;
    }

    public Enemy Clone()
    {
        var clone = new Enemy(Name, Level, Hp, NowHp , Atk);
        return clone;
    }
}

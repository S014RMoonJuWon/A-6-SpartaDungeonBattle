using System;

internal class Enemy
{
    public string Name { get; }
    public int Level { get; private set; }
    public int Hp { get; private set; }
    public int Atk { get; private set; }
    public int Exp { get; private set; }
    public bool IsDead { get; private set; }

    public Enemy(string name, int level, int hp, int atk, int exp, bool isDead = false)
    {
        Name = name;
        Level = level;
        Hp = hp;
        Atk = atk;
        Exp = exp;
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
        var clone = new Enemy("", 0, 0, 0, false);
        return clone;
    }
}

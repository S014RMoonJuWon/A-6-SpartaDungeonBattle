using System;

internal class Enemy
{
    public string Name { get; }
    public int Level { get; }
    public int Hp { get; }
    public int Atk { get; }
    public bool IsDead { get; private set; }

    public Enemy(string name, int level, int hp, int atk, bool isDead = false)
    {
        Name = name;
        Level = level;
        Hp = hp;
        Atk = atk;
        IsDead = isDead;
    }

    internal void PrintEnemyStatDescription(bool withNumber = false, int idx = 0)
    {

    }

    internal void Died()
    {
        string alive = $"Hp {Hp}";
        IsDead = true;
        alive.Replace ($"Hp {Hp}","Dead");
    }

    public Enemy Clone()
    {
        var clone = new Enemy("", 0, 0, 0, false);
        return clone;
    }
}

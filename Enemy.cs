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
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            IsDead = true;
            Console.WriteLine($"{Name}이(가) 죽었습니다!");
        }
    }
    public int GiveExperience()
    {
<<<<<<< Updated upstream
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
=======
        // 죽은 몬스터가 주는 경험치를 반환
        return Exp;
    }
}
>>>>>>> Stashed changes

internal class Enemy // 해당 cs파일 주원님이 추가 설정
{
    public string Name { get; }
    public int Level { get; set; } // 재원님 set 설정 
    public int Hp { get; set; }
    public int Atk { get; set; } // 재원님 set 설정
    public int Exp { get; set; } // 재원님 추가 설정
    public bool IsDead { get; private set; }

    public Enemy(string name, int level, int hp, int atk, int exp, bool isDead = false)
    {
        Name = name;
        Level = level;
        Hp = hp;
        Atk = atk;
        Exp = exp; // 재원님 추가설정
        IsDead = isDead;
    }

    // 여기부터(주원님 자료)
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
        var clone = new Enemy(Name, Level, Hp, Atk, Exp);
        return clone;
    }
}

internal class Enemy // 해당 cs파일 주원님이 추가 설정
{
    public string Name { get; }
    public int Level { get; private set; } // 재원님 자료에 private set 설정 되어 있음 
    public int Hp { get; private set; } // 재원님 자료는 private set 설정/ 유창님 자료에는 set 설정되어 있음
    public int Atk { get; private set; } // 재원님 자료에 private set 설정 되어 있음
    public int Exp { get; private set; } // 재원님 추가 설정
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
        var clone = new Enemy(Name, Level, Hp, Atk);
        return clone;
    }
    // 여기까지 주원님 자료


    // 여기부터 재원님 자료 
    public void TakeDamage(int damage) // 재원님 확인 필요함_ㅡMonster.cs에 동일한 내용이 있음
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            IsDead = true;
            Console.WriteLine($"{Name}이(가) 죽었습니다!");
        }
    }
    public int GiveExperience() // 해당 메서드는 재원님으로 추정됨
    {
<<<<<<< Updated upstream
        string alive = $"Hp {Hp}";
        IsDead = true;
        alive.Replace($"Hp {Hp}", "Dead");
    }


    // 주원님, 재원님 자료가 충돌난 거 같음
    // return 값이 어떤 건지 확인필요함
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

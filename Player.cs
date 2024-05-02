internal class Player
{
    public string Name { get; set; } // 다빈_set 설정
    public string Job { get; }
    public int Level { get; private set; } // 재원님 자료에 private set 설정되어있음(다빈, 주원 설정x)
    public int Atk { get; private set; } // 재원님 자료에 private set 설정되어있음(다빈, 주원 설정x)
    public int Def { get; private set; } // 재원님 자료에 private set 설정되어있음(다빈, 주원 설정x)
    public int Exp { get; private set; } // 재원님 추가 설정

    public int Hp { get; private set; } // 재원님 자료에 private set 설정되어있음(다빈, 주원 설정x  / 유창님은 set 설정)
    public int Gold { get; set; }

    public Player(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
    }




    // 'Atttack'메서드가 중복되어 충돌이 발생한 것 같음
    // 해당 부분은 유창님이 작성함

<<<<<<< Updated upstream
    // 공격 메서드 추가
    public void Attack(Enemy enemy)
    {
        // 플레이어의 공격력을 적의 체력에서 차감
        enemy.Hp -= this.Atk;
        Console.WriteLine($"{this.Name}이(가) {enemy.Name}에게 {this.Atk}의 피해를 입혔습니다!");

        // 적의 체력이 0 이하로 내려가는 경우 처리
        if (enemy.Hp <= 0)
        {
            enemy.Hp = 0; // 적의 체력이 음수가 되지 않도록 보정
            enemy.Died(); // 적의 상태를 사망으로 변경
            Console.WriteLine($"{enemy.Name}을(를) 처치했습니다!");
        }
    }
}
=======



    // 여기부터 재원님 추가 설정으로 추정됨

    // 플레이어가 피해를 입는 메서드
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            Console.WriteLine($"{Name}이(가) 죽었습니다!");
        }
    }

    // 플레이어가 죽었는지 확인하는 메서드
    public bool IsDead
    {
        get { return Hp <= 0; }
    }

    public void Attack(Enemy enemy)  
    {
        int damage = (int)Atk;
        enemy.TakeDamage(damage);
        Console.WriteLine($"{Name}이(가) {enemy.Name}에게 {damage}의 피해를 입혔습니다.");
    }

    public void LevelUp()
    {
        // 레벨 업 조건에 따라 레벨을 증가시키고 능력치를 증가시킴
        Level++;
        Exp = CalculateRequiredExp(Level); // 레벨마다 필요한 경험치 증가
        Atk += 0.5f; // 공격력 증가
        Def += 1; // 방어력 증가
    }

    private int CalculateRequiredExp(int level)
    {
        // 레벨에 따라 필요한 경험치를 계산하여 반환
        if (level == 2) return 10;
        else if (level == 3) return 35;
        else if (level == 4) return 65;
        else if (level == 5) return 100;
        else return 0; // 다른 레벨에 대한 경험치가 필요한 경우 추가 가능
    }
}

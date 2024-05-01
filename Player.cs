internal class Player
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; private set; }
    public float Atk { get; private set; }
    public int Def { get; private set; }
    public int Hp { get; private set; }
    public int Exp { get; private set; }
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


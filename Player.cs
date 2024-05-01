internal class Player
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; set; }
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


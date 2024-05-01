internal class Enemy
{
    public string Name { get; }
    public int Level { get; }
    public int Hp { get; set; }
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

    // 적이 플레이어를 공격하는 메서드 추가
    public void Attack(Player player)
    {
        // 적의 공격력을 플레이어의 체력에서 차감
        player.Hp -= this.Atk;
        Console.WriteLine($"{this.Name}이(가) {player.Name}에게 {this.Atk}의 피해를 입혔습니다!");

        // 플레이어의 체력이 0 이하로 내려가는 경우 처리
        if (player.Hp <= 0)
        {
            player.Hp = 0; // 플레이어의 체력이 음수가 되지 않도록 보정
            Console.WriteLine($"{player.Name}이(가) 사망했습니다.");
        }
    }

    internal void Died()
    {
        IsDead = true;
    }
}

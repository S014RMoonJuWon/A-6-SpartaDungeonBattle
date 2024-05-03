using System.Numerics;

internal class Player
{
    public string Name { get; set; } // 다빈_set 설정
    public string Job { get; }
    public int Level { get; set; } 
    public float Atk { get; set; } 
    public int Def { get; set; } 
    public int Exp { get; set; } // 재원님 추가 설정

    public int Hp { get; set; } // 유창님 set 설정
    public int Gold { get; set; }

    public Player(string name, string job, int level, float atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
    }


    // 여기부터 재원님 추가 설정으로 추정됨
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


    // 해당 부분은 유창님이 작성함

    // 공격 메서드 추가
    //public void Attack(Enemy enemy)
    //{
    //    // 플레이어의 공격력을 적의 체력에서 차감
    //    enemy.Hp -= this.Atk;
    //    Console.WriteLine($"{this.Name}이(가) {enemy.Name}에게 {this.Atk}의 피해를 입혔습니다!");

    //    // 적의 체력이 0 이하로 내려가는 경우 처리
    //    if (enemy.Hp <= 0)
    //    {
    //        enemy.Hp = 0; // 적의 체력이 음수가 되지 않도록 보정
    //        enemy.Died(); // 적의 상태를 사망으로 변경
    //        Console.WriteLine($"{enemy.Name}을(를) 처치했습니다!");
    //    }
    //}

    // 데미지 만큼 체력 감소
    // randomEnemy가 죽었을 때 IsDead true, dead 문자열 활성화, enemy 글자색 변경
    public static void Attack(int enemyCount, List<Enemy> randomEnemies, int keyInput, Player player)
    {
        Random random = new Random();
        int minDamage = (int)Math.Ceiling(player.Atk * 0.9f);
        int maxDamage = (int)Math.Ceiling(player.Atk * 1.1f);
        int damage = random.Next(minDamage, maxDamage + 1);

        randomEnemies[keyInput -1].NowHp -= damage;

        ConsoleUtility.ShowTitle("■ Battle!! ■");
        Console.WriteLine("");

        Console.WriteLine($"{player.Name}의 공격!");
        Console.WriteLine($"Lv.{randomEnemies[keyInput - 1].Level} {randomEnemies[keyInput - 1].Name}을(를) 맞췄습니다. [데미지 : {damage}]\n");

        if (randomEnemies[keyInput - 1].NowHp <= 0)
        { 
            Console.WriteLine($"Lv.{randomEnemies[keyInput - 1].Level} {randomEnemies[keyInput - 1].Name}\nHp {randomEnemies[keyInput - 1].NowHp+damage} -> Dead");
        }
        else if(randomEnemies[keyInput - 1].NowHp >0 && randomEnemies[keyInput - 1].NowHp < randomEnemies[keyInput - 1].Hp)
        {
            Console.WriteLine($"Lv.{randomEnemies[keyInput - 1].Level} {randomEnemies[keyInput - 1].Name}\nHp {randomEnemies[keyInput - 1].Hp} -> {randomEnemies[keyInput - 1].NowHp}");
        }
        else 
        {            
            Console.WriteLine($"Lv.{randomEnemies[keyInput - 1].Level} {randomEnemies[keyInput - 1].Name}\nHp {randomEnemies[keyInput - 1].NowHp+damage} -> {randomEnemies[keyInput - 1].NowHp}");
        }

        Console.WriteLine("\n0. 다음\n");
        
        switch (ConsoleUtility.PromptMenuChoice(0, 0))
        {
            case 0:
                break;
        }

        Console.Clear();

        // 공격 후 콘솔 창
        for (int i = 0; i < enemyCount; i++)
        {
            if (randomEnemies[i].NowHp > 0)
            {   
                Console.WriteLine($"{i + 1} Lv{randomEnemies[i].Level} {randomEnemies[i].Name} Hp {randomEnemies[i].NowHp}");
            }
            else
            {
                randomEnemies[i].Died();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1} Lv{randomEnemies[i].Level} {randomEnemies[i].Name} Hp Dead");
                Console.ResetColor();
            }
        }
        Console.WriteLine("\n");
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{(player.Level.ToString("00"))} {player.Name} {player.Job}\nHp {player.Hp}/100");
        Console.WriteLine("");
        Console.WriteLine("적의 공격 차례!");
        Thread.Sleep(3000);
    }
}


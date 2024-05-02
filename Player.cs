using System.Numerics;

internal class Player
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; }
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

    // 데미지 만큼 체력 감소
    // randomEnemy가 죽었을 때 IsDead true, dead 문자열 활성화, enemy 글자색 변경
    public static void Attack(int enemyCount, List<Enemy> randomEnemies, int keyInput, Player player)
    {
        Random random = new Random();
        int minDamage = (int)Math.Ceiling(player.Atk * 0.9f);
        int maxDamage = (int)Math.Ceiling(player.Atk * 1.1f);
        int damage = random.Next(minDamage, maxDamage + 1);

        randomEnemies[keyInput -1].NowHp = randomEnemies[keyInput - 1].Hp - damage;

        ConsoleUtility.ShowTitle("■ Battle!! ■");
        Console.WriteLine("");

        Console.WriteLine($"{player.Name}의 공격!");
        Console.WriteLine($"Lv.{randomEnemies[keyInput - 1].Level} {randomEnemies[keyInput - 1].Name}을(를) 맞췄습니다. [데미지 : {damage}]\n");
        if (randomEnemies[keyInput - 1].Hp > 0)
        {
            Console.WriteLine($"Lv.{randomEnemies[keyInput - 1].Level} {randomEnemies[keyInput - 1].Name}\nHp {randomEnemies[keyInput - 1].Hp} -> {randomEnemies[keyInput -1].NowHp}");
        }
        else
        {
            Console.WriteLine($"Lv.{randomEnemies[keyInput - 1].Level} {randomEnemies[keyInput - 1].Name}\nHp {randomEnemies[keyInput - 1].Hp} -> Dead");
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
            if (randomEnemies[i].Hp > 0)
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


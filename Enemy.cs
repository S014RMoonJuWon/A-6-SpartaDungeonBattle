
﻿using System;
using System.Numerics;

internal class Enemy
{
    public string Name { get; }
    public int Level { get; set; } // 재원님 set 설정 
    public int Hp { get; set; }
    public int NowHp { get; set; }
    public int Exp { get; set; } // 재원님 추가 설정
    public int Atk { get; set; } // 재원님 set 설정
    public bool IsDead { get; set; }

    public Enemy(string name, int level, int hp, int nowHp,int atk, int exp, bool isDead = false)

    {
        Name = name;
        Level = level;
        Hp = hp;
        NowHp = nowHp;
        Atk = atk;
        Exp = exp; // 재원님 추가설정
        IsDead = isDead;
    }


    internal void PrintEnemyStatDescription(bool withNumber = false, int idx = 0)
    {

    }

    internal void Died()
    {
        IsDead = true;
    }

    public Enemy Clone()
    {
        var clone = new Enemy(Name, Level, Hp, NowHp , Atk, Exp);
        return clone;
    }
    
    public static List<Enemy> GenerateRandomEnemies(List<Enemy> enemyList)
    {
        List<Enemy> enemies = new List<Enemy>();
        Random random = new Random();
        int enemyCount = random.Next(1, 5);

        for (int i = 0; i < enemyCount; i++)
        {
            int randomEncount = random.Next(enemyList.Count);
            Enemy randomEnemy = enemyList[randomEncount].Clone(); // 복제된 적 추가
            enemies.Add(randomEnemy);
        }

        return enemies;
    }

    public static void Attack(int enemyCount, List<Enemy> randomEnemies, Player player)
    {
        int sumAtk = randomEnemies.Sum(randomEnemies => randomEnemies.IsDead ? 0 : randomEnemies.Atk);
        player.NowHp -= sumAtk;

        Console.Clear();

        ConsoleUtility.ShowTitle("■ Battle!! ■");
        Console.WriteLine("");

        for (int i = 0; i < enemyCount; i++)
        {
            if (randomEnemies[i].NowHp > 0)
            {
                Console.WriteLine($"Lv{randomEnemies[i].Level} {randomEnemies[i].Name} 의 공격!\n{player.Name} 을(를) 맞췄습니다. [데미지 : {randomEnemies[i].Atk}]\n");
            }
            else
            {
                Console.WriteLine($"Lv{randomEnemies[i].Level} {randomEnemies[i].Name}은(는) 죽어있습니다!\n");
            }
        }

        Console.WriteLine($"총 {sumAtk} 데미지!\n");
        Console.WriteLine("[내정보]");
        if(player.NowHp >0)
        {
            Console.WriteLine($"Lv.{(player.Level.ToString("00"))} {player.Name} {player.Job}\nHp {player.NowHp}/{player.Hp}");
        }
        else
        {
            Console.WriteLine($"Lv.{(player.Level.ToString("00"))} {player.Name} {player.Job}\nHp 0/{player.Hp}");
        }
        Console.WriteLine("");
        Console.WriteLine("0. 다음\n");

        switch (ConsoleUtility.PromptMenuChoice(0, 0))
        {
            case 0:
                break;
        }
    }
}

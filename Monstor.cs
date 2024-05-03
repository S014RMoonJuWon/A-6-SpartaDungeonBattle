using System;
using System.Collections.Generic;

namespace SpartaDungeon  // 해당 cs파일 재원님이 추가 설정
{
    class Monster
    {
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }

        public Monster(string name, int maxHP)
        {
            Name = name;
            MaxHP = maxHP;
            CurrentHP = maxHP;
        }

    }

    class Game
    {
        private int initialPlayerHP;
        private int playerHP;
        private List<Monster> monsters;

        public Game(int playerHP, List<Monster> monsters)
        {
            initialPlayerHP = playerHP;
            this.playerHP = playerHP;
            this.monsters = monsters;
        }

        public void Start()
        {
            Console.WriteLine("Battle!!");

            bool allMonstersDead = true;
            foreach (var monster in monsters)
            {
                if (monster.CurrentHP > 0)
                {
                    allMonstersDead = false;
                    break;
                }
            }

            if (allMonstersDead) // 던전 클리어 했을 때
            {
                Console.WriteLine("Battle!! - Result\n");
                Console.WriteLine("Victory\n");

                Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.\n");

                foreach (var monster in monsters)
                {
                    Console.WriteLine($"{monster.Name}\nHP {monster.MaxHP} -> {monster.CurrentHP}\n");
                }
            }
            else if (playerHP <= 0) // 던전 실패 했을 때
            {
                Console.WriteLine("Battle!! - Result\n");
                Console.WriteLine("You Lose\n");

                foreach (var monster in monsters)
                {
                    Console.WriteLine($"{monster.Name}\nHP {monster.MaxHP} -> {monster.CurrentHP}\n");
                }
            }

            Console.WriteLine("0. 다음");
            playerHP = GetCurrentPlayerHP();
            Console.ReadLine();
        }

        private int GetCurrentPlayerHP()
        {
            int remainingHP = 0;
            foreach (var monster in monsters)
            {
                remainingHP += monster.CurrentHP;
            }
            return remainingHP;
        }

        public int GetInitialPlayerHP()
        {
            return initialPlayerHP;
        }
    }
}

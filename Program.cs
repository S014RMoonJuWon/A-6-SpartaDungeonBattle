<<<<<<< Updated upstream
﻿using SpartaDungeon;
=======
﻿
using SpartaDungeon;
>>>>>>> Stashed changes
using System;

public class GameManager
{
    private Player player;
    private List<Item> inventory;

    private List<Item> storeInventory;

    private List<Enemy> enemy;
    private Game game;

    public GameManager()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        player = new Player("Jiwon", "Programmer", 1, 10, 5, 1000, 15000);

        inventory = new List<Item>();

        storeInventory = new List<Item>();
        storeInventory.Add(new Item("무쇠갑옷", "튼튼한 갑옷", ItemType.ARMOR, 0, 5, 0, 500));
        storeInventory.Add(new Item("낡은 검", "낡은 검", ItemType.WEAPON, 2, 0, 0, 1000));
        storeInventory.Add(new Item("골든 헬름", "희귀한 투구", ItemType.ARMOR, 0, 9, 0, 2000));

        // 적 초기화
        enemy = new List<Enemy>();
        Enemy minion = new Enemy("미니언", 2, 15, 5, 2);
        Enemy voiding = new Enemy("공허충", 3, 10, 9, 3);
        Enemy seigeMinion = new Enemy("대포미니언", 5, 25, 8, 5);
        enemy.Add(minion);
        enemy.Add(voiding);
        enemy.Add(seigeMinion);

        // Game 객체 초기화

    }

    public void StartGame()
    {
        Console.Clear();
        ConsoleUtility.PrintGameHeader();
        MainMenu();
    }

    private void MainMenu()
    {
        // 구성
        // 0. 화면 정리
        Console.Clear();

        // 1. 선택 멘트를 줌
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("");

        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine("4. 전투시작");
        Console.WriteLine("");

        // 2. 선택한 결과를 검증함
        int choice = ConsoleUtility.PromptMenuChoice(1, 4);

        // 3. 선택한 결과에 따라 보내줌
        switch (choice)
        {
            case 1:
                StatusMenu();
                break;
            case 2:
                InventoryMenu();
                break;
            case 3:
                StoreMenu();
                break;
            case 4:
                BattleStartMenu();
                break;
        }
        MainMenu();
    }

    private void StatusMenu()
    {
        Console.Clear();

        ConsoleUtility.ShowTitle("■ 상태보기 ■");
        Console.WriteLine("캐릭터의 정보가 표기됩니다.");

        ConsoleUtility.PrintTextHighlights("Lv. ", player.Level.ToString("00"));
        Console.WriteLine("");
        Console.WriteLine($"{player.Name} ( {player.Job} )");

        // TODO : 능력치 강화분을 표현하도록 변경

        int bonusAtk = inventory.Select(item => item.IsEquipped ? item.Atk : 0).Sum();
        int bonusDef = inventory.Select(item => item.IsEquipped ? item.Def : 0).Sum();
        int bonusHp = inventory.Select(item => item.IsEquipped ? item.Hp : 0).Sum();

        ConsoleUtility.PrintTextHighlights("공격력 : ", (player.Atk + bonusAtk).ToString(), bonusAtk > 0 ? $" (+{bonusAtk})" : "");
        ConsoleUtility.PrintTextHighlights("방어력 : ", (player.Def + bonusDef).ToString(), bonusDef > 0 ? $" (+{bonusDef})" : "");
        ConsoleUtility.PrintTextHighlights("체 력 : ", (player.Hp + bonusHp).ToString(), bonusHp > 0 ? $" (+{bonusHp})" : "");

        ConsoleUtility.PrintTextHighlights("Gold : ", player.Gold.ToString());
        Console.WriteLine("");

        Console.WriteLine("0. 뒤로가기");
        Console.WriteLine("");

        switch (ConsoleUtility.PromptMenuChoice(0, 0))
        {
            case 0:
                MainMenu();
                break;
        }
    }

    private void InventoryMenu()
    {
        Console.Clear();

        ConsoleUtility.ShowTitle("■ 인벤토리 ■");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine("");
        Console.WriteLine("[아이템 목록]");

        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i].PrintItemStatDescription();
        }

        Console.WriteLine("");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("1. 장착관리");
        Console.WriteLine("");

        switch (ConsoleUtility.PromptMenuChoice(0, 1))
        {
            case 0:
                MainMenu();
                break;
            case 1:
                EquipMenu();
                break;
        }
    }

    private void EquipMenu()
    {
        Console.Clear();

        ConsoleUtility.ShowTitle("■ 인벤토리 - 장착 관리 ■");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine("");
        Console.WriteLine("[아이템 목록]");
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i].PrintItemStatDescription(true, i + 1); // 나가기가 0번 고정, 나머지가 1번부터 배정
        }
        Console.WriteLine("");
        Console.WriteLine("0. 나가기");

        int KeyInput = ConsoleUtility.PromptMenuChoice(0, inventory.Count);

        switch (KeyInput)
        {
            case 0:
                InventoryMenu();
                break;
            default:
                inventory[KeyInput - 1].ToggleEquipStatus();
                EquipMenu();
                break;
        }
    }

    private void StoreMenu()
    {
        Console.Clear();

        ConsoleUtility.ShowTitle("■ 상점 ■");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine("");
        Console.WriteLine("[보유 골드]");
        ConsoleUtility.PrintTextHighlights("", player.Gold.ToString(), " G");
        Console.WriteLine("");
        Console.WriteLine("[아이템 목록]");
        for (int i = 0; i < storeInventory.Count; i++)
        {
            storeInventory[i].PrintStoreItemDescription();
        }
        Console.WriteLine("");
        Console.WriteLine("1. 아이템 구매");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("");
        switch (ConsoleUtility.PromptMenuChoice(0, 1))
        {
            case 0:
                MainMenu();
                break;
            case 1:
                PurchaseMenu();
                break;
        }
    }

    private void PurchaseMenu(string? prompt = null)
    {
        if (prompt != null)
        {
            // 1초간 메시지를 띄운 다음에 다시 진행
            Console.Clear();
            ConsoleUtility.ShowTitle(prompt);
            Thread.Sleep(1000); // 시간 줄여도 될 것 같음
        }

        Console.Clear();

        ConsoleUtility.ShowTitle("■ 상점 ■");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine("");
        Console.WriteLine("[보유 골드]");
        ConsoleUtility.PrintTextHighlights("", player.Gold.ToString(), " G");
        Console.WriteLine("");
        Console.WriteLine("[아이템 목록]");
        for (int i = 0; i < storeInventory.Count; i++)
        {
            storeInventory[i].PrintStoreItemDescription(true, i + 1);
        }
        Console.WriteLine("");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("");

        int keyInput = ConsoleUtility.PromptMenuChoice(0, storeInventory.Count);

        switch (keyInput)
        {
            case 0:
                StoreMenu();
                break;
            default:
                // 1 : 이미 구매한 경우
                if (storeInventory[keyInput - 1].IsPurchased) // index 맞추기
                {
                    PurchaseMenu("이미 구매한 아이템입니다.");
                }
                // 2 : 돈이 충분해서 살 수 있는 경우
                else if (player.Gold >= storeInventory[keyInput - 1].Price)
                {
                    player.Gold -= storeInventory[keyInput - 1].Price;
                    storeInventory[keyInput - 1].Purchase();
                    inventory.Add(storeInventory[keyInput - 1]);
                    PurchaseMenu();
                }
                // 3 : 돈이 모자라는 경우
                else
                {
                    PurchaseMenu("Gold가 부족합니다.");
                }
                break;
        }
    }

    private void BattleStartMenu()
    {
        enemy = new List<Enemy>();

        Enemy minion = new Enemy("미니언", 2, 15, 5, 2);
        Enemy voiding = new Enemy("공허충", 3, 10, 9, 3);
        Enemy seigeMinion = new Enemy("대포미니언", 5, 25, 8, 5);

        enemy.Add(minion);
        enemy.Add(voiding);
        enemy.Add(seigeMinion);

        Random random = new Random();
        int enemycount = random.Next(1, 5);

        Console.Clear();

        ConsoleUtility.ShowTitle("■ Battle!! ■");
        Console.WriteLine("");
        // 1~4 마리의 몬스터가 랜덤하게 등장, 표시되는 순서는 랜덤
        for (int i = 0; i < enemycount; i++)
        {
            int randomEncount = random.Next(enemy.Count);
            Enemy randomEnemy = enemy[randomEncount];
            Console.WriteLine($"{i + 1} : {randomEnemy.Name} Hp {randomEnemy.Hp}");
        }

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{(player.Level.ToString("00"))} {player.Name} {player.Job}\nHp {player.Hp}/100");
        Console.WriteLine("");
        Console.WriteLine("1. 공격");
        Console.WriteLine("2. 스킬");
        Console.WriteLine("3. 아이템");

        int KeyInput = ConsoleUtility.PromptMenuChoice(1, 3);
        // swich 함수
        switch (KeyInput)
        {
            case 1:
                BattleMenu();
                break;
        }
        // Attck, Skill 함수는 enemycount 수 까지 누를 수 있게

    }
    private void BattleMenu()
    {
        if (enemy.Count == 0 || player.IsDead)
        {
            MainMenu();
            return;
        }

        int selectedEnemyIndex = SelectEnemy(enemy);
        Enemy selectedEnemy = enemy[selectedEnemyIndex];
        player.Attack(selectedEnemy);

        if (selectedEnemy.IsDead)
        {
            Console.WriteLine($"{selectedEnemy.Name}이(가) 죽었습니다!");
            enemy.RemoveAt(selectedEnemyIndex);
        }
        else
        {
            int enemyDamage = selectedEnemy.Atk;
            player.TakeDamage(enemyDamage);

            Console.WriteLine($"{selectedEnemy.Name}이(가) {player.Name}에게 {enemyDamage}의 피해를 입혔습니다.");

            if (player.IsDead)
            {
                Console.WriteLine($"{player.Name}이(가) 사망했습니다.");
                // 게임 오버 또는 다른 처리를 추가할 수 있습니다.
                return;
            }
        }

        // 플레이어와 몬스터가 번갈아가며 공격하는 과정을 반복합니다.
        BattleMenu();
    }


    private int SelectEnemy(List<Enemy> enemies)
    {
        Console.WriteLine("공격할 몬스터를 선택하세요:");
        for (int i = 0; i < enemies.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {enemies[i].Name} (HP: {enemies[i].Hp})");
        }

        int selectedEnemyIndex = ConsoleUtility.PromptMenuChoice(1, enemies.Count) - 1;

        return selectedEnemyIndex;
    }

    private int CalculatePlayerDamage()
    {
        // 플레이어 공격력 계산 로직 추가
        return 10; // 임시로 10을 반환
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.StartGame();
    }
}



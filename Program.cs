using System;
using System.Reflection;


public class GameManager
{
    private Player player;
    private List<Item> inventory;

    private List<Item> storeInventory;

    private List<Enemy> enemy;

    private List<Player> GetPlayer; // 다빈_직업 선택 및 추가 작업


    public GameManager()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        //player = new Player("Jiwon", "Programmer", 1, 10, 5, 1000, 15000);

        inventory = new List<Item>();

        storeInventory = new List<Item>();
        storeInventory.Add(new Item("무쇠갑옷", "튼튼한 갑옷", ItemType.ARMOR, 0, 5, 0, 500));
        storeInventory.Add(new Item("낡은 검", "낡은 검", ItemType.WEAPON, 2, 0, 0, 1000));
        storeInventory.Add(new Item("골든 헬름", "희귀한 투구", ItemType.ARMOR, 0, 9, 0, 2000));
        storeInventory.Add(new Item("공진단", "공진단", ItemType.Mediecine, 0, 0, 10, 3000));


        GetPlayer = new List<Player>();
        // 다빈_'name'에 할당될 부분은 작성해도 무관함(어차피 이름 입력받으면 값이 달라짐)
        GetPlayer.Add(new Player("", "전사", 1, 10, 5, 100, 15000));
        GetPlayer.Add(new Player("", "마법사", 1, 12, 3, 50, 20000));
        GetPlayer.Add(new Player("", "궁수", 1, 7, 8, 80, 17000));
        GetPlayer.Add(new Player("", "도적", 1, 9, 6, 80, 16000));

        // 적 초기화
        enemy = new List<Enemy>();
        Enemy minion = new Enemy("미니언", 2, 15,15, 5, 2); // 경험치추가 및 다른 스탯 변경되었는지 확인 필요_주원님 작성은 아님
        Enemy voiding = new Enemy("공허충", 3, 10,10, 9, 3);
        Enemy seigeMinion = new Enemy("대포미니언", 5, 25, 25, 8, 5);
        enemy.Add(minion);
        enemy.Add(voiding);
        enemy.Add(seigeMinion);

        // Game 객체 초기화

    }

    public void StartGame()
    {
        Console.Clear();
        ConsoleUtility.PrintGameHeader();
        CreatePlayerMenu();
    }

    private void CreatePlayerMenu() // 다빈_이름생성 및 직업선택 화면
    {
        Console.Clear();

        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("원하시는 이름을 설정해주세요.");
        Console.WriteLine("(설정된 이름은 변경이 어려우니 신중히 작성해주세요!)");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("");

        string name = Console.ReadLine();

        // 다빈_스페이스바만 입력되거나 엔터키만 입력 시 fals임
        while (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("잘못된 입력입니다.");
            Console.WriteLine("다시 입력해주세요.");
            name = Console.ReadLine();
        }

        Console.WriteLine("");
        Console.WriteLine($"{name}님, 환영합니다!");

        Console.Clear();

        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("직업을 선택해주세요.");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("");

        for (int i = 0; i < GetPlayer.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {GetPlayer[i].Job} (공격력 : {GetPlayer[i].Atk} | 방어력 : {GetPlayer[i].Def} | 체력 : {GetPlayer[i].Hp} | Gold :{GetPlayer[i].Gold} )");
        }

        Console.WriteLine("");

        switch (ConsoleUtility.PromptMenuChoice(1, GetPlayer.Count))
        {
            case 1:
                player = GetPlayer[0];
                player.Name = name; // 입력받은 이름 할당
                Console.WriteLine($"{GetPlayer[0].Job}를(을) 선택했습니다.");
                break;
            case 2:
                player = GetPlayer[1];
                player.Name = name;
                Console.WriteLine($"{GetPlayer[1].Job}를(을) 선택했습니다.");
                break;
            case 3:
                player = GetPlayer[2];
                player.Name = name;
                Console.WriteLine($"{GetPlayer[2].Job}를(을) 선택했습니다.");
                break;
            case 4:
                player = GetPlayer[3];
                player.Name = name;
                Console.WriteLine($"{GetPlayer[3].Job}를(을) 선택했습니다.");
                break;
        }

        Console.WriteLine("\n0. 다음\n");

        switch (ConsoleUtility.PromptMenuChoice(0, 0))
        {
            case 0:
                break;
        }

        Console.WriteLine("");

        Thread.Sleep(2000); // 다빈_콘솔 클리어가 너무 빨라서 설정해둠(수정해도 무관)
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
    // 1차 : 주원님 자료 진행 후 확인 필요사항 주석남김
    // 2차 : 재원님 자료 진행 후 확인 필요사항 주석남김
    // 3차 : 유창님 자료 진행 후 확인 필요사항 주석남김
    {
        List<Enemy> randomEnemies = new List<Enemy>();
        Random random = new Random();
        int enemyCount = random.Next(1, 5);

        Console.Clear();

        ConsoleUtility.ShowTitle("■ Battle!! ■");
        Console.WriteLine("");
        // 1~4 마리의 몬스터가 랜덤하게 등장, 표시되는 순서는 랜덤

        for (int i = 0; i < enemyCount; i++) // 이전에 enemy.count였음_주원님이 수정 작성함
        {
            int randomEncount = random.Next(enemy.Count);
            Enemy randomEnemy = enemy[randomEncount];
            randomEnemies.Add(randomEnemy.Clone());
        }

        // 다빈_장비 착용 시 증가되는 Hp 표현 복붙해옴
        int bonusHp = inventory.Select(item => item.IsEquipped ? item.Hp : 0).Sum();

        for (int i = 0; i < enemyCount; i++) 
        {
            Console.WriteLine($"Lv{randomEnemies[i].Level} {randomEnemies[i].Name} Hp {randomEnemies[i].Hp}");
        }

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("[내정보]");
        // 다빈_장비착용 시 보너스 AP 표기되는 것 추가함
        Console.WriteLine($"Lv.{(player.Level.ToString("00"))} {player.Name} {player.Job}\nHp {player.Hp + bonusHp}/{player.Hp + bonusHp}");
        Console.WriteLine("");
        Console.WriteLine("1. 공격\n2. 스킬\n3. 아이템");
        Console.WriteLine("");

        int KeyInput = ConsoleUtility.PromptMenuChoice(1, 3);
        switch (KeyInput)
        {
            // 1. 전투
            case 1:
                BattleMenu(enemyCount, randomEnemies);
                break;
        }
        // Attck, Skill 함수는 enemyCount 수 까지 누를 수 있게
    }
    // 클론된 randomEnemies 중 공격 대상을 고르는 메뉴
    void BattleMenu(int enemyCount, List<Enemy> randomEnemies)
    {
        Console.Clear();

        ConsoleUtility.ShowTitle("■ Battle!! ■");
        Console.WriteLine("");

        for (int i = 0; i < enemyCount; i++)
        {
            if (randomEnemies[i].NowHp > 0)
            {
                Console.WriteLine($"{i + 1} Lv{randomEnemies[i].Level} {randomEnemies[i].Name} Hp {randomEnemies[i].NowHp}");
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1} Lv{randomEnemies[i].Level} {randomEnemies[i].Name} Hp Dead");
                Console.ResetColor();
            }

            Console.WriteLine($"{i+1} Lv{randomEnemies[i].Level} {randomEnemies[i].Name} Hp {randomEnemies[i].Hp}");

        }

         // 다빈_장비 착용 시 증가되는 Hp 표현 복붙해옴
        int bonusHp = inventory.Select(item => item.IsEquipped ? item.Hp : 0).Sum();

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{(player.Level.ToString("00"))} {player.Name} {player.Job}\nHp {player.Hp + bonusHp}/{player.Hp + bonusHp}");
        Console.WriteLine("");
        Console.WriteLine("공격할 대상을 고르세요.");

        int keyInput = ConsoleUtility.PromptMenuChoice(1, enemyCount);

        switch (keyInput)
        {
            default:
                Console.Clear();
                Player.Attack(enemyCount, randomEnemies, keyInput, player);

                Battle(enemyCount, randomEnemies); //"재워" 호출 기능 하나 추가
                break;
        }

    }

    private void Battle(int enemyCount, List<Enemy> randomEnemies) // "재원" 결과출력 화면 코드 넣음
    {
        Console.Clear();
        ConsoleUtility.ShowTitle("■ Battle!! ■");
        Console.WriteLine("");
        // 플레이어의 총 체력과 남은 체력을 계산합니다.
        int totalPlayerHp = player.Hp;
        int remainingPlayerHp = totalPlayerHp;

        // 인벤토리에 있는 장비의 체력을 추가합니다.
        foreach (var item in inventory)
        {
            if (item.IsEquipped)
            {
                totalPlayerHp += item.Hp;
            }
        }

        // 플레이어의 현재 체력을 적용합니다.
        remainingPlayerHp = player.Hp > 0 ? player.Hp : 0;

        // 남은 체력이 플레이어의 최대 체력을 초과하지 않도록 합니다.
        remainingPlayerHp = remainingPlayerHp > totalPlayerHp ? totalPlayerHp : remainingPlayerHp;


        // 몬스터가 죽은 경우
        if (randomEnemies.All(e => e.NowHp <= 0))
        {
            Console.WriteLine("전투에서 승리하였습니다!");
            Console.WriteLine("");
            Console.WriteLine($"던전에서 몬스터 {enemyCount}마리를 잡았습니다.");
            // 플레이어의 체력을 표시합니다.
            Console.WriteLine("[플레이어 정보]");
            Console.WriteLine($"Lv.{player.Level.ToString("00")} {player.Name} {player.Job}\nHP {remainingPlayerHp}/{totalPlayerHp}");
            Console.WriteLine("");
            Console.WriteLine("0. 다음");
            // 사용자 입력을 기다립니다.
            Console.ReadKey();
            MainMenu();
            return;
        }
        // 플레이어가 죽은 경우
        else if (player.Hp <= 0)
        {
            Console.WriteLine("전투에서 패배하였습니다...");
            Console.WriteLine("게임오버");
            // 플레이어의 체력을 표시합니다.
            Console.WriteLine("[플레이어 정보]");
            Console.WriteLine($"Lv.{player.Level.ToString("00")} {player.Name} {player.Job}\nHP 0/{totalPlayerHp}");
            Console.ReadKey();
            Environment.Exit(0);
            return;

        }
        else
        {
            Console.Clear(); // 전투가 계속되는 경우에도 화면을 지워줍니다.
            // 전투가 계속되는 경우 BattleMenu를 호출하여 다음 공격을 진행합니다.
            BattleMenu(enemyCount, randomEnemies);
        }
    }

    // 데미지 만큼 체력 감소
    // randomEnemy가 죽었을 때 IsDead true, dead 문자열 활성화, enemy 글자색 변경

    // 여기까지 주원님 자료


    // !!여기부터 다시 봐야 함!!


    // 주원님, 유창님 자료에는 여기까지 없음
    // 재원님 자료에는 여기까지 있음

    // 유창님 자료에는 여기부터 Bettle Menu가 시작임
    //bool playerTurn = true; // 플레이어의 차례인지 여부를 나타내는 변수

    //foreach (Enemy enemy in enemy)
    //{
    //    while (!enemy.IsDead && player.Hp > 0)
    //    {
    //        Console.Clear();
    //        if (playerTurn)
    //        {
    //            ConsoleUtility.ShowTitle($"{player.Name} 의 공격!");
    //        }
    //        else
    //        {
    //            ConsoleUtility.ShowTitle($"{enemy.Name} 의 공격!");
    //        }
    //        Console.WriteLine("");
    //        Console.WriteLine($"[적 정보]");
    //        Console.WriteLine($"이름: {enemy.Name} | 체력: {enemy.Hp}/{enemy.Hp}");
    //        Console.WriteLine("");
    //        Console.WriteLine("[플레이어 정보]");
    //        Console.WriteLine($"레벨: {player.Level.ToString("00")} | 이름: {player.Name} | 직업: {player.Job} | 체력: {player.Hp}/100");
    //        Console.WriteLine("");
    //        Console.WriteLine("1. 공격");
    //        Console.WriteLine("2. 스킬");
    //        Console.WriteLine("3. 아이템");
    //        Console.WriteLine("");

    //        int choice = ConsoleUtility.PromptMenuChoice(1, 3);

    //        switch (choice)
    //        {
    //            case 1:
    //                if (playerTurn)
    //                {
    //                    // 플레이어가 적을 공격함
    //                    player.Attack(enemy);
    //                    Console.WriteLine($"{player.Name}이(가) {enemy.Name}에게 {player.Atk}의 피해를 입혔습니다!");
    //                    if (enemy.IsDead)
    //                    {
    //                        Console.WriteLine($"{enemy.Name}을(를) 처치했습니다!");
    //                        Console.WriteLine("계속하려면 아무 키나 누르세요...");
    //                        Console.ReadKey();
    //                        break;
    //                    }
    //                    else
    //                    {
    //                        // 적의 공격 구현
    //                        enemy.Attack(player);
    //                        Console.WriteLine($"{enemy.Name}의 공격!");
    //                        Console.WriteLine($"{enemy.Name}이(가) {player.Name}에게 {enemy.Atk}의 피해를 입혔습니다!");
    //                        Console.WriteLine($"{player.Name}의 체력: {player.Hp}");
    //                        Console.WriteLine("계속하려면 아무 키나 누르세요...");
    //                        Console.ReadKey();
    //                    }
    //                    playerTurn = false; // 플레이어의 공격이 끝났으므로 적의 차례로 변경
    //                }
    //                else
    //                {
    //                    // 적이 플레이어를 공격함
    //                    enemy.Attack(player);
    //                    Console.WriteLine($"{enemy.Name}이(가) {player.Name}에게 {enemy.Atk}의 피해를 입혔습니다!");
    //                    if (player.Hp <= 0)
    //                    {
    //                        Console.WriteLine($"{enemy.Name}에게 패배했습니다!");
    //                        Console.WriteLine("게임 오버.");
    //                        Console.ReadKey();
    //                        Environment.Exit(0);
    //                    }
    //                    playerTurn = true; // 적의 공격이 끝났으므로 플레이어의 차례로 변경
    //                }
    //                break;
    //            case 2:
    //                // 스킬 기능 구현
    //                break;
    //            case 3:
    //                // 아이템 기능 구현
    //                break;
    //        }
    //    }
    //}
    void enemyAttack(int enemyCount, List<Enemy> randomEnemies)
    {
        Console.Clear();

        ConsoleUtility.ShowTitle("■ Battle!! ■");
        Console.WriteLine("");

        for (int i = 0; i < enemyCount; i++)
        {

            if (randomEnemies[i].NowHp > 0)
            {
                Console.WriteLine($"Lv{randomEnemies[i].Level} {randomEnemies[i].Name} 의 공격!\n{player.Name} 을(를) 맞췄습니다. [데미지 : {randomEnemies[i].Atk}]");
            }
            else
            {

            }
        }

        int sumAtk = randomEnemies.Sum(randomEnemies => randomEnemies.IsDead ? 0 : randomEnemies.Atk);

        Console.WriteLine("\n");
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{(player.Level.ToString("00"))} {player.Name} {player.Job}\nHp {player.Hp - sumAtk}/100");
        Console.WriteLine("");
        Console.WriteLine("0. 다음\n");
        BattleMenu(enemyCount, randomEnemies);
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



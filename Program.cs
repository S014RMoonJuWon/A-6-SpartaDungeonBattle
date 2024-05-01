


public class GameManager
{
    private Player player;
    private List<Item> inventory;

    private List<Item> storeInventory;

    private List<Enemy> enemy;

    private List<Player> GetPlayer;

    public GameManager()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        // player = new Player("Jiwon", "Programmer", 1, 10, 5, 100, 15000);

        inventory = new List<Item>();

        storeInventory = new List<Item>();
        storeInventory.Add(new Item("무쇠갑옷", "튼튼한 갑옷", ItemType.ARMOR, 0, 5, 0, 500));
        storeInventory.Add(new Item("낡은 검", "낡은 검", ItemType.WEAPON, 2, 0, 0, 1000));
        storeInventory.Add(new Item("골든 헬름", "희귀한 투구", ItemType.ARMOR, 0, 9, 0, 2000));
        storeInventory.Add(new Item("공진단", "공진단", ItemType.Mediecine, 0, 0, 10, 3000));

        GetPlayer = new List<Player>();
        // 'name'에 할당될 부분은 작성해도 무관함(어차피 이름 입력받으면 값이 달라짐)
        GetPlayer.Add(new Player("", "전사", 1, 10, 5, 100, 15000));
        GetPlayer.Add(new Player("", "마법사", 1, 12, 3, 50, 20000));
        GetPlayer.Add(new Player("", "궁수", 1, 7, 8, 80, 17000));
        GetPlayer.Add(new Player("", "도적", 1, 9, 6, 80, 16000));

    }

    public void StartGame()
    {
        Console.Clear();
        ConsoleUtility.PrintGameHeader();
        CreatePlayerMenu();
    }

    private void CreatePlayerMenu()
    {
        Console.Clear();

        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("원하시는 이름을 설정해주세요.");
        Console.WriteLine("(설정된 이름은 변경이 어려우니 신중히 작성해주세요!)");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("");

        string name = Console.ReadLine();

        // 스페이스바만 입력되거나 엔터만 누르면 메인메뉴로 넘어갈 수 없음
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
        Console.WriteLine("");

        Thread.Sleep(2000); // 콘솔 클리어가 너무 빨라서 설정해둠
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
                else if(player.Gold >= storeInventory[keyInput - 1].Price)
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
        
        Enemy minion = new Enemy("미니언", 2, 15, 5);
        Enemy voiding = new Enemy("공허충", 3, 10, 9);
        Enemy seigeMinion = new Enemy("대포미니언", 5, 25, 8);

        enemy.Add(minion);
        enemy.Add(voiding);
        enemy.Add(seigeMinion);
        
        Random random = new Random();
        int enemycount = random.Next(1, 5);
        
        Console.Clear();

        ConsoleUtility.ShowTitle("■ Battle!! ■");
        Console.WriteLine("");
        // 1~4 마리의 몬스터가 랜덤하게 등장, 표시되는 순서는 랜덤
        for(int i = 0; i < enemycount; i++)
        {
            int randomEncount = random.Next(enemy.Count);
            Enemy randomEnemy = enemy[randomEncount];
            Console.WriteLine($"{i + 1} : LV. {randomEnemy.Level} {randomEnemy.Name} Hp {randomEnemy.Hp}") ;
        }

        // 장비 착용 시 증가되는 Hp 표현
        int bonusHp = inventory.Select(item => item.IsEquipped ? item.Hp : 0).Sum();


        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{(player.Level.ToString("00"))} {player.Name} {player.Job}\nHp {player.Hp + bonusHp}/{player.Hp + bonusHp}");
        Console.WriteLine("");
        Console.WriteLine("1. 공격");
        Console.WriteLine("2. 스킬");
        Console.WriteLine("3. 아이템");

        int KeyInput = ConsoleUtility.PromptMenuChoice(1, 3);
        // switch 함수
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
        // 데미지 만큼 체력 감소
        // randomEnemy가 죽었을 때 IsDead true, dead 문자열 활성화, enemy 글자색 변경
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

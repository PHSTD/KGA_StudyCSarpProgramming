﻿using System.Diagnostics;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;

namespace Day250319_1;

class Program
{

    struct PlayerPos
    {
        public int x;
        public int y;
    }
    
    static void Main()
    {
        Console.Clear();
        
        Console.WriteLine("----- 디지몬 ----- ");
        Console.WriteLine("1. 디지털 세계로 진입(시작) ");
        Console.WriteLine("2. 디지바이스(설정) ");
        Console.WriteLine("0. 디지털 세계 나가기(종료) ");

        PlayerPos playerPos;
        playerPos.x = 0;
        playerPos.y = 0;

        bool gameOver = false;
        while (!gameOver)
        {
            // 1) 문자열로 먼저 입력을 받는다.
            string input = Console.ReadLine();

            // 2) TryParse()가 false이면 변환에 실패한 것이므로 OverRange() 호출
            if (!int.TryParse(input, out int z))
            {
                OverRange();
                continue; 
            }

            switch (z)
            {
                case 1:
                    Start(playerPos, gameOver);
                    break;
                
                case 2:
                    // 디지바이스 설정
                    break;
                
                case 0:
                    End();
                    // 필요 시 여기에서 gameOver = true; 로 바꿔주면 while문 탈출
                    break;
                    
                default:
                    OverRange();
                    break;
            }
        }
    }




    static void Start(PlayerPos playerPos, bool gameOver)
    {
        Console.CursorVisible = false;
        Render(playerPos, gameOver);
    }
    
    static void End()
    {
        Console.Clear();
        Console.Write("게임이 종료 되었습니다.");
        Environment.Exit(0);
    }

    static void Render(PlayerPos playerPos, bool gameOver)
    {
        Console.Clear();
        int myClLv = 2;
        bool typeCH = true;
        
        Console.WriteLine("몇 단계로 시작하시겠습니까?");
        Console.WriteLine("1. 레벨 1(클리어)");
        Console.WriteLine("2. 레벨 2(클리어)");
        Console.WriteLine("3. 레벨 3");
        Console.WriteLine("4. 레벨 4(실행 불가)");
        Console.WriteLine("5. 레벨 5(실행 불가)");
        Console.WriteLine("0. 메인으로");
        
        while (true)
        {
            string input = Console.ReadLine();
            
            // 1) 유효한 int인지 먼저 판단
            // 2) TryParse()가 false면 숫자로 변환 실패 → OverRange() 처리
            if (!int.TryParse(input, out int z))
            {
                OverRange();
                continue;
            }

            // 변환에 성공한 경우, z의 값에 따라 분기
            if (z == 1 || z == 2 || z == 3 || z == 4 || z == 5)
            {
                // 클리어하지 않은 맵은 내부에서 막는다고 가정
                MapLevel(z, myClLv, playerPos, gameOver);
            }
            else if (z == 0)
            {
                // 메인 화면으로 이동
                Main();
                // break; // 계속 while 문을 돌리고 싶지 않다면 break 처리
            }
            else
            {
                // 범위를 벗어난 입력
                OverRange();
            }
        }
    }

        
    // 지정하기 않은 맵 이나 키를 선택한 경우
    static void OverRange()
    {
        Console.WriteLine("범위를 벗어났습니다.");
    }
    
    
    // 클리어 하지 않음 맵
    static void NoNextMap()
    {
        Console.WriteLine("지금은 실행할 수 없는 맵 입니다.");
    }
    
    static bool MapLevelCheck(int mapLevel, int myClLv)
    {
        if (mapLevel > ++myClLv)
        {
            NoNextMap();
            return false;
        }

        return true;
    }
    
    static void MapLevel(int level, int myClLv, PlayerPos playerPos,bool gameOver)
    {
        bool bol = MapLevelCheck(level, myClLv);

        if (bol)
        {
            char[,] map = CreateMapPrint(level);
            PlayerPrint(level, playerPos);
            ConsoleKey key = Input();
            Update(key, ref playerPos, map, ref gameOver);
        }
    }

    static void PlayerPrint(int level, PlayerPos playerPos)
    {
        // 플레이어 위치 설정
        Console.SetCursorPosition(playerPos.x, playerPos.y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write('▼');
        Console.ResetColor(); 
        
    }

    static void MapPrint(char[,] map)
    {
        
        // 예시: 맵 데이터 출력
        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                Console.Write(map[row, col]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    static char[,] CreateMapPrint(int level)
    {
        Console.Clear();
        
        char[,] map = new char[,] { };
        
        
        switch (level)
        {
            case 1:
                
                map = new char[15,20]{
                    {'@','@','@','@','@','@','@','@','@','@','@','@','@','@','@','@','@','@','@','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','@'},
                    {'@','@','@','@','@','@','@','@','@','@','@','@','@','@','@','@','@','@','@','@'},
                };

                
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            
            default:
                OverRange();
                break;
        }
        
        return map;
    }
    
    static ConsoleKey Input()
    {
        return Console.ReadKey(true).Key;
    }
    
    static void Update(ConsoleKey key, ref PlayerPos playerPos, char[,] map, ref bool gameOver)
    {
        Move(key, ref playerPos, map);
        if (gameOver)
        {
            End();
        }
    }

    static void Move(ConsoleKey key, ref PlayerPos playerPos, char[,] map)
    {
        PlayerPos targetPos;
        PlayerPos overPos;

        switch (key)
        {
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                targetPos.x = playerPos.x - 1;
                targetPos.y = playerPos.y;
                overPos.x = playerPos.x - 2;
                overPos.y = playerPos.y;
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                targetPos.x = playerPos.x + 1;
                targetPos.y = playerPos.y;
                overPos.x = playerPos.x + 2;
                overPos.y = playerPos.y;
                break;
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                targetPos.x = playerPos.x;
                targetPos.y = playerPos.y - 1;
                overPos.x = playerPos.x;
                overPos.y = playerPos.y - 2;
                break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                targetPos.x = playerPos.x;
                targetPos.y = playerPos.y + 1;
                overPos.x = playerPos.x;
                overPos.y = playerPos.y + 2;
                break;
            default:
                return;
        } 
    }
}

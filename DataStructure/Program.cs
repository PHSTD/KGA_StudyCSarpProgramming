﻿using System.ComponentModel;

namespace DataStructure;

class Program
{
    /**********************************************************************************
     * 알고리즘 (Algorithm)
     *
     * 문제를 해결하기 위해 정해진 진행절차나 방법
     * 컴퓨터에서 알고리즘은 어떠한 행동을 하기 위해서 만들어진 프로그램명령어의 집합
     **********************************************************************************/

    // <알고리즘 조건>
    // 1. 입력 : 알고리즘은 0개 이상의 입력을 가져야 함
    // 2. 출력 : 알고리즘은 최소 1개 이상의 결과를 가져야 함
    // 3. 명확성 : 수행 과정은 모호하지 않고 정확한 수단을 제공해야 함
    // 4. 유한성 : 수행 과정은 무한하지 않고 유한한 작업 이후에 정지해야 함
    // 5. 효과성 : 모든 과정은 명백하게 실행 가능해야 함
    
    /*********************************************************************
     * 자료구조(DataStructure)
     *
     * 프로그래밍에서 데이터를 효율적인 접근 및 수정을 가능케하는 자료의 조직, 관리, 저장을 의미
    *********************************************************************/
    
    // 자료구조 형태
    // 선형구조 : 자료 간 관계가 1 대 1인 구조
    //          배열, 연결리스트, 스택, 큐, 덱
    // 비선형구조 : 자료 간 관계가 1 대 다 혹은 다 대 다인 구조
    //          트리, 그래프
    
    /*********************************************************************
     * 알고리즘성능
     *
     * 효율적인 문제해결을 위해선 알고르즘의 성능을 판단할 수 있는 기준이 필요
     * 상황에 따라 적합한 알고리즘을 선택할 수 있도록 하는 기준
    *********************************************************************/
    
    // 알고리즘 평가 기준
    // 컴퓨터에서 알고리즘과 자료구조의 평가는 시간과 공간 두 자원을 얼마나 소모하는지가 효율성의 중점
    // 일반적으로 시간을 위해 공간이 희생되는 경우가 많음
    // 시간복잡도 : 알고리즘의 시간적 자원 소모량
    // 공간복잡도 : 알고리즘의 공간적 자원 소모량
    
    
    // Big-O 표기법
    // 알고리즘의 복잡도를 나타내는 점근표기법
    // 데이터 증가량에 따른 시간 증가량을 계산
    // 가장 높은 차수의 계수와 나머지 모든 항을 제거하고 표기
    // 알고리즘의 대략적인 효율을 파악할 수 있는 수단

    int Case1(int n) 
    {
        int sum = 0;
        sum = n * n;
        return sum;
    }
    int Case2(int n)
    {
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += n;
        }
        return sum;
    }
    int Case3(int n)
    {
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sum++;
            }
        }
        return sum;
    }

    // 입력값       Case1        Case2          Case3
    //     1            1           1              1
    //    10            1          10            100
    //   100            1         100         10,000
    //  1000            1        1000      1,000,000
    //     n            1           n             n²
    // Big-O         O(1)        O(n)          O(n²)


    // <수행 시간 분석>
    // 알고리즘의 성능은 상황에 따라 수행 시간이 달라짐
    // 수행 시간을 분석하는 경우 평균의 상황과 최악의 상황을 기준으로 평가함
    // 최선의 상황의 경우 알고리즘의 성능을 분석하는 수단으로 적합하지 않음

    int FindIndex(int[] array, int value)
    {
        for (int i = 0; i <  array.Length; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }
        return -1;
    }
    // 최선   평균   최악
    // O(1)   O(n)   O(n)

    
    
    static void Main(string[] args)
    {
        
        
        // List list = new List();
        // list.ListTest();

        // Stack stack = new Stack();
        // stack.Stacks();

        // Queue queue = new Queue();
        // queue.Queues();


        // Dictionary dictionary = new Dictionary();
        // dictionary.MyDictionary();
        
        
        // 그래프
        // Graph graph = new Graph();
        // ver 1
        // Graph.GraphNode<int> node0 = new Graph.GraphNode<int>(0);
        // Graph.GraphNode<int> node1 = new Graph.GraphNode<int>(1);
        // Graph.GraphNode<int> node2 = new Graph.GraphNode<int>(2);
        // Graph.GraphNode<int> node3 = new Graph.GraphNode<int>(3);
        // Graph.GraphNode<int> node4 = new Graph.GraphNode<int>(4);
        // Graph.GraphNode<int> node5 = new Graph.GraphNode<int>(5);
        // Graph.GraphNode<int> node6 = new Graph.GraphNode<int>(6);
        // Graph.GraphNode<int> node7 = new Graph.GraphNode<int>(7);
        //
        // node0.AddEdge(node3);
        // node3.AddEdge(node0);
        // node0.AddEdge(node4);
        // node4.AddEdge(node0);
        
        // ver 2
        // graph.CreateGraph1();
        // graph.CreateGraph2();

    }
}

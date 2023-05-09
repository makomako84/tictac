﻿namespace MakoSystems.TicTac.Core;

public class RuleService : IRuleService
{ 
    private readonly IFrameContextBuilder _frameContextBuilder;
    public RuleService(
        IFrameContextBuilder frameContextBuilder) 
    { 
        _frameContextBuilder = frameContextBuilder;
    }

    public object Capture(CaptureItemCommand captureItemCommand)
    {
        UniqueObjectType itemType = _frameContextBuilder.Get(captureItemCommand.X, 
            captureItemCommand.Y);
        if(itemType == UniqueObjectType.E)
        {
            _frameContextBuilder.Capture(captureItemCommand);
            if(CheckWinningState())
            {
                Console.WriteLine("win check: win");
            }
            else
            {
                Console.WriteLine("win check: nothing");
            }
            return "Success";
        }
        else
        {
            // some handling here
            return "Error, попытка занять занятую клетку";
        }
    }

    private bool CheckWinningState()
    {
        return CheckHorizontalWin() || CheckVerticalWin() || CheckDiagonalWin();
    }

    private bool CheckHorizontalWin()
    {
        IFramable captureItems = _frameContextBuilder.CaptureItems;
        bool winningState = false;
        for (int y = 0; y < captureItems.Height; y++)
        {
            winningState = true;
            CaptureItem last = (CaptureItem)captureItems.Get(0, y);
            UniqueObjectType winObjectType = last.UniqueObjectType;
            if (winObjectType == UniqueObjectType.E)
            {
                winningState = false;
                // cell is captured by E, skip to next Y loop cycle
                continue;
            }

            for (int x = 1; x < captureItems.Width; x++)
            {
                CaptureItem next = (CaptureItem)captureItems.Get(x, y);
                winningState &= winObjectType == next.UniqueObjectType;
            }
            if (winningState == true)
            {
                break;
            }
        }
        return winningState;
    }

    private bool CheckVerticalWin()
    {
        IFramable captureItems = _frameContextBuilder.CaptureItems;
        bool winningState = false;
        for (int x = 0; x < captureItems.Width; x++)
        {
            winningState = true;
            CaptureItem last = (CaptureItem)captureItems.Get(x, 0);
            UniqueObjectType winObjectType = last.UniqueObjectType;
            if (winObjectType == UniqueObjectType.E)
            {
                winningState = false;
                // cell is captured by E, skip to next Y loop cycle
                continue;
            }

            for (int y = 1; y < captureItems.Height; y++)
            {
                CaptureItem next = (CaptureItem)captureItems.Get(x, y);
                winningState &= winObjectType == next.UniqueObjectType;
            }
            if (winningState == true)
            {
                break;
            }
        }
        return winningState;
    }

    private bool CheckDiagonalWin()
    {
        IFramable captureItems = _frameContextBuilder.CaptureItems;
        bool winningState = false;

        CaptureItem last1 = (CaptureItem)captureItems.Get(0, 0);
        UniqueObjectType winObject1Type = last1.UniqueObjectType;

        CaptureItem last2 = (CaptureItem)captureItems.Get(captureItems.Width - 1, 0);
        UniqueObjectType winObject2Type = last2.UniqueObjectType;

        if(winObject1Type == UniqueObjectType.E && winObject2Type == UniqueObjectType.E)
        {
            return winningState;
        }



        if (winObject1Type != UniqueObjectType.E)
        {
            winningState = true;
            for (int x = 1; x < captureItems.Width; x++)
            {
                CaptureItem next = (CaptureItem)captureItems.Get(x, x);
                winningState &= winObject1Type == next.UniqueObjectType;
            }
            if (winningState == true)
            {
                return winningState;
            }
        }        


        if (winObject2Type != UniqueObjectType.E)
        {
            winningState = true;
            for (int x = captureItems.Width - 2; x >= 0; x--)
            {
                // 1,1; 0,2
                CaptureItem next = (CaptureItem)captureItems.Get(x, captureItems.Width - x - 1);
                winningState &= winObject2Type == next.UniqueObjectType;
            }
            if (winningState == true)
            {
                return winningState;
            }
        }
        return winningState;
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MakoSystems.TicTac.Core;
public class FrameContextBuilder : IFrameContextBuilder
{
    private readonly IFrame _frame;
    private readonly IList<CaptureItem> _captureItems;

    public FrameContextBuilder(IFrame frame)
    {
        _frame = frame;
        _captureItems = new List<CaptureItem>();
    }

    public void Capture(int x, int y, UniqueObjectType objectType)
    {
        var captureItem = _captureItems.First(item => item.X == x && item.Y == y);
        captureItem.UniqueObjectType = objectType;
    }

    public void Initialize()
    {
        for (int x = 0; x < _frame.Width; x++)
        {
            for (int y = 0; y < _frame.Height; y++)
            {
                var captureItem = CaptureItem.CreateEmptyItem(x, y);
                _captureItems.Add(captureItem);
                _frame.Set(x, y, (int)captureItem.UniqueObjectType);
            }
        }
    }

    public UniqueObjectType Get(int x, int y)
    {
        var item = _captureItems.First(item => item.X == x && item.Y == y).UniqueObjectType;
        return item;
    }
}

public interface IFrameContextBuilder
{
    public void Capture(int x, int y, UniqueObjectType objectType);
    public UniqueObjectType Get(int x, int y);
    public void Initialize();
}
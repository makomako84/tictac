using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using System.Linq;
using System.Runtime.InteropServices;

namespace MakoSystems.TicTac.Core;

public class Frame : IFrame, IEnumerable
{
    private int _width, _height;
    private FrameItem2[] _frames;
    private const int _freeId = -1;

    public int Width => _width;
    public int Height => _height;
    public FrameItem2[] Frames => _frames;

    public Frame(int width, int height)
    {
        _width = width;
        _height = height;
        _frames = new FrameItem2[width * height];
    }
    public Frame(FrameItem2[] frames, int width, int height)
    {
        _frames = frames;
        _width = width;
        _height = height;
    }

    public IEnumerator GetEnumerator()
    {
        return _frames.GetEnumerator();
    }

    FrameItem2 IFrame.Get(int x, int y)
    {
        return _frames[GetIndex(x,y)];
    }
    
    void IFrame.Set(int x, int y, int objectId)
    {
        _frames[GetIndex(x,y)].ObjectId = objectId;
    }
    
    void IFrame.Set(int x, int y, int width, int height, int objectId)
    {
        for(int ix = x; ix < x+width; ix++)
        {
            for(int iy = x; iy < y+width; iy++)
            {
                _frames[GetIndex(ix, iy)].ObjectId = objectId;
            }
        }
    }
    
    void IFrame.Free(int x, int y)
    {
        ((IFrame)this).Free(x,y);
    }

    void IFrame.Free(int x, int y, int width, int height)
    {
        ((IFrame)this).Free(x, y, width, height);
    }

    void IFrame.Initialize(IEnumerable source)
    {
        _frames = (FrameItem2[])source;
    }

    void IFrame.Intialize()
    {
        for(int x = 0; x < _width; x++)
        {
            for(int y =0; y < _height; y++)
            {
                _frames[GetIndex(x, y)] = new FrameItem2(x, y) {ObjectId = _freeId};
            }
        }
    }


    internal static int GetIndex(int width, int height, int x, int y)
        => (y % height) * width + x % width;

    private int GetIndex(int x, int y)
    {
        return (y % _height) * _width + x % _width;
    }



    void InitTest()
    {
        for(int y=0; y < _height; y++)
        {
            for(int x=0; x < _width; x++)
            {
                _frames[GetIndex(x,y)] = new FrameItem2(x, y);
            }
        }
    }
    void InternalDebug()
    {
        for(int i=0; i< _frames.Length; i++)
        {
            var f = _frames[i];
            System.Console.WriteLine($"i: {i}, x:{f.X}, y:{f.Y}, val: {f.ObjectId}");
        }
    }
}

public interface IFrame
{
    public int Width { get;  }
    public int Height { get; }
    public FrameItem2[] Frames { get; }
    internal void Set(int x, int y, int objectId);
    internal void Set(int x, int y, int width, int height, int objectId);
    internal void Free(int x, int y);
    internal void Free(int x, int y, int width, int height);
    public FrameItem2 Get(int x, int y);
    internal void Intialize();
    [Obsolete]
    internal void Initialize(IEnumerable source);
}



public struct FrameItem2
{ 
    private int _x;
    private int _y;
    private int _objectId;
    public FrameItem2(int x, int y)
    {
        _x = x;
        _y = y;
        _objectId = -1;
    }
    public int X { get => _x; }
    public int Y { get => _y; }
    public int ObjectId
    {
        get => _objectId;
        set => _objectId = value;
    }

    public override string ToString() =>
        $"({_x},{_y}):{_objectId}";
}
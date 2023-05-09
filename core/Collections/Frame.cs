using System.Collections;

namespace MakoSystems.TicTac.Core;

public class Frame : IFrame, IEnumerable
{
    private int _width, _height;
    private FrameItem[] _frames;
    private const int _freeId = -1;

    public int Width => _width;
    public int Height => _height;
    public IFrameItem Get(int x, int y)
    {
        return _frames[this.GetIndex(x, y)];
    }

    public FrameItem[] Frames => _frames;

    public Frame(int width, int height)
    {
        _width = width;
        _height = height;
        _frames = new FrameItem[width * height];
    }
    public Frame(FrameItem[] frames, int width, int height)
    {
        _frames = frames;
        _width = width;
        _height = height;
    }

    public IEnumerator GetEnumerator()
    {
        return _frames.GetEnumerator();
    }


    
    void IFrame.Set(int x, int y, int objectId)
    {
        _frames[this.GetIndex(x,y)].ObjectId = objectId;
    }
    
    void IFrame.Set(int x, int y, int width, int height, int objectId)
    {
        for(int ix = x; ix < x+width; ix++)
        {
            for(int iy = x; iy < y+width; iy++)
            {
                _frames[this.GetIndex(ix, iy)].ObjectId = objectId;
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
        _frames = (FrameItem[])source;
    }

    void IFrame.Intialize()
    {
        for(int x = 0; x < _width; x++)
        {
            for(int y =0; y < _height; y++)
            {
                _frames[this.GetIndex(x, y)] = new FrameItem(x, y) {ObjectId = _freeId};
            }
        }
    }


    #region test
    void InitTest()
    {
        for(int y=0; y < _height; y++)
        {
            for(int x=0; x < _width; x++)
            {
                _frames[this.GetIndex(x,y)] = new FrameItem(x, y);
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
    #endregion
}
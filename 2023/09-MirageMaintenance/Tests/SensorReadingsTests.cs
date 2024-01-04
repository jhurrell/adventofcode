using Code;

namespace Tests;

public class SensorReadingsTests
{
    [Fact]
    public void Initialize()
    {
        var puzzle = new string[] {
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45",
        };

        var results = SensorReadings.Initialize(puzzle);
        Assert.Collection(results.Readings, 
            item => 
            {
                Assert.Collection(item, 
                    element => Assert.Equal(0, element),
                    element => Assert.Equal(3, element),
                    element => Assert.Equal(6, element),
                    element => Assert.Equal(9, element),
                    element => Assert.Equal(12, element),
                    element => Assert.Equal(15, element)
                );
            },
            item => {
                Assert.Collection(item, 
                    element => Assert.Equal(1, element),
                    element => Assert.Equal(3, element),
                    element => Assert.Equal(6, element),
                    element => Assert.Equal(10, element),
                    element => Assert.Equal(15, element),
                    element => Assert.Equal(21, element)
                );
            },
            item => {
                Assert.Collection(item, 
                    element => Assert.Equal(10, element),
                    element => Assert.Equal(13, element),
                    element => Assert.Equal(16, element),
                    element => Assert.Equal(21, element),
                    element => Assert.Equal(30, element),
                    element => Assert.Equal(45, element)
                );
            }         
        );
    }

    [Fact]
    public void GetDeltas_Example1()
    {
        var readings = new List<int> { 0, 3, 6, 9, 12, 15 };
        var deltas = new List<List<int>> {};
        
        SensorReadings.GetDeltas(readings, ref deltas);

        Assert.Collection(deltas, 
            set => 
            {
                Assert.Collection(set, 
                    item => Assert.Equal(3, item),
                    item => Assert.Equal(3, item),
                    item => Assert.Equal(3, item),
                    item => Assert.Equal(3, item),
                    item => Assert.Equal(3, item)
                );
            }
        );
    }

    [Fact]
    public void GetDeltas_Example2()
    {
        var readings = new List<int> { 1, 3, 6, 10, 15, 21 };
        var deltas = new List<List<int>> {};
        
        SensorReadings.GetDeltas(readings, ref deltas);

        Assert.Collection(deltas, 
            set => 
            {
                Assert.Collection(set, 
                    item => Assert.Equal(2, item),
                    item => Assert.Equal(3, item),
                    item => Assert.Equal(4, item),
                    item => Assert.Equal(5, item),
                    item => Assert.Equal(6, item)
                );
            },
            set => 
            {
                Assert.Collection(set, 
                    item => Assert.Equal(1, item),
                    item => Assert.Equal(1, item),
                    item => Assert.Equal(1, item),
                    item => Assert.Equal(1, item)
                );
            }
        );
    }    

    [Fact]
    public void GetDeltas_Example3()
    {
        var readings = new List<int> { 10, 13, 16, 21, 30, 45 };
        var deltas = new List<List<int>> {};
        
        SensorReadings.GetDeltas(readings, ref deltas);

        Assert.Collection(deltas, 
            set => 
            {
                Assert.Collection(set, 
                    item => Assert.Equal(3, item),
                    item => Assert.Equal(3, item),
                    item => Assert.Equal(5, item),
                    item => Assert.Equal(9, item),
                    item => Assert.Equal(15, item)
                );
            },
            set => 
            {
                Assert.Collection(set, 
                    item => Assert.Equal(0, item),
                    item => Assert.Equal(2, item),
                    item => Assert.Equal(4, item),
                    item => Assert.Equal(6, item)
                );
            },
            set => 
            {
                Assert.Collection(set, 
                    item => Assert.Equal(2, item),
                    item => Assert.Equal(2, item),
                    item => Assert.Equal(2, item)
                );
            }
        );
    }   

    [Fact]
    public void CalculateNextSequence_ForExample1()
    {
        var readings = new List<int> { 0, 3, 6, 9, 12, 15 };
        var deltas = new List<List<int>> {};
        
        SensorReadings.GetDeltas(readings, ref deltas);
        
        Assert.Equal(18, SensorReadings.CalculateNextSequence(readings, deltas));
    }

    [Fact]
    public void CalculateNextSequence_ForExample2()
    {
        var readings = new List<int> { 1, 3, 6, 10, 15, 21 };
        var deltas = new List<List<int>> {};
        
        SensorReadings.GetDeltas(readings, ref deltas);
        
        Assert.Equal(28, SensorReadings.CalculateNextSequence(readings, deltas));
    }   

    [Fact]
    public void CalculateNextSequence_ForExample3()
    {
        var readings = new List<int> { 10, 13, 16, 21, 30, 45 };
        var deltas = new List<List<int>> {};
        
        SensorReadings.GetDeltas(readings, ref deltas);
        
        Assert.Equal(68, SensorReadings.CalculateNextSequence(readings, deltas));
    }    


    [Fact]
    public void Whatever()
    {
        var puzzle = new string[] {
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45",
        };

        var results = SensorReadings.Initialize(puzzle);
    }
}

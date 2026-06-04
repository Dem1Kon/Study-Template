using System;
using Xunit;
using Study.LabWork1.Features.Task1;
using Assert = Xunit.Assert;

namespace Study.LabWork1.Features.Tests;

public class MyVectorTests
{
    [Fact]
    public void Constructor_ShouldSetDirectionXAndDirectionY()
    {
        var vector = new MyVector(3.5f, -2.8f);

        Assert.Equal(3.5f, vector.DirectionX);
        Assert.Equal(-2.8f, vector.DirectionY);
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        var vector = new MyVector(10, 15);
        Assert.Equal("(10, 15)", vector.ToString());

        var vector2 = new MyVector(-1.5f, 2.5f);
        Assert.Equal("(-1,5, 2,5)", vector2.ToString());
    }

    [Theory]
    [InlineData(1.6, 2, 3, 4.9, 3.6, 7.9)]
    [InlineData(-5.8, 4, 7.2, -4, -1.8, 3.2)]
    [InlineData(4, -5, -4, 1, -1, -3)]
    public void OperatorPlus_ShouldSumVectors(double x1, double x2, double y1, double y2, double expectedX, double expectedY)
    {
        var v1 = new MyVector((float)x1, (float)y1);
        var v2 = new MyVector((float)x2, (float)y2);
        var expected = new MyVector((float)expectedX, (float)expectedY);

        var result = v1 + v2;

        Assert.Equal(expected.DirectionX, result.DirectionX, 5);
        Assert.Equal(expected.DirectionY, result.DirectionY, 5);
    }

    [Theory]
    [InlineData(1.6, 2, 3, 4.9, -0.4, -1.9)]
    [InlineData(-5.8, 4, 7.2, -4, -9.8, 11.2)]
    public void OperatorMinus_ShouldSubtractVectors(double x1, double x2, double y1, double y2, double expectedX, double expectedY)
    {
        var v1 = new MyVector((float)x1, (float)y1);
        var v2 = new MyVector((float)x2, (float)y2);
        var expected = new MyVector((float)expectedX, (float)expectedY);

        var result = v1 - v2;

        Assert.Equal(expected.DirectionX, result.DirectionX, 5);
        Assert.Equal(expected.DirectionY, result.DirectionY, 5);
    }

    [Theory]
    [InlineData(1.6, 2, 3, 4.9)]
    [InlineData(-5.8, 4, 7.2, -4)]
    public void OperatorMultiply_ShouldCountVectorMultiply(double x1, double x2, double y1, double y2)
    {
        var v1 = new MyVector((float)x1, (float)y1);
        var v2 = new MyVector((float)x2, (float)y2);
        float expected = (float)x1 * (float)x2 + (float)y1 * (float)y2;

        float result = v1 * v2;

        Assert.Equal(expected, result, 2);
    }

    [Theory]
    [InlineData(3, 4)]
    [InlineData(1.6, 4)]
    public void UnaryPlus_ShouldReturnLength(double x, double y)
    {
        var v = new MyVector((float)x, (float)y);
        float length = +v;
        float expected = (float)Math.Sqrt(x * x + y * y);
        Assert.Equal(expected, length, 5);
    }

    [Fact]
    public void EqualityOperator_ShouldReturnTrueForEqualVectors()
    {
        var v1 = new MyVector(2.5f, 3.5f);
        var v2 = new MyVector(2.5f, 3.5f);

        Assert.True(v1 == v2);
    }

    [Fact]
    public void EqualityOperator_ShouldReturnFalseForDifferentVectors()
    {
        var v1 = new MyVector(1, 2);
        var v2 = new MyVector(1, 3);

        Assert.False(v1 == v2);
    }
}

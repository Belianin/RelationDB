using System;
using FluentAssertions;
using NUnit.Framework;
using RelationalDB;

namespace RelationDB.Tests;

public class RowSerializerGeneratorTests
{
    public class TestData
    {
        public Guid Id;
        public int Number;
        public string Text;
    }
    
    [Test]
    public void Should_serialize_and_deserialize_correct()
    {
        var testData = new TestData
        {
            Id = Guid.NewGuid(),
            Number = 1234,
            Text = "Hello"
        };
        
        var serializer = RowSerializerGenerator.Generate<TestData>();

        var serialized = serializer.Serialize(testData);

        var deserialized = serializer.Deserialize(serialized);

        deserialized.Should().BeEquivalentTo(testData);
    }
}
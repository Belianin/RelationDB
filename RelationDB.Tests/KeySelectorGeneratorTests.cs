using System;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using RelationalDB;

namespace RelationDB.Tests;

public class KeySelectorGeneratorTests
{
    public class DataType
    {
        [Key]
        public int Key { get; set; }
        public string Value { get; set; }
    }

    [Test]
    public void Create_correct_selector_on_correct_data_type()
    {
        var keySelector = KeySelectorGenerator.Generate<DataType>();

        var data = new DataType
        {
            Key = 10
        };

        var key = keySelector(data);
        
        Assert.AreEqual(key.GetType(), typeof(int));

        ((int) key).Should().Be(10);
    }
}
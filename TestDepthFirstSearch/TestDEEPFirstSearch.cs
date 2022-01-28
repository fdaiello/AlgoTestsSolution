using NUnit.Framework;
using AlgoTests;
using System.Collections.Generic;

namespace TestUnits
{
    public class TestDEEPFirstSearch
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DEEPFirstSearch_Test1()
        {
            Node node = new("A")
            {
                children = {
                    new ("B")
                {
                        children =
                        {
                            new ("E"),
                            new ("F")
                            {
                                children =
                                {
                                    new ("I"),
                                    new ("J")
                                }
                            }
                        }
                },
                    new ("C"),
                    new ("D")
                    {
                        children =
                        {
                            new ("G")
                            {
                                children = { new ("K") }
                            },
                            new ("H")
                        }
                    }
                }
            };

            List<string> stringList = new();
            stringList = node.DepthFirstSearch(stringList);

            List<string> expectedList = new() { "A", "B", "E", "F", "I", "J", "C", "D", "G", "K", "H" };

            Assert.AreEqual(stringList,expectedList);
        }
        [Test]
        public void DEEPFirstSearch_Test2()
        {
            Node node = new("A")
            {
                children = {
                    new ("B")
                {
                        children =
                        {
                            new ("E"),
                            new ("F")
                            {
                                children =
                                {
                                    new ("I"),
                                    new("J")
                                    {
                                        children =
                                        {
                                            new("J1"),
                                            new("J2")
                                        }
                                    }
                                }
                            }
                        }
                },
                    new ("C") {
                        children =
                        {
                            new Node("C1"),
                            new Node("C2")
                        }
                    },
                    new ("D")
                    {
                        children =
                        {
                            new ("G")
                            {
                                children = { new ("K") }
                            },
                            new ("H")
                        }
                    }
                }
            };

            List<string> stringList = new();
            stringList = node.DepthFirstSearch(stringList);

            List<string> expectedList = new() { "A", "B", "E", "F", "I", "J", "J1", "J2", "C", "C1", "C2", "D", "G", "K", "H" };

            Assert.AreEqual(stringList, expectedList);
        }
    }
}
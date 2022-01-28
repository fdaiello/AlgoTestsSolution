using System.Text.Json;
using NUnit.Framework;
using AlgoTests;

namespace TestUnits
{
	class testBST
	{
		[Test]
		public void Test1BSB()
		{
			BST bstInput = new BST(10)
			{
				left = new BST(5)
				{
					left = new BST(2)
					{ 
						left = new BST(1),
					},
					right = new BST(5)
				},
				right = new BST(15) 
				{
					left = new BST(13) 
					{ 
						right = new BST(14)
					},
					right = new BST(22)
				}
			};

			BST bstExpected = new BST(10)
			{
				left = new BST(5)
				{
					left = new BST(2)
					{
						left = new BST(1),
					},
					right = new BST(5)
				},
				right = new BST(15)
				{
					left = new BST(13)
					{
						right = new BST(14),
						left = new BST(12)
					},
					right = new BST(22)
				}
			};

			BST bstAfterInsert = bstInput.Insert(12);

			Assert.AreEqual(JsonSerializer.Serialize(bstAfterInsert), JsonSerializer.Serialize(bstExpected));

			BST bstAfterRemove = bstInput.Remove(10);

			Assert.True(!bstAfterRemove.Contains(10));

			bstAfterRemove = bstAfterRemove.Remove(22);
			Assert.True(!bstAfterRemove.Contains(22));

			bstAfterRemove = bstAfterRemove.Remove(1);
			Assert.True(!bstAfterRemove.Contains(1));

			bstAfterRemove = bstAfterRemove.Remove(15);
			Assert.True(!bstAfterRemove.Contains(15));

			bstAfterRemove = bstAfterRemove.Remove(13);
			bstAfterRemove = bstAfterRemove.Remove(14);
			bstAfterRemove = bstAfterRemove.Remove(2);
			bstAfterRemove = bstAfterRemove.Remove(12);
			bstAfterRemove = bstAfterRemove.Remove(5);
			bstAfterRemove = bstAfterRemove.Remove(5);
			Assert.True(bstAfterRemove.Contains(5));
		}
		public void Test2BSB()
		{
			BST bstInput = new BST(10)
			{
				left = new BST(5)
				{
					left = new BST(2)
					{
						left = new BST(1),
					},
					right = new BST(5)
				},
				right = new BST(15)
				{
					left = new BST(13)
					{
						right = new BST(14)
					},
					right = new BST(22)
				}
			};

			BST bstExpected = new BST(12)
			{
				left = new BST(5)
				{
					left = new BST(2)
					{
						left = new BST(1),
					},
					right = new BST(5)
				},
				right = new BST(15)
				{
					left = new BST(13)
					{
						right = new BST(14)
					},
					right = new BST(22)
				}
			};

			BST bstAfterInsert = bstInput.Insert(12);
			BST bstAfterRemove = bstAfterInsert.Remove(10);
			
			Assert.AreEqual(JsonSerializer.Serialize(bstAfterRemove), JsonSerializer.Serialize(bstExpected));

		}

		public void Test3BSB()
		{
			BST bstInput = new BST(10)
			{
				left = new BST(5)
				{
					left = new BST(2)
					{
						left = new BST(1),
					},
					right = new BST(5)
				},
				right = new BST(15)
				{
					left = new BST(13)
					{
						right = new BST(14)
					},
					right = new BST(22)
				}
			};

			BST bstExpected = new BST(12)
			{
				left = new BST(5)
				{
					left = new BST(2)
					{
						left = new BST(1),
					},
					right = new BST(5)
				},
				right = new BST(15)
				{
					left = new BST(13)
					{
						right = new BST(14)
					},
					right = new BST(22)
				}
			};

			BST bstAfterInsert = bstInput.Insert(12);
			BST bstAfterRemove = bstAfterInsert.Remove(10);

			Assert.AreEqual(bstAfterRemove.Contains(15), true);

		}

		[Test]
		public void TestCase1()
		{
			var root = new BST(10);
			root.left = new BST(5);
			root.left.left = new BST(2);
			root.left.left.left = new BST(1);
			root.left.right = new BST(5);
			root.right = new BST(15);
			root.right.left = new BST(13);
			root.right.left.right = new BST(14);
			root.right.right = new BST(22);

			root.Insert(12);

			Assert.True(root.right.left.left.value == 12);

			root.Remove(10);
			Assert.True(root.Contains(10) == false);
			Assert.True(root.value == 12);

			Assert.True(root.Contains(15));
		}
		[Test]
		public void TestCase2()
		{
			var root = new BST(10);
			root.Insert(5);
			root.Insert(15);
			root.Remove(10);

			Assert.True(!root.Contains(10));
		}
		[Test]
		public void TestCase5()
		{
			var root = new BST(1);
			root.Insert(-2);
			root.Insert(-3);
			root.Insert(-4);
			root.Remove(-2);

			Assert.True(root.Contains(1));
			root.Remove(1);
			Assert.True(!root.Contains(1));
		}


	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTests
{
	public class BST
	{
		public int value;
		public BST left;
		public BST right;

		public BST(int value)
		{
			this.value = value;
		}

		public BST Insert(int value)
		{
			if ( value < this.value)
			{
				if ( this.left == null )
				{
					this.left = new BST(value);
				}
				else
				{
					this.left.Insert(value);
				}
			}
			else
			{
				if ( this.right == null)
				{
					this.right = new BST(value);
				}
				else
				{
					this.right.Insert(value);
				}
			}
			return this;
		}

		public bool Contains(int value)
		{
			if ( this.value == value)
			{
				return true;
			}
			else if ( value < this.value && this.left != null )
			{
				return this.left.Contains(value);
			}
			else if ( this.right != null )
			{
				return this.right.Contains(value);
			}

			return false;
		}

		public BST RemoveChild(int value)
		{
			if ( this.value == value)
			{
				if (this.right != null) 
				{
					int minValue = this.right.MinValue();
					this.right = this.right.RemoveChild(minValue);
					this.value = minValue;
				}
				else if ( this.left != null)
				{
					int maxValue = this.left.MaxValue();
					this.left = this.left.RemoveChild(maxValue);
					this.value = maxValue;
				}
				else
				{
					return null;
				}
			}
			else if ( value < this.value)
			{
				this.left = this.left.RemoveChild(value);
			}
			else
			{
				this.right = this.right.RemoveChild(value);
			}
			return this;
		}
		public BST Remove(int value)
		{
			if ( this.left == null && this.right == null)
			{
				return this;
			}
			else
			{
				return this.RemoveChild(value);
			}
		}
		private int MinValue()
		{
			if (this.left != null)
			{
				return this.left.MinValue();
			}
			else
			{
				return this.value;
			}
		}
		private int MaxValue()
		{
			if (this.right != null)
			{
				return this.right.MaxValue();
			}
			else
			{
				return this.value;
			}
		}

	}
}

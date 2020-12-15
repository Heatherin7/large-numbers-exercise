using System.Collections.Generic;

namespace LargeNumbers
{
	public class LargeNumberFilter
	{
		/// <summary>
		/// Returns an array containing all of the elements of the input array that are greater than or equal the maxValue parameter 
		/// </summary>
		/// <param name="values"></param>
		/// <param name="maxValue"></param>
		/// <returns></returns>
		public int[] FilterNumbers(int[] values, int maxValue)
		{
			if(values == null)
            {
				return new int[0];
            }

			var largeValues = new List<int>();

			foreach(int value in values)
            {
				if(value >= maxValue)
                {
					largeValues.Add(value);
				}
            }
			
			return largeValues.ToArray();
		}
	}
}

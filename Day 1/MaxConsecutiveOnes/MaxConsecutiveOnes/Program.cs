using System;

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        // Test case 1
        int[] nums1 = { 1, 1, 0, 1, 1, 1 };
        int result1 = solution.FindMaxConsecutiveOnes(nums1);
        Console.WriteLine($"Test case 1: Expected 3, Got {result1}");

        // Test case 2
        int[] nums2 = { 1, 0, 1, 1, 0, 1 };
        int result2 = solution.FindMaxConsecutiveOnes(nums2);
        Console.WriteLine($"Test case 2: Expected 2, Got {result2}");

        // Test case 3 - all ones
        int[] nums3 = { 1, 1, 1, 1, 1 };
        int result3 = solution.FindMaxConsecutiveOnes(nums3);
        Console.WriteLine($"Test case 3: Expected 5, Got {result3}");

        // Test case 4 - all zeros
        int[] nums4 = { 0, 0, 0, 0 };
        int result4 = solution.FindMaxConsecutiveOnes(nums4);
        Console.WriteLine($"Test case 4: Expected 0, Got {result4}");

        // Test case 5 - alternating 1s and 0s
        int[] nums5 = { 1, 0, 1, 0, 1, 0 };
        int result5 = solution.FindMaxConsecutiveOnes(nums5);
        Console.WriteLine($"Test case 5: Expected 1, Got {result5}");
    }
}

public class Solution
{
    int maxCount = 0;
    int currentCount = 0;
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        maxCount = 0;
        currentCount = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                currentCount++;
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                }
            }
            else
            {
                currentCount = 0;
            }
        }
        return maxCount;
    }
}


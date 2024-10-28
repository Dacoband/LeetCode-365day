using System;

public class Solution
{
    public bool PredictTheWinner(int[] nums)
    {
        int[,] memo = new int[nums.Length, nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                memo[i, j] = int.MinValue;
            }
        }

        int scoreLast = Score(nums, 0, nums.Length - 1, memo);
        return scoreLast >= 0;
    }
    private int Score(int[] nums, int start, int end, int[,] memo)
    {
        if (start == end) return nums[start];
        if (memo[start, end] != int.MinValue) return memo[start, end];

        int pickStart = nums[start] - Score(nums, start + 1, end, memo);
        int pickEnd = nums[end] - Score(nums, start, end - 1, memo);

        memo[start, end] = Math.Max(pickStart, pickEnd);
        return memo[start, end];
    }



    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            int[] nums1 = { 1, 5, 2 };
            Console.WriteLine("Test Case 1: " + solution.PredictTheWinner(nums1)); // Expected output: False

            int[] nums2 = { 1, 5, 233, 7 };
            Console.WriteLine("Test Case 2: " + solution.PredictTheWinner(nums2)); // Expected output: True

            int[] nums3 = { 1, 3, 1 };
            Console.WriteLine("Test Case 3: " + solution.PredictTheWinner(nums3)); // Expected output: True

            int[] nums4 = { 5, 3, 4, 5 };
            Console.WriteLine("Test Case 4: " + solution.PredictTheWinner(nums4)); // Expected output: True

            int[] nums5 = { 2, 4, 55, 6, 8 };
            Console.WriteLine("Test Case 5: " + solution.PredictTheWinner(nums5)); // Expected output: False
        }
    }
}

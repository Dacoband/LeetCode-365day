# Intuition

Khi đọc đề bài, ta nhận thấy yêu cầu của bài toán là tìm số lượng `1` liên tiếp dài nhất trong một mảng nhị phân. Một ý tưởng trực quan là duyệt qua từng phần tử trong mảng và đếm các phần tử `1` liên tiếp. Mỗi khi gặp một phần tử `0`, chúng ta sẽ đặt lại bộ đếm và cập nhật giá trị nếu số `1` liên tiếp dài hơn giá trị lớn nhất đã ghi nhận.

# Approaches

1. Khởi tạo biến `maxCount` để lưu trữ số lượng `1` liên tiếp dài nhất tìm được cho đến thời điểm hiện tại và biến `currentCount` để lưu trữ số `1` liên tiếp hiện tại.
2. Duyệt qua từng phần tử trong mảng `nums`:
   - Nếu phần tử hiện tại là `1`, tăng `currentCount` lên 1 vì đã tìm thấy một `1` liên tiếp nữa.
   - So sánh `currentCount` với `maxCount`, nếu `currentCount` lớn hơn `maxCount`, gán giá trị `currentCount` cho `maxCount` để cập nhật số lượng `1` liên tiếp dài nhất.
   - Nếu phần tử hiện tại là `0`, đặt lại `currentCount` về `0` vì chuỗi `1` liên tiếp đã bị ngắt.
3. Sau khi duyệt hết mảng, trả về `maxCount`, giá trị lưu trữ số lượng `1` liên tiếp dài nhất.

# Complexity 
- Time complexity:

Độ phức tạp thời gian là $$O(n)$$ vì chúng ta chỉ cần duyệt qua từng phần tử một lần.

- Space complexity:

Độ phức tạp không gian là $$O(1)$$ vì chúng ta chỉ sử dụng một số biến để lưu trữ kết quả, không cần thêm không gian cho dữ liệu phụ.

# Code
```csharp
public class Solution {
    int maxCount = 0;          // Biến lưu số lượng 1 liên tiếp dài nhất
    int currentCount = 0;      // Biến lưu số lượng 1 liên tiếp hiện tại

    public int FindMaxConsecutiveOnes(int[] nums) 
    {
        for (int i = 0; i < nums.Length; i++)   // Duyệt qua từng phần tử trong mảng
        {
            if (nums[i] == 1)                   // Nếu phần tử là 1
            {
                currentCount++;                 // Tăng currentCount lên 1
                if (currentCount > maxCount)    // Kiểm tra nếu currentCount lớn hơn maxCount
                {
                    maxCount = currentCount;    // Cập nhật maxCount nếu tìm thấy chuỗi dài hơn
                }
            }
            else                                // Nếu phần tử là 0
            {
                currentCount = 0;               // Đặt lại currentCount về 0
            }
        }
        return maxCount;                        // Trả về maxCount sau khi duyệt hết mảng
    }
}

#Link
 [Link LeetCode]("https://leetcode.com/problems/max-consecutive-ones/submissions/1435321150")

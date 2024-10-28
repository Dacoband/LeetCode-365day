# Predict The Winner - Giải Pháp

## Mô Tả Bài Toán

Trong bài toán này, bạn được cung cấp một mảng `nums` đại diện cho điểm số của các quân bài mà hai người chơi sẽ thay phiên nhau chọn. Mỗi người chơi có thể chọn một quân bài ở đầu hoặc cuối của mảng. Mục tiêu là xác định liệu người chơi đầu tiên có thể thắng với điểm số cao hơn hoặc bằng người chơi thứ hai hay không, với điều kiện cả hai người chơi đều chọn các quân bài tối ưu.

## Ý Tưởng Ban Đầu

Đầu tiên, chúng ta có thể nghĩ đến việc tính toán tổng điểm chênh lệch giữa hai người chơi. Nếu người chơi đầu tiên có thể đạt được điểm số không thấp hơn người chơi thứ hai, thì người chơi đầu tiên sẽ thắng. Do đó, chúng ta cần tính điểm chênh lệch tối ưu mà người chơi đầu tiên có thể đạt được.

## Phương Pháp Giải Quyết

Chúng ta sẽ sử dụng kỹ thuật **quy hoạch động** (dynamic programming) kết hợp với **tối ưu hóa ghi nhớ** (memoization) để giảm bớt chi phí tính toán:

1. **Hàm PredictTheWinner**: Hàm chính để kiểm tra xem người chơi đầu tiên có thể thắng hay không.
   - Tạo một mảng `memo` để ghi nhớ các kết quả đã tính toán trước đó nhằm tránh tính toán lại, giúp tăng hiệu suất.
   - Gọi hàm phụ `Score` để tính toán điểm chênh lệch tối ưu từ vị trí đầu đến vị trí cuối mảng `nums`.

2. **Hàm Score**:
   - Đây là hàm phụ để tính toán điểm chênh lệch tối ưu giữa hai người chơi khi họ thay phiên chọn quân bài từ đầu hoặc cuối.
   - Nếu người chơi đầu tiên chọn quân bài ở vị trí `start`, điểm số còn lại sẽ là `nums[start] - Score(...)`, và tương tự nếu chọn quân bài ở `end`.
   - Ghi lại kết quả vào `memo` để tránh tính toán lại trong các lần gọi tiếp theo.

## Độ Phức Tạp

- **Độ phức tạp thời gian**: $$O(n^2)$$, trong đó `n` là độ dài của mảng `nums`. Do mỗi đoạn con của mảng có thể được tính một lần nhờ kỹ thuật ghi nhớ.
- **Độ phức tạp không gian**: $$O(n^2)$$, do chúng ta cần lưu trữ bảng `memo` có kích thước `n x n`.

## Code

```csharp
public class Solution {
    public bool PredictTheWinner(int[] nums) {
        int[,] memo = new int[nums.Length, nums.Length];
        for(int i = 0; i < nums.Length; i++)
        {
            for(int j = 0; j < nums.Length; j++)
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
}
```

## Hướng Dẫn Chạy Code

Bạn có thể copy đoạn mã trên và chạy trực tiếp trong C# bằng cách tạo một chương trình console. Để kiểm tra kết quả, bạn có thể tạo hàm `Main` để chạy các bộ dữ liệu kiểm thử.


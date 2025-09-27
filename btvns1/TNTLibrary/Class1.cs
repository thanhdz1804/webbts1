using System;

namespace TNTLibrary
{
    public class HappinessCalculator
    {
        // Property để nhập
        public string InputName { get; set; }

        // Property để han
        public int HappinessIndex { get; private set; }

        // Hàm xử lý
        public void Calculate()
        {
            if (string.IsNullOrEmpty(InputName))
            {
                HappinessIndex = 0;
                return;
            }

            int sum = 0;
            foreach (char c in InputName.ToUpper())
            {
                if (char.IsLetter(c))
                    sum += (c - 'A' + 1); // A=1, B=2,...
            }

            HappinessIndex = (sum * 7) % 100; // công thức độc lạ
        }

        // Hàm trả kết quả nhanh
        public string GetMessage()
        {
            return $"Xin chào {InputName}, chỉ số vui vẻ của bạn là {HappinessIndex}/100 😊";
        }
    }
}

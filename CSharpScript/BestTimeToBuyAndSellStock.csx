/*
You are given an array prices where prices[i] is the price of a given stock on the ith day.
You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

Example 1:
    Input: prices = [7,1,5,3,6,4]
    Output: 5
    Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
    Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
*/
public class Solution {
    public int MaxProfit(int[] prices) {
        var maxProfit = 0;

        for(var i = 0; i < prices.Count(); i++)
        {
            var sell = prices[i];
            for(var j = 0; j < i; j++)
            {
                var buy = prices[j];
                if(sell > buy) {
                    var profit = sell - buy;

                    if(maxProfit < profit) 
                    {
                        Console.WriteLine($"{sell.ToString()} - {buy.ToString()}");
                        maxProfit = profit;
                    }
                }
            }
        }

        return maxProfit;
    }

    // 4 2 9 1 5 => 2, 9, 7  / 1, 5, 4
    // 4 2 9 3 12 => 2, 9, 7 / 3, 12, 9 / 2, 12, 10
    public int MaxProfitImproved(int[] prices) 
    {
        var maxProfit = 0;
        var minValue = Int32.MaxValue;

        for(var i = 0; i < prices.Count(); i++)
        {
            var price = prices[i];

            if(minValue > price) {
                minValue = price;
            } else {
                var profit = price - minValue;

                if(maxProfit < profit)
                {
                    maxProfit = profit;
                }
            }
        }

        return maxProfit;
    }
}

var profit = new Solution().MaxProfit([7,1,5,3,6,4]);

Console.WriteLine(profit);
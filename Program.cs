/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Text;
using System.Collections.Generic;
namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                IList<IList<int>> out1 = new List<IList<int>>(); // Create a list to store lists of integer ranges.
                int i = 0; // Initialize an integer variable 'i' to 0.

                // Check if the 'lower' bound is less than or equal to the first element in the 'nums' array minus 1.
                if (lower <= nums[0] - 1)
                {
                    out1.Add(new List<int> { lower, nums[0] - 1 }); // Add a range from 'lower' to 'nums[0] - 1' to 'out1'.
                }

                // Iterate through the 'nums' array, comparing adjacent elements to find gaps.
                for (i = 0; i < nums.Length - 1; i++)
                {
                    // Check if there is a gap between 'nums[i] + 1' and 'nums[i + 1] - 1'.
                    if (nums[i] + 1 <= nums[i + 1] - 1)
                    {
                        out1.Add(new List<int> { nums[i] + 1, nums[i + 1] - 1 }); // Add the gap as a range to 'out1'.
                    }
                }

                // Check if there is a gap between the last element in 'nums' and the 'upper' bound.
                if (nums[i] + 1 <= upper)
                {
                    out1.Add(new List<int> { nums[i] + 1, upper }); // Add a range from 'nums[i] + 1' to 'upper' to 'out1'.
                }

                return out1; // Return the list of integer ranges 'out1'.

            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Create a character array 'stack' to act as a stack for storing opening brackets.
                char[] stack = new char[s.Length];

                // Initialize a variable 'j' to represent the top of the stack, initially set to -1.
                int j = -1;

                // Iterate through each character in the input string 's'.
                for (int i = 0; i < s.Length; i++)
                {
                    // Check if the current character is an opening bracket ('{', '[', or '(').
                    if (s[i] == '{' || s[i] == '[' || s[i] == '(')
                    {
                        j++; // Increment 'j' to simulate pushing the opening bracket onto the stack.
                        stack[j] = s[i]; // Store the opening bracket in the stack.
                    }
                    else
                    {
                        // Check if there's a mismatch because a closing bracket is encountered without a corresponding opening bracket.
                        if (j == -1)
                        {
                            return false; // Return 'false' because there's no matching opening bracket.
                        }

                        // Check if the current closing bracket matches the last opening bracket on the stack.
                        if ((stack[j] == '(' && s[i] == ')') || (stack[j] == '[' && s[i] == ']') || (stack[j] == '{' && s[i] == '}'))
                        {
                            stack[j] = '\0'; // Mark the matched opening bracket as null ('\0') to indicate it's consumed.
                            j--; // Decrement 'j' to simulate popping the opening bracket from the stack.
                        }
                        else
                        {
                            return false; // Return 'false' because there's a mismatch between opening and closing brackets.
                        }
                    }
                }

                // Check if the stack is empty (all opening brackets matched with closing brackets).
                if (j == -1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                int profit = 0;     // Initialize a variable 'profit' to keep track of the maximum profit.
                int buy = prices[0]; // Initialize a variable 'buy' to store the price at which you bought a stock, starting with the first price in the 'prices' array.

                // Iterate through the 'prices' array starting from the second element (index 1).
                for (int i = 1; i < prices.Length; i++)
                {
                    // Check if selling the stock at the current price 'prices[i]' results in a higher profit.
                    if (prices[i] - buy > profit)
                    {
                        profit = prices[i] - buy; // Update 'profit' to the new, higher profit.
                    }
                    else
                    {
                        // If the current price 'prices[i]' is lower than the previous 'buy' price,
                        // update 'buy' to the new, lower price because it may be a better buying opportunity.
                        if (prices[i] < buy)
                            buy = prices[i];
                    }
                }

                return profit; // Return the maximum profit that can be achieved.

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                for (int i = 0, j = s.Length - 1; i <= j; i++, j--)
                {
                    // Check if the characters at positions 'i' and 'j' in the string 's' form a valid symmetric pair.
                    if (!((s[i] == '1' && s[j] == '1') || (s[i] == '8' && s[j] == '8') || (s[i] == '6' && s[j] == '9') || (s[i] == '9' && s[j] == '6')))
                    {
                        return false; // If not, return 'false' because the string is not symmetric.
                    }
                }

                return true; // If the loop completes without finding any invalid pairs, return 'true' because the string is symmetric.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Create a dictionary 'countN' to store the count of each unique integer in the 'nums' array.
                Dictionary<int, int> countN = new Dictionary<int, int>();

                // Initialize a variable 'sum' to keep track of the sum of counts for each unique integer.
                int sum = 0;

                // Iterate through each integer 'num' in the 'nums' array.
                foreach (int num in nums)
                {
                    // Check if the 'countN' dictionary already contains 'num' as a key.
                    if (countN.ContainsKey(num))
                    {
                        // If 'num' is already in the dictionary, increment its count and add the current count to 'sum'.
                        sum += countN[num]++;
                    }
                    else
                    {
                        // If 'num' is not in the dictionary, add it as a key with a count of 1.
                        countN[num] = 1;
                    }
                }

                // Return the final 'sum', which represents the sum of counts for each unique integer in 'nums'.
                return sum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Sort the 'nums' array in ascending order.
                Array.Sort(nums);

                // Initialize variables 'max' to store the maximum value and 'c' as a counter.
                int max = nums[nums.Length - 1];
                int c = 1;

                // Iterate through the 'nums' array from the end to the beginning.
                for (int i = nums.Length - 1; i > 0; i--)
                {
                    // Check if 'c' has reached 3, indicating that we've found the third distinct largest element.
                    if (c == 3)
                    {
                        break; // Exit the loop as we have found the result.
                    }

                    // Compare the current element 'nums[i]' with the previous element 'nums[i - 1]'.
                    if (nums[i] != nums[i - 1])
                    {
                        c++; // Increment the counter 'c' when a distinct element is encountered.

                        // Check if 'c' is equal to 2, indicating that we've found the second largest element. This will be useful when there are only 2 distinct elements
                        if (c == 2)
                        {
                            continue; // Skip the second largest element and continue with the loop.
                        }

                        // Update 'max' to the value of the previous element 'nums[i - 1]'.
                        max = nums[i - 1];
                    }
                }

                // Return the 'max' value, which represents the third largest distinct element in the sorted 'nums' array.
                return max;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Create a list of strings 'output' to store the results.
                IList<string> output = new List<string>();

                // Iterate through the characters in the 'currentState' string up to the second-to-last character.
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    // Check if the current character 'currentState[i]' and the next character 'currentState[i+1]' are both '+'.
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // If a "++" pattern is found, create a new string by replacing it with "--",
                        // and add it to the 'output' list.
                        output.Add(currentState.Substring(0, i) + "--" + currentState.Substring(i + 2));
                    }
                }

                // Return the 'output' list containing strings with "++" replaced by "--".
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            // Write your code here and you can modify the return value according to the requirements
            // Create a StringBuilder 'sb' to efficiently build a new string.
            StringBuilder sb = new StringBuilder();

            // Iterate through each character in the input string 's'.
            for (int i = 0; i < s.Length; i++)
            {
                // Check if the current character 's[i]' is not a vowel (not 'a', 'e', 'i', 'o', or 'u').
                if (!(s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u'))
                {
                    // If the character is not a vowel, append it to the StringBuilder 'sb'.
                    sb.Append(s[i]);
                }
            }

            // Convert the contents of the StringBuilder 'sb' into a new string and return it.
            return sb.ToString();

        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
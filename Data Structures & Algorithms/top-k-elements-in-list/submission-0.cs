public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {

        // 1 frequency count
        // key = number from nums,
        // value = count frequency on appearence
        var res = new Dictionary<int, int>();

        // sort by frequency
        foreach (int num in nums) {
            if (res.ContainsKey(num)) {
                res[num]++;
            }
            else {res[num] = 1;}
        }

        // create frequency map
        // creating frequency map (dictionary) that counts how many times each element appears in the nums array
        
        // "nums.GroupBy(n => n)" = method groups the elemts in nums bu their value.
        // n => n is a lambda expression. grouping elements of nums by themselves. = same number is grouped
        
        // ".ToDictionary(g => g.Key, g => g.Count())" = converts grouped results into a dictionary. 
        // Key: g.Key = value of number
        // Value: g.Count() counts elements in each group. = times number appears in nums // frequency
        // example: number KEY = (VALUE OF NUMBER (X)) appears (g.Count (X)) times in nums
        var frequencyMap = nums.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());
        
        
        // sort by frequency and get top k elements
        var topKElements = frequencyMap
            .OrderByDescending(pair => pair.Value) // sort by value in DESC / sort from most frequent to least
            .Take(k)                               // take the top "k" elements. if k = 2, the two most frequent elements will appear
            .Select(pair => pair.Key)              // extract only the keys (numbers) from the group. if k = 2 outputs the grouped elements, by extracting the numbers, only the numbers from the element group will output. Example: If Take(2) gives { 3: 3, 2: 2 }, applying Select(pair => pair.Key) gives: [3, 2] (just the numbers).
            .ToArray();                            // convert result to array

        // return result
        return topKElements;
    }
}

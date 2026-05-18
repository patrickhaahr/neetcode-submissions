public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        // hashmap with string key and list string value
        var res = new Dictionary<string, List<string>>();

        // iterates over each string in the strs array.
        foreach (string str in strs) {
        
        // new string variable that orders the characters alphabetically (unicode) in ascending order., then groups the individual char into a string using Concat
        string sortedKey = String.Concat(str.OrderBy(c => c));


        // if the res varible doesnt contains the sortedKey, then add to List.
        // only create a new list for a unique anagram group
        //check: if no => create list
        //       if yes => skip 
        if (!res.ContainsKey(sortedKey)) {
            res[sortedKey] = new List<string>();
        }
        // add the current str to the list corresponding to its sortedKey
        // always: add current string (str) to the list
        res[sortedKey].Add(str);
        }
        return res.Values.ToList();
    }
}

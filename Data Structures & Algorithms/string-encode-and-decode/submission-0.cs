public class Solution {

    public string Encode(IList<string> strs) {
        // StringBuilder to append strings
        // normal strings is immutable = cant be changed
        // StringBuilder is mutable = can be changed
        StringBuilder sb = new StringBuilder();
        
        // loop through each string in input list strs
        foreach (string str in strs) {
            // sb is the new string mutable variable (StringBuilder)
            // Add the length of the input strs, Add the delimiter '#', Add the input string itself.
            sb.Append(str.Length).Append('#').Append(str);
        }        
        // convert StringBuilder object back to string and return
        return sb.ToString();
    }

    // encoded string: "4#neet4#code4#love3#you"
    
    public List<string> Decode(string s) {
        // initialize list to store decoded strings
        List<string> decodedStrings = new List<string>();

        int i = 0; // 'i' to track current position in encoded string

        while (i < s.Length) {

            int j = i;
            // moves 'j' to the right until it hits the delimiter '#'
            while (s[j] != '#') {
                j++; 
            }

            // Substring is a part of a string. string x = "My name is Patrick";
            // x.Substring(0, 7); = "My name"
            // x.Substring(11, 7); = "Patrick"
            // the Substring input parameter is start index and Length. = .Substring(startIndex, Length);
            // s.Substring(startIndex of 'i', Length of 'j' subtract by length of 'i')

            // parse the length of the string (before the #) to int
            
            // i points to the start of the number (in this case, "4" in "4#neet").
            // j points to the #, which is the end of the number (right after "4" but before "neet").

            // j - i gives the length of the number before the '#' (e.g., "4" in "4#neet"), 
            // allowing us to extract the correct substring for the length of the string.


            int length = Int32.Parse(s.Substring(i, j - i));

            // move index i past the '#'
            i = j + 1; // + 1 to move past delimiter '#' so after the loop, start at next index

            // extract the actual string of 'length' characters
            string currentString = s.Substring(i, length);
            decodedStrings.Add(currentString); // add the string to the result list

            i += length; // move the index past the current strong to process the next one
        }

        return decodedStrings;
   }
}

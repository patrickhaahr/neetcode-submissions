impl Solution {
    pub fn merge(nums1: &mut Vec<i32>, m: i32, nums2: &mut Vec<i32>, n: i32) {
        let mut i = m as usize;
        let mut j = n as usize;
        let mut last = i + j;

        while j > 0 {
            last -= 1;
            if i > 0 && nums1[i - 1] > nums2[j - 1] {
                nums1[last] = nums1[i -1];
                i -= 1;
            } else {
                nums1[last] = nums2[j - 1];
                j -=1;
            }
        }
    }
}

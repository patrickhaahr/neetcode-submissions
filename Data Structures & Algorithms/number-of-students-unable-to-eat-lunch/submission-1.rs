impl Solution {
    pub fn count_students(students: Vec<i32>, sandwiches: Vec<i32>) -> i32 {
        let mut counts = [0; 2];

        for s in students {
            counts[s as usize] += 1;
        }

        for s in sandwiches {
            if counts[s as usize] > 0 {
                counts[s as usize] -= 1;
            } else {
                break;
            }
        }
        counts[0] + counts[1]
    }
}
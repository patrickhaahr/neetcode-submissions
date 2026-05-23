use std::collections::VecDeque;

struct MyStack {
    q: VecDeque<i32>,
}

impl MyStack {
    pub fn new() -> Self {
        MyStack { q: VecDeque::new() }
    }

    pub fn push(&mut self, x: i32) {
        self.q.push_back(x);
        let size = self.q.len();
        for _ in 0..size - 1 {
            let front = self.q.pop_front().expect("Queue cannot be empty during rotation");
            self.q.push_back(front);
        }
    }

    pub fn pop(&mut self) -> i32 {
        self.q.pop_front().unwrap_or(-1)
    }

    pub fn top(&self) -> i32 {
        self.q.front().copied().unwrap_or(-1)
    }

    pub fn empty(&self) -> bool {
        self.q.is_empty()
    }
}

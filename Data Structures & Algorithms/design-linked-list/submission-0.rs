struct Node {
    val: i32,
    next: Option<Box<Node>>,
}

struct MyLinkedList {
    head: Option<Box<Node>>,
    size: usize,
}


/** 
 * `&self` means the method takes an immutable reference.
 * If you need a mutable reference, change it to `&mut self` instead.
 */
impl MyLinkedList {

    fn new() -> Self {
        Self {
            head: None,
            size: 0,
        }
    }
    
    fn get(&self, index: i32) -> i32 {
        if index < 0 || index >= self.size as i32 {
            return -1;
        }

        let mut curr = &self.head;
        
        for _ in 0..index {
            if let Some(node) = curr {
                curr = &node.next;
            }
        }

        if let Some(node) = curr {
            node.val
        } else {
            -1
        }
    }
    
    fn add_at_head(&mut self, val: i32) {
        let old_head = self.head.take();

        let new_node = Node {
            val,
            next: old_head,
        };

        self.head = Some(Box::new(new_node));
        self.size += 1;
    }
    
    fn add_at_tail(&mut self, val: i32) {
        if self.head.is_none() {
            self.add_at_head(val);
            return;
        }

        let mut curr = &mut self.head;

        while let Some(node) = curr {
            curr = &mut node.next;
        }

        *curr = Some(Box::new(Node {
            val,
            next: None
        }));
        self.size += 1;
    }
    
    fn add_at_index(&mut self, index: i32, val: i32) {
        if index <= 0 {
            self.add_at_head(val);
            return;
        }

        if index == self.size as i32 {
            self.add_at_tail(val);
            return;
        }

        if index > self.size as i32 {
            return;
        }

        let mut curr = &mut self.head;
        for _ in 0..(index -1) {
            if let Some(node) = curr {
                curr = &mut node.next;
            }
        }

        if let Some(node) = curr {
            let next_nodes = node.next.take();

            let new_node = Node {
                val,
                next: next_nodes,
            };

            node.next = Some(Box::new(new_node));
            self.size += 1;
        }
    }
    
    fn delete_at_index(&mut self, index: i32) {
        if index < 0 || index >= self.size as i32 {
            return;
        }

        if index == 0 {
            if let Some(old_head) = self.head.take() {
                self.head = old_head.next;
            }
            self.size -= 1;
            return;
        }

        let mut curr = &mut self.head;

        for _ in 0..(index - 1) {
            if let Some(node) = curr {
                curr = &mut node.next;
            }
        }

        if let Some(node) = curr {
            let deleted_node = node.next.take();
            
            if let Some(b_node) = deleted_node {
                node.next = b_node.next;
            }
            self.size -= 1;
        }
    }
}
class Solution:
    def inorder_predeccessorUtil(self,root,prev):
        if root:
            self.inorder_predeccessorUtil(root.left,prev)
            root.next=prev[0]
            if prev:
                prev.append(root)
            else:
                prev[0]=root
            self.inorder_predeccessorUtil(root.right,prev)
    def inorder_predeccessor(self,root):
        self.inorder_predeccessorUtl(root,[])
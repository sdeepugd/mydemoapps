# Python3 program to find the diameter of binary tree
 
# A binary tree node
 
 
class Node:
 
    # Constructor to create a new node
    def __init__(self, data):
        self.data = data
        self.left = None
        self.right = None

# dia or root = dia of left + dia of right
# find if the roots dia is max, maintain global max
# return max(dia of left,dia of right)+1
# 

class Solution(object):
    def init(self):
        self.maxd=0
    
    def diautil(self,root):
        if not root:
            return 0
        l=self.diautil(root.left)
        r=self.diautil(root.right)
        self.maxd=max(self.maxd,l+r)
        return 1+max(l,r)
    
    def diameterOfBinaryTree(self, root):
        """
        :type root: TreeNode
        :rtype: int
        """
        self.init()
        self.diautil(root)
        return self.maxd


# Driver Code
if __name__ == "__main__":
    """
    Constructed binary tree is
                1
              /   \
            2      3
          /  \
        4     5
    """
 
    root = Node(1)
    root.left = Node(2)
    root.right = Node(3)
    root.left.left = Node(4)
    root.left.right = Node(5)
 
    # Function Call
    print(diameter(root))
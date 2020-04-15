class Node:
    def __init__(self, info): 
        self.info = info  
        self.left = None  
        self.right = None 
        self.level = None 

    def __str__(self):
        return str(self.info) 

class BinarySearchTree:
    def __init__(self): 
        self.root = None

    def create(self, val):  
        if self.root == None:
            self.root = Node(val)
        else:
            current = self.root
         
            while True:
                if val < current.info:
                    if current.left:
                        current = current.left
                    else:
                        current.left = Node(val)
                        break
                elif val > current.info:
                    if current.right:
                        current = current.right
                    else:
                        current.right = Node(val)
                        break
                else:
                    break

"""
Node is defined as
self.left (the left child of the node)
self.right (the right child of the node)
self.info (the value of the node)
"""
def levelOrder(root):
    #Write your code here
    h = height(root)
    for i in range(1, h+1):
        givenLevel(root, i)

#return nodes at a given level
def givenLevel(root, level):
    if root is None:
        return
    if level == 1:
        print(root.info, end=' ')
    elif level > 1:
        givenLevel(root.left, level - 1)
        givenLevel(root.right, level - 1)

def height(node):
    #computer the height of the tree: the number of nodes along the longest path from the root node down to the farthest leaf node
    if node is None:
        return 0
    
    #compute height of each subtree
    lheight = height(node.left)
    rheight = height(node.right)

    #use larger one
    if(lheight > rheight):
        return lheight+1
    else:
        return rheight+1



tree = BinarySearchTree()
t = int(input())

arr = list(map(int, input().split()))

for i in range(t):
    tree.create(arr[i])

levelOrder(tree.root)
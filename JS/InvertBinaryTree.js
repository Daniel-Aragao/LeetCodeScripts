

function TreeNode(val, left, right) {
    this.val = (val===undefined ? 0 : val);
    this.left = (left===undefined ? null : left);
    this.right = (right===undefined ? null : right);
    this.toArray = () => {
        let queue = [this];
        let result = [];

        do {
            let i = queue.shift();

            result.push(i.val);

            if(i.left) {
                queue.push(i.left);
            }

            if(i.right) {
                queue.push(i.right);
            }
        } while(queue.length)

        return result;
    };

    this.PrintableTree = () => {
        let matrix = [[[this.val]]]
        let queue = [[this, 0]];
        let max = this.val;

        do {
            let item = queue.shift();
            let node = item[0];
            let nextFloor = item[1] + 1;
            let children = [];
            
            if(node.left) {
                queue.push([node.left, nextFloor]);
                children.push(node.left.val);
                if(node.left.val > max) max = node.left.val;
            }
            
            if(node.right) {
                queue.push([node.right, nextFloor]);
                children.push(node.right.val);

                if(node.right.val > max) max = node.right.val;
            }

            if(children.length) {
                matrix[nextFloor] = matrix[nextFloor] || [];
                matrix[nextFloor].push(children);
            }
        } while(queue.length)

        return {matrix, max: max};
    }

    this.PrintTree = () => {
        let { matrix, max } = this.PrintableTree();
        let height = matrix.length;
        let numberSize = max.toString().length;
        let baseNumberQuantity = Math.pow(2, height - 1);
        let separator = " ";
        let baseSize =  baseNumberQuantity * numberSize + (baseNumberQuantity - 1) * separator.length;

        for(let i = 0; i < matrix.length; i++) {
            let line = matrix[i];
            // let lineQuantity = Math.pow(2, i);
            
            let lineStr = "";

            line.forEach(column => {
                lineStr += column.join(separator)
            });

            let missingSize = baseSize - lineStr.length;

            lineStr = lineStr.padStart(missingSize / 2, separator);
            lineStr = lineStr.padEnd(baseSize, separator);

            console.log(lineStr);
        }
    }
}

FromArray = (list) => {
    function build(i) {
        if(i < list.length) {
            return new TreeNode(list[i], build(2*i + 1), build(2*i + 2));
        }
    }

    return build(0);
}

/**
 * Given the root of a binary tree, invert the tree, and return its root.
 *       4        =>        4
 *   2       7    =>    7        2
 * 1  3    6   9  =>  9   6    3   1
 *  [4,2,7,1,3,6,9] => [4,7,2,9,6,3,1]
 * 
 *    2   =>    2
 *  1   3 =>  3   1
 * [2,1,3] => [2,3,1]
 * 
 * @param {TreeNode} root
 * @return {TreeNode}
 */
var invertTree = function(root) {
    if(!root) {
        return null;
    }

    if(root.left) {
        invertTree(root.left);
    }

    if(root.right) {
        invertTree(root.right);
    }
    
    let holder = root.left;
    root.left = root.right;
    root.right = holder;

    return root;
};

// Element quantity vs height => quantity = 2^height - 1
// 1 => 1  = 2^1 - 1 | 1 => 1  = 2 ^ 0
// 2 => 3  = 2^2 - 1 | 2 => 2  = 2 ^ 1
// 3 => 7  = 2^3 - 1 | 3 => 4  = 2 ^ 2
// 4 => 15 = 2^4 - 1 | 4 => 8  = 2 ^ 3
// 4 => 31 = 2^5 - 1 | 5 => 16 = 2 ^ 4
// 15 + 1 = 16

let tree = FromArray([4,2,7,1,3,6,9,8,5,3,9,2,1,7,0]);
let mat = tree.PrintableTree();
// let tree = FromArray([4,2,7,1,3,6,9]);
console.log(tree.toArray());
console.log(tree.PrintTree());
// let inverted = invertTree([4,2,7,1,3,6,9]);
// console.log(inverted);
/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var twoSum = function(nums, target) {
    let parts = 2;
    let hash = []; 
    let size = Math.ceil(Math.abs(target|| 1) / parts);
    
    for(let i in nums) {
        let bucket = Math.floor(Math.abs(nums[i])/size);

        for(let j = 0; j <= bucket; j++) {
            if(hash[j]){
                for(let bucketItem of hash[j]) {
                    if(nums[bucketItem] + nums[i] === target) {
                        return [bucketItem, i];
                    }
                }
            }
        }

        hash[bucket] = hash[bucket] || [];
        hash[bucket].push(i);
    }
};
let result = twoSum([5,75,25], 100);

console.log(result);
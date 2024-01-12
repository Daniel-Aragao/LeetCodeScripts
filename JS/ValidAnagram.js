/**
 * Given two strings s and t, return true if t is an anagram of s, and false otherwise.
 * An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
 * Example 1:
 *  Input: s = "anagram", t = "nagaram"
 *  Output: true
 * Example 2:
 *   Input: s = "rat", t = "car"
 *   Output: false
 * @param {string} s
 * @param {string} t
 * @return {boolean}
 */
var isAnagram = function(s, t) {
    var x = s;

    let letterCounter = {};

    for(let letter of s) {
        letterCounter[letter] = letterCounter[letter] || 0;
        letterCounter[letter]++;
    }

    for(let letter of t) {
        if(!letterCounter[letter]) {
            return false;
        }

        letterCounter[letter]--;
    }

    for(let letter in letterCounter) {
        if(letterCounter[letter]) {
            return false;
        }
    }

    return true;
};

console.log(isAnagram('rat', 'car'))
console.log(isAnagram('anagram', 'nagaram'))
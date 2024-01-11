/**
    A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
    Given a string s, return true if it is a palindrome, or false otherwise.

    Example 1:
    Input: s = "A man, a plan, a canal: Panama"
    Output: true
    Explanation: "amanaplanacanalpanama" is a palindrome.

    Example 2:
    Input: s = "race a car"
    Output: false
    Explanation: "raceacar" is not a palindrome.

    Example 3:
    Input: s = " "
    Output: true
    Explanation: s is an empty string "" after removing non-alphanumeric characters.
    Since an empty string reads the same forward and backward, it is a palindrome.

 * @param {string} s
 * @return {boolean}
 */
var isPalindrome = function(s) {
    let length = s.length;
    let forwardOffset = 0;
    let backwardOffset = 0;

    for(let i = 0; i < Math.floor(length / 2); i++) {
        let forwardCursor = i + forwardOffset;
        let backwardCursor = length - 1 - i - backwardOffset;

        while(forwardCursor < length && !isAlphaNumeric(s[forwardCursor])) {
            forwardCursor++;
            forwardOffset++;
        }

        while(backwardCursor >= 0 && !isAlphaNumeric(s[backwardCursor])) {
            backwardCursor--;
            backwardOffset++;
        }
        
        if(forwardCursor < length && backwardCursor >= 0 && s[forwardCursor].toLowerCase() != s[backwardCursor].toLowerCase()) {
            showCursors(forwardCursor, backwardCursor, s)
            return false;
        }
    }

    return true;
};

/**
 * Return if char is alphanumeric
 * '0' = 48, '9' = 57; A = 65, Z = 90; a = 97, z = 122
 * @param {strintg} character 
 * @returns {boolean}
 */
var isAlphaNumeric = function(character) {
    let code = character.charCodeAt(0);
    let ranges = [[48, 57], [65, 90], [97, 122]];

    return ranges.findIndex(range => code >= range[0] && code <= range[1]) >= 0;
}

var showCursors = function (forwardCursor, backwardCursor, txt) {
    console.log(" ");
    console.log(txt, ":" + txt.length);
    console.log("".padStart(forwardCursor, ">").padEnd(backwardCursor, " ").padEnd(txt.length, "<"));
    console.log(forwardCursor, txt[forwardCursor], backwardCursor, txt[backwardCursor]);
    console.log(" ");
}


console.log("Palindrome");
console.log(isPalindrome("A man, a plan, a canal: Panama"));
console.log(isPalindrome("race a car"));
console.log(isPalindrome(" "));
console.log(isPalindrome(".,"));
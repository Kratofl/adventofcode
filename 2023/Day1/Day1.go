package day1

import (
	"strconv"
	"strings"
	"unicode"
)

func PartOne(input *[]string) int {
	var sum int
	for _, line := range *input {

		totalNumber := getFirstDigit(&line)
		reversedLine := reverse(line)
		totalNumber = totalNumber + getFirstDigit(&reversedLine)

		twoDigitNumber, _ := strconv.Atoi(totalNumber)
		sum += twoDigitNumber
	}
	return sum
}
func getFirstDigit(line *string) string {
	for _, char := range *line {
		if unicode.IsDigit(char) {
			return string(char)
		}
	}
	return ""
}
func reverse(str string) (result string) {
	for _, v := range str {
		result = string(v) + result
	}
	return
}

func PartTwo(input *[]string) int {
	var sum int
	for _, line := range *input {
		firstDigit, lastDigit := -1, -1

		for lineIdx, digitRune := range line {
			if digitRune >= '0' && digitRune <= '9' {
				if firstDigit == -1 {
					firstDigit = int(digitRune - '0')
				}
				lastDigit = int(digitRune - '0')
				continue
			}

			for word, digit := range wordsToDigits {
				if strings.HasPrefix(line[lineIdx:], word) {
					if firstDigit == -1 {
						firstDigit = digit
					}
					lastDigit = digit
				}
			}
		}

		sum += firstDigit*10 + lastDigit
	}
	return sum
}

var wordsToDigits = map[string]int{
	"zero":  0,
	"one":   1,
	"two":   2,
	"three": 3,
	"four":  4,
	"five":  5,
	"six":   6,
	"seven": 7,
	"eight": 8,
	"nine":  9,
}

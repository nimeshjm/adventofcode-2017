package main

import (
	"bufio"
	"log"
	"os"
	"strconv"
)

func main() {
	exercise2()
}

func exercise1() {
	file, err := os.Open("input1.txt")
	if err != nil {
		log.Fatal(err)
	}
	defer file.Close()
	scanner := bufio.NewScanner(file)
	var frequency = 0
	for scanner.Scan() {
		var row, _ = strconv.Atoi(scanner.Text())
		frequency += row
	}
	log.Print("Frequency: ", frequency)
	if err := scanner.Err(); err != nil {
		log.Fatal(err)
	}
}

func exercise2() {
	file, err := os.Open("input1.txt")
	if err != nil {
		log.Fatal(err)
	}
	defer file.Close()
	var frequency = 0
	m := map[int]map[int]int{}
	m[0] = make(map[int]int)
	m[1] = make(map[int]int)
	var frequencyFound = false

	for !frequencyFound {
		file.Seek(0,0)
		scanner := bufio.NewScanner(file)
		for scanner.Scan() {
			var row, _= strconv.Atoi(scanner.Text())
			frequency += row

			found := m[1][frequency]
			if found != 0 {
				log.Println("Twice ", found)
				frequencyFound = true
				break
			}

			found = m[0][frequency]
			if found != 0 {
				delete(m[0], frequency)
				m[1][frequency] = 1
			} else {
				m[0][frequency] = 1
				found = m[0][frequency]
			}
			log.Println("m0 ", len(m[0]))
			log.Println("m1 ", len(m[1]))
		}

		if err := scanner.Err(); err != nil {
			log.Fatal(err)
		}
	}
}

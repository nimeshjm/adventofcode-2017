package main

import (
	"bufio"
	"log"
	"os"
	"strconv"
)

func main() {
	exercise1()
}

func exercise1() {
	file, err := os.Open("input1.txt")
	if err != nil {
		log.Fatal(err)
	}
	defer file.Close()
	scanner := bufio.NewScanner(file)
	var frequency int = 0
	for scanner.Scan() {
		var row, _ = strconv.Atoi(scanner.Text());
		frequency += row;
	}
	log.Print("Frequency: ", frequency)
	if err := scanner.Err(); err != nil {
		log.Fatal(err)
	}
}

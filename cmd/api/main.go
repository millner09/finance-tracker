package main

import (
	"log"
	"net/http"

	"github.com/julienschmidt/httprouter"
)

type application struct {
}

func main() {
	app := &application{}

	router := httprouter.New()
	router.HandlerFunc(http.MethodGet, "/", app.sayHello)

	log.Fatal(http.ListenAndServe(":8080", router))
}

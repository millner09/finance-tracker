package main

import (
	"flag"
	"fmt"
	"log"
	"net/http"

	"github.com/julienschmidt/httprouter"
)

type config struct {
	port int
}

type application struct {
	config config
}

func main() {
	var cfg config

	flag.IntVar(&cfg.port, "port", 8080, "Api server port")
	flag.Parse()

	app := &application{
		config: cfg,
	}

	router := httprouter.New()
	router.HandlerFunc(http.MethodGet, "/", app.sayHello)
	router.HandlerFunc(http.MethodGet, "/accounts", app.CreateAccount)

	fmt.Println("starting server on port:", app.config.port)
	log.Fatal(http.ListenAndServe(fmt.Sprintf(":%d", cfg.port), router))
}

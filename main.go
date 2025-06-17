package main

import (
	"log"
	"net/http"

	"github.com/go-chi/chi/v5"
	"github.com/millner09/finance-tracker/handlers"
)

func main() {
	r := chi.NewRouter()

	r.Get("/hello", handlers.SayHello)
	log.Println("Running server on :8080")
	http.ListenAndServe(":8080", r)
}

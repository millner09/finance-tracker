package main

import (
	"net/http"
)

func (app *application) CreateAccount(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "text/plain")
	w.Write([]byte("Hello, world!"))
}

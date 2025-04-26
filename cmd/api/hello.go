package main

import (
	"fmt"
	"net/http"
)

func (app *application) sayHello(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "Hello, world!")
}

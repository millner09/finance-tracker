package handlers

import (
	"encoding/json"
	"net/http"

	"github.com/millner09/finance-tracker/models"
)

func SayHello(w http.ResponseWriter, r *http.Request) {
	res := models.Hello{
		Name: "Hello, world!",
	}

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(res)
}

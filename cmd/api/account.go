package main

import (
	"encoding/json"
	"net/http"

	"amillner.dev/finance-tracker/internal/data"
)

func (app *application) CreateAccount(w http.ResponseWriter, r *http.Request) {
	var account data.Account

	account.ID = 1
	account.AccountName = "Checking"
	account.AccountType = data.Checking
	account.Institution = "Ally"

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(account)
}

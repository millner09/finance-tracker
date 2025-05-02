package data

import "time"

type Account struct {
	ID          int64       `json:"id"`
	AccountName string      `json:"account_name"`
	AccountType AccountType `json:"account_type"`
	Institution string      `json:"institution"`
	CreatedAt   time.Time   `json:"-"` // Use the - directive
}

type AccountType string

const (
	Checking AccountType = "checking"
	Savings  AccountType = "savings"
)

package data

type Account struct {
	ID          int         `json:"id"`
	AccountName string      `json:"account_name"`
	AccountType AccountType `json:"account_type"`
	Institution string      `json:"institution"`
	Balance     float64     `json:"balance"`
}

type AccountType string

const (
	Checking AccountType = "checking"
	Savings  AccountType = "savings"
)

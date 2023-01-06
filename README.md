<!-- GRAPHIC -->

# bsn.CashCtrl

Inofficial .NET API client for CashCtrl.

Note: Calls in current version are not async since the library was created for use in a non-async scenario. However, adding async method signatures analoguous to the sync methods is just routine work, there is nothing preventing that.

<!-- badges -->

---
## Links

- [CashCtrl.com](https://cashctrl.com/)
- [CashCtrl API](https://app.cashctrl.com/static/help/en/api/index.html)

---
## Description

.NET Client for the CashCtrl REST API:
- Entities implemented as .NET objects
- Supports most of the API calls
- Supports multilanguage strings
- Entities can be assigned to ID properties

### Listing with filtering example

```cs
var invoices = cashctrl.OrderList(new () {
		CategoryId = invoiceCategory,
		Type = OrderType.Sales,
		FiscalPeriodId = fiscalPeriod,
		["associateId"] = customer,
		["date"] = date.ToCashCtrlString(true)
});
```

### Create or update entity example

```cs
// read existing journal entry (ID known, e.g. > 0) oder create a new one (ID unknown)
var journal = journalId > 0
	? cashctrl.JournalRead(journalId)
	: new Journal { // Prepare new journal entry
		CreditId = accounts[2850],
		DebitId = accounts[6200]
	};
 // Set properties
journal.DateAdded = date;
journal.Title = $"Private car {kilometer} km";
journal.Amount = kilometer * priceCarPerKm;
// Generic helper for entity upsert
journalId = cashctrl.UpdateOrCreate(journal, CashCtrlClientExtensions.JournalUpdate, CashCtrlClientExtensions.JournalCreate);
```

<!--
---
## FAQ
- **Q**
    - A
-->

---
## Source

[https://github.com/avonwyss/bsn.CashCtrl](https://github.com/avonwyss/bsn.CashCtrl)

---
## License

- **[MIT license](LICENSE.txt)**
- Copyright 2022 © Arsène von Wyss.

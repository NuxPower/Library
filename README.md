# Library Management System

A desktop library administration application built with VB.NET Windows Forms, .NET Framework 4.8, and MySQL.

The application provides screens for managing authors, books, borrowers, and loans. It uses a dashboard-style shell with dynamically loaded `UserControl` views, plus secondary forms for add, update, detail, return, and delete workflows.

> [!IMPORTANT]
> This repository does not contain a database dump, migration, seed script, automated tests, or packaged release. The database schema documented below is reconstructed from the SQL used by the application.

## Contents

- [Features](#features)
- [Technology stack](#technology-stack)
- [System requirements](#system-requirements)
- [Quick start](#quick-start)
- [Database setup](#database-setup)
- [Configuration](#configuration)
- [Build and run](#build-and-run)
- [Application workflow](#application-workflow)
- [Architecture](#architecture)
- [Database model](#database-model)
- [Validation and business rules](#validation-and-business-rules)
- [Project structure](#project-structure)
- [Component reference](#component-reference)
- [Dependencies](#dependencies)
- [Current limitations and known issues](#current-limitations-and-known-issues)
- [Development notes](#development-notes)

## Features

### Dashboard

- Displays total counts for authors, borrowers, loans, and books.
- Provides navigation cards for each management area.
- Loads management pages inside the main dashboard without opening a new main window.

### Author management

- List all authors with their database ID and date added.
- Search authors by name.
- Sort author data in memory by name or date through the `ISortable` contract.
- Add an author and up to two books in the current primary add-author screen.
- Reject a duplicate author name using a case-insensitive comparison.
- Validate entered ISBN values as numeric when an ISBN is supplied.
- Update an author's name.
- View all books associated with an author.
- Update a book title and ISBN from the author detail view.
- Delete a book unless it currently has an unreturned loan.

### Book management

- List books with ID, title, author, and ISBN.
- Search by title, author, or ISBN.
- Add a book for an existing author.
- View a book's metadata and complete loan history.
- Display how many loans for the book have not been returned.

### Borrower management

- List borrowers with ID, name, email, and mobile number.
- Search by name, email, or mobile number.
- Add a borrower.
- Update borrower details.
- View a borrower's loan history.
- Derive and color-code borrower loan status:
  - `ACTIVE`: no return date and the due date has not passed.
  - `OVERDUE`: no return date and the due date has passed.
  - `RETURNED`: a return date exists.

### Loan management

- List all loans with book, borrower, loan date, due date, and return date.
- Search loans by book title or borrower name.
- Create a loan for a selected book and borrower.
- Automatically calculate the due date as 14 days after the selected loan date.
- View full loan details, including the author and derived status.
- Set or change a loan's return date.
- Delete a loan after confirmation.

## Technology stack

| Area | Technology |
|---|---|
| Language | Visual Basic .NET |
| UI | Windows Forms |
| Runtime | .NET Framework 4.8 |
| Database | MySQL |
| Database provider | `MySql.Data` 9.3.0 |
| Project type | Classic non-SDK Visual Studio project |
| Output | Windows executable (`WinExe`) |
| IDE metadata | Visual Studio 2022 solution format |
| Platform target | Any CPU |

The application assembly is named `Library`, uses root namespace `Library`, and currently reports version `1.0.0.0`.

## System requirements

Recommended development environment:

- Windows 10 or Windows 11.
- Visual Studio 2022 with the **.NET desktop development** workload.
- .NET Framework 4.8 Developer Pack.
- MySQL Server 8.x or another server compatible with the queries in this project.
- NuGet package restore access.

The project is Windows-specific because it uses .NET Framework Windows Forms. Building or running it directly on Linux or macOS is not supported by the project configuration.

The checked-in connection string expects:

- Host: `127.0.0.1`
- Port: `3307`
- Database: `library_management`
- User: `root`
- Password: empty

## Quick start

1. Clone the repository.
2. Create the `library_management` MySQL database using the schema below.
3. Confirm that MySQL is listening on port `3307`, or edit the connection string.
4. Open `Library.sln` in Visual Studio.
5. Restore NuGet packages.
6. Build the solution.
7. Run the `Library` project.

The generated application entry point creates `Dashboard`, implemented in `Library/Form.vb`, as the main form. The source `Application.myapp` still contains the older `Form1` name, but `Application.Designer.vb` is the generated code currently used by the project.

## Database setup

No authoritative SQL schema is included in the repository. The following schema is the minimal structure inferred from every query in the codebase:

```sql
CREATE DATABASE IF NOT EXISTS library_management
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;

USE library_management;

CREATE TABLE authors (
    author_id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    date_added DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (author_id)
);

CREATE TABLE books (
    book_id INT NOT NULL AUTO_INCREMENT,
    title VARCHAR(255) NOT NULL,
    author_id INT NOT NULL,
    isbn VARCHAR(32) NULL,
    PRIMARY KEY (book_id),
    INDEX idx_books_author_id (author_id),
    CONSTRAINT fk_books_author
        FOREIGN KEY (author_id)
        REFERENCES authors (author_id)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);

CREATE TABLE borrowers (
    borrower_id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    mobile_no VARCHAR(50) NOT NULL,
    PRIMARY KEY (borrower_id)
);

CREATE TABLE loans (
    loan_id INT NOT NULL AUTO_INCREMENT,
    book_id INT NOT NULL,
    borrower_id INT NOT NULL,
    loan_date DATE NOT NULL,
    due_date DATE NOT NULL,
    return_date DATE NULL,
    PRIMARY KEY (loan_id),
    INDEX idx_loans_book_id (book_id),
    INDEX idx_loans_borrower_id (borrower_id),
    INDEX idx_loans_due_date (due_date),
    CONSTRAINT fk_loans_book
        FOREIGN KEY (book_id)
        REFERENCES books (book_id)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,
    CONSTRAINT fk_loans_borrower
        FOREIGN KEY (borrower_id)
        REFERENCES borrowers (borrower_id)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);
```

This schema deliberately keeps `isbn` nullable because one author workflow allows books to be inserted without an ISBN. If stricter data integrity is required, consolidate the add-book workflows first and then make the column `NOT NULL`.

### Optional sample data

```sql
USE library_management;

INSERT INTO authors (name) VALUES
    ('George Orwell'),
    ('Jane Austen');

INSERT INTO books (title, author_id, isbn) VALUES
    ('1984', 1, '9780451524935'),
    ('Animal Farm', 1, '9780451526342'),
    ('Pride and Prejudice', 2, '9780141439518');

INSERT INTO borrowers (name, email, mobile_no) VALUES
    ('Alex Rivera', 'alex@example.com', '09171234567');
```

## Configuration

The database connection is defined directly in `Library/Global Module.vb`:

```vb
Property conn As New MySqlConnection(
    "Server=127.0.0.1;Port=3307;Database=library_management;User ID=root;Password=;"
)
```

Change this value if the MySQL host, port, database, username, or password differs.

For example, the common default MySQL port is `3306`:

```vb
Property conn As New MySqlConnection(
    "Server=127.0.0.1;Port=3306;Database=library_management;User ID=library_app;Password=your_password;"
)
```

For a maintained or deployed application, move the connection string to `App.config`, do not commit production credentials, and use a dedicated least-privilege database account instead of `root`.

`App.config` currently contains only:

- The .NET Framework 4.8 startup declaration.
- Binding redirects for `System.Runtime.CompilerServices.Unsafe`.
- Binding redirects for `System.Memory`.

## Build and run

### Visual Studio

1. Open `Library.sln`.
2. Allow Visual Studio to restore packages from `Library/packages.config`.
3. Select `Debug` or `Release` and `Any CPU`.
4. Build with **Build > Build Solution**.
5. Start with **Debug > Start Debugging** or press `F5`.

Build output is written to:

- `Library/bin/Debug/`
- `Library/bin/Release/`

### Developer Command Prompt

After package restore, a Visual Studio Developer Command Prompt can build the solution with:

```powershell
msbuild Library.sln /p:Configuration=Debug
```

Release build:

```powershell
msbuild Library.sln /p:Configuration=Release
```

This repository was inspected in an environment without Visual Studio, MSBuild, NuGet, or the .NET SDK installed, so a local compilation could not be executed as part of this documentation update.

## Application workflow

```text
Dashboard form
└── Main dashboard
    ├── Authors
    │   └── Author management table
    │       ├── Add author
    │       ├── Update author
    │       └── View author's books
    │           ├── Update book
    │           └── Delete book
    ├── Books
    │   └── Book management table
    │       ├── Add book
    │       └── View book and its loan history
    ├── Borrowers
    │   └── Borrower management table
    │       ├── Add borrower
    │       ├── Update borrower
    │       └── View borrower loan history
    └── Loans
        └── Loan management form
            ├── Create loan
            ├── Search loans
            ├── View loan details
            ├── Update return date
            └── Delete loan
```

### Dynamic navigation

`Dashboard.dashboardLoad` replaces the contents of the main `fragment` panel with a supplied `UserControl`.

`Author_Management` performs the same role for its `fragment2` content panel. It wraps each loaded control in an auto-scrolling panel.

`LOAN_MANAGEMENT` is a secondary host form. It hides the main dashboard while open, dynamically loads a requested control into `Panel1`, and restores the dashboard when it closes.

### Management type routing

Several views are selected using string values:

| Value | Result |
|---|---|
| `AUTHORS` | Author list or add-author control |
| `BOOKS` | Book list, book details, or add-book control depending on host context |
| `BORROWERS` | Borrower list or add-borrower control |
| `LOAN` | Loan management control |
| `VIEW_BORROWER` | Borrower loan-history control |
| `UPDATE_BORROWER` | Borrower update control |

These strings are not represented by an enum, so spelling and host context matter.

## Architecture

### Presentation

The UI is made entirely from Windows Forms controls:

- `Form` classes provide top-level or modal windows.
- `UserControl` classes provide dashboard pages and reusable management views.
- `Panel` containers are used for navigation and dynamic content replacement.
- `ListView` controls use owner drawing to render centered cells and action buttons.
- `.Designer.vb` files contain generated control construction and layout.
- `.resx` files contain form resources and embedded visual metadata.

### Data access

There is no repository, service, or ORM layer. Each screen executes SQL directly with `MySqlCommand`.

The global module exposes:

```vb
Property conn As MySqlConnection
Property reader As MySqlDataReader
Sub dbConn()
Sub dbDisconn()
```

Most values are supplied through parameters, which reduces SQL-injection exposure. One borrower sort query interpolates a locally controlled `ORDER BY` clause; it does not accept raw user input.

### In-memory view models

The author, book, and borrower tables define small private model classes and retain loaded rows in lists. Search and some sort operations filter these lists without another database query.

### Shared behavior contracts

`ISearchable` defines:

```vb
Sub PerformSearch(query As String)
```

It is implemented by:

- `AUTHOR_MANAGEMENT_TABLE`
- `BOOK_MANAGEMENT_TABLE`
- `BORROWER_MANAGEMENT_TABLE`
- `VIEW_AUTHOR_TABLE`

`ISortable` defines:

```vb
Sub SortByName()
Sub SortByDate()
```

It is implemented by `AUTHOR_MANAGEMENT_TABLE`.

Loan search is implemented directly inside `LOAN_MANAGEMENT_CONTROL` instead of through `ISearchable`.

## Database model

```text
authors 1 ────────< books 1 ────────< loans >──────── 1 borrowers
```

### `authors`

| Column | Used as | Notes |
|---|---|---|
| `author_id` | Integer primary key | Displayed directly as the author number |
| `name` | Author full name | Duplicate check is case-insensitive only in the primary add-author workflow |
| `date_added` | Date/time | Displayed as `yyyy-MM-dd`; primary workflow inserts `NOW()` |

### `books`

| Column | Used as | Notes |
|---|---|---|
| `book_id` | Integer primary key | Used by detail, update, delete, and loan workflows |
| `title` | Book title | Searchable |
| `author_id` | Foreign key to `authors` | Required by all active book queries |
| `isbn` | Text identifier | Some workflows require it; others allow it to be empty |

ISBN is stored as text even though one workflow validates it as numeric. Text storage preserves leading zeroes and avoids integer-size limitations.

### `borrowers`

| Column | Used as | Notes |
|---|---|---|
| `borrower_id` | Integer primary key | Used by borrower and loan workflows |
| `name` | Combined full name | Most screens split or combine first and last name |
| `email` | Email address | Add workflow only checks that it contains `@` |
| `mobile_no` | Phone number text | Add workflow requires at least 10 characters |

### `loans`

| Column | Used as | Notes |
|---|---|---|
| `loan_id` | Integer primary key | Used for view, return, and delete actions |
| `book_id` | Foreign key to `books` | A book can have multiple historical or simultaneous loan rows |
| `borrower_id` | Foreign key to `borrowers` | Associates the loan with a borrower |
| `loan_date` | Date | Selected by the operator |
| `due_date` | Date | New-loan code sets it to `loan_date + 14 days` |
| `return_date` | Nullable date | `NULL` means not returned |

### Derived loan statuses

Different views use slightly different labels:

| Condition | Loan details | Borrower history | Book history |
|---|---|---|---|
| `return_date IS NOT NULL` | `Returned` | `RETURNED` | `RETURNED` |
| Not returned and overdue | `Overdue` | `OVERDUE` | `ON LOAN` |
| Not returned and not overdue | `Borrowed` | `ACTIVE` | `ON LOAN` |

No status column is stored in the database.

## Validation and business rules

### Authors

- The primary add-author control requires a non-empty combined name.
- It compares `LOWER(name)` with the entered lowercase full name to reject duplicate authors.
- Up to two optional books can be added with the author.
- Entered ISBNs must contain digits only.
- Author creation and related book creation are not wrapped in a database transaction.
- Updating an author only validates that the new name is non-empty.

### Books

- The primary add-book control requires title, ISBN, and an existing author.
- The author-detail update form requires both title and ISBN.
- The alternate `update_book` form requires a title and author but permits an empty ISBN.
- The guarded delete dialog blocks deletion when an unreturned loan exists.
- The alternate `update_book` delete path does not perform the same active-loan check.

### Borrowers

- First and last name are required during creation.
- Email must be non-empty and contain `@`.
- Phone number must be at least 10 characters.
- The update control requires all fields but does not repeat the email or phone-format checks.
- Stored names are split on spaces when loading the update form; only the first two tokens are placed into first-name and last-name fields.

### Loans

- Book and borrower selections are required.
- New loans receive a due date exactly 14 days after the chosen loan date.
- The second date picker displayed by the loan UI is not used when saving; the calculated date is used instead.
- The application does not prevent multiple active loans for the same book.
- The application does not validate that a return date is on or after the loan date.
- Deleting a loan permanently removes its history after confirmation.

## Project structure

```text
.
├── Library.sln
├── README.md
└── Library/
    ├── Library.vbproj
    ├── App.config
    ├── packages.config
    ├── Global Module.vb
    ├── Interface1.vb
    ├── Interface2.vb
    ├── Form.*
    ├── Main Dashboard.*
    ├── Author Management.*
    ├── LOAN MANAGEMENT.*
    ├── *_CONTROL.*
    ├── *_TABLE.*
    ├── update_*.*
    ├── delete_conf.*
    ├── return_book.*
    ├── My Project/
    └── Resources/
```

For most screens, the file set is:

- `Name.vb`: handwritten event and data-access logic.
- `Name.Designer.vb`: Visual Studio-generated layout and control declarations.
- `Name.resx`: generated resources for the screen.

Do not manually edit designer files unless necessary; use the Visual Studio Forms Designer so generated layout code remains synchronized.

## Component reference

### Core shell and navigation

| File/class | Type | Responsibility |
|---|---|---|
| `Form.vb` / `Dashboard` | Form | Startup shell; hosts the current main page in `fragment` |
| `Main Dashboard.vb` / `Main_Dashboard` | UserControl | Navigation cards and live entity counts |
| `Author Management.vb` / `Author_Management` | UserControl | Shared management navigation, search box, add action, and `fragment2` host |
| `LOAN MANAGEMENT.vb` / `LOAN_MANAGEMENT` | Form | Secondary dynamic host for loan, add, detail, and borrower screens |
| `Global Module.vb` / `Global_Module` | Module | Shared MySQL connection, reader, and open/close helpers |
| `Interface1.vb` / `ISearchable` | Interface | Common search contract |
| `Interface2.vb` / `ISortable` | Interface | Common sort contract |

### Author components

| File/class | Type | Responsibility |
|---|---|---|
| `AUTHOR_MANAGEMENT_TABLE` | UserControl | Lists, searches, sorts, views, and launches author updates |
| `ADDING_AUTHOR_CONTROL` | UserControl | Primary author creation workflow with two optional books |
| `update_auth` | Form | Updates an author name |
| `VIEW_AUTHOR_TABLE` | UserControl | Lists and searches books for a selected author |
| `VIEW_AUTHOR_TABLE_UPDATE` | Form | Updates a selected book's title and ISBN |
| `delete_conf` | Form | Guarded book deletion with active-loan check |
| `add_auth` | Form | Older alternate author form supporting four books |

### Book components

| File/class | Type | Responsibility |
|---|---|---|
| `BOOK_MANAGEMENT_TABLE` | UserControl | Lists and searches all books; exposes view/update action regions |
| `ADD_BOOK_CONTROL` | UserControl | Adds a book for an existing author |
| `BOOK_MANAGEMENT_CONTROL` | UserControl | Shows one book's metadata, on-loan count, and loan history |
| `update_book` | Form | Alternate book update/delete form |
| `UPDATE_BOOK_CONTROL` | UserControl | Placeholder control with no implemented update logic |
| `book_status` | Form | Empty placeholder form |

### Borrower components

| File/class | Type | Responsibility |
|---|---|---|
| `BORROWER_MANAGEMENT_TABLE` | UserControl | Lists, searches, views, and launches borrower updates |
| `ADDING_BORROWER_CONTROL` | UserControl | Creates borrowers |
| `UPDATING_BORROWER_CONTROL` | UserControl | Loads and updates one borrower |
| `VIEW_BORROWER_MANAGEMENT_CONTROL` | UserControl | Shows a borrower's loan history and selected borrower details |
| `add_borrower` | Form | Empty placeholder form |

### Loan components

| File/class | Type | Responsibility |
|---|---|---|
| `LOAN_MANAGEMENT_CONTROL` | UserControl | Lists, searches, creates, views, deletes, and updates loans |
| `VIEW_LOAN_MANAGEMENT_TABLE` | UserControl | Shows full details for one loan |
| `return_book` | Form | Sets a loan's return date |

### Other placeholders

`ADDING_FORM` is a shell form without handwritten behavior. Several older or placeholder forms remain included in the project even though the active navigation does not use them.

## Dependencies

NuGet packages are managed through `packages.config`.

| Package | Version | Purpose |
|---|---:|---|
| `MySql.Data` | 9.3.0 | MySQL ADO.NET provider used directly by the application |
| `BouncyCastle.Cryptography` | 2.5.1 | Transitive/runtime support for MySQL connectivity |
| `Google.Protobuf` | 3.30.0 | MySQL protocol/runtime dependency |
| `K4os.Compression.LZ4` | 1.3.8 | Compression dependency |
| `K4os.Compression.LZ4.Streams` | 1.3.8 | Stream compression dependency |
| `K4os.Hash.xxHash` | 1.0.8 | Hash dependency used by LZ4 |
| `Microsoft.Bcl.AsyncInterfaces` | 5.0.0 | Async interface compatibility |
| `System.Buffers` | 4.5.1 | Buffer APIs |
| `System.Configuration.ConfigurationManager` | 8.0.0 | Configuration compatibility |
| `System.Diagnostics.DiagnosticSource` | 8.0.1 | Diagnostic APIs |
| `System.IO.Pipelines` | 5.0.2 | Pipeline APIs |
| `System.Memory` | 4.5.5 | Memory/span compatibility |
| `System.Numerics.Vectors` | 4.5.0 | Vector APIs |
| `System.Runtime.CompilerServices.Unsafe` | 6.0.0 | Low-level runtime compatibility |
| `System.Threading.Tasks.Extensions` | 4.5.4 | Task compatibility |
| `ZstdSharp.Port` | 0.8.5 | Zstandard compression dependency |

The project references package DLLs from a solution-level `packages/` directory. Visual Studio/NuGet must restore that directory before a successful build.

## Current limitations and known issues

The following points describe the checked-in implementation:

1. **No database provisioning is included.** The application fails at runtime until the expected MySQL schema exists.
2. **The connection string is hard-coded.** It uses `root`, an empty password, and port `3307`.
3. **No authentication or authorization exists.** Anyone who can launch the application receives all available management actions.
4. **No automated tests exist.** Database operations and UI workflows are not covered by unit or integration tests.
5. **No transaction protects multi-step author creation.** An author can be inserted even if a later book insert fails.
6. **Global mutable database state is shared.** A single connection and reader are exposed through `Global_Module`, making nested operations fragile.
7. **Book update navigation is incomplete.** The all-books table loads `UPDATE_BOOK_CONTROL`, but that control contains no update implementation and is not given the selected book ID.
8. **There are duplicate and legacy workflows.** `ADDING_AUTHOR_CONTROL` and `add_auth` add authors differently; `VIEW_AUTHOR_TABLE_UPDATE` and `update_book` update books differently.
9. **Validation is inconsistent.** ISBN, email, phone, and delete protections differ between screens.
10. **Book availability is not enforced.** A book may receive more than one simultaneous active loan.
11. **The displayed due-date picker is ignored.** New-loan code always calculates a 14-day due date.
12. **Return-date updates do not automatically refresh the loan table.** An event exists in `return_book`, but the parent does not subscribe to it.
13. **Search/sort wiring is incomplete.** Author sort methods exist, but the corresponding panel handlers are not connected in the checked-in code.
14. **A borrower with no loans can trigger a format error.** Selecting the synthetic “No loans found” row attempts to parse that text as an integer loan ID.
15. **Name parsing loses information.** Borrower updates only preserve the first two space-separated name tokens.
16. **Deletion semantics are inconsistent.** The guarded delete dialog checks active loans, while the alternate update form directly deletes a book.
17. **Some screens are placeholders.** `UPDATE_BOOK_CONTROL`, `book_status`, `add_borrower`, and `ADDING_FORM` have little or no behavior.
18. **No installer or deployment profile is included.**
19. **No license file is included.** Reuse terms are therefore unspecified.

## Development notes

### Suggested modernization priorities

1. Move the connection string into configuration and use a dedicated database account.
2. Add a versioned schema/migration and seed process.
3. Replace the shared global reader/connection with short-lived `Using` blocks.
4. Introduce repositories or services so UI controls do not own SQL.
5. Consolidate duplicate author and book workflows.
6. Replace string-based management routing with an enum or typed navigation model.
7. Enforce availability and data integrity in both application logic and database constraints.
8. Add transactions to multi-table operations.
9. Add tests for validation, status calculation, and CRUD operations.
10. Remove unused placeholder forms after confirming they are not needed.

### UI conventions

- Management tables use `ListView` in `Details` mode.
- Rows are full-row selectable.
- Action buttons are painted manually inside the final column; they are not real child `Button` controls.
- Column widths are recalculated when each list resizes.
- Fonts used explicitly in code include Segoe UI and Inter.
- Two PNG files under `Library/Resources/` support the visual design.

### Error handling

Most database calls:

1. Open the shared connection with `dbConn()`.
2. Execute a parameterized `MySqlCommand`.
3. Show errors through `MessageBox`.
4. Close readers and the connection in `Finally`.

Errors are not logged to disk or to a telemetry system.

### Generated files

The following should generally be treated as generated artifacts:

- `*.Designer.vb`
- `*.resx`
- `My Project/Application.Designer.vb`
- `My Project/Resources.Designer.vb`
- `My Project/Settings.Designer.vb`

The repository's `.gitignore` excludes Visual Studio state, build output, restored packages, test output, and common generated files.

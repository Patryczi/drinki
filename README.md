# Projekt: Drinki

## 1. Instalacja i wymagania systemowe

### Wymagania systemowe:
- .NET 8.0
- Baza danych SQLite
- Przeglądarka internetowa
- dodatkowo można doinstalować Visual Studio

### Jak uruchamiać:
1. Pobierz i zainstaluj .NET SDK 8.0 ze strony [Microsoft](https://dotnet.microsoft.com/download).
2. Pobierz projekt lub użyj `git clone`
3. Przejdź do katalogu projektu:
   ```bash
   cd drinki
   ```
4. Przygotuj bazę danych:
   - W pliku `program.cs` należy sprawdzić czy mamy podany istniejący plik do bazy danych.
   
        ```
        builder.Services.AddDbContext<ContextBazy>(x => x.UseSqlite("Data Source=Baza.db"));
        ```
   - Baza.db to nasza baza danych

5. Uruchom aplikację przez Visual Studio

6. Ewentualnie należy uruchamić `dotnet tool install --global dotnet-ef` i potem `dotnet ef database update`


## 2. Opis działania aplikacji

### Funkcje aplikacji:

1. **Dodawanie drinków**  
   Użytkownik może dodawać nowe drinki do listy poprzez formularz. Wymagane jest wprowadzenie nazwy drinka oraz przypisanie kategorii i składników.

2. **Edycja drinków**  
   Istnieje możliwość edycji drinków, zmieniając ich nazwę, kategorię lub składniki.

3. **Usuwanie drinków**  
   Użytkownik może usunąć dowolny drink z listy, co spowoduje trwałe usunięcie go z bazy danych.

4. **Lista drinków**  
   Aplikacja wyświetla listę wszystkich drinków, które są zapisane w bazie danych.

5. **Kategorie drinków**  
   Do każdego drinka można przypisać kategorię, co umożliwia filtrowanie drinków według kategorii.

6. **Składniki drinków**  
   Użytkownik może dodawać składniki do drinków, definiując ich ilość oraz rodzaj.

7. **Oceny drinków**  
   Użytkownicy mogą oceniać drinki oraz edytować swoje oceny, co pozwala innym użytkownikom zobaczyć opinie o danym drinku.

### Przykładowe kroki użytkownika:
- Aby dodać nowy drink, użytkownik wchodzi na stronę "Dodaj Drink", wypełnia formularz, a następnie zapisuje.
- Aby dodać kategorię lub składnik, użytkownik przechodzi do odpowiedniej sekcji w formularzu drinka.
- Oceny drinków można wystawiać bezpośrednio z widoku szczegółów drinka.

### Do aplikacji można dodać jeszcze autoryzacje użytkowników np za pomocą sesji ale nie zdążyłem tego zrobić
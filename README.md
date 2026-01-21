# GameShop

**GameShop** je moderna i robusna CRUD web aplikacija razvijena u **ASP.NET Core MVC** okruženju. Projekat predstavlja kompletan ekosistem za digitalnu distribuciju video igara, gde korisnici mogu da upravljaju svojim budžetom, kupuju naslove i grade ličnu kolekciju, dok administratori kontrolišu celokupan sadržaj platforme.

---

## Tehnologije i Arhitektura (Modern Stack)

Umesto klasičnog prikaza, tvoj projekat koristi **N-tier arhitekturu** sa jasno razdvojenim odgovornostima.

<div align="center">

### Backend & Core
`C#` • `.NET 8.0` • `EF Core` • `LINQ`
*Srce aplikacije koje pokreće asinhronu poslovnu logiku i sigurnosne protokole.*

### Frontend & UX
`Razor Views` • `Bootstrap 5` • `CSS3 (Neon Design)` • `JavaScript`
*Dinamičan korisnički interfejs sa prilagođenim Neon-Glass stilom i responzivnim komponentama.*

### Security & Auth
`Cookie Auth` • `Role-based Authorization` • `BCrypt`
*Sigurna autentifikacija sa različitim nivoima pristupa za Admire i Korisnike.*

</div>

---

## Ključne Funkcionalnosti (Key Features)

* **Digitalni Novčanik (Wallet)**: Potpuna kontrola nad balansom korisnika u RSD valuti, uz mogućnost trenutne dopune sredstava.
* **Prodavnica & Filteri**: Napredna pretraga igara po nazivu, žanru i ceni kako bi korisnici lakše pronašli željeni naslov.
* **Moja Biblioteka**: Pregled kupljenih igara sa vizuelnim statusom i simulacijom pokretanja softvera.
* **Admin Dashboard**: Centralizovano upravljanje svim korisnicima i katalogom igara kroz zaštićeni administrativni panel.
* **Validacija Podataka**: Dvostruka provera unosa na klijentskoj i serverskoj strani radi maksimalne stabilnosti.

---

## Struktura Projekta

Projekat je podeljen na tri ključna sloja radi bolje organizacije i lakšeg testiranja:
* **DAL (Data Access Layer)**: Upravlja bazom podataka preko `AppDbContext` i čuva modele entiteta.
* **BLL (Business Logic Layer)**: Sadrži servise koji obrađuju zahteve, interfejse i DTO objekte za siguran prenos informacija.
* **MVC (Presentation Layer)**: Zadužen za prikazivanje podataka korisniku i upravljanje navigacijom.

---

## Buduće Implementacije

* **Shopping Cart**: Mogućnost kupovine više igara odjednom.
* **Review System**: Sistem ocenjivanja i ostavljanja utisaka o igrama.
* **Cloud Storage**: Čuvanje slika igara i avatara na eksternim serverima.
* **SignalR Chat**: Komunikacija korisnika u realnom vremenu.

---

## Brza Instalacija (Setup Guide)

Pratite ove korake da biste podesili projekat na svom računaru:

1.  **Klonirajte repozitorijum**:
    ```bash
    git clone [https://github.com/vas-username/GameShop.git](https://github.com/vas-username/GameShop.git)
    ```
2.  **Podešavanje baze**:
    Ažurirajte `DefaultConnection` string u `appsettings.json` (GameShop.MVC) tako da pokazuje na vaš lokalni SQL Server.
3.  **Primena migracija**:
    Otvorite konzolu i pokrenite komandu:
    ```powershell
    Update-Database -Project GameShop.DAL -StartupProject GameShop.MVC
    ```
4.  **Pokretanje**:
    Pokrenite aplikaciju. `DbSeeder` će automatski kreirati početne podatke, uključujući Admina i testne igre.

---

**© 2026 - GameShop Team**

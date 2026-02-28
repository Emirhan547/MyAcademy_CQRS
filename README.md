# 🏗️ Bagery

**Bagery**, ASP.NET Core MVC üzerinde **Clean Architecture (Onion) + CQRS + MediatR** prensipleriyle geliştirilmiş katmanlı bir e-ticaret / bakery yönetim uygulamasıdır.

Proje; public mağaza deneyimi, kullanıcı akışları, sepet ve sipariş yönetimi ile admin panel içerik yönetimini tek çözüm altında toplar.

---

## 🚀 Mimari Özellikler

* Clean Architecture (Onion)
* CQRS (Command / Query Separation)
* MediatR tabanlı handler yapısı
* Domain Event (Observer Pattern)
* Sipariş İşleme Pipeline yapısı (Chain of Responsibility)
* Rol bazlı yetkilendirme (ASP.NET Core Identity)

---

## 🧱 Çözüm Yapısı

```
Presentation → Application → Domain
                 ↑
         Infrastructure
```

### Katmanlar

**Presentation (Sunum Katmanı)**

* MVC Controller’lar
* Razor View’lar
* Admin & User Area yapısı

**Application (Uygulama Katmanı)**

* Command / Query modelleri
* Handler’lar
* Validator’lar (FluentValidation)
* Result modelleri
* Pipeline adımları

**Domain (Çekirdek Katman)**

* Entity’ler
* Enum’lar
* Domain Event’ler

**Infrastructure (Altyapı Katmanı)**

* EF Core (DbContext)
* Repository implementasyonları
* Event handler implementasyonları
* Storage servisleri

Domain katmanı dış bağımlılık içermez.
Infrastructure, Application sözleşmelerini implement eder.

---

## 🧩 Temel Kavramlar

### CQRS Yapısı

```
Features/
 ├── Commands
 ├── Queries
 ├── Handlers
 ├── Validators
 └── Results
```

* Command → State değiştirir
* Query → Veri okur
* Handler → İş akışını yönetir
* Validator → FluentValidation ile doğrulama yapar

---

### Sipariş İşleme Pipeline Yapısı

Sipariş süreci adım adım işlenir:

1. Validation
2. StockControl
3. PriceValidation
4. PromotionApply
5. FraudRuleControl
6. Persist
7. Event Publish

Bu yapı sayesinde iş kuralları modüler ve genişletilebilir hale gelir.

---

### Domain Event Yapısı

Sipariş oluşturulduğunda `OrderCreatedEvent` yayınlanır.

Event handler’lar:

* Activity log oluşturur
* Bildirim tetikler
* Yan etkileri ana iş akışından ayırır

Bu sayede sistem daha esnek ve sürdürülebilir olur.

---

## 🧩 Fonksiyonel Kapsam

### Public Alan

* Ana Sayfa
* Ürün Listeleme / Detay
* Sepet
* Checkout
* İletişim Formu

### Admin Panel

* Category
* Product
* Slider
* Service
* Promotion
* Gallery
* News
* Orders
* Dashboard
* ActivityLog

---

## ⚙️ Kullanılan Teknolojiler

* .NET 9
* ASP.NET Core MVC
* MediatR
* FluentValidation
* Entity Framework Core
* SQL Server
* ASP.NET Core Identity
* Google Cloud Storage SDK

---

## 📌 Projenin Amacı

Bu proje:


* Clean Architecture pratiği sunar
* CQRS yaklaşımının gerçek uygulamasını gösterir
* Domain Event kullanımını örneklendirir
* Katmanlı mimari disiplinini somutlaştırır

---

<img width="1897" height="859" alt="Ekran görüntüsü 2026-02-18 153242" src="https://github.com/user-attachments/assets/b1b4264f-0d4a-4bea-9f51-849eaaa98595" />

<img width="576" height="724" alt="Ekran görüntüsü 2026-02-18 155318" src="https://github.com/user-attachments/assets/9c34fb04-b0b3-4d2d-8755-d5c30ad3a079" />

<img width="1030" height="663" alt="Ekran görüntüsü 2026-02-18 155701" src="https://github.com/user-attachments/assets/8b2cf452-eaa8-476d-971a-cf8d1c96cc6c" />

<img width="1028" height="711" alt="Ekran görüntüsü 2026-02-18 171647" src="https://github.com/user-attachments/assets/22857ceb-1022-4674-8602-f2072b1e14df" />

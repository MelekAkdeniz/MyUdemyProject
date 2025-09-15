## 🏨 Cunklab / Hotelier - Bir Otel Yönetim Paneli Projesi

MyUdemyProject, otel yönetimini dijitalleştiren ve modernize eden kapsamlı bir yazılım çözümüdür. .NET 8, Blazor, JWT, RapidAPI ve daha birçok modern teknolojiyi bir araya getirerek, otel işletmelerinin operasyonel verimliliğini artırmayı hedefler.

### 🚀 Proje Özeti

MyUdemyProject, otel yönetimi için gerekli temel modülleri entegre eden bir platformdur. Proje, kullanıcıların otel odalarını yönetmelerine, rezervasyon işlemlerini takip etmelerine ve API entegrasyonlarıyla dış sistemlerle iletişim kurmalarına olanak tanır.

### 🧩 Ana Özellikler

- Kullanıcı Yönetimi: Kullanıcı kayıt, giriş ve yetkilendirme işlemleri JWT tabanlı güvenli bir şekilde gerçekleştirilir.

- Rezervasyon Yönetimi: Oda rezervasyonları, iptalleri ve değişiklikleri yönetilebilir.

- API Entegrasyonları: RapidAPI üzerinden dış servislerle entegrasyon sağlanır.

- Blazor Web UI: Kullanıcı dostu ve modern bir arayüz sunulur.

- Veritabanı Yönetimi: SQL Server ile verimli veri yönetimi sağlanır.

### 🛠️ Teknolojiler

- Backend: ASP.NET 8 Web API, JWT Authentication

- Frontend: Blazor WebAssembly

- Veritabanı: SQL Server

- API Entegrasyonu: RapidAPI

- Diğer: Docker, Swagger, GitHub Actions

### 📁 Proje Yapısı
```bash
MyUdemyProject/
├── ApiConsume/               # API tüketimi ve entegrasyonları
├── Frontend/                 # Blazor Web UI uygulaması
│   └── HotelProject.WebUI/   # Blazor WebAssembly projesi
├── JwtProject/               # JWT tabanlı kimlik doğrulama
│   └── WebApiJwt/            # Web API projeleri
├── RapidApi/                 # RapidAPI entegrasyonları
│   └── RapidapiConsume/      # API tüketim modülü
├── .gitignore                # Git ignore dosyası
├── Adımlar.txt               # Proje adımları ve notlar
└── MyUdemyProject.sln        # Solution dosyası
```
## 📦 Kurulum ve Çalıştırma

### 1. Projeyi Klonlayın
```bash
git clone https://github.com/MelekAkdeniz/MyUdemyProject.git
cd MyUdemyProject
```
### 2. Backend API Projesini Çalıştırın
```bash
cd JwtProject/WebApiJwt
dotnet run
```
### 3. Frontend Blazor Uygulamasını Çalıştırın
```bash
cd Frontend/HotelProject.WebUI
dotnet run
```
### 4. API Entegrasyonlarını Yapılandırın

RapidAPI anahtarınızı ve gerekli yapılandırmaları RapidApi/RapidapiConsume dizinindeki konfigürasyon dosyalarına ekleyin.

### 🧪 Test ve Doğrulama

- Swagger UI: API uç noktalarını test etmek için Swagger UI kullanabilirsiniz.

- Unit Testler: Backend projelerinde yer alan birim testleri çalıştırarak işlevselliği doğrulayın.

### 📄 Lisans

Bu proje, MIT Lisansı
 ile lisanslanmıştır.

### 🤝 Katkı Sağlama

Katkılarınız için teşekkür ederiz! Değişiklik önerileri, hata raporları veya yeni özellik talepleri için lütfen Issues
 bölümünü kullanın.

### 🧾 Kaynaklar ve Referanslar

- RapidAPI

- JWT Authentication

- Blazor WebAssembly

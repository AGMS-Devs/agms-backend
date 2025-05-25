# AGMS Backend - Render Deployment Guide

## 🚀 Render'a Deployment

### 1. Repository Hazırlığı
Repository'nizi GitHub'a push'layın ve Render'a bağlayın.

### 2. Environment Variables (Render Dashboard)
Render servis ayarlarınızda şu environment variable'ları set edin:

```bash
# Required
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=http://0.0.0.0:8080

# Database (otomatik set edilir)
DATABASE_URL=postgres://username:password@host:port/database

# Security
JWT_SECRET_KEY=your-super-secret-jwt-key-here

# API Configuration
API_DOMAIN=https://your-app-name.onrender.com
FRONTEND_URL=https://your-frontend-url.com

# Mail Settings (opsiyonel)
MAIL_USERNAME=your-email@gmail.com
MAIL_PASSWORD=your-app-password
MAIL_SENDER_EMAIL=your-email@gmail.com

# Azure Storage (opsiyonel)
AZURE_STORAGE_CONNECTION_STRING=your-azure-connection-string
```

### 3. PostgreSQL Database
1. Render dashboard'da PostgreSQL database oluşturun
2. Database ismi: `agms`
3. Database user: `agms_user`
4. Region: Ohio (performance için aynı region)

### 4. Web Service Ayarları
```yaml
# Build Command: (empty)
# Start Command: (empty - Docker kullanıyor)
# Environment: Docker
# Dockerfile Path: ./Dockerfile
# Port: 8080
# Health Check Path: /health
```

### 5. Connection String Formatları

Sistem şu sırayla connection string arar:
1. `DATABASE_URL` environment variable (Render standard)
2. Render PostgreSQL env variables (`PGHOST`, `PGPORT`, etc.)
3. `appsettings.json` içindeki `ConnectionStrings:PostgreSql`

### 6. Debugging

Log'larda connection string sorunları için:
```bash
# Render log'larında arayın:
"Using connection string: Host=***"
"Found DATABASE_URL environment variable"
"Found Render PostgreSQL environment variables"
```

### 7. Deployment Checklist
- [ ] GitHub repository bağlantısı
- [ ] Render PostgreSQL database oluşturuldu
- [ ] Environment variables set edildi
- [ ] Docker build başarılı
- [ ] Health check `/health` endpoint'i çalışıyor
- [ ] Database migrations uygulandı

### 8. Troubleshooting

#### Connection String Hatası
```
Format of the initialization string does not conform to specification
```
**Çözüm:** 
- DATABASE_URL doğru formatda olmalı: `postgres://user:pass@host:port/db`
- Render PostgreSQL environment variables kontrol edin
- Log'larda "Using connection string" çıktısını kontrol edin

#### Migration Hatası
```
Error applying migrations
```
**Çözüm:**
- Database'e connection yapılabildiğinden emin olun
- PostgreSQL version compatibility kontrol edin
- Manual migration: `dotnet ef database update`

### 9. Useful Commands

```bash
# Local testing
docker build -t agms-backend .
docker run -p 8080:8080 -e DATABASE_URL="postgres://..." agms-backend

# Render logs
render logs --service your-service-name

# Health check
curl https://your-app.onrender.com/health
```

### 10. Performance Optimization
- Free tier'da 750 saat/ay limit var
- Sleep mode'dan çıkmak 30-60 saniye sürer
- Production'da paid plan önerilir
- Database connection pool ayarları optimize edin

## 📞 Support
Deployment sorunları için logs'ları kontrol edin ve gerekirse GitHub issue açın. 
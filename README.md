
# Простой калькулятор на Minimal API и HTML/CSS/JS

Этот проект представляет собой простой веб-калькулятор, созданный с использованием:
- **Backend:** Minimal API на C# (.NET 8)
- **Frontend:** HTML, CSS, JavaScript

Калькулятор поддерживает базовые математические операции: сложение, вычитание, умножение и деление. Также реализована история вычислений, которая отображается на странице.

---

## 🚀 Как запустить проект

### 1. Убедитесь, что у вас установлен .NET 8 SDK

### 2. Клонируйте репозиторий
```bash
git clone https://github.com/Antongo22/MinimalApiSimpleCalculator
cd MinimalApiSimpleCalculator
```

### 3. Запустите проект
```bash
cd MinimalApi
dotnet run
```

### 4. Откройте браузер
Перейдите по адресу: [http://localhost:5000](http://localhost:5000).

---

## 🛠️ Функционал

### Калькулятор
- **Сложение (`+`)**
- **Вычитание (`-`)**
- **Умножение (`*`)**
- **Деление (`/`)**

### История вычислений
- Все выполненные операции сохраняются и отображаются на странице.
- История автоматически обновляется после каждого вычисления.
- Есть кнопка **"Clear History"** для очистки истории.

---

## 📂 Структура проекта

```
MinimalApiCalculator/
├── Program.cs             # Основной файл Minimal API
├── MinimalApi.csproj      # Файл проекта
└── wwwroot/               # Статические файлы фронтенда
    ├── index.html         # Главная страница
    ├── style.css          # Стили для страницы
    └── script.js          # Логика калькулятора
```

---

## 🛠️ Технологии

- **Backend:**
  - C# (.NET 8)
  - Minimal API
- **Frontend:**
  - HTML
  - CSS
  - JavaScript

---


Наслаждайтесь использованием калькулятора! 😊

📧 aiMail – AI 기반 자동 이메일 발송 프로그램

aiMail은 C# / WPF 기반 데스크톱 애플리케이션으로,
AI를 활용해 이메일 작성 및 발송을 자동화하여 반복적인 메일 업무를 효율적으로 처리할 수 있도록 설계된 프로젝트입니다.

✨ 주요 기능

🤖 AI 기반 이메일 내용 생성

📤 자동 이메일 발송

🧾 메일 템플릿 관리

📎 첨부파일 포함 발송 지원

📋 수신자 목록 관리

🖥️ WPF + MVVM 구조의 데스크톱 UI

🛠️ 기술 스택

Language: C#

Framework: .NET (WPF)

UI Pattern: MVVM

IDE: Visual Studio

AI API: 외부 AI API (개인 Key 필요)

Version Control: Git / GitHub

📂 프로젝트 구조
AutoMail/
 ├─ AutoMail/
 │   ├─ Models/
 │   ├─ ViewModels/
 │   │   └─ MainViewModel.cs
 │   ├─ Views/
 │   ├─ App.xaml
 │   └─ MainWindow.xaml
 ├─ aMail.png
 └─ README.md

🚀 실행 방법

저장소 클론

git clone https://github.com/your-id/aiMail.git


Visual Studio에서 AutoMail.sln 열기

빌드 후 실행

권장: Debug | Any CPU

🖼️ 실행 화면

🔐 AI API Key 설정 안내

본 프로젝트의 AI 기능을 사용하려면 개인 AI API Key(토큰)를 직접 입력해야 합니다.

⚠️ 보안상의 이유로 API Key는 저장소에 포함되지 않습니다.

✅ 개인 입력이 필요한 이유

API Key는 개인 계정에 종속

GitHub 공개 시 키 노출 및 과금 위험

무단 사용 방지

🛠️ API Key 설정 방법 (권장: 환경 변수)
1️⃣ Windows 환경 변수 추가

변수 이름

AIMAIL_API_KEY


변수 값

본인의 AI API Key

2️⃣ 프로그램 실행 시 자동으로 환경 변수 로드

별도의 코드 수정 없이 실행 가능하도록 설계되었습니다.

❌ 주의 사항

API Key를 소스 코드에 직접 작성하지 마세요

appsettings.json, .env 파일을 사용할 경우
반드시 .gitignore에 추가하세요

📌 개발 목적

반복적인 이메일 업무 자동화

AI API 연동 경험

WPF + MVVM 구조 학습 및 정리

개인 포트폴리오 프로젝트

📄 라이선스

This project is licensed under the MIT License.

👤 작성자

김민한

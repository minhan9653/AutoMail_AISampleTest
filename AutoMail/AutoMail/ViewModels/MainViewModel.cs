using AutoMail.Commands;
using AutoMail.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMail.Services;
using System.Windows.Input;




namespace AutoMail.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // =========================
        // 🔹 ComboBox 목록 데이터
        // =========================

        public ObservableCollection<string> WorkTypes { get; }
        public ObservableCollection<string> Targets { get; }
        public ObservableCollection<string> Tones { get; }

        // =========================
        // 🔹 입력 영역 바인딩 속성
        // =========================

        private string _selectedWorkType;
        public string SelectedWorkType
        {
            get => _selectedWorkType;
            set
            {
                _selectedWorkType = value;
                OnPropertyChanged();
            }
        }

        private string _selectedTarget;
        public string SelectedTarget
        {
            get => _selectedTarget;
            set
            {
                _selectedTarget = value;
                OnPropertyChanged();
            }
        }

        private string _selectedTone;
        public string SelectedTone
        {
            get => _selectedTone;
            set
            {
                _selectedTone = value;
                OnPropertyChanged();
            }
        }

        private string _coreContent;
        public string CoreContent
        {
            get => _coreContent;
            set
            {
                _coreContent = value;
                OnPropertyChanged();
            }
        }

        // =========================
        // 🔹 결과 영역 바인딩 속성
        // =========================

        private string _resultText;
        public string ResultText
        {
            get => _resultText;
            set
            {
                _resultText = value;
                OnPropertyChanged();
            }
        }

        // =========================
        // 🔹 Commands
        // =========================

        public ICommand GenerateMailCommand { get; }
        public ICommand GenerateReportCommand { get; }
        public ICommand GenerateReplyCommand { get; }



        // =========================
        // 🔹 Field
        // =========================
        private readonly PromptBuilderService _promptBuilder;
        private readonly AiClientService _aiClient;

        // =========================
        // 🔹 Constructor
        // =========================

        public MainViewModel()
        {
            _promptBuilder = new PromptBuilderService();
            _aiClient = new AiClientService();

            // ComboBox 목록 초기화
            WorkTypes = new ObservableCollection<string>
            {
                "장애 공지",
                "업무 요청",
                "일정 변경",
                "문의 회신"
            };

            Targets = new ObservableCollection<string>
            {
                "내부 직원",
                "상급자",
                "고객",
                "협력사"
            };

            Tones = new ObservableCollection<string>
            {
                "매우 정중",
                "정중",
                "중립",
                "간결"
            };

            // 기본 선택값
            SelectedWorkType = WorkTypes.First();
            SelectedTarget = Targets.First();
            SelectedTone = Tones.First();

            // Command 연결
            GenerateMailCommand = new RelayCommand(GenerateMail);
            GenerateReportCommand = new RelayCommand(GenerateReport);
            GenerateReplyCommand = new RelayCommand(GenerateReply);
        }

        // =========================
        // 🔹 Command 실행 메서드
        // =========================

        private async void GenerateMail()
        {
            ResultText = "⏳ AI가 메일을 작성 중입니다...";

            string prompt = _promptBuilder.BuildMailPrompt(
                SelectedWorkType,
                SelectedTarget,
                SelectedTone,
                CoreContent
            );

            try
            {
                string aiResult = await _aiClient.GenerateAsync(prompt);
                ResultText = aiResult;
            }
            catch (System.Exception ex)
            {
                ResultText = "❌ AI 호출 중 오류 발생\n" + ex.Message;
            }
        }

        private void GenerateReport()
        {
            ResultText = "[보고서 프롬프트 연결 예정]";

        }

        private void GenerateReply()
        {
            ResultText = "[보고서 프롬프트 연결 예정]";

        }
    }
}
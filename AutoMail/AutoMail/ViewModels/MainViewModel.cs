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
            //ResultText = "⏳ AI가 메일을 작성 중입니다...";
            ResultText = "제목\r\n\r\n안녕하십니까.\r\n\r\n항상 업무에 협조해 주셔서 감사드립니다.\r\n\r\n보다 안정적인 시스템 운영을 위하여\r\n아래와 같이 윈도우 시스템 재부팅 작업이 예정되어 있어 안내드립니다.\r\n\r\n■ 작업 내용\r\n\r\n윈도우 시스템 재부팅\r\n\r\n■ 작업 일시\r\n\r\n(예시) 2026년 1월 21일(수) 19:00 ~ 19:30\r\n※ 작업 상황에 따라 종료 시간이 변동될 수 있습니다.\r\n\r\n■ 영향 범위\r\n\r\n해당 시간 동안 관련 시스템 접속 및 사용이 일시적으로 제한될 수 있습니다.\r\n\r\n업무에 불편을 드리게 되어 대단히 송구하오며,\r\n원활한 작업 진행을 위해 사전에 업무 참고 및 준비를 부탁드립니다.\r\n\r\n작업이 완료되는 대로 다시 한번 안내드리겠습니다.\r\n기타 문의사항이 있으신 경우 담당 부서로 연락 주시기 바랍니다.";

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
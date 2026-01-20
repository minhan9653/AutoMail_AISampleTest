using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMail.Services
{
    public class PromptBuilderService
    {
        public string BuildMailPrompt(
            string workType,
            string target,
            string tone,
            string coreContent)
        {
            var sb = new StringBuilder();

            sb.AppendLine("너는 IT 기업의 실무 담당자다.");
            sb.AppendLine("아래 조건에 맞춰 업무 메일을 작성하라.");
            sb.AppendLine();

            sb.AppendLine("[문서 유형]");
            sb.AppendLine($"- {workType}");
            sb.AppendLine();

            sb.AppendLine("[수신 대상]");
            sb.AppendLine($"- {target}");
            sb.AppendLine();

            sb.AppendLine("[톤]");
            sb.AppendLine($"- {tone}");
            sb.AppendLine();

            sb.AppendLine("[핵심 내용]");
            sb.AppendLine(coreContent);
            sb.AppendLine();

            sb.AppendLine("[작성 규칙]");
            sb.AppendLine("- 불필요한 사과 표현은 최소화한다.");
            sb.AppendLine("- 사실 위주로 명확하게 작성한다.");
            sb.AppendLine("- 한국어로 작성한다.");
            sb.AppendLine("- 메일 형식으로 작성한다.");

            return sb.ToString();
        }

        public string BuildReportPrompt(
            string workType,
            string target,
            string tone,
            string coreContent)
        {
            var sb = new StringBuilder();

            sb.AppendLine("너는 IT 기업의 실무 담당자다.");
            sb.AppendLine("아래 조건에 맞춰 업무 보고서를 작성하라.");
            sb.AppendLine();

            sb.AppendLine("[보고서 유형]");
            sb.AppendLine($"- {workType}");
            sb.AppendLine();

            sb.AppendLine("[대상]");
            sb.AppendLine($"- {target}");
            sb.AppendLine();

            sb.AppendLine("[톤]");
            sb.AppendLine($"- {tone}");
            sb.AppendLine();

            sb.AppendLine("[핵심 내용]");
            sb.AppendLine(coreContent);
            sb.AppendLine();

            sb.AppendLine("[작성 규칙]");
            sb.AppendLine("- 개요 / 조치 내용 / 결과 순으로 작성한다.");
            sb.AppendLine("- 불필요한 감정 표현은 제외한다.");
            sb.AppendLine("- 명확하고 간결하게 작성한다.");
            sb.AppendLine("- 한국어로 작성한다.");

            return sb.ToString();
        }

        public string BuildReplyPrompt(
            string workType,
            string target,
            string tone,
            string coreContent)
        {
            var sb = new StringBuilder();

            sb.AppendLine("너는 IT 기업의 실무 담당자다.");
            sb.AppendLine("아래 조건에 맞춰 회신 메일을 작성하라.");
            sb.AppendLine();

            sb.AppendLine("[문의 유형]");
            sb.AppendLine($"- {workType}");
            sb.AppendLine();

            sb.AppendLine("[회신 대상]");
            sb.AppendLine($"- {target}");
            sb.AppendLine();

            sb.AppendLine("[톤]");
            sb.AppendLine($"- {tone}");
            sb.AppendLine();

            sb.AppendLine("[문의 내용 요약]");
            sb.AppendLine(coreContent);
            sb.AppendLine();

            sb.AppendLine("[작성 규칙]");
            sb.AppendLine("- 질문에 대한 답변을 명확히 포함한다.");
            sb.AppendLine("- 필요 시 추가 안내를 포함한다.");
            sb.AppendLine("- 한국어로 작성한다.");
            sb.AppendLine("- 회신 메일 형식으로 작성한다.");

            return sb.ToString();
        }
    }
}
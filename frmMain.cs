using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class frmMain : Form
    {
        List<MyQuestion> questionList = new List<MyQuestion>();
        private Stack<MyAnswer> myAnswers = new Stack<MyAnswer>();
        private Dictionary<String, String> description = new Dictionary<string, string>();
        private int currentQuestion = -1;
        private List<String> key = new List<string>()
        {           
            "hocluc","csvc","linhvuc","pm1","pc1","dn1","nc1"
        };
        private MyProlog prolog;
        private const String prologFilePath = @"..\..\Prolog_Code.pl";
        public frmMain()
        {
            InitializeComponent();
            // Init & Load prolog file
            prolog = new MyProlog();
            prolog.LoadFile(prologFilePath);
            // Build List question
            buildListQuestion();
        }

        private void buildListQuestion()
        {
            // 0
            questionList.Add(new MyQuestion("Your valuation in Learning (Học lực của bạn như thế nào ?)",
                new List<string>() { "very good", "good", "fair" }));
            // 1
            questionList.Add(new MyQuestion("School facilities (Bạn muốn học trong điều kiện cơ sở vật chất như thế nào ?)",
                new List<string>() { "Normal", "Good" }));
            // 2
            questionList.Add(new MyQuestion("Your major ? (Bạn muốn theo học lĩnh vực nào ?)",
                new List<string>() { "Software and system", "Hardware", "Business", "Research" }));
            // 3
            questionList.Add(new MyQuestion("Chọn loại phần mềm, hệ thống:",
                new List<string>() { "Application software", "Web development", "Game development", "Mobile development", "Database system design", "Information Security" }));
            // 4
            questionList.Add(new MyQuestion("Chọn loại phần cứng:",
                new List<string>() { "Embedded system", "Digital circuit design", "Networks and systems administration", "Internet of things" }));
            // 5
            questionList.Add(new MyQuestion("Chọn nhóm kiến thức:",
                new List<string>() { "Business management", "E commerce", "Data analyst in business" }));
            // 6
            questionList.Add(new MyQuestion("Chọn nhóm nghiên cứu:",
                new List<string>() { "Artificial intelligence", "Natural language processing", "Computer vision", "Data science", "Machine learning" }));


            description.Add("KTPM", "Khoa Công nghệ phần mềm\r\nChương trình đào tạo kỹ sư ngành Kỹ thuật phần mềm\r\nChi tiết xem tại: http://se.uit.edu.vn");
            description.Add("PMCL", "Khoa Công nghệ phần mềm\r\nChương trình đào tạo kỹ sư ngành Kỹ thuật phần mềm (CLC)\r\nChi tiết xem tại: http://se.uit.edu.vn");
            description.Add("HTTT", "Khoa Hệ thống thông tin\r\nChương trình đào tạo kỹ sư ngành Hệ thống thông tin\r\nChi tiết xem tại: http://is.uit.edu.vn");
            description.Add("HTCL", "Khoa Hệ thống thông tin\r\nChương trình đào tạo kỹ sư ngành Hệ thống thông tin (CLC)\r\nChi tiết xem tại: http://is.uit.edu.vn");
            description.Add("TMDT", "Khoa Hệ thống thông tin\r\nChương trình đào tạo cử nhân ngành Thương mại điện tử\r\nChi tiết xem tại: http://is.uit.edu.vn");
            description.Add("TMCL", "Khoa Hệ thống thông tin\r\nChương trình đào tạo cử nhân ngành Thương mại điện tử (CLC)\r\nChi tiết xem tại: http://is.uit.edu.vn");
            description.Add("KHMT", "Khoa khoa học máy tính\r\nChương trình đào tạo cử nhân ngành Khoa học máy tính\r\nChi tiết xem tại: http://cs.uit.edu.vn");
            description.Add("KHCL", "Khoa khoa học máy tính\r\nChương trình đào tạo cử nhân ngành Khoa học máy tính (CLC)\r\nChi tiết xem tại: http://cs.uit.edu.vn");
            description.Add("KHTN", "Khoa khoa học máy tính\r\nhương trình đào tạo cử nhân ngành Khoa học máy tính (Tài năng)\r\nChi tiết xem tại: http://cs.uit.edu.vn");
            description.Add("CNTT", "Khoa Khoa học và kỹ thuật thông tin\r\nChương trình đào tạo cử nhân ngành Công nghệ thông tin\r\nChi tiết xem tại: http://fit.uit.edu.vn");
            description.Add("CNNB1", "Khoa Khoa học và kỹ thuật thông tin\r\nChương trình đào tạo cử nhân ngành Công nghệ thông tin (định hướng Nhật Bản) - định hướng Data science & Big Data\r\nChi tiết xem tại: http://fit.uit.edu.vn");
            description.Add("CNNB2", "Khoa Khoa học và kỹ thuật thông tin\r\nCChương trình đào tạo cử nhân ngành Công nghệ thông tin (định hướng Nhật Bản) - định hướng Web technology\r\nChi tiết xem tại: http://fit.uit.edu.vn");
            description.Add("KHDL", "Khoa Khoa học và kỹ thuật thông tin\r\nChương trình đào tạo cử nhân ngành khoa học dữ liệu\r\nChi tiết xem tại: http://fit.uit.edu.vn");
            description.Add("KTMT", "Khoa Kỹ thuật máy tính\r\nChương trình đào tạo kỹ sư ngành Kỹ thuật máy tính\r\nChi tiết xem tại: http://ce.uit.edu.vn");
            description.Add("MTCL", "Khoa Kỹ thuật máy tính\r\nChương trình đào tạo kỹ sư ngành Kỹ thuật máy tính (CLC)\r\nChi tiết xem tại: http://ce.uit.edu.vn");
            description.Add("KTIT", "Khoa Kỹ thuật máy tính\r\nChương trình đào tạo kỹ sư ngành Kỹ thuật máy tính - định hướng IOT\r\nChi tiết xem tại: http://ce.uit.edu.vn");
            description.Add("ATTT", "Khoa Mạng máy tính và truyền thông\r\nChương trình đào tạo kỹ sư ngành An toàn thông tin\r\nChi tiết xem tại: http://nc.uit.edu.vn");
            description.Add("ATTN", "Khoa Mạng máy tính và truyền thông\r\nChương trình đào tạo kỹ sư ngành An toàn thông tin (Tài năng)\r\nChi tiết xem tại: http://nc.uit.edu.vn");
            description.Add("ATCL", "Khoa Mạng máy tính và truyền thông\r\nChương trình đào tạo kỹ sư ngành An toàn thông tin (CLC)\r\nChi tiết xem tại: http://nc.uit.edu.vn");
            description.Add("MMTT", "Khoa Mạng máy tính và truyền thông\r\nChương trình đào tạo kỹ sư ngành Mạng máy tính và truyền thông dữ liệu\r\nChi tiết xem tại:http://nc.uit.edu.vn");
            description.Add("MMCL", "Khoa Mạng máy tính và truyền thông\r\nChương trình đào tạo kỹ sư ngành Mạng máy tính và truyền thông dữ liệu (CLC)\r\nChi tiết xem tại: http://nc.uit.edu.vn");
            description.Add("KHNT", "Khoa Mạng máy tính và truyền thông\r\nChương trình đào tạo cử nhân ngành Khoa học máy tính - định hướng trí tuệ nhân tạo\r\nChi tiết xem tại: http://cs.uit.edu.vn");

        }

        private void BindQuestion(int index)
        {
            HideRadioButton();
            lbQuestion.Text = questionList[index].Question;
            for (int i = 0; i < questionList[index].Answers.Count; i++)
            {
                RadioButton c = (RadioButton)this.Controls.Find("rd" + (i + 1), true).FirstOrDefault();
                c.Text = questionList[index].Answers[i];
                c.Visible = true;
            }
        }

        private int QuestionControl(int index, String ans)
        {
            int current = -1;
            switch (index)
            {
                case 0:
                    if (ans.Equals("very_good") || ans.Equals("good") || ans.Equals("fair")) { BindQuestion(1); current = 1; }
                    break;
                case 1:
                    if (ans.Equals("normal") || ans.Equals("good")) { BindQuestion(2); current = 2; }
                    break;
                case 2:
                    if (ans.Equals("software_and_system")) { BindQuestion(3); current = 3; }
                    else if (ans.Equals("hardware")) { BindQuestion(4); current = 4; }
                    else if (ans.Equals("business")) { BindQuestion(5); current = 5; }
                    else if (ans.Equals("research")) { BindQuestion(6); current = 6; }
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
            return current;
        }

        private String GetResult(String ans)
        {
            return ans.Replace(" ", "_").Replace("'", "").ToLower();
        }

        private void HideRadioButton()
        {
            rd1.Visible = false;
            rd2.Visible = false;
            rd3.Visible = false;
            rd4.Visible = false;
            rd5.Visible = false;
            rd6.Visible = false;
            rd7.Visible = false;
            rd8.Visible = false;
            rd9.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            gpQuestion.Visible = true;
            lbTitle.Location = new Point(lbTitle.Location.X, lbTitle.Location.Y - 115);
            currentQuestion = 0;
            BindQuestion(0);
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            btnStart.Visible = true;
            gpQuestion.Visible = false;
            lbTitle.Location = new Point(lbTitle.Location.X, lbTitle.Location.Y + 115);
            myAnswers.Clear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rd1.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd1.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd1.Text)); }
            else if (rd2.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd2.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd2.Text)); }
            else if (rd3.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd3.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd3.Text)); }
            else if (rd4.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd4.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd4.Text)); }
            else if (rd5.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd5.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd5.Text)); }
            else if (rd6.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd6.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd6.Text)); }
            else if (rd7.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd7.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd7.Text)); }
            else if (rd8.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd8.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd8.Text)); }
            else if (rd9.Checked) { myAnswers.Push(new MyAnswer(currentQuestion, GetResult(rd9.Text))); currentQuestion = QuestionControl(currentQuestion, GetResult(rd9.Text)); }
            if (currentQuestion == -1)
            {
                String query = "";
                String history = "";
                while (myAnswers.Count > 0)
                {
                    MyAnswer ma = myAnswers.Pop();
                    query = key[ma.QuestionIndex] + "('" + ma.Answer + "'), " + query;
                    history = "---------------------------------------------------\r\n" + history;
                    history = "[Q] " + ma.Answer + "\r\n" + history;
                    history = "[A] " + questionList[ma.QuestionIndex].Question + "\r\n" + history;
                }
                query = query.Substring(0, query.Length - 2);
                query = "major(X, " + query + ").";
                try
                {
                    String result = description[prolog.GetResult(query).ToUpper()];
                    MessageBox.Show(result, "Chúc mừng bạn !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("View your question history?", "View History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        history += "System result:\r\n" + result;
                        new frmHistory(history).ShowDialog();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lựa chọn của bạn không phù hợp\r\n P/s:Dựa theo điểm chuẩn hằng năm,chương trình đào tạo chính quy đạo trà yêu cầu học lực ở mức \"Good\" trở lên ?");
                }
                reset();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (myAnswers.Count > 0)
            {
                currentQuestion = myAnswers.Peek().QuestionIndex;
                BindQuestion(currentQuestion);
                myAnswers.Pop();
            }
            else
            {

            }
        }
    }
}

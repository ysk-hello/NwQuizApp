using NwQuizApp.Controls;
using NwQuizApp.Models;
using NwQuizApp.Services;

namespace NwQuizApp;

public partial class QuizPage : ContentPage
{
    private List<Question> _questions;

    private int _count = 0;

    private QuizPage()
	{
		InitializeComponent();
    }

    public QuizPage(string year) : this()
    {
        this.Title = year;
        Init(year);
    }

    private async void Init(string year)
    {
        var service = new QuestionService();
        _questions = await service.LoadQuestionsAsync(year);

        InitUI();
    }

    private async void InitUI()
    {
        answer1.Init();
        answer2.Init();
        answer3.Init();
        answer4.Init();

        resultView.IsVisible = false;

        noLabel.Text = $"–â{_questions[_count].No}";
        questionLabel.Text = _questions[_count].QuestionText;
        questionLabel.WidthRequest = this.Width - 300;

        questionImage.HeightRequest = (_questions[_count].QuestionImage == null) ? 0 : 200;
        questionImage.Source = _questions[_count].QuestionImage;

        answer1.QuestionText = _questions[_count].Options[0];
        answer2.QuestionText = _questions[_count].Options[1];
        answer3.QuestionText = _questions[_count].Options[2];
        answer4.QuestionText = _questions[_count].Options[3];

        answer1.DescriptionText = _questions[_count].Explains[0];
        answer2.DescriptionText = _questions[_count].Explains[1];
        answer3.DescriptionText = _questions[_count].Explains[2];
        answer4.DescriptionText = _questions[_count].Explains[3];
    }

    private async void NextPageButton_Clicked(object sender, EventArgs e)
    {
        _count++;

        if (_count == _questions.Count())
        {
            await DisplayAlert("‚¨‚µ‚Ü‚¢", "‚¨”æ‚ê—l‚Å‚µ‚½", "OK");
            await Shell.Current.GoToAsync("//MainPage");
            return;
        }

        InitUI();
    }

    private async void answerButton_Clicked(object sender, EventArgs e)
    {
        var optionView = (OptionView)sender;

        var ans = optionView.SetAnswer(_questions[_count].Answer);
        resultView.UpdateResult(ans);
    }
}
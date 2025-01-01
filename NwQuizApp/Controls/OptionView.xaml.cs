namespace NwQuizApp.Controls;

public enum ButtonState
{
    Correct,
    InCorrect,
    Default,
}

public partial class OptionView : ContentView
{
    public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(OptionView), string.Empty);

    public static readonly BindableProperty QuestionTextProperty = BindableProperty.Create(nameof(QuestionText), typeof(string), typeof(OptionView), string.Empty);

    public static readonly BindableProperty DescriptionTextProperty = BindableProperty.Create(nameof(DescriptionText), typeof(string), typeof(OptionView), string.Empty);

    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    public string QuestionText
    {
        get => (string)GetValue(QuestionTextProperty);
        set => SetValue(QuestionTextProperty, value);
    }

    public string DescriptionText
    {
        get => (string)GetValue(DescriptionTextProperty);
        set => SetValue(DescriptionTextProperty, value);
    }

    public string Answer { get; private set; }

    public event EventHandler ButtonClicked;

    public OptionView()
	{
		InitializeComponent();
     
        BindingContext = this;  // ÅöïKóv
        ChangeButtonColor(ButtonState.Default);
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        if(ButtonClicked != null)
        {
            descriptionLabel.IsVisible = true;
            ButtonClicked(this, EventArgs.Empty);
        }
    }

    private void ChangeButtonColor(ButtonState state)
    {
        switch (state)
        {
            case ButtonState.Correct:
                button.Background = Colors.LightSalmon;
                break;
            case ButtonState.InCorrect:
                button.Background = Colors.LightBlue;
                break;
            case ButtonState.Default:
                button.Background = Colors.LightGray;
                break;
            default:
                button.Background = Colors.LightGray;
                break;
        }
    }

    public void Init()
    {
        descriptionLabel.IsVisible = false;
        ChangeButtonColor(ButtonState.Default);
    }

    public bool SetAnswer(string answer)
    {
        Answer = answer;

        if (answer == ButtonText)
        {
            ChangeButtonColor(ButtonState.Correct);
            return true;
        }
        else
        {
            ChangeButtonColor(ButtonState.InCorrect);
            return false;
        }
    }
}
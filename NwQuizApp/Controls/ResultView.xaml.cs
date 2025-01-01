namespace NwQuizApp.Controls;

public partial class ResultView : ContentView
{
    public ResultView()
	{
		InitializeComponent();
    }

	public void UpdateResult(bool isCorrect)
    {
        this.IsVisible = true;
        resultLabel.IsVisible = true;

        if (isCorrect)
		{
            resultLabel.Text = "ê≥â";
            resultLabel.TextColor = Colors.Red;
        }
		else
		{
            resultLabel.Text = "ïsê≥â";
            resultLabel.TextColor = Colors.Blue;
        }
    }
}
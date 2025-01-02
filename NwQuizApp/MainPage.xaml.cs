namespace NwQuizApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//QuizPage");

            var button = (Button)sender;
            if(button.Text == "R06")
            {
                await Navigation.PushAsync(new QuizPage("令和6年"));
            }
            else if(button.Text == "R05")
            {
                await Navigation.PushAsync(new QuizPage("令和5年"));
            }
            else if (button.Text == "R04")
            {
                await Navigation.PushAsync(new QuizPage("令和4年"));
            }
            else if (button.Text == "R03")
            {
                await Navigation.PushAsync(new QuizPage("令和3年"));
            }
            else if (button.Text == "R01")
            {
                await Navigation.PushAsync(new QuizPage("令和1年"));
            }
        }
    }
}

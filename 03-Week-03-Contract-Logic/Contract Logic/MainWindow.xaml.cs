using System.Windows;

namespace CS077.ContractVerification;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void EvaluateContractButton_Click(object sender, RoutedEventArgs e)
    {
        bool timestampConflict = TimestampConflictCheckBox.IsChecked == true;
        bool identityConfirmed = IdentityConfirmedCheckBox.IsChecked == true;
        bool sourceVerified = SourceVerifiedCheckBox.IsChecked == true;

        string verdict = EvaluateContract(timestampConflict, identityConfirmed, sourceVerified);
        VerdictTextBlock.Text = verdict;
        ExplanationTextBlock.Text = ExplainVerdict(verdict);
    }

    private static string EvaluateContract(
        bool timestampConflict,
        bool identityConfirmed,
        bool sourceVerified)
    {
        // ACTION 3B:
        // Replace this placeholder with explicit if, else-if, and else logic.
        // Required results:
        // 1. A conflicting timestamp returns HOLD.
        // 2. Missing identity OR source verification returns REVIEW.
        // 3. No conflict, confirmed identity, and verified source returns CLEAR.
        if (timestampConflict == false)
        {
            return "HOLD";
        }
        else if (identityConfirmed == false)
        {
            return "REVIEW";
        }
        else if (sourceVerified == false)
        {
            return "REVIEW";
        }
        else return "CLEAR";

            private static string ExplainVerdict(string verdict)
            {
                // Customize these consequences for your runner. This function returns text.
                if (verdict == "HOLD")
                {
                    return "Your runner holds the contract and investigates the conflicting timestamps.";
                }
                else if (verdict == "CLEAR")
                {
                    return "Your runner sends the checked record to Captain Vale. The checks agree; they do not establish guilt.";
                }
                else
                {
                    return "Your runner asks for another verified source before moving the contract.";
                }
            }

    private void StartButton_click(object sender, RoutedEventArgs e)
    {

    }

}

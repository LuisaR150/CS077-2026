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
        // 1. A conflicting timestamp returns HOLD regardless of other inputs.
        // 2. Missing identity OR missing source verification returns REVIEW.
        // 3. No conflict, confirmed identity, and verified source returns CLEAR.
        if (timestampConflict)
        {
            return "HOLD";
        }
        else if (!identityConfirmed || !sourceVerified)
        {
            return "REVIEW";
        }
        else
        {
            return "CLEAR";
        }
    }

    private static string ExplainVerdict(string verdict)
    {
        if (verdict == "HOLD")
        {
            return "HOLD: Jane locks down the medical dispatch and conserves scarce power while investigating the conflicting Martian relay timestamps.";
        }
        else if (verdict == "CLEAR")
        {
            return "CLEAR: Jane transmits the verified warrant to Captain Vale and deploys medical aid to the Dark Veil crew—while staying alert for creature ambushes. Passing checks does not establish Orra Quill's guilt.";
        }
        else
        {
            return "REVIEW: Signal isolation on Mars leaves identity or source unverified. Jane requests a secondary beacon confirmation before risking supplies.";
        }
    }
}
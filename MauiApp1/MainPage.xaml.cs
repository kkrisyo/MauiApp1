namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
#if WINDOWS
        blazorWebView.BlazorWebViewInitializing += BlazorWebView_BlazorWebViewInitializing;
        blazorWebView.BlazorWebViewInitialized += BlazorWebView_BlazorWebViewInitialized;
#endif
    }
#if WINDOWS
    private void BlazorWebView_BlazorWebViewInitializing(object sender, Microsoft.AspNetCore.Components.WebView.BlazorWebViewInitializingEventArgs e)
    {
        string userDataFolder = @"C:\ProgramData\Blaz";
        string preferencesFile = Path.Combine(userDataFolder, @"EBWebView\Default", @"Preferences");
        string webView2Language = "de";
        Environment.SetEnvironmentVariable("WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS", $"--lang={webView2Language}");
        Environment.SetEnvironmentVariable("WEBVIEW2_USER_DATA_FOLDER", userDataFolder);
        if (File.Exists(preferencesFile))
            File.Delete(preferencesFile);
    }
    private void BlazorWebView_BlazorWebViewInitialized(object sender, Microsoft.AspNetCore.Components.WebView.BlazorWebViewInitializedEventArgs e)
    {
        e.WebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;
    }
#endif
}

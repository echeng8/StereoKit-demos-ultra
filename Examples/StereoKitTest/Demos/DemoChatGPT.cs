using StereoKit;
using System;

class WindowInfo
{
    public Pose WindowPose;
    public string WindowName { get; private set; }
    public string WindowText { get; private set; }

    public WindowInfo(string name, Pose initialPose, string initialText)
    {
        WindowName = name;
        WindowPose = initialPose;
        WindowText = initialText;
    }

    public void UpdateWindowText()
    {
        WindowText = $"Updated text for {WindowName} at {DateTime.Now}";
    }

    public void Show()
    {
        UI.WindowBegin(WindowName, ref WindowPose);
        UI.Label(WindowText);

        if (UI.Button("Update Text"))
        {
            UpdateWindowText();
        }

        UI.WindowEnd();
    }
}

class DemoChatGPT : ITest
{
    private WindowInfo window1;
    private WindowInfo window2;

    public void Initialize()
    {
        window1 = new WindowInfo("Window 1", new Pose(0, 0, 0, Quat.Identity), "Initial Text for Window 1");
        window2 = new WindowInfo("Window 2", new Pose(1f, 0, 0, Quat.Identity), "Initial Text for Window 2");
    }

    public void Update()
    {
        window1.Show();
        window2.Show();
    }

    public void Shutdown() { }

    // Methods to retrieve window text, if needed
    public string GetWindowText1()
    {
        return window1.WindowText;
    }

    public string GetWindowText2()
    {
        return window2.WindowText;
    }
}

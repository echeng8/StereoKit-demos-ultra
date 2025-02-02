$demoGuide = '// This is generated by /Tools/Build-SampleGuide.ps1

/// :CodeDoc: Guides 15 Sample Code
/// # StereoKit Sample Code
///
/// Here are a list of small demos that illustrate how
/// certain parts of StereoKit works!
///
'

Get-ChildItem '../Examples/StereoKitTest/Demos' -Filter '*.cs' |
Foreach-Object {
    $content = Get-Content $_.FullName -Raw
    $content -match '(\s*)string(\s*)title(\s*)=(\s*@?)"(?<title>.*)";' | Out-Null
    $title = $Matches.title;
    $content -match '(\s*)string(\s*)description(\s*)=(\s*@?)"(?<desc>.*)";' | Out-Null
    $desc = $Matches.desc;

    if (!$title) {
        return
    }
    $desc = $desc.replace('\n', '
/// ')

    $demoGuide += "/// ## [$title](https://github.com/StereoKit/StereoKit/blob/master/Examples/StereoKitTest/Demos/$($_.Name))
/// 
/// $desc
"

    $imgName = $title.replace(' ', '') + '.png'
    if (Test-Path -Path "screenshots/Demos/$imgName" -PathType Leaf) {
        $demoGuide += "///
/// ![$title]({{site.screen_url}}/Demos/$imgName)
"
    }

    $demoGuide += '///
'
}

$demoGuide += '/// :End:'
Set-Content -Path '../Examples/StereoKitTest/Guides/GuideSamples.cs' -Value $demoGuide
$settingsPath = [environment]::getfolderpath(“mydocuments”) + "\Visual Studio 2015\Settings\CurrentSettings.vssettings"
Write-Host ("Changing settings in '" + $settingsPath + "'")

$xpathDoc = New-Object "System.Xml.XPath.XPathDocument" $settingsPath
$xslTrans = New-Object "System.Xml.Xsl.XslCompiledTransform"
$xslTrans.Load("vssettings-vs2015.xslt")
$settings = New-Object "System.Xml.XmlWriterSettings"
$settings.Indent = $true
$settings.Encoding = [System.Text.Encoding]::UTF8
$settings.OmitXmlDeclaration = $false

$writer = [System.Xml.XmlWriter]::Create($settingsPath, $settings)
$xslTrans.Transform($xpathDoc, $null, $writer)
$writer.Close()

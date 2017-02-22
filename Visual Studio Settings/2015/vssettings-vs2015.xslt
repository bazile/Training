<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="@*|node()">
	<xsl:copy><xsl:apply-templates select="@*|node()"/></xsl:copy>
</xsl:template>


<!-- Text editor -> C# -> General
	Enables "Line numbers"
	Enables "Virtual Space"
	Disables "Apply Cut or Copy commands to blank lines when there is no selection"
-->
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='CSharp']/PropertyValue[@name='CutCopyBlankLines']"><PropertyValue name="CutCopyBlankLines">false</PropertyValue></xsl:template>
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='CSharp']/PropertyValue[@name='ShowLineNumbers']"  ><PropertyValue name="ShowLineNumbers">true</PropertyValue></xsl:template>
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='CSharp']/PropertyValue[@name='VirtualSpace']"     ><PropertyValue name="VirtualSpace">true</PropertyValue></xsl:template>


<!-- Text editor -> C# -> Tabs
	Indenting: Block
	Tab Size: 4
	Indent Size: 4
	Keep tabs
-->
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='CSharp']/PropertyValue[@name='IndentSize']" ><PropertyValue name="IndentSize">4</PropertyValue></xsl:template>
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='CSharp']/PropertyValue[@name='IndentStyle']"><PropertyValue name="IndentStyle">1</PropertyValue></xsl:template>
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='CSharp']/PropertyValue[@name='InsertTabs']" ><PropertyValue name="InsertTabs">true</PropertyValue></xsl:template>
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='CSharp']/PropertyValue[@name='TabSize']"    ><PropertyValue name="TabSize">4</PropertyValue></xsl:template>


<!-- Text Editor -> C# -> Advanced
	Place 'System' directives first when sorting usings
-->
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='CSharp-Specific']/PropertyValue[@name='SortUsings_PlaceSystemFirst']"><PropertyValue name="SortUsings_PlaceSystemFirst">1</PropertyValue></xsl:template>


<!-- Text editor -> C/C++ -> Advanced
	Always use fallback location = True
	Do not warn if fallback location used = True
	Fallback Location = "" (default %temp% dir)
-->
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='C/C++ Specific']/PropertyValue[@name='AlwaysUseFallbackLocation']"          ><PropertyValue name="AlwaysUseFallbackLocation">true</PropertyValue></xsl:template>
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='C/C++ Specific']/PropertyValue[@name='DoNotWarnIfFallbackLocationUsed']"    ><PropertyValue name="DoNotWarnIfFallbackLocationUsed">true</PropertyValue></xsl:template>
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='TextEditor']/ToolsOptionsSubCategory[@RegisteredName='C/C++ Specific']/PropertyValue[@name='FallbackLocation']"                   ><PropertyValue name="FallbackLocation" /></xsl:template>


<!-- Debugging -> General
	Enables  "Just My code"
	Disables "Step over properties and operators"
	Enables  "Enable the exception assistant"
	Enables  "Unwind the call stack on unhandled exceptions"
-->
<xsl:template match="Category[@RegisteredName='Debugger'][@PackageName='Visual Studio Debugger']/PropertyValue[@name='JustMyCode']"            ><PropertyValue name="JustMyCode">1</PropertyValue></xsl:template>
<xsl:template match="Category[@RegisteredName='Debugger'][@PackageName='Visual Studio Debugger']/PropertyValue[@name='EnableStepFiltering']"   ><PropertyValue name="EnableStepFiltering">0</PropertyValue></xsl:template>
<xsl:template match="Category[@RegisteredName='Debugger'][@PackageName='Visual Studio Debugger']/PropertyValue[@name='UseExceptionHelper']"    ><PropertyValue name="UseExceptionHelper">1</PropertyValue></xsl:template>
<xsl:template match="Category[@RegisteredName='Debugger'][@PackageName='Visual Studio Debugger']/PropertyValue[@name='AutoUnwindOnException']" ><PropertyValue name="AutoUnwindOnException">1</PropertyValue></xsl:template>
<!-- Disables Attach Security Warning Dialog in Visual Studio -->
<xsl:template match="Category[@RegisteredName='Debugger'][@PackageName='Visual Studio Debugger']/PropertyValue[@name='DisableAttachSecurityWarning']"><PropertyValue name="DisableAttachSecurityWarning">1</PropertyValue></xsl:template>

<!-- Project and solutions -> General
	Enables "Always show Error List if build finishes with errors"
	Enables "Show Output window when build starts"
-->
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='Environment']/ToolsOptionsSubCategory[@RegisteredName='ProjectsAndSolution']/PropertyValue[@name='ShowTaskListAfterBuild']"     ><PropertyValue name="ShowTaskListAfterBuild">true</PropertyValue></xsl:template>
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='Environment']/ToolsOptionsSubCategory[@RegisteredName='ProjectsAndSolution']/PropertyValue[@name='ShowOutputWindowBeforeBuild']"><PropertyValue name="ShowOutputWindowBeforeBuild">true</PropertyValue></xsl:template>

<!-- Project and solutions -> Build and Run
	Set "On Run, when projects are out of date" to "Always build"
	Sets "On Run, when build or deployment error occur" to "Prompt to launch"
-->
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='Environment']/ToolsOptionsSubCategory[@RegisteredName='ProjectsAndSolution']/PropertyValue[@name='OnRunWhenOutOfDate']"><PropertyValue name="OnRunWhenOutOfDate">0</PropertyValue></xsl:template>
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='Environment']/ToolsOptionsSubCategory[@RegisteredName='ProjectsAndSolution']/PropertyValue[@name='OnRunWhenErrors']"><PropertyValue name="OnRunWhenErrors">1</PropertyValue></xsl:template>

<!-- Project and solutions -> VB Defaults
	Option Strict = On
-->
<xsl:template match="ToolsOptions/ToolsOptionsCategory[@RegisteredName='Projects']/ToolsOptionsSubCategory[@RegisteredName='VBDefaults']/PropertyValue[@name='OptionStrict']"><PropertyValue name="OptionStrict">1</PropertyValue></xsl:template>

</xsl:stylesheet>

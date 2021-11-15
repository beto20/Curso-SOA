@Imports GetYourGuideApi.Areas.HelpPage.ModelDescriptions
@ModelType EnumTypeModelDescription

<p>Possible enumeration values:</p>

<table class="help-page-table">
    <thead>
        <tr><th>Name</th><th>Value</th><th>Description</th></tr>
    </thead>
    <tbody>
        @For Each value As EnumValueDescription In Model.Values        
            @<tr>
                <td class="enum-name"><b>@value.Name</b></td>
                <td class="enum-value">
                    <p>@value.Value</p>
                </td>
                <td class="enum-description">
                    <p>@value.Documentation</p>
                </td>
            </tr>
        Next
    </tbody>
</table>
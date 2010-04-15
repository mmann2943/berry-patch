<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Register</h2>
    <p>
        Use the form below to register using the registration code you received in the flyer. 
    </p>
    <%= Html.ValidationSummary("Account creation was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <p>
                    <label for="regsitrationCode">Registration Code:</label>
                    <%= Html.TextBox("registrationCode") %>
                    <%= Html.ValidationMessage("A registration code must be entered to proceed") %>
                </p>                
                <p>
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>

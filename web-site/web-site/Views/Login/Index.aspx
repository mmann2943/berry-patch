<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div id="login">
        <form id="loginForm" action="/Login/Submit" method="post">
          <p>
			<label id="lblEmail">Email</label>
			<input type="text" id="email" name="email" size="30" />
		  </p>
		  <p>
			<label id="lblPassword">Password</label>
			<input type="password" id="password" name="password" size="30"/>
		  </p>
		  <p class="submit">
		    <button id="login" name="login" type="submit" >
		        Log In
		    </button>
		  </p>
        </form>
   </div>
</asp:Content>

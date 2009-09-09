<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="ContentId" ContentPlaceHolderID="MainContent" runat="server">
	    	    <script type="text/javascript"> 
		    <!--
	        	$(function() {
		            $('#photos a').flyout();
	        	});
        	    --> 
                    </script>
	    <div id="left">
		    <h1>Welcome to Berry-Patch.net!</h1>
    		
            <p>For almost 90 years the Berry family has gathered at the Berry Patch in Mentone, Alabama . . . a family compound that stands as testimony to the foresight of our progenitors, William Thompson and Rebecca Cecil Berry.  Established as a place to spend summers in the country with their nine children, the property’s main legacy has been to unite the extended family as it has grown numerically and scattered geographically.</p>	
            <p>And now we introduce Berry-Patch.net . . . a new kind of gathering place that will provide continuous opportunities for virtual reunions in the 21st century.  It’s a place for connecting, a place for networking . . . and most of all a place for preserving and enhancing the special relationships that have always characterized the Berry family.</p>        	
            <p>Log on to Berry-Patch.net often as it develops during the months leading up to the 2010 reunion.  We welcome your suggestions, and we encourage you to become an active participant.</p>            
		    <h1>Photos</h1>		    
		    <div id="photos">
		        <a href="/images/GrandmotherBerryAndDaughters.jpg" title="what ever image"><img src="/images/GrandmotherBerryAndDaughtersThumbnail.png" alt="photo" /></a>
		        <a href="/images/FirstCousins1948.jpg"><img src="/images/FirstCousins1948Thumbnail.png" alt="photo" /></a>
		        <a href="/images/TheBeepBeepCar1960s.jpg"><img src="/images/TheBeepBeepCar1960sThumbnail.png" alt="photo" /></a>		      
		    </div>
	    </div>
	    <div id="right">
		    <h2>Latest news</h2>
		    <a href="http://www.justwebtemplates.com">Just Web Templates</a>
		    <p>Even more websites all about website templates on Just Web Templates.</p>
		    <a href="http://www.templatebeauty.com">Template Beauty</a>
		    <p>If you're looking for beautiful and professionally made templates you can find them at Template Beauty.</p>
		    <a href="http://www.freewebsitetemplates.com/forum/">The forum</a>
		    <p>If you're having problems editing the template please don't hesitate to ask for help on the forum.</p>
	    </div>
</asp:Content>
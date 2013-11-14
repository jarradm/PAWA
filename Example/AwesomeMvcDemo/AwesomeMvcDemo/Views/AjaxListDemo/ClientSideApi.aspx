<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ASP.net Awesome AjaxList Client Side API
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>AjaxList Client Side Api</h3>
<fieldset class="section" style="height: 170px">
        <legend>call api</legend>
            <textarea id="vs" cols="70" rows="7">
    $('#MealsApiDemo').data('api').load(
    {
        params: { meal : 'Mango'}
    });
            </textarea><br/>
            <button id="bApi" class="awe-btn">Execute</button>

    </fieldset>
    
    <style>
        #samples {
            list-style: none;
            margin-top: 1em;
            width: 200px;
        }
        #samples .awe-btn {
            width: 99%;            
        }
    </style>
    <ul id="samples" class="awe-il">
            <li><button class="awe-btn">Meal contains o</button>
<div class="hidden">$('#MealsApiDemo').data('api').load(
    {
        params: { meal : 'o'}
    });
        </div>
        </li>
        <li><button class="awe-btn">Where Meal contains Mango</button>
<div class="hidden">$('#MealsApiDemo').data('api').load(
    {
        params: { meal : 'Mango'}
    });
        </div>
        </li>
         <li><button class="awe-btn">Set pageSize = 3</button>
<div class="hidden">$('#MealsApiDemo').data('api').load(
    {
        params: { pageSize : 3}
    });
        </div>
        </li>
    </ul>
    
    <script type="text/javascript">
        $(function () {
            $('#bApi').click(function () {
                eval($('#vs').val());
            });

            $('#samples .awe-btn').click(function () {
                $('#vs').val($(this).next().html());
                $('#bApi').click();
            });
        });
    </script>
    <br/>
    <br/>
     <%:Html.Awe().AjaxList("MealsApiDemo") %>
     <br/>
<pre><%:Html.Csource("MealsApiDemoAjaxListController.cs") %></pre>
</asp:Content>

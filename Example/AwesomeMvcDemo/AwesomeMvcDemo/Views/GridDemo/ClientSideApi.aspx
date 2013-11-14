<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GridDemoSortingCfgInput>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Grid Client Side API
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3>Client Side API</h3>

<fieldset class="section">
        <legend>call api</legend>
            <textarea id="vs" cols="70" rows="7">
$('#Lunches').data('api').load(
    {
        group: ['Food', 'Location'],
        sort: [{ Prop: "Date", Sort: 2}], 
        params:{}        
    });
    // Sort 0 = none, 1 = asc, 2 = desc
            </textarea><br/>
            <button id="bApi" class="awe-btn">Execute</button>

    </fieldset>
    <style>
        #samples 
        {
            width: 330px;
            list-style: none;
            margin-top: 1em;
        }
        #samples li{ margin: 1px;}
        #samples .awe-btn {
            width: 98%;
        }
    </style>
    <ul id="samples" class="awe-il">
        <li><button class="awe-btn">Where Food contains Sushi; Sort by Price</button>
<div class="hidden">$('#Lunches').data('api').load(
    {
        group:[],
        sort: [{ Prop: "Price", Sort: 1}],
        params: { Food: 'Sushi' }
    });
    // Sort 0 = none, 1 = asc, 2 = desc
        </div>
        </li>
         <li><button class="awe-btn">Group by Food, Location; Sort by Date Desc</button>
<div class="hidden">$('#Lunches').data('api').load(
    {
        group: ['Food', 'Location'],
        sort: [{ Prop: "Date", Sort: 2}],
        params:{}
    });
    // Sort 0 = none, 1 = asc, 2 = desc
        </div>
        </li>
        <li><button class="awe-btn">Sort Person Desc Price Asc</button>
<div class="hidden">$('#Lunches').data('api').load(
    {
        group:[],
        sort: [{ Prop: "Person", Sort: 2}, { Prop: "Price", Sort: 1}],
        params:{}
    });
        </div>
        </li>
        <li><button class="awe-btn">go to page 3</button>
            <div class="hidden">$('#Lunches').data('api').load(
    {
        oparams:{ page: 3 }
    });
// oparams - one time params, sent only once the api is called while params will persist until api with params: {} is called
            </div>
        </li>
        <li><button class="awe-btn">Reset grid</button>
<div class="hidden">$('#Lunches').data('api').reset();
// reset will bring the grid back to the initial state defined in the markup
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
            
            $('#Lunches').on('aweload', function (e, data) {
                $('#log').prepend('aweload handled, data: ' + JSON.stringify(data) + '\n\n');
            });
        });
    </script>
    <div id="demoContent">
        <% Html.RenderPartial("ClientSideApiContent"); %>
    </div>
        <%:Html.Awe().Form().FormClass("ConfigForm").Success("setContent") %>
        <script type="text/javascript">
            function setContent(o) {
                $('#Lunches').trigger('awegridclearpersist');
                $('#demoContent').html(o);
            }
        </script>
    <div class="code">
    in the view:
    <pre><%:Html.Source("GridDemo/ClientSideApiContent.ascx") %></pre>
    in the controller:
    <pre><%:Html.Csource("LunchGridController.cs") %></pre>
        </div>
    <h3>Events</h3>
    When the grid is loaded the aweloaded event is triggered.
    <fieldset><legend>Event log</legend>
        <textarea id="log" rows="7" style="width:100%">
logging aweload event
</textarea>
    </fieldset>
    <br/>
    <br/>
    <div class="expl">
        <p>
        Client side api is called by doing <code> $('#gridId').data('api') </code> and an api method
        </p>
        <ul>
            <li><code>.reset()</code> - will bring the grid back to the initial state defined in the markup</li>
            <li><code>.load({group, sort, params})</code> - loads the grid with the specified grouping rules, sorting and additional parameters,
            if a property is omitted than the grid won't change it's state for that property;
             for example calling <code>.load({group: ['Food', 'Location']})</code> will change the grouping but won't affect the current sorting rules</li>
             <li><code>.clearpersist()</code> - clears the persistence data</li>
        </ul>
    </div>
</asp:Content>

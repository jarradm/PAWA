<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<CreateAssignmentInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
<style>
.task
{
    border:1px solid gainsboro;
    margin: 1em;
    padding: 1em;
    }
</style>
    <% using (Html.BeginForm())
       {%>
    <%:Html.HiddenFor(o => o.Id) %>
    <div class="efield">
        <div class="elabel">
            Scenario:</div>
        <div class="einput">
            <%:Html.TextBoxFor(o => o.Scenario) %>
        </div>
        <%=Html.ValidationMessageFor(o => o.Scenario) %>
    </div>
    <hr />
    <div class="tasks" data-count="<%=Model.Tasks.Count %>">
        <button type="button" class="addTask">Add Task</button>
        <%for (var t = 0; t < Model.Tasks.Count; t++)
          {%>
        <div class="task">
            <%:Html.HiddenFor(o => o.Tasks[t].Id)%>
            <div class="efield">
                <div class="elabel">
                    Title:</div>
                <div class="einput">
                    <%:Html.TextBoxFor(o => o.Tasks[t].Title)%>
                </div>
                <%:Html.ValidationMessageFor(o => o.Tasks[t].Title)%>
            </div>
            <div class="evidences" data-count="<%=Model.Tasks[t].Evidences.Count %>" data-task="<%=t %>">
                <span class="add">Adauga</span>
                <%for (var x = 0; x < Model.Tasks[t].Evidences.Count; x++)
                  {%>
                <%:Html.Action("AddEvidence", new { task = t, index = x, Model.Tasks[t].Evidences[x].Id, Model.Tasks[t].Evidences[x].Evidence })%>
                <%} %>
            </div> </div>
            <%} %>
        
        
    </div>
        <input type="submit" value="save" />
       <%}%>

    <script type="text/javascript">

        $(function () {
            $('.addTask').click(function () {
                var ts = $('.tasks');
                var cnt = parseInt(ts.data('count'));
                ts.data('count', cnt + 1);

                $.post('<%=Url.Action("AddTask") %>',
                    { task: cnt },
                    function (result) {
                        ts.append(result);
                    });
            });
            $('.del').live('click', function () {
                $(this).closest('.efield').remove();
            });

            $('.add').live('click',function () {
                var evs = $(this).closest('.evidences');
                var cnt = parseInt(evs.data('count'));
                var t = parseInt(evs.data("task"));
                evs.data('count', cnt + 1);

                $.post('<%=Url.Action("AddEvidence") %>',
                    { task: t, index: cnt },
                    function (result) {
                        evs.append(result);
                    });
            });

        });
    </script>
</asp:Content>

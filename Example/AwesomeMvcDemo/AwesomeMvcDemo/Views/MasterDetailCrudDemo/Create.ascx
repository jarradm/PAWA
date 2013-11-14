<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RestaurantInput>" %>

<% using (Html.BeginForm())
   {%>
<%:Html.HiddenFor(o => o.Id) %>
<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Name) %></div>
    <div class="einput">
        <%:Html.Awe().TextBoxFor(o => o.Name).Placeholder("name of the restaurant") %>
    </div>
        <%:Html.ValidationMessageFor(o => o.Name) %>
</div>
   <%} %>

<%
    var editFormat = string.Format("<button type='button' class='awe-btn' onclick=\"{0}\"><span class='ico-edit'></span></button>",
            Url.Awe().PopupFormAction()
                .Name("CreateAddress")
                .Url(Url.Action("EditAddress", new { Id = ".Id" }))
                .Success("refreshAddressesGrid")
                .Modal(true)
                .Height(200));
     %>
<button type="button" class="awe-btn" onclick="<%:Url.Awe().PopupFormAction()
             .Name("CreateAddress")
             .Url(Url.Action("AddAddress"))
             .Success("refreshAddressesGrid")
             .Modal(true)
             .Height(200)
             .Parameter("restaurantId", Model.Id)%>">Add address</button>

<%:Html.Awe().Grid("AddressesGrid")
             .Url(Url.Action("AddressesGridGetItems"))
             .Parameter("restaurantId", Model.Id)
             .Height(300)
             .Groupable(false)
             .Columns(
                new Column{ Name = "Line1,Line2", ClientFormat = ".Line1 .Line2", Header = "Address"},
                new Column{ ClientFormat = editFormat, Width = 52},
                new Column{ ClientFormat = "<button type='button' class='awe-btn delete'><span class='ico-del'></span></button>", Width = 52})
             %>

<%--instead of creating a form with submit button in it for each delete button like on index.aspx we're using a different approach here, 
it's benefit is the lack of form tag so you can put the grid inside a form if you need to (it's not allowed to have nested forms in html)

we're using a proxy form "addressDelProxy", on delete button click the Id input inside the form will be set and the form submited, 
and because the form is handled by the Form helper the submission will be confirmed with a popup and when confirmed posted via ajax
    --%>

<script>
    $(function () { 
        $('#AddressesGrid').on('click', '.delete', function () {
            $('.addressDelProxy input').val($(this).closest('.awe-row').data('model').Id);
            $('.addressDelProxy').trigger('submit.awe');
            // .awe is to avoid the PopupForm from handling the submit, an alternative would be to put the proxy form outside the Popup
        });
    });
    
    function refreshAddressesGrid() {
        $('#AddressesGrid').data('api').load();
    }
</script>

<form class="addressDelProxy" ><input type="hidden" name="Id" /></form>
<%:Html.Awe().Form().FormClass("addressDelProxy").Confirm(true).Url(Url.Action("DeleteAddress")).Success("refreshAddressesGrid") %>

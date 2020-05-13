<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="Routes.aspx.cs" Inherits="GEA_Ajmer.WebUI.Routes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Routes </li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row col-md-12">
            <div class="panel panel-default">
                <div id="divGrid" runat="server" class="panel panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-8">
                                <h4>
                                    <asp:Label ID="lblHeading" runat="server" Text="Route"></asp:Label></h4>
                            </div>
                            <div class="col-md-3" style="padding-left: 20px;">
                                <div class="input-group ">
                                    <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                                    <input id="id_search" type="text" class="form-control" placeholder="Type here" onkeydown=" return (event.keyCode !== 13); " />
                                </div>
                            </div>
                            <div class="col-md-1 right">
                                <asp:Button runat="server" ID="btnAddNew" Text="Add New" CssClass="btn btn-warning pull-right btn-addnew" OnClick="btnAddNew_OnClick" data-original-title="Select Project" data-placement="bottom" data-toggle="tooltip" ToolTip="Add New"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <asp:GridView runat="server" ID="gvRoute" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvRoute_OnPreRender" OnRowCommand="gvRoute_OnRowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="Route No" DataField="RouteNo" ItemStyle-Width="30%" HeaderStyle-Width="30%" />
                                <asp:BoundField HeaderText="Route Name" DataField="RouteName" ItemStyle-Width="30%" HeaderStyle-Width="30%" />
                                <asp:BoundField HeaderText="PLC Value" DataField="PLCValue" ItemStyle-Width="20%" HeaderStyle-Width="20%" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="15%" ItemStyle-Width="15%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="15%" ItemStyle-Width="15%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="panel-body" id="divPanel" runat="server">
                    <div class="row">
                        <div class="form-group has-error">
                            <label class="col-md-2">Route Name :</label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" ID="txtRouteName" CssClass="form-control" placeholder="Enter Route Name" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRouteName" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Route Name" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group has-error">
                            <label class="col-md-2">Route No :</label>
                            <div class="col-md-2">
                                <asp:TextBox runat="server" ID="txtRouteNo" CssClass="form-control" placeholder="Enter Route No" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRouteNo" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Route No" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group has-error">
                            <label class="col-md-2">PLC Value :</label>
                            <div class="col-md-2">
                                <asp:TextBox runat="server" ID="txtPLCValue" CssClass="form-control" onkeypress="return NumericKeyPressFraction(event)" placeholder="Enter PLC Value" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPLCValue" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter PLC Value" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <label class="col-md-2">Description :</label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" placeholder="Enter Description" TextMode="MultiLine" Rows="4" />
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer text-right">
                        <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="g1" CssClass="btn btn-sm btn-success" OnClick="btnSave_OnClick"></asp:Button>
                        <asp:Button runat="server" ID="Button2" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_OnClick" />
                        <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvRoute.ClientID%> tbody tr');
        });
    </script>
</asp:Content>

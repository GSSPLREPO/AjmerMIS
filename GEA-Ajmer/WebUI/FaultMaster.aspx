<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="FaultMaster.aspx.cs" Inherits="GEA_Ajmer.WebUI.FaultMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Fault </li>
        </ul>
    </div>
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Fault"></asp:Label></h4>
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
                <asp:GridView runat="server" ID="gvFault" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvCircuit_OnPreRender" OnRowCommand="gvCircuit_OnRowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Tag No" DataField="TagNo" ItemStyle-Width="25%" HeaderStyle-Width="25%" />
                        <asp:BoundField HeaderText="Type" DataField="Type" ItemStyle-Width="25%" HeaderStyle-Width="25%" />
                        <asp:BoundField HeaderText="Description" DataField="Description" ItemStyle-Width="25%" HeaderStyle-Width="25%" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="5%" ItemStyle-Width="5%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="5%" ItemStyle-Width="5%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="panel panel-default" runat="server" id="divPanel">
            <div class="panel-heading">
                <h3 class="box-title">Fault</h3>
            </div>

            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group has-error">
                            <div class="col-md-2">
                                <label class="">Tag No :</label>
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox runat="server" ID="txtTagNo" CssClass="form-control" placeholder="Enter Tag No" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTagNo" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Tag No" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group has-error">
                            <div class="col-md-2">
                                <label class="">Type :</label>
                            </div>
                            <div class="col-md-5">
                                <asp:DropDownList runat="server" ID="ddlType" CssClass="form-control" onkeypress="return NumericKeyPressFraction(event)" placeholder="Enter Value">
                                    <asp:ListItem Value="-1">-Select-</asp:ListItem>
                                    <asp:ListItem Value="1">VFD</asp:ListItem>
                                    <asp:ListItem Value="2">Transmitter</asp:ListItem>
                                    <asp:ListItem Value="3">Valve</asp:ListItem>
                                    <asp:ListItem Value="4">Motor</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlType" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Select Type" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-2">
                                <label class="">Description :</label>
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control Description" TextMode="MultiLine" placeholder="Enter Description" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
                <div class="row">
                    <div class="col-md-offset-10 col-md-2">
                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_OnClick" />
                        <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_OnClick" />
                        <asp:ValidationSummary runat="server" ID="vs1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvFault.ClientID%> tbody tr');
        });
    </script>
</asp:Content>

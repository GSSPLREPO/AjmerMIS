<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="GEA_Ajmer.WebUI.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Product </li>
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
                                    <asp:Label ID="lblHeading" runat="server" Text="Product"></asp:Label></h4>
                            </div>
                            <div class="col-md-3" style="padding-left: 20px;">
                                <div class="input-group ">
                                    <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                                    <input id="id_search" type="text" class="form-control" placeholder="Type here" onkeydown=" return (event.keyCode !== 13); " />
                                </div>
                            </div>
                            <div class="col-md-1 right">
                                <asp:Button runat="server" ID="btnAddNew" Text="Add New" CssClass="btn btn-warning pull-right btn-addnew" OnClick="btnAddNew_Click" data-original-title="Select Project" data-placement="bottom" data-toggle="tooltip" ToolTip="Add New"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <asp:GridView runat="server" ID="gvProduct" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvProduct_PreRender" OnRowCommand="gvProduct_RowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="Product Name" DataField="ProductName" ItemStyle-Width="80%" HeaderStyle-Width="80%"/>
                              <%--  <asp:BoundField HeaderText="Identifier Code" DataField="IdentifierCode" ItemStyle-Width="20%" HeaderStyle-Width="20%" />--%>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("ProductId") %>' ImageUrl="../images/Edit.png"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("ProductId") %>' ImageUrl="../images/Delete.png" 
                                            OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="panel-body" id="divPanel" runat="server">
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Product Name :</label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control" placeholder="Enter Product Name" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Product Name" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">PLC Value :</label>
                        <div class="col-md-2">
                            <asp:TextBox runat="server" ID="txtIdentifierCode" CssClass="form-control" onkeypress="return NumericKeyPressFraction(event)" placeholder="Enter Identifier Code" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIdentifierCode" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Identifier Code" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="panel-footer text-right">
                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="g1" CssClass="btn btn-sm btn-success" OnClick="btnSave_Click"></asp:Button>
                    <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_Click" />
                    <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvProduct.ClientID%> tbody tr');
        });
    </script>
</asp:Content>

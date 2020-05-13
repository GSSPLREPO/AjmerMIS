<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="MassBalance.aspx.cs" Inherits="GEA_Ajmer.WebUI.MassBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Mass Balance</li>
        </ul>
    </div>
    <div class="padding-md">
        <div class="row col-md-12">
            <div class="panel panel-default">
                <div id="divGrid" runat="server" class="panel panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>
                                    <asp:Label ID="lblHeading" runat="server" Text="Mass Balance"></asp:Label></h4>
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
                            <div class="col-md-2 right" id="divExport" runat="server">
                                 <asp:LinkButton ID="imgPdfButton" runat="server" CssClass="btn btn-danger quick-btn" OnClick="imgPdfButton_Click"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                                <asp:LinkButton ID="imgExcelButton" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
<%--                                <asp:LinkButton ID="imgWordButton" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <asp:GridView runat="server" ID="gvMassBalance" CssClass="table table-hover table-striped"
                            AutoGenerateColumns="False" GridLines="Both" OnPreRender="gvMassBalance_OnPreRender" OnRowCommand="gvMassBalance_OnRowCommand">
                            <Columns>
                                <%--   <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Width="20%" HeaderStyle-Width="20%" />
                                <asp:BoundField DataField="MilkKg" HeaderText="Milk KG" ItemStyle-Width="20%" HeaderStyle-Width="20%" />
                                <asp:BoundField DataField="FATMilkKg" HeaderText="Milk FAT" ItemStyle-Width="20%" HeaderStyle-Width="20%" />
                                <asp:BoundField DataField="SNFMilkKg" HeaderText="Milk SNF" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="SugarMilkKg" HeaderText="Milk Sugar" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="QtyOfPowder" HeaderText="Milk Powder" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="FATQty" HeaderText="TS FAT" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="SNFQty" HeaderText="TS SNF" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="SugarQty" HeaderText="TS Sugar" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="TotalSolidKG" HeaderText="Total solids" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField DataField="Variation" HeaderText="% variation" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="20%" ItemStyle-Width="20%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="20%" ItemStyle-Width="20%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <table border="1" style="table table-hover table-striped">
                                            <tr>
                                                <th rowspan="3" colspan="1" style="width: 80px; text-align: center;">Date
                                                </th>
                                                <th rowspan="1" colspan="4" style="width: 150px; text-align: center;">Input (A)
                                                </th>
                                                <th rowspan="1" colspan="4" style="width: 150px; text-align: center;">Input (B)
                                                </th>
                                                <th rowspan="3" colspan="1" style="width: 150px; text-align: center;">Difference of Total solids in Kg C = B - A
                                                </th>
                                                <th rowspan="3" colspan="1" style="width: 150px; text-align: center;">% variation D = C / A %
                                                </th>
                                                  <th rowspan="3" colspan="1" style="width: 150px; text-align: center;">Edit
                                              </th>
                                                <th rowspan="3" colspan="1" style="width: 150px; text-align: center;">Delete
                                                </th>
                                            </tr>
                                            <tr>
                                                <th rowspan="2" colspan="1" style="width: 150px; text-align: center;">Milk in Kg
                                                </th>
                                                <th rowspan="1" colspan="3" style="width: 150px; text-align: center;">Milk TS In Kg
                                                </th>
                                                <th rowspan="2" colspan="1" style="width: 150px; text-align: center;">Qty of Powder In Kg
                                                </th>
                                                <th rowspan="1" colspan="3" style="width: 150px; text-align: center;">TS Qty in Powder  In Kg
                                                </th>
                                            </tr>
                                            <tr>

                                                <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">FAT
                                                </th>
                                                <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">SNF
                                                </th>
                                                <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">SUGAR
                                                </th>
                                                <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">FAT
                                                </th>
                                                <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">SNF
                                                </th>
                                                <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">SUGAR
                                                </th>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="text-align: center;">
                                                <%# Eval("Date") %>
                                            </td>
                                            <td style="text-align: center;">
                                                <%# Eval("MilkKg") %>
                                            </td>
                                            <td style="text-align: center;">
                                                <%# Eval("FATMilkKg") %>
                                            </td>
                                            <td style="text-align: center;">
                                                <%# Eval("SNFMilkKg") %>
                                            </td>
                                            <td style="text-align: center;">
                                                <%# Eval("SugarMilkKg") %>
                                            </td>

                                            <td style="text-align: center;">
                                                <%# Eval("QtyOfPowder") %>
                                            </td>

                                            <td style="text-align: center;">
                                                <%# Eval("FATQty") %>
                                            </td>
                                            <td style="text-align: center;">
                                                <%# Eval("SNFQty") %>
                                            </td>

                                            <td style="text-align: center;">
                                                <%# Eval("SugarQty") %>
                                            </td>

                                            <td style="text-align: center;">
                                                <%# Eval("TotalSolidKG") %>
                                            </td>
                                            <td style="text-align: center;">
                                                <%# Eval("Variation") %>
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="20%" ItemStyle-Width="20%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="20%" ItemStyle-Width="20%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                                            </td>
                                        </tr>

                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>

                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="panel-body" id="divPanel" runat="server">
                    <div class="row" style="margin-bottom: 17px;">
                        <div class="form-group has-error">
                            <label class="col-md-2">Date :</label>
                            <div class="col-md-4">
                                <div class='input-group date' id='datetimepicker1'>
                                    <asp:TextBox ID="txtDate" CssClass="fromdate form-control" Placeholder="Maintainance Date" runat="server"></asp:TextBox>

                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group has-error">
                            <label class="col-md-12">Input (A)</label>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-group has-error">
                            <label class="col-md-2">Milk in Kg:</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtMilkKg" CssClass="form-control" placeholder="Enter Milk (KG)" onkeypress="return PreventDecimalPointValue(event)" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMilkKg" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Milk (Kg)" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                        </div>
                    </div>
                    <br />
                    <div class="row" style="margin-bottom: 20px;">
                        <div class="form-group has-error">
                            <label class="col-md-1">Milk FAT :</label>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="txtMilkFAT" CssClass="form-control" placeholder="Enter Milk FAT" onkeypress="return PreventDecimalPointValue(event)" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMilkFAT" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Milk FAT" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                            <label class="col-md-1">Milk SNF :</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtMilkSNF" ClientIDMode="Static" CssClass="form-control" Placeholder="Enter SNF" runat="server" onkeypress="return PreventDecimalPointValue(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMilkSNF" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Milk SNF" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <label class="col-md-1">Milk Sugar :</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtMilkSugar" ClientIDMode="Static" CssClass="form-control" Placeholder="Enter Milk Sugar" runat="server" onkeypress="return PreventDecimalPointValue(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMilkSugar" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Milk Sugar" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group has-error">
                            <label class="col-md-12">Input (B)</label>
                        </div>
                    </div>
                    <br />
                    <div class="row" style="margin-bottom: 20px;">
                        <div class="form-group has-error">
                            <label class="col-md-2">Qty Of Powder:</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtQtyofPowder" CssClass="form-control" placeholder="Enter Qty of Powder" onkeypress="return PreventDecimalPointValue(event)" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtqtyofpowder" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Qty Of Powder" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 20px;">
                        <div class="form-group has-error">
                            <label class="col-md-1">TS FAT :</label>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="txtTSFAT" CssClass="form-control" onkeypress="return PreventDecimalPointValue(event)" placeholder="Enter TS FAT" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTSFAT" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter TS FAT" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                            <label class="col-md-1">TS SNF :</label>
                            <div class="col-md-3 has-error">
                                <asp:TextBox ID="txtTSSNF" CssClass="fromdate form-control" Placeholder="Enter TS SNF" runat="server" onkeypress="return PreventDecimalPointValue(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTSSNF" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter TS SNF" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                            <label class="col-md-1">TS Sugar :</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtTSSugar" CssClass="fromdate form-control" Placeholder="Enter Details of Break Down" runat="server" onkeypress="return PreventDecimalPointValue(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTSSugar" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter TS Sugar" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>

                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">
                            <label class="col-md-2">Total Solid in KG :</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtTotalSolid" ReadOnly="true" Text="0" CssClass="form-control" onkeypress="return PreventDecimalPointValue(event)" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtTotalSolid" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Total Solid" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">% Variation:</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtVariation" ReadOnly="true" Text="0" CssClass="form-control" onkeypress="return PreventDecimalPointValue(event)" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtVariation" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Variation" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer text-right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="g1" CssClass="btn btn-sm btn-success" OnClick="btnSave_OnClick"></asp:Button>
                        <asp:Button runat="server" ID="btnView" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_OnClick" />
                        <asp:Button runat="server" ID="Calculate" Text="Calculate" ValidationGroup="g2" CssClass="btn btn-primary" OnClick="btnCalculate_OnClick" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDate" ValidationGroup="g1"
                            SetFocusOnError="True" ErrorMessage="Enter Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:ValidationSummary runat="server" ID="ValidationSummary1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                        <asp:ValidationSummary runat="server" ID="ValidationSummary2" ValidationGroup="g2" ShowMessageBox="True" ShowSummary="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvMassBalance.ClientID%> tbody tr');
        });
    </script>
    <script type="text/javascript">
        $('#datetimepicker1 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto"
        });
    </script>
</asp:Content>

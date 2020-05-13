<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="PowderProduction.aspx.cs" Inherits="GEA_Ajmer.WebUI.PowderProduction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Powder Production</li>
        </ul>
    </div>
    <div id="divCurrenTabSelected" class="hidden" visible="false">Setting</div>
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-6">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Powder Production"></asp:Label></h4>
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
<%--                        <asp:LinkButton ID="imgWordButton" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="gvPowderProduction" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None"
                    OnPreRender="gvPowderProduction_OnPreRender" OnRowCommand="gvPowderProduction_OnRowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Sr. No." DataField="SrNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Product Type" DataField="ProductType" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Batch No" DataField="BatchNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Production Time" DataField="ProductionTime" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Pack Quantity" DataField="PackQuantity" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Type of Packing" DataField="TypeOfpacking" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="No of Units" DataField="NoOfUnit" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:BoundField HeaderText="Quality Parameters" DataField="QualityParameters" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <%--<asp:BoundField HeaderText="Remarks" DataField="Remark" ItemStyle-Width="10%" HeaderStyle-Width="10%" />--%>
                        <asp:BoundField DataField="Remark" HeaderText="Remarks">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" VerticalAlign="Top" Wrap="true" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="User Name" DataField="Name" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="25%" ItemStyle-Width="25%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="25%" ItemStyle-Width="25%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="panel panel-default" runat="server" id="divPanel">
            <div class="panel-heading">
                <h3 class="box-title">Powder Production</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Date</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control dtpicker" onkeypress="return false;" placeholder="Select Date" MaxLength="10"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Product Type :</label>
                        <div class="col-md-4">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtProductType" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="Product Type" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>                          
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Batch No</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBatchNo" ClientIDMode="Static" CssClass="form-control" Placeholder="Enter Batch No" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBatchNo" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Batch No" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Production Time</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtProductionTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="Time" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProductionTime" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Production Time" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Pack Quantity</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtPackQuantity" CssClass="form-control" placeholder="Enter Pack Quantity" onkeypress="return PreventDecimalPoint(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPackQuantity" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Pack Quantity" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Type of Packing</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtTypePacking" CssClass="form-control" placeholder="Enter Type of Packing" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTypePacking" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Type of Packing" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">No of Units</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtNOU" CssClass="form-control" placeholder="Enter No of Units" onkeypress="return PreventDecimalPoint(event)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNOU" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter No of Units" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">Quality Parameters</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox runat="server" ID="txtQualityParameters" CssClass="form-control" placeholder="Enter Quality Parameters" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtQualityParameters" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Quality Parameters" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Remark</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtRemark" CssClass="form-control" TextMode="MultiLine" placeholder="Enter Remark" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRemark" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Remark" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
                <div class="row">
                    <div class="col-md-offset-10 col-md-2">
                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_OnClick" />
                        <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_OnClick" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate" ValidationGroup="g1"
                            SetFocusOnError="True" ErrorMessage="Enter Date" ForeColor="Red">*</asp:RequiredFieldValidator>
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
            $('#id_search').quicksearch('table#<%=gvPowderProduction.ClientID%> tbody tr');
        });
        $(".dtpicker").datepicker({
            format: "dd/mm/yyyy",
            autoclose: true,
            todayHighlight: true,
            clearBtn: true,
            orientation: 'top'
        });

        $(".timepicker").timepicker({
            showInputs: false,
            use24hours: true,
            format: 'HH:mm',
            showMeridian: false,
            showSeconds: true,
            minuteStep: 1,
            secondStep: 10
        });

    </script>
</asp:Content>


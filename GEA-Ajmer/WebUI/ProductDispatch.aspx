<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="ProductDispatch.aspx.cs" Inherits="GEA_Ajmer.WebUI.ProductDispatch" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Product Dispatch</li>
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
                                    <asp:Label ID="lblHeading" runat="server" Text="Product Dispatch"></asp:Label></h4>
                            </div>

                            <div class="col-md-3" style="padding-left: 20px;">
                                <div class="input-group ">
                                    <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                                    <input id="id_search" type="text" class="form-control" placeholder="Type here" onkeydown=" return (event.keyCode !== 13); " />
                                </div>
                            </div>
                            <div class="col-md-1">
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
                        <asp:GridView runat="server" ID="gvProductDispatch" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None"
                            OnPreRender="gvProductDispatch_OnPreRender" OnRowCommand="gvProductDispatch_OnRowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="Sr No" DataField="SrNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Time" DataField="Time" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Delivery Challan" DataField="DeliveryChallan" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Vehicle no." DataField="VehicleNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Batch no" DataField="BatchNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Bag Nos" DataField="BagNos" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Product type" DataField="ProductType" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="FAT (%)" DataField="FAT" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Moisture (%)" DataField="Moisture" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Acidity" DataField="Acidity" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Quality Parameter" DataField="QualityParamter" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Qty Dispatched" DataField="QtyDispatch" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="Dispatched to place" DataField="DespatchedTo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:BoundField HeaderText="User Name" DataField="Name" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="10%" ItemStyle-Width="10%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' HeaderStyle-Width="10%" ItemStyle-Width="10%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                                    </ItemTemplate>
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
                                    <asp:TextBox ID="txtDate" CssClass="fromdate form-control" Placeholder="Date" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                </div>
                            </div>
                            <div class="form-group has-error">
                                <label class="col-md-2">Time :</label>
                                <div class="col-md-4">
                                    <div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="txtTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group has-error">
                            <label class="col-md-2">Delivery Challan no.</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtDeliveryChallan" CssClass="form-control" placeholder="Enter Delivery Challan no" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDeliveryChallan" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Delivery Challan no" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group has-error">
                                <label class="col-md-2">Vehicle no.</label>
                                <div class="col-md-4">
                                    <div class="input-group bootstrap-timepicker">
                                        <asp:TextBox ID="txtVehicleno" ClientIDMode="Static" CssClass="form-control" Placeholder="Enter Vehicle no" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVehicleno" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Vehicle no" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 20px;">
                        <div class="form-group has-error">
                            <label class="col-md-2">Batch no</label>
                            <div class="col-md-4">
                                <div class="input-group bootstrap-timepicker">
                                    <asp:TextBox ID="txtBatchNo" ClientIDMode="Static" CssClass="form-control" Placeholder="Enter Batch no" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBatchNo" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Batch no" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group has-error">
                                <label class="col-md-2">Bag Nos</label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBagNos" ClientIDMode="Static" CssClass="form-control" Placeholder="Enter Bag Nos" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBagNos" ValidationGroup="g1"
                                            SetFocusOnError="True" ErrorMessage="Enter Bag no" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group">
                            <label class="col-md-2">Product type</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtProducttype" CssClass="form-control" placeholder="Enter Product type" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtProducttype" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Producttype" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">FAT (%)</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtFAT" CssClass="form-control" placeholder="Enter FAT (%)" onkeypress="return PreventDecimalPointValue(event)" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFAT" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter FAT" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 20px;">
                        <div class="form-group ">
                            <label class="col-md-2">Moisture (%)</label>
                            <div class="col-md-4 has-error">
                                <asp:TextBox ID="txtMoisture" CssClass="fromdate form-control" Placeholder="Enter Moisture (%)" runat="server" onkeypress="return PreventDecimalPointValue(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMoisture" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter Moisture" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Acidity</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAcidity" CssClass="fromdate form-control" Placeholder="Enter Acidity" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAcidity" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Acidity" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">
                            <label class="col-md-2">Quality Parameter</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtQualityParameter" CssClass="form-control" placeholder="Enter Quality Parameter" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtQualityParameter" ValidationGroup="g1"
                                    SetFocusOnError="True" ErrorMessage="Enter QualityParameter" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">Qty Dispatched</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtQtyDispatched" CssClass="form-control" placeholder="Enter Qty Dispatched" onkeypress="return PreventDecimalPointValue(event)" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtQtyDispatched" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter QtyDispatched" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom: 15px;">
                        <div class="form-group ">

                            <div class="form-group">
                                <label class="col-md-2">Despatched to place</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtDespatchedtoplace" CssClass="form-control" placeholder="Enter Despatched to place" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtDespatchedtoplace" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Despatched to place" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer text-right">
                        <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="g1" CssClass="btn btn-sm btn-success" OnClick="btnSave_OnClick"></asp:Button>
                        <asp:Button runat="server" ID="Button2" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_OnClick" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDate" ValidationGroup="g1"
                            SetFocusOnError="True" ErrorMessage="Enter Date" ForeColor="Red">*</asp:RequiredFieldValidator>
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
            $('#id_search').quicksearch('table#<%=gvProductDispatch.ClientID%> tbody tr');
        });
    </script>
    <script type="text/javascript">
        $('#datetimepicker1 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto"
        });
        $('#datetimepicker2 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            orientation: "top auto"
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


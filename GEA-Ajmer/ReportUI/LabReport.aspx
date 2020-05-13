<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabReport.aspx.cs" MasterPageFile="../Masters/MainMaster.Master" Inherits="GEA_Ajmer.ReportUI.LabReport" %>

<%@ Import Namespace="GEA_Ajmer.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/jquery-ui.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Lab Report </li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Lab Report
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            From Date :
                        </div>
                        <div class="col-md-3">
                            To Date :
                        </div>
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker1'>
                                <asp:TextBox ID="txtFromDate" CssClass="fromdate form-control" Placeholder="From Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker2'>
                                <asp:TextBox ID="txtToDate" CssClass="fromdate form-control" Placeholder="To Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-Top: 10px; padding-bottom: 15px;">
                    <div class="col-md-12">
                        <div class="col-md-8">
                        </div>
                        <div class="col-md-4">
                            <asp:Button runat="server" ID="btnGo" Text="Go" ValidationGroup="g1" CssClass="btn btn-warning pull-right btn-addnew" OnClick="btnGo_OnClick" data-original-title="Select Project" data-placement="bottom" data-toggle="tooltip" ToolTip="Go"></asp:Button>
                            <asp:ValidationSummary runat="server" ID="vs1" ValidationGroup="g1" ShowSummary="False" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ValidationGroup="g1"
                                SetFocusOnError="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" ValidationGroup="g1"
                                SetFocusOnError="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <asp:GridView runat="server" ID="gvLabReport" CssClass="table table-striped" AutoGenerateColumns="False" GridLines="None">
                    <Columns>
                        <asp:BoundField HeaderText="Date" DataField="LabDate" />
                        <asp:BoundField HeaderText="VehicleID" DataField="VehicleCode" />
                        <asp:BoundField HeaderText="Vehicle No." DataField="VehicleNumber" />
                        <asp:BoundField HeaderText="Route" DataField="RouteNo" />
                        <asp:BoundField HeaderText="Product Name" DataField="ProductName" />
                        <asp:BoundField HeaderText="OT" DataField="OT" />
                        <asp:BoundField HeaderText="Temp" DataField="Temp" />
                        <asp:BoundField HeaderText="Fat" DataField="Fat" />
                        <asp:BoundField HeaderText="SNF" DataField="SNF" />
                        <asp:BoundField HeaderText="Acidity" DataField="Acidity" />
                        <asp:BoundField HeaderText="COB" DataField="COB" />
                        <asp:BoundField HeaderText="Alcohol No" DataField="AlcoholNo" />
                        <asp:BoundField HeaderText="Neutralizer" DataField="Neutralizer" />
                        <asp:BoundField HeaderText="Urea" DataField="Urea" />
                        <asp:BoundField HeaderText="Salt" DataField="Salt" />
                        <asp:BoundField HeaderText="Startch" DataField="Startch" />
                        <asp:BoundField HeaderText="FPD" DataField="FPD" />
                        <asp:BoundField HeaderText="Status" DataField="Status" />
                        <asp:BoundField HeaderText="User" DataField="Name" />
                    </Columns>
                </asp:GridView>
                <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvLabReport.ClientID%> tbody tr');
        });
        $('#datetimepicker1 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto"
        });
        $('#datetimepicker2 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto"
        });
        $('#datetimepicker3 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto"
        });
    </script>
</asp:Content>

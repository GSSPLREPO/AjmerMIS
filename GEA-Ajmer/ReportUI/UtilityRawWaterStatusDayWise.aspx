<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="UtilityRawWaterStatusDayWise.aspx.cs" Inherits="GEA_Ajmer.ReportUI.UtilityRawWaterStatusDayWise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Utility Raw Water Status Day Wise</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Utility Raw Water Status Day Wise
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="imgbtnPDF" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgbtnExcel" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgbtnWord" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>
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
                            From Time :
                        </div>
                        <div class="col-md-3">
                            To Date :
                        </div>
                        <div class="col-md-3">
                            To Time :
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
                        <div class="col-md-3">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtFromTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="From Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker2'>
                                <asp:TextBox ID="txtToDate" CssClass="form-control" Placeholder="To Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtToTime" ClientIDMode="Static" CssClass="form-control timepicker1" Placeholder="To Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 10px; padding-bottom: 15px;">
                    <div class="col-md-12">
                        <div class="col-md-8">
                        </div>
                        <div class="col-md-4">
                            <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-primary pull-right" ValidationGroup="g1" OnClick="btnGo_OnClick" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter From Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter To Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row" style="overflow: scroll;">
                    <asp:GridView runat="server" ID="gvReport2" CssClass="table table-hover table-striped" ShowHeader="false"
                        AutoGenerateColumns="true" GridLines="Both" HeaderStyle-Wrap="false" OnRowCreated="gvReport2_RowCreated">
                        <RowStyle HorizontalAlign="Center" />
                        <%--<asp:GridView ID="gvReport2" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" GridLines="Both" HeaderStyle-Wrap="false">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table cellspacing="1" rules="all" border="1">
                                    <tr style="border: inset">
                                        <th rowspan="3" colspan="1" style="width: 80px; text-align: center;">Date
                                        </th>
                                        <th rowspan="3" colspan="1" style="width: 80px; text-align: center;">Time
                                        </th>
                                        <th rowspan="1" colspan="4" style="width: 100px; text-align: center;">Process Section
                                        </th>
                                        <th rowspan="1" colspan="4" style="width: 380px; text-align: center;">Packing Section
                                        </th>
                                        <th rowspan="1" colspan="4" style="width: 80px; text-align: center;">CURD Section
                                        </th>
                                    </tr>

                                    <tr style="border: inset">
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">PRESSURE
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Flow 
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">SUPPLY TEMP.
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">RETURN TEMP.
                                        </th>

                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">PRESSURE
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Flow 
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">SUPPLY TEMP.
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">RETURN TEMP.
                                        </th>


                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">PRESSURE
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Flow 
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">SUPPLY TEMP.
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">RETURN TEMP.
                                        </th>
                                       
                                    </tr>

                                    <tr style="border: inset">
                                         <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Bar
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">m3
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Deg C
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Deg C
                                        </th>

                                         <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Bar
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">m3
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Deg C
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Deg C
                                        </th>

                                         <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Bar
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">m3
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Deg C
                                        </th>
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Deg C
                                        </th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="text-align: center;">
                                        <%# Eval("Date") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Time") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Proc_Pressure") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Proc_Flow") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Proc_SupplyTemp") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Proc_ReturnTemp") %>
                                    </td>

                                    <td style="text-align: center;">
                                        <%# Eval("Pack_Pressure") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Pack_Flow") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Pack_SupplyTemp") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Pack_ReturnTemp") %>
                                    </td>

                                    <%-- <td style="text-align: center;">
                                        <%# Eval("CIP_Pressure") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("CIP_Flow") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("CIP_SupplyTemp") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("CIP_ReturnTemp") %>
                                    </td>

                                     <td style="text-align: center;">
                                        <%# Eval("Curd_Pressure") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Curd_Flow") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Curd_SupplyTemp") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Curd_ReturnTemp") %>
                                    </td>

                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>

                        </asp:TemplateField>
                    </Columns>--%>
                    </asp:GridView>
                </div>
                <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
            autoclose: true,
            orientation: "top auto"
        });
        //Timepicker
        $(".timepicker").timepicker({
            showInputs: false,
            use24hours: true,
            format: 'HH:mm',
            showMeridian: false,
            showSeconds: true,
            minuteStep: 1,
            secondStep: 10
        });
        $(".timepicker1").timepicker({
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

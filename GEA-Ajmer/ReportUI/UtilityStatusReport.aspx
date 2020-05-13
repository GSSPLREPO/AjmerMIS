<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UtilityStatusReport.aspx.cs" MasterPageFile="../Masters/MainMaster.Master" Inherits="GEA_Ajmer.ReportUI.UtilityStatusReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Utility Status </li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Utility Status
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>
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
            <%--    <asp:GridView ID="gvReport2" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" GridLines="Both" HeaderStyle-Wrap="false">--%>
                   <asp:GridView runat="server" ID="gvReport2" CssClass="table table-hover table-striped" ShowHeader="false"
                        AutoGenerateColumns="true" GridLines="Both" HeaderStyle-Wrap="false" OnRowCreated="gvReport2_RowCreated">
                        <RowStyle HorizontalAlign="Center" />
                     <%--<Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table cellspacing="1" rules="all" border="1">
                                    <tr style="border: inset">
                                        <th rowspan="3" colspan="1" style="width: 80px; text-align: center;">Date
                                        </th>
                                        <th rowspan="3" colspan="1" style="width: 80px; text-align: center;">Time
                                        </th>
                                        <th rowspan="2" colspan="1" style="width: 100px; text-align: center;">Soft
                                        </th>
                                        <th rowspan="1" colspan="4" style="width: 380px; text-align: center;">CHILLED WATER
                                        </th>
                                        <th rowspan="2" colspan="1" style="width: 80px; text-align: center;">LP Steam
                                        </th>
                                        <th rowspan="2" colspan="1" style="width: 80px; text-align: center;">Air
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
                                       
                                    </tr>

                                    <tr style="border: inset">
                                         <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Bar
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
                                        <th rowspan="1" colspan="1" style="width: 42px; text-align: center;">Bar
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
                                        <%# Eval("Soft_Water_Pressure") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("CH_Water_Pressure") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("CH_Water_Flow") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("CH_Sup_Temp") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("CH_Ret_Temp") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("LP_Steam_Pressure") %>
                                    </td>
                                    <td style="text-align: center;">
                                        <%# Eval("Air_Pressure") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>

                        </asp:TemplateField>
                    </Columns>--%>
                </asp:GridView>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="MassBalanceReport.aspx.cs" Inherits="GEA_Ajmer.ReportUI.MassBalanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Mass Balance Report</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Mass Balance Report
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
<%--                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="imgbtnDoc_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            From Date :
                        </div>
                        <%-- <div class="col-md-3">
                            From Time :
                        </div>--%>
                        <div class="col-md-3">
                            To Date :
                        </div>
                        <div class="col-md-3">
                            Report :
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker1'>
                                <asp:TextBox ID="txtFromDate" CssClass="form-control" Placeholder="From Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <%--<div class="col-md-3">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtFromTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="From Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker2'>
                                <asp:TextBox ID="txtToDate" CssClass="form-control" Placeholder="To Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlReport" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Daily" Value="1" />
                                <asp:ListItem Text="monthly" Value="2" />
                            </asp:DropDownList>

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
                    <asp:GridView runat="server" ID="gvMassBalanceReport" CssClass="table table-hover table-striped"
                        ShowHeader="false" OnRowCreated="gvMassBalanceReport_RowCreated"
                        GridLines="Both" HeaderStyle-Wrap="false">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <%--  <asp:TemplateField>
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
                                        </tr>

                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>

                                </asp:TemplateField>--%>
                        </Columns>
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

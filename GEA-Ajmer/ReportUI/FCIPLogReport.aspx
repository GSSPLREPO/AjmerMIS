<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="FCIPLogReport.aspx.cs"
     Inherits="GEA_Ajmer.ReportUI.FCIPLogReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">FCIP Log</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Fermented CIP Log
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="imgbtnDoc_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>
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
                                <asp:TextBox ID="txtFromDate" CssClass="form-control" Placeholder="From Date" runat="server"></asp:TextBox>
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
                    <asp:GridView runat="server" ID="gvFCIPLogReport" CssClass="table table-hover table-striped" ShowHeader="false"
                        AutoGenerateColumns="true" GridLines="Both" HeaderStyle-Wrap="false" OnRowCreated="gvFCIPLogReport_RowCreated">
                        <RowStyle HorizontalAlign="Center" />
                        <%--<Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table cellspacing="0" rules="all" border="1">
                                        <tr>
                                            <th rowspan="2" colspan="1" style="width: 80px; text-align: center;">Date
                                            </th>
                                            <th rowspan="2" colspan="1" style="width: 150px; text-align: center;">Time
                                            </th>
                                            <th rowspan="2" colspan="1" style="width: 150px; text-align: center;">Line No
                                            </th>
                                            <th rowspan="2" colspan="1" style="width: 150px; text-align: center;">Route No
                                            </th>
                                            <th rowspan="2" colspan="1" style="width: 150px; text-align: center;">Receipe
                                            </th>
                                            <th rowspan="2" colspan="1" style="width: 150px; text-align: center;">Flow Sp
                                            </th>
                                            <th rowspan="1" colspan="5" style="width: 150px; text-align: center;">LYE RINSE
                                            </th>
                                            <th rowspan="1" colspan="5" style="width: 150px; text-align: center;">ACID RINSE
                                            </th>
                                            <th rowspan="1" colspan="5" style="width: 150px; text-align: center;">INTERMEDIATE RINSE
                                            </th>
                                            <th rowspan="1" colspan="5" style="width: 150px; text-align: center;">FINAL RINSE
                                            </th>
                                            <th rowspan="1" colspan="3" style="width: 150px; text-align: center;">STERILIZATION
                                            </th>
                                            <th rowspan="2" colspan="1" style="width: 150px; text-align: center;">SANITIZATION
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Status
                                            </th>
                                        </tr>
                                        <tr>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Step Time
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Temp SP
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Return Temp
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">LYE SP
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Return Cond.
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Step Time
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Temp SP
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Return Temp
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">LYE SP
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Return Cond.
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Step Time
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Temp SP
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Return Temp
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">LYE SP
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Return Cond.
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Step Time
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Temp SP
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Return Temp
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Step Time
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Return Cond.
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Step Time
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Temp SP
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Return Avg. Temp
                                            </th>
                                            <th rowspan="1" colspan="1" style="width: 150px; text-align: center;">Return Cond.
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
                                            <%# Eval("LineNo") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("RouteNo") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("Receipe") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("FlowSP") %>
                                        </td>

                                        <td style="text-align: center;">
                                            <%# Eval("LYEStepTime") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("LYETempSP") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("LYEReturnTemp") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("LYESP") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("LYEReturnCond") %>
                                        </td>

                                        <td style="text-align: center;">
                                            <%# Eval("ACIDStepTime") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("ACIDTempSP") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("ACIDReturnTemp") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("ACIDSP") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("ACIDReturnCond") %>
                                        </td>

                                        <td style="text-align: center;">
                                            <%# Eval("INTERMEDIATEStepTime") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("INTERMEDIATETempSP") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("INTERMEDIATEReturnTemp") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("INTERMEDIATESP") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("INTERMEDIATEReturnCond") %>
                                        </td>

                                        <td style="text-align: center;">
                                            <%# Eval("FINALStepTime") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("FINALTempSP") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("FINALReturnTemp") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("FINALSP") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("FINALReturnCond") %>
                                        </td>

                                        <td style="text-align: center;">
                                            <%# Eval("STERILIZATIONStepTime") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("STERILIZATIONTempSP") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("STERILIZATIONReturnCond") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("SANITIZATIONStepTime") %>
                                        </td>
                                        <td style="text-align: center;">
                                            <%# Eval("Status") %>
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

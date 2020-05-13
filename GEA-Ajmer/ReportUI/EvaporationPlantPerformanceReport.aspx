<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="EvaporationPlantPerformanceReport.aspx.cs" Inherits="GEA_Ajmer.ReportUI.EvaporationPlantPerformanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/canvasjs.min.js" rel="stylesheet" />
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active"><i class="fa fa-file"></i>Evaporation Plant Breakdown (B/D) Report</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        <label id="lblHeader" runat="server" visible="false"></label>
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="imgPdfButton" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgExcelButton" runat="server" CssClass="btn btn-success quick-btn" OnClick="imgExcelButton_Click"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
<%--                        <asp:LinkButton ID="imgWordButton" runat="server" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
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
                            <asp:Button runat="server" ID="btnGo" Text="Go" OnClick="btnGo_Click" CssClass="btn btn-primary pull-right" ValidationGroup="g1" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter From Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter To Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row" style="overflow: scroll;">
                    <asp:GridView runat="server" ID="gvPlantPerformance" CssClass="table table-hover table-striped" AutoGenerateColumns="false"
                        GridLines="Both" HeaderStyle-Wrap="false">
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Date/Month" HeaderText="Date" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Date/Year" HeaderText="Month/Year" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Shift" HeaderText="Shift" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="OperationHours" HeaderText="Operation Hrs." ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="CIPHours" HeaderText="CIP hrs." ItemStyle-Wrap="false" />
                            <asp:TemplateField HeaderText="B/D Hrs.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBreakdownHours" runat="server" placeholder="Breakdown Hours" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Idle Hrs.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIdleHours" class="timepicker" runat="server" placeholder="Idle Hours" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TotalHours" HeaderText="Total Hrs" ItemStyle-Wrap="false" />
                             <asp:BoundField DataField="PercentageEnggBD" HeaderText="% Engg B/D" ItemStyle-Wrap="false" />
                            <asp:TemplateField HeaderText="Remarks of Breakdown">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemarks" runat="server" placeholder="Remarks of Breakdown" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="User" HeaderText="User" ItemStyle-Wrap="false" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>
        </div>
        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" />
    </div>

 <%--   <div id="chartContainer"  style="position: relative;"></div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        var date = new Date();
        var end = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        $('#datetimepicker1 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto",
            endDate: end
        });
        $('#datetimepicker2 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
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
        var trace1 = {
            x: [1, 2, 3, 4],
            y: [10, 15, 13, 17],
            mode: 'markers'
        };

        var trace2 = {
            x: [2, 3, 4, 5],
            y: [16, 5, 11, 9],
            mode: 'lines'
        };

        var trace3 = {
            x: [1, 2, 3, 4],
            y: [12, 9, 15, 12],
            mode: 'lines+markers'
        };

        var data = [trace1, trace2, trace3];

        var layout = {
            title: 'Line and Scatter Plot'
        };

        Plotly.newPlot('chartContainer', data, layout);
        $('datetimepicker1').datepicker('setDate', today);
        $('datetimepicker2').datepicker('setDate', today);
    </script>
    <script type="text/javascript">

</script>
</asp:Content>

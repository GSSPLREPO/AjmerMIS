<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="GEA_Ajmer.WebUI.Test1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JS/highcharts.js"></script>
    <script src="../JS/exporting.js"></script>
    <script src="../JS/export-data.js"></script>
    <script src="../JS/rephael-min.js"></script>
    <script src="../JS/jquery-1.9.1.js"></script>
    <script src="../JS/jquery-ui.js"></script>
    <script src="../JS/morris.js"></script>
    <script src="../JS/Alljs.js"></script>
    <script src="../JS/canvasjs.min.js"></script>
    <script src="../JS/jquery.canvasjs.min.js"></script>
    <script src="../JS/rephael-min.js"></script>
    <script src="../JS/jquery-1.9.1.js"></script>
    <script src="../JS/jquery-ui.js"></script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Temperature & Flow Diversion Trend</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Temperature & Flow Diversion Trend
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <%--   <asp:LinkButton ID="imgPDFButton" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgExcelButton" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgWordButton" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
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
                        <div class="col-md-2">
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
                        <div class="col-md-2">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtToTime" ClientIDMode="Static" CssClass="form-control timepicker1" Placeholder="To Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-primary pull-right" ValidationGroup="g1" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter From Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter To Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                </div>
                <br />
                <div class="row" style="overflow: scroll;">
                    <div class="col-md-12" style="overflow-y: scroll; overflow-x: scroll">
                        <div id="containerForTempAV" style="min-width: 150px; height: 200px; margin: 0 auto;"></div>
                    </div>
                    <div class="col-md-12" style="overflow-y: scroll; overflow-x: scroll">
                        <div id="containerForTempSP" style="min-width: 150px; height: 200px; margin: 0 auto"></div>
                    </div>
                    <div class="col-md-12" style="overflow-y: scroll; overflow-x: scroll">
                        <div id="containerForValve" style="min-width: 150px; height: 200px; margin: 0 auto"></div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">

        //--Date JS Start from here..
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


    <script type="text/javascript">

        //--Chart JS Start from here..
        $(document).ready(function () {
            $("#<%=btnGo.ClientID%>").click(function () {
                <%--alert(($("#<%=txtFromDate.ClientID%>").val()));
                alert(($("#<%=txtFromTime.ClientID%>").val()));
                alert(($("#<%=txtToDate.ClientID%>").val()));
                alert(($("#<%=txtToTime.ClientID%>").val()));--%>
                Graph();
            });

            function Graph() {
                debugger;
                $.ajax({
                    type: "POST",
                    //contentType: "application/json; charset=utf-8",
                    url: "../WebServices/DashBoard.asmx/MPL1Data",
                    data: { 'Fromdate': ($("#<%=txtFromDate.ClientID%>").val()), 'Fromtime': $("#<%=txtFromTime.ClientID%>").val(), 'Todate': $("#<%=txtToDate.ClientID%>").val(), 'Totime': $("#<%=txtToTime.ClientID%>").val() },
                    success: function (Result) {
                        var seriesPastPV = [];
                        var seriesPastSP = [];

                        var Date = [];
                        var quarterPastPV = [];
                        var quarterPastSP = [];
                        var quarterChillPV = [];
                        var quarterChillSP = [];
                        var quarterHotValveStatus = [];
                        var quarterChillValveStatus = [];
                        //alert('2');
                        var data2 = (Result.d);
                        debugger;
                        for (var i in data2) {
                            Date.push(data2[i].Datetime);
                            quarterPastPV.push((data2[i].Mpl1_Past_PV));
                            quarterPastSP.push((data2[i].Mpl1_Past_SP));
                            quarterChillPV.push(data2[i].Mpl1_Chill_PV);
                            quarterChillSP.push(data2[i].Mpl1_Chill_SP);

                            if (data2[i].Mpl1_Hot_Valve == true) {
                                quarterHotValveStatus.push(10);
                            }
                            else {
                                quarterHotValveStatus.push(-10);
                            }
                            if (data2[i].Mpl1_Cold_Valve == true) {
                                quarterChillValveStatus.push(10);
                            }
                            else {
                                quarterChillValveStatus.push(-10);
                            }

                            //quarterChillValveStatus.push(data2[i].Mpl1_Cold_Valve);
                        }
                        //alert('Date' + Date);
                        //alert('quarterPastPV' + quarterPastPV);
                        //alert('quarterPastSP' + quarterPastSP);

                        //------CHart Code
                        BindChart_PastTemp(Date, quarterPastPV, quarterPastSP);
                        BindChart_ChillTemp(Date, quarterChillPV, quarterChillSP);
                        BindValveStatus(Date, quarterHotValveStatus, quarterChillValveStatus)
                        //----End CHart Code


                    },
                    error: function (xhr, status, error) {
                        //alert(error);
                    }
                });
            }

            // 1.---- BindChart_PastTemp for MPL1
            function BindChart_PastTemp(Date, quarterPastPV, quarterPastSP) {
                //alert('hi');

                var Mpl1PastPV = String(quarterPastPV).split(',').map(function (item) {
                    return parseInt(item, 10);
                });

                var Mpl1PastSP = String(quarterPastSP).split(',').map(function (item) {
                    return parseInt(item, 10);
                });
                //alert(Mpl1PastPV);
                //alert(Mpl1PastSP);
                debugger;
                Highcharts.chart('containerForTempAV', {
                    chart: {
                        type: 'spline'
                    },
                    title: {
                        text: 'MPL-1 Temprature & Flow Diversion Log Trend (For Past-Temp)'
                    },
                    xAxis: {
                        //categories: ['01/01/2018 8:15', '01/01/2018 9:15', '01/01/2018 10:15', '01/01/2018 11:15', '01/01/2018 12:15', '02/01/2018 12:15', '02/01/2018 12:15', '02/01/2018 12:15', '02/01/2018 12:15']
                        categories: Date
                    },
                    credits: {
                        enabled: false
                    },
                    series: [
                        {
                            name: 'PastTemp PV',
                            //data: ['5.1', '3.0', '40.4', '-7', '2.40', '0', '3.50', -4, 4.67]
                            data: Mpl1PastPV
                        },
                        {
                            name: 'PastTemp SP',
                            //data: [2, -2, -30.578, 2, 1, 5, 6, 0, 1]
                            data: Mpl1PastSP
                        },
                    ]
                });
            }
            //----End BindChart_PastTemp for MPL1

            // 2.---- BindChart_ChillTemp for MPL1
            function BindChart_ChillTemp(Date, quarterChillPV, quarterChillSP) {
                // alert('ChillTemp-2');

                var Mpl1ChillPV = String(quarterChillPV).split(',').map(function (item) {
                    return parseInt(item, 10);
                });

                var Mpl1ChillSP = String(quarterChillSP).split(',').map(function (item) {
                    return parseInt(item, 10);
                });

                debugger;
                Highcharts.chart('containerForTempSP', {
                    chart: {
                        type: 'spline'
                    },
                    title: {
                        text: 'MPL-1 Temprature & Flow Diversion Log Trend (For Chill-Temp)'
                    },
                    xAxis: {
                        //categories: ['01/01/2018 8:15', '01/01/2018 9:15', '01/01/2018 10:15', '01/01/2018 11:15', '01/01/2018 12:15', '02/01/2018 12:15', '02/01/2018 12:15', '02/01/2018 12:15', '02/01/2018 12:15']
                        categories: Date
                    },
                    credits: {
                        enabled: false
                    },
                    series: [
                        {
                            name: 'Chill-Temp PV',
                            //data: ['5.1', '3.0', '40.4', '-7', '2.40', '0', '3.50', -4, 4.67]
                            data: Mpl1ChillPV
                        },
                        {
                            name: 'Chill-Temp SP',
                            //data: [2, -2, -30.578, 2, 1, 5, 6, 0, 1]
                            data: Mpl1ChillSP
                        },
                    ],

                });
            }
            //----End BindChart_ChillTemp for MPL1

            //3.---- Bind Chart Valve On-Off Status
            function BindValveStatus(Date, quarterHotValveStatus, quarterChillValveStatus) {
                //alert('h')
                debugger
                alert('1');
                var Mpl1HotStatus = String(quarterHotValveStatus).split(',').map(function (item) {
                    return parseInt(item, 10);
                });

                var Mpl1ChillStatus = String(quarterChillValveStatus).split(',').map(function (item) {
                    return parseInt(item, 10);
                });

                Highcharts.chart('containerForValve', {
                    chart: {
                        type: 'column'
                    },
                    title: {
                        text: 'Hot & Cold Diversion Valve On/Off Status'
                    },
                    xAxis: {
                        //categories: ['Apples', 'Oranges', 'Pears', 'Grapes', 'Bananas']
                        categories: Date
                    },
                    credits: {
                        enabled: true
                    },
                    series: [{
                        name: 'Hot Diversion valve Status',
                        //data: [5, 3, 4, 7, 2]
                        data: Mpl1HotStatus
                    }, {
                        name: 'Cold Diversion Valve Status',
                        // data: [2, -2, -3, 2, 1]
                        data: Mpl1ChillStatus
                    }]
                });
            }
            // End BindChart Valve On-Off Status
        });



    </script>


</asp:Content>

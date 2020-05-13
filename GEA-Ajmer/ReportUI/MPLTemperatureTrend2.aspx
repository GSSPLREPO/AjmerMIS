<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="MPLTemperatureTrend2.aspx.cs" Inherits="GEA_Ajmer.ReportUI.MPLTemperatureTrend2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/highcharts.js"></script>
    <script src="../Scripts/exporting.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var FromDate = '', ToDate = '', FromTime = '', ToTime = '';

            $('#btnSave').click(function (e) {
                FromDate = $('input[id$=txtFromDate]').val();
                ToDate = $('input[id$=txtToDate]').val();
                FromTime = $('input[id$=txtFromTime]').val();
                ToTime = $('input[id$=txtToTime]').val();

                if (FromDate == "" || FromTime == "" || ToDate == "" || ToTime == "") {
                    alert("Select Date Or Time Properly.")
                }
                else {
                    ChartData();
                }
            });

            function ChartData() {
                debugger;
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "../WebServices/DashBoard.asmx/MPL1Data",
                    data: '{strGraph:"Second", Fromdate: "' + FromDate + '", Fromtime: "' + FromTime + '", Todate: "' + ToDate + '", Totime: "' + ToTime + '" }',
                    //data: '{ Fromdate :"' + FromDate + '"}',
                    dataType: "json",
                    success: function (data) {
                        SuccessData(data);
                    },
                    error: function (xhr, status, error) {
                        //alert(error);
                    }
                });
            }

            function SuccessData(response) {


                var seriesPastPV = [];
                var seriesPastSP = [];

                var Date = [];
                var quarterPastPV = [];
                var quarterPastSP = [];
                var quarterChillPV = [];
                var quarterChillSP = [];
                var quarterHotValveStatus = [];
                var quarterChillValveStatus = [];

                var data2 = JSON.parse(response.d);
                //alert(data2);
                //debugger;
                //for (i = 0; i < jsonResponse.Table1.length; i++) {

                //}
                debugger;
                for (var i in data2) {
                    Date.push(data2[i].Datetime);
                    quarterPastPV.push(parseFloat(data2[i].MPL2_Past_TempPV));
                    quarterPastSP.push(parseFloat(data2[i].MPL2_Past_TempSP));
                    quarterChillPV.push(parseFloat(data2[i].MPL2_Chill_TempPV));
                    quarterChillSP.push(parseFloat(data2[i].MPL2_Chill_TempSP));
                    //quarterHotValveStatus.push((data2[i].MPL1_Hot_Valve_Status));
                    //quarterChillValveStatus.push((data2[i].MPL1_Cold_Valve_Status));

                    if (data2[i].MPL2_Hot_Valve_Status == true) {
                        quarterHotValveStatus.push(1);
                    }
                    else {
                        quarterHotValveStatus.push(0);
                    }
                    if (data2[i].MPL2_Cold_Valve_Status == true) {
                        quarterChillValveStatus.push(1);
                    }
                    else {
                        quarterChillValveStatus.push(0);
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


                // 1.---- BindChart_PastTemp for MPL1
                function BindChart_PastTemp(Date, quarterPastPV, quarterPastSP) {
                    //alert('hi');

                    var Mpl1PastPV = String(quarterPastPV).split(',').map(function (item) {
                        return parseFloat(item, 10);
                    });

                    var Mpl1PastSP = String(quarterPastSP).split(',').map(function (item) {
                        return parseFloat(item, 10);
                    });
                    //alert(Mpl1PastPV);
                    //alert(Mpl1PastSP);
                    debugger;
                    Highcharts.chart('containerForTempAV', {
                        chart: {
                            type: 'spline'
                        },
                        title: {
                            text: 'MPL-2 Temprature & Flow Diversion Log Trend (For Past-Temp (Deg C))'
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
                        return parseFloat(item, 10);
                    });

                    var Mpl1ChillSP = String(quarterChillSP).split(',').map(function (item) {
                        return parseFloat(item, 10);
                    });

                    debugger;
                    Highcharts.chart('containerForTempSP', {
                        chart: {
                            type: 'spline'
                        },
                        title: {
                            text: 'MPL-2 Temprature & Flow Diversion Log Trend (For Chill-Temp (Deg C))'
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

                    Highcharts.chart('containerForHot_Valve', {
                        //$('#containerForValve').highcharts('StockChart', {
                        rangeSelector: {
                            selected: 1,
                            allButtonsEnabled: true
                        },
                        title:
                            {
                                text: 'MPL-2 Hot-Diversion Valve Status (On-Off)'
                            },
                        tooltip: {
                            valueDecimals: 0
                        },
                        yAxis: [
                             {
                                 title: {
                                     text: ''
                                 },
                                 gridLineWidth: 0,
                                 gridLineWidth: 0,
                                 gridLineColor: 'transparent',
                                 lineWidth: 2
                             },
                         {
                             title: {
                                 text: ''
                             },
                             gridLineWidth: 0,
                             gridLineColor: 'transparent',
                             lineWidth: 2
                         },
                        ],
                        series: [
                            {
                                name: 'Hot Diversion',
                                lineWidth: 3,
                                type: 'line',
                                data: quarterHotValveStatus,
                                step: 'left',
                                yAxis: 1,
                                color: '#D2691E',

                                lineWidth: 2,
                                tooltip: {
                                    pointFormatter: function () {
                                        var point = this;
                                        return '<span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': <b>' + (point.y > 0 ? 'On' : 'Off') + '</b><br/>';
                                    }
                                }
                            },
                     //{
                     //    name: 'Cold Diversion',
                     //    type: 'line',
                     //    data: quarterChillValveStatus,
                     //    step: 'right',
                     //    yAxis: 1,
                     //    color: '#191970',
                     //    lineWidth: 2,
                     //    tooltip: {
                     //        pointFormatter: function () {
                     //            var point = this;
                     //            return '<span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': <b>' + (point.y > 0 ? '1' : '0') + '</b><br/>';
                     //        }
                     //    }
                     //}
                        ],

                        xAxis: {
                            categories: Date
                        },
                    });

                    Highcharts.chart('containerForCold_Valve', {
                        //$('#containerForValve').highcharts('StockChart', {
                        rangeSelector: {
                            selected: 1,
                            allButtonsEnabled: true
                        },
                        tooltip: {
                            valueDecimals: 0
                        },
                        title:
                            {
                                text: 'MPL2 Cold-Diversion Valve Status (On-Off)'
                            },
                        yAxis: [
                             {
                                 title: {
                                     text: ''
                                 },
                                 gridLineWidth: 0,
                                 gridLineWidth: 0,
                                 gridLineColor: 'transparent',
                                 lineWidth: 2
                             },
                         {
                             title: {
                                 text: ''
                             },
                             gridLineWidth: 0,
                             gridLineColor: 'transparent',
                             lineWidth: 2
                         },
                        ],
                        series: [
                            {
                                name: 'Cold Diversion',
                                lineWidth: 3,
                                type: 'line',
                                data: quarterChillValveStatus,
                                step: 'left',
                                yAxis: 1,
                                color: '#191970',

                                lineWidth: 2,
                                tooltip: {
                                    pointFormatter: function () {
                                        var point = this;
                                        return '<span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': <b>' + (point.y > 0 ? 'On' : 'Off') + '</b><br/>';
                                    }
                                }
                            },

                        ],

                        xAxis: {
                            categories: Date
                        },
                    });
                }
                // End BindChart Valve On-Off Status




            }
        });
    </script>
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
                      MPL2 Temperature & Flow Diversion Trend
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
                            <button type="button" id="btnSave" class="btn btn-primary">Go</button>
                            <%-- <asp:Button runat="server" ID="btnSave" Text="Go" CssClass="btn btn-primary pull-right" ValidationGroup="g1" />--%>
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
                        <div id="containerForHot_Valve" style="min-width: 150px; height: 200px; margin: 0 auto"></div>
                    </div>
                    <div class="col-md-12" style="overflow-y: scroll; overflow-x: scroll">
                        <div id="containerForCold_Valve" style="min-width: 150px; height: 200px; margin: 0 auto"></div>
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
</asp:Content>

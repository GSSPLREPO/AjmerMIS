<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TempChart2.aspx.cs" Inherits="GEA_Ajmer.WebUI.TempChart2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../_JS/ModalPopupWindow.js"></script>
    <script src="../_JS/Alljs.js"></script>
    <script src="../JS/highcharts.js"></script>
    <script src="../JS/exporting.js"></script>
    <script src="../JS/export-data.js"></script>
    <script src="../JS/rephael-min.js"></script>
    <script src="../JS/jquery-1.9.1.js"></script>
    <script src="../JS/jquery-ui.js"></script>
    <script src="../JS/morris.js"></script>
    <script src="../JS/Alljs.js"></script>

    <script src="../JS/highcharts.js"></script>
    <script src="../JS/exporting.js"></script>
    <script src="../JS/canvasjs.min.js"></script>
    <script src="../JS/jquery.canvasjs.min.js"></script>
    <script src="../JS/rephael-min.js"></script>
    <script src="../JS/jquery-1.9.1.js"></script>
    <script src="../JS/jquery-ui.js"></script>
    <script src="../JS/morris.js"></script>
    <script src="../JS/Alljs.js"></script>
    <link href="../css/morris.css" rel="stylesheet" />
    <link href="../css/Allcss.css" rel="stylesheet" />
    <link href="../css/jquery-ui.css" rel="stylesheet" />




    <script type="text/javascript">

        window.onload = function () {

            Graph();
           // BindValveStatus();

            function Graph() {
                debugger;
                jQuery.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "../WebServices/DashBoard.asmx/MPL1Data",
                    data: {},
                    dataType: "json",
                    success: function (Result) {
                        // SuccessData(data);

                        debugger;
                        var seriesPastPV = [];
                        var seriesPastSP = [];

                        var Date = [];
                        var quarterPastPV = [];
                        var quarterPastSP = [];
                        var quarterChillPV = [];
                        var quarterChillSP = [];
                        var quarterHotValveStatus = [];
                        var quarterChillValveStatus = [];

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
                            else
                            {
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
            function BindValveStatus(Date, quarterHotValveStatus, quarterChillValveStatus)
            {
                //alert('h')
                debugger

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
        }

    </script>
</head>
<body>

    <form id="form1" runat="server">
        <div class="col-md-12">
            <div class="col-md-6" style="overflow-y: scroll; overflow-x: scroll">
                <div id="containerForTempAV" style="min-width: 150px; height: 200px; margin: 0 auto;"></div>
            </div>
            <div class="col-md-6" style="overflow-y: scroll; overflow-x: scroll">
                <div id="containerForTempSP" style="min-width: 150px; height: 200px; margin: 0 auto"></div>
            </div>
            <div class="col-md-6" style="overflow-y: scroll; overflow-x: scroll">
                <div id="containerForValve" style="min-width: 150px; height: 200px; margin: 0 auto"></div>
            </div>
        </div>
    </form>

</body>
</html>

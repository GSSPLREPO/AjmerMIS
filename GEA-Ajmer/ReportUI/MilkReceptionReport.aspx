<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="MilkReceptionReport.aspx.cs" Inherits="GEA_Ajmer.ReportUI.MilkReceptionReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Milk Reception Report</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Milk Reception Report
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="imgPDFButton" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgExcelButton" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgWordButton" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>
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
                        <div class="col-md-4 has-error">
                            <div class='input-group date' id='datetimepicker1'>
                                <asp:TextBox ID="txtFromDate" CssClass="form-control" Placeholder="From Date" runat="server" OnTextChanged="txtFromDate_TextChanged" AutoPostBack="true"></asp:TextBox>
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
                        <div class="col-md-4 has-error">
                            <div class='input-group date' id='datetimepicker2'>
                                <asp:TextBox ID="txtToDate" CssClass="form-control" Placeholder="To Date" runat="server" OnTextChanged="txtToDate_TextChanged" AutoPostBack="true"></asp:TextBox>
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

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            Shift No :
                        </div>
                        <div class="col-md-3">
                            Reception Line No :
                        </div>
                        <%-- <div class="col-md-3">
                            TankerID :
                        </div>--%>
                        <div class="col-md-3">
                            SILO No :
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlShiftNo" runat="server" CssClass="form-control input-sm inline-block"></asp:DropDownList>
                        </div>
                         <div class="col-md-3">
                            <asp:DropDownList ID="ddlReceptionLineNo" runat="server" CssClass="form-control input-sm inline-block" AutoPostBack="true"
                                 OnSelectedIndexChanged="ddlReceptionLineNo_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                      <%--  <div class="col-md-3">
                            <asp:DropDownList ID="ddlTankerID" runat="server" CssClass="form-control input-sm inline-block"></asp:DropDownList>
                        </div>--%>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlSILONo" runat="server" CssClass="form-control input-sm inline-block"></asp:DropDownList>
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
                <br />
                <div class="row" style="overflow: scroll;">
                    <asp:GridView runat="server" ID="gvMilkReception" CssClass="table table-hover table-striped"
                        AutoGenerateColumns="False" GridLines="Both" Width="100%" HeaderStyle-Wrap="false">
                        <Columns>
                            <asp:BoundField DataField="ShiftNo" HeaderText="Shift" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="StartTime" HeaderText="Loading Start Time" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="StopTime" HeaderText="Loading Stop Time" ItemStyle-Wrap="false" />
                          <%--  <asp:BoundField DataField="TotalTimeInMilkReception" HeaderText="Total Time" ItemStyle-Wrap="false" />--%>
                            <asp:BoundField DataField="TankerId" HeaderText="Tanker ID" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="TankerNo" HeaderText="Tanker No." ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Reception Line No" HeaderText="Reception Line No" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Silo No" HeaderText="SILO No" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Chilled temp (SP)" HeaderText="Chilled temp" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Qty Received" HeaderText="Qty Received (kg)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Weighbridge Qty" HeaderText="Weighbridge Qty (kg)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Difference Between Wb Qty & FT" HeaderText="Difference Between WB Qty & FT (kg)" ItemStyle-Wrap="true" />

                        </Columns>

                    </asp:GridView>
                </div>

<%--                <div class="row" style="overflow: scroll; padding-left: 60%">
                    <asp:GridView runat="server" ID="gvTotalQty" CssClass="table table-hover table-striped"
                        AutoGenerateColumns="False" GridLines="Both" Width="50%" HeaderStyle-Wrap="false">
                        <Columns>
                            <asp:BoundField DataField="TotalReceivedQty" HeaderText="Total Received Quantity" ItemStyle-Wrap="true" />
                            <asp:BoundField DataField="TotalWeighBridgeQty" HeaderText="Total WeighBridge Quantity" ItemStyle-Wrap="true" />
                            <asp:BoundField DataField="DifferenceQty" HeaderText="Total Differnece Quantity" ItemStyle-Wrap="true" />

                        </Columns>

                    </asp:GridView>
                </div>--%>

                <div class="center" id="divId" runat="server">No records found.</div>
                <%-- <div class="col-md-12 center" id="divNo" runat="server">
                    No records found.
                </div>--%>
                <%-- <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnSave_OnClick" />--%>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">

   <%--     $('[id$=chkHeader]').click(function () {
            if ($(this).is(":checked")) {
                $('[id*=chkChild]').prop("checked", true);
                $(document.getElementById('<%= btnSave.ClientID %>')).prop("disabled", false);
                $(document.getElementById('<%= btnSave.ClientID %>')).css("background-color", "#3b5998");
            } else {
                $('[id*=chkChild]').prop("checked", false);
                $(document.getElementById('<%= btnSave.ClientID %>')).prop("disabled", true);
                $(document.getElementById('<%= btnSave.ClientID %>')).css("background-color", "#848484");
            }
        });
         
        $("[id*=chkChild]").click(function () {
            if ($(this).is(":checked")) {
                $(document.getElementById('<%= btnSave.ClientID %>')).prop("disabled", false);
                $(document.getElementById('<%= btnSave.ClientID %>')).css("background-color", "#3b5998");
            }
            if ($('[id*=chkChild]').length == $('[id*=chkChild]:checked').length) {
                $('[id*=chkHeader]').prop("checked", true);
                $(document.getElementById('<%= btnSave.ClientID %>')).prop("disabled", false);
                $(document.getElementById('<%= btnSave.ClientID %>')).css("background-color", "#3b5998");
            }
            else {
                $('[id*=chkHeader]').removeAttr("checked");
            }
            if ($('[id*=chkChild]').length == $('[id*=chkChild]:not(:checked)').length) {
                $(document.getElementById('<%= btnSave.ClientID %>')).prop("disabled", true);
                $(document.getElementById('<%= btnSave.ClientID %>')).css("background-color", "#848484");
            }
        });--%>
        //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(jqry);

        $("[id*=chkHeader]").bind("click", function () {
            var chkHeader = $(this);

            //Find and reference the GridView.
            var grid = $(this).closest("table");

            //Loop through the CheckBoxes in each Row.
            $("td", grid).find("input[type=checkbox]").each(function () {

                //If Header CheckBox is checked.
                //Then check all CheckBoxes and enable the TextBoxes.
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#D8EBF2" });
                    //  $("input[type=text]", td).removeAttr("disabled");
                } else {
                    $(this).removeAttr("checked");
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#FFF" });
                    //  $("input[type=text]", td).attr("disabled", "disabled");
                }
            });
        });

        //$("[id*=chkChild]").bind("click", function () {

        //    //Find and reference the GridView.
        //    var grid = $(this).closest("table");

        //    //Find and reference the Header CheckBox.
        //    var chkHeader = $("[id*=chkHeader]", grid);

        //    //If the CheckBox is Checked then enable the TextBoxes in thr Row.
        //    if (!$(this).is(":checked")) {
        //        var td = $("td", $(this).closest("tr"));
        //        td.css({ "background-color": "#FFF" });
        //        $("input[type=text]", td).attr("disabled", "disabled");
        //    } else {
        //        var td = $("td", $(this).closest("tr"));
        //        td.css({ "background-color": "#D8EBF2" });
        //        $("input[type=text]", td).removeAttr("disabled");
        //    }

        //    //Enable Header Row CheckBox if all the Row CheckBoxes are checked and vice versa.
        //    if ($("[id*=chkChild]", grid).length == $("[id*=chkChild]:checked", grid).length) {
        //        chkHeader.attr("checked", "checked");
        //    } else {
        //        chkHeader.removeAttr("checked");
        //    }
        //});

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

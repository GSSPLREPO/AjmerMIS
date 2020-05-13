<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMaster.Master" AutoEventWireup="true" CodeBehind="Refrigerator_ChillerWater.aspx.cs" Inherits="GEA_Ajmer.ReportUI.Refrigerator_ChillerWater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Refrigerator Chiller Water Report </li>
        </ul>
    </div>


    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Refrigerator Chiller Water Report
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="imgbtnPDF" runat="server" OnClick="imgbtnPDF_Click" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgbtnExcel" runat="server" OnClick="imgbtnExcel_Click" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <%--<asp:LinkButton ID="imgbtnWord" runat="server" OnClick="imgbtnWord_Click" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
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
                        <%--<div class="col-md-3">
                            To Time :
                        </div>--%>
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
                                <asp:TextBox ID="txtToDate" CssClass="form-control" Placeholder="To Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 10px; padding-bottom: 15px;">
                    <div class="col-md-12">
                        <div class="col-md-8">
                        </div>
                        <div class="col-md-4">
                            <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-primary pull-right" ValidationGroup="g1" OnClick="btnGo_Click" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter From Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter To Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row col-md-12" id="GridView" runat="server" style="overflow: scroll;">
                    <asp:GridView runat="server" ID="gvRefChilledWater"  CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="Both" >
                        <Columns>
                             <asp:BoundField DataField="DateTime" HeaderText="DateTime" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="CHW_HeaderPressure_1" HeaderText="CHW PUMP HEADER PRESSURE-1 (Bar)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="CHW_HeaderPressure_2" HeaderText="CHW PUMP HEADER PRESSURE-2 (Bar)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="CHW_HeaderPressure_3" HeaderText="CHW PUMP HEADER PRESSURE-3 (Bar)" ItemStyle-Wrap="false" />
                            <%--<asp:BoundField DataField="CHW_HeaderPressure_4" HeaderText="CHW PUMP HEADER PRESSURE-4" ItemStyle-Wrap="false" />--%>
                            <asp:BoundField DataField="LP_RCV_Level" HeaderText="LP RCV LEVEL" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="PHE_Cond_Inlet_Temp" HeaderText="PHE COND INLET TEMP (Deg C)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="PHE_Cond_Outlet_Temp" HeaderText="PHE COND OUTLET TEMP (Deg C)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="CHW_PHE_Cond_Inlet_Temp" HeaderText="CHW PHE COND INLET TEMP (Deg C)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="CHW_PHE_Cond_Outlet_Temp" HeaderText="CHW PHE COND OUTLET TEMP (Deg C)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="IBT_Bank_Temp" HeaderText="IBT BANK TEMP (Deg C)" ItemStyle-Wrap="false" />
                           <%--  <asp:BoundField DataField="EnergyMeterPhaseCurrent_R" HeaderText="Energy Meter Phase Current R" ItemStyle-Wrap="false" />
                             <asp:BoundField DataField="EnergyMeterPhaseCurrent_Y" HeaderText="Energy Meter Phase Current Y" ItemStyle-Wrap="false" />
                             <asp:BoundField DataField="EnergyMeterPhaseCurrent_B" HeaderText="Energy Meter Phase Current B" ItemStyle-Wrap="false" />--%>
                             <asp:BoundField DataField="EnergyMeterTotalPower" HeaderText="Energy Meter Total Power (kWh)" ItemStyle-Wrap="false" />

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
